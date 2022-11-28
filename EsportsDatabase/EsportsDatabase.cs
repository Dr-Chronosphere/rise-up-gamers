using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static EsportsDatabase.EsportsDatabase;
using System.Xml.Schema;
using System.Reflection;

namespace EsportsDatabase
{
    public partial class EsportsDatabase : Form
    {
        public EsportsDatabase()
        {
            // Much easier constructor-based database initialization.
            // Consider making database constructor alter/add to existing database object.
            database = new Database("Esports.db",
                @"CREATE TABLE Teams(
                    TeamID INTEGER PRIMARY KEY NOT NULL,
                    Name TEXT, 
                    GameID INTEGER,
                    Location TEXT,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID)
                );",
                @"CREATE TABLE Games(
                    GameID INTEGER PRIMARY KEY NOT NULL,
                    Name TEXT,
                    Device TEXT,
                    Type TEXT,
                    NumberOfPlayers INTEGER
                );",
                @"CREATE TABLE Players(
                    PlayerID INTEGER PRIMARY KEY NOT NULL,
                    GamerTag TEXT,
                    FirstName TEXT
                    LastName TEXT,
                    GameID INTEGER,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID)
                );",
                @"CREATE TABLE Rosters
                    RosterID INTEGER PRIMARY KEY NOT NULL,
                    TeamID TEXT,
                    GameID INTEGER,
                    ListOfPlayerIDs TEXT,
                    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID),
                    FOREIGN KEY (GameID) REFERENCES Games(GameID),
                );",
                @"CREATE TABLE Events(
                    EventID INTEGER PRIMARY KEY NOT NULL,
                    Name TEXT,
                    Date TEXT,
                    GameID INTEGER,
                    Location TEXT,
                    PrizeMoney INTEGER,
                    Format TEXT,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID)
                );"
            );
            database.InitializeTables();
            // WinForms Designer Generator
            InitializeComponent();

            // Put our modifications here:
            InitializeTabs();
            ShowData(SelectTable.SelectedTab.Text);
        }

        // Bootstraps the creation of tabs after the creation of tables.
        public void InitializeTabs()
        {
            foreach (KeyValuePair<string, Table> table in database.Tables)
            {
                TabPage tabpage = table.Value.LinkedTab.Generate();
                this.SelectTable.TabPages.Add(tabpage);
            }
            this.SelectTable.SelectedIndex = 0;
        }

        // A wrapper class for Database CRUD functionality
        // TODO: look into making a factory class
        public class Database
        {
            public Database(string filename, params string[] creationSQL)
            {
                _filename = filename;
                _path = "URI=file:" + Application.StartupPath + "\\" + _filename;
                _creationSQL = creationSQL;
                Connection = new SQLiteConnection(_path);
                Connection.Open();
                Create();
            }

            public bool Create()
            {
                if (!System.IO.File.Exists(_filename))
                {
                    SQLiteConnection.CreateFile(_filename);
                    foreach (string sql in _creationSQL)
                    {
                        Command = new SQLiteCommand(sql, Connection);
                        Command.ExecuteNonQuery();
                    }
                    return true;
                }
                Console.WriteLine("Database already created.");
                return false;
            }

            public void InitializeTables()
            {
                Tables = new Dictionary<string, Table>();
                Query("SELECT name FROM sqlite_schema WHERE type = 'table';");
                foreach(string tableName in lastQueryResults)
                {
                    Tables[tableName] = new Table(tableName);
                }
            }

            public List<string> Query(string sql)
            {
                lastQueryResults = new List<string>();
                Command = new SQLiteCommand(sql, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        lastQueryResults.Add(Reader.GetValue(i).ToString());
                    }
                }
                Reader.Close();
                return lastQueryResults;
            }

            public SQLiteConnection Connection
            { get; private set; }

            public SQLiteCommand Command
            { get; set; }

            public SQLiteDataReader Reader
            { get; set; }

            public List<string> lastQueryResults;

            public string ActiveTable
            { get; set; }

            public Dictionary<string, Table> Tables;

            private static string[] _creationSQL;
            private static string _filename;
            private static string _path;
        }

        // Potentially make the Database class have a list of Table objects,
        // where each Table is initialized by the Database constructor
        public class Table
        {
            public Table(string name)
            {
                this.Name = name;
                Fields = database.Query($"SELECT name FROM pragma_table_info('{name}')");
                LinkedTab = new Tab(name);
            }

            public void Insert()
            {

                string id = this.Fields[0];
                this.Fields.RemoveAt(0);

                database.Command.CommandText = $"INSERT INTO {Name}({string.Join(",", Fields)}) VALUES(@{string.Join(",@", Fields)})";
                foreach (KeyValuePair<string, TextBox> input in LinkedTab.Inputs)
                {
                    database.Command.Parameters.AddWithValue($"@{input.Key}", input.Value.Text);
                }
                database.Command.ExecuteNonQuery();
                this.Fields.Insert(0, id);
            }

            public string Name { get; set; }
            public List<string> Fields { get; set; }
            public Tab LinkedTab { get; set; }
        }

        public class Tab
        {
            public Tab(string table)
            {
                this.LinkedTable = table;
                Inputs = new Dictionary<string, TextBox>();
            }

            public TabPage Generate()
            {
                FlowLayoutPanel flow = new FlowLayoutPanel();
                flow.AutoScroll = true;
                flow.Dock = DockStyle.Fill;

                foreach (string field in database.Tables[LinkedTable].Fields)
                {
                    Label label = new Label();
                    label.Text = field;
                    flow.Controls.Add(label);
                    
                    TextBox textbox = new TextBox();
                    textbox.Name = LinkedTable + field + "Input";
                    flow.Controls.Add(textbox);
                    Inputs[field] = textbox;
                }

                TabPage tab = new TabPage();
                tab.Text = LinkedTable;
                tab.Controls.Add(flow);

                return tab;
            }

            public string LinkedTable;
            public Dictionary<string, TextBox> Inputs
            { get; set; }
        }

        // Rewritten with query function and Table Object
        private void ShowData(string table)
        {
            displayTable.Rows.Clear();

            var columnHeaders = database.Tables[table].Fields;
            displayTable.ColumnCount = columnHeaders.Count;
            for (int i = 0; i < columnHeaders.Count; i++)
            {
                displayTable.Columns[i].Name = columnHeaders[i];
            }

            var data = database.Query($"SELECT * FROM {table}");
            for (int i = 0; i < data.Count - 1; i += (columnHeaders.Count))
            {
                displayTable.Rows.Add(data.GetRange(i, columnHeaders.Count).ToArray());
            }
        }

        // All the following buttons will be greatly condensed by a generalized function call.
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            // TODO: These will not be if statements, but a function call to a generalized insert function
                /*if(database.ActiveTable == "Teams")
                {

                }
                else if(database.ActiveTable == "Games")
                {
                    database.Command.CommandText = "INSERT INTO Games(Name, Device, Type, NumberOfPlayers) VALUES(@name, @device, @type, @numPlayers)";
                    database.Command.Parameters.AddWithValue("@name", GamesNameInput.Text);
                    database.Command.Parameters.AddWithValue("@device", GamesDeviceInput.Text);
                    database.Command.Parameters.AddWithValue("@type", GamesNameInput.Text);
                    database.Command.Parameters.AddWithValue("@numPlayers", Int32.Parse(GamesNumberOfPlayersInput.Text));
                }
                else if (database.ActiveTable == "Players")
                {

                }
                else if (database.ActiveTable == "Rosters")
                {

                }
                else if (database.ActiveTable == "Events")
                {

                }
                oy67
                database.Command.ExecuteNonQuery();*/
                database.Tables[SelectTable.SelectedTab.Text].Insert();

            ShowData(SelectTable.SelectedTab.Text);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (database.ActiveTable == "Teams")
                {

                }
                else if (database.ActiveTable == "Games")
                {
                    database.Command.CommandText = "UPDATE Games SET Name = @name, Device = @device, Type = @type, NumberOfPlayers = @numPlayers WHERE GameID = @gameID";
                    /*database.Command.Parameters.AddWithValue("@gameID", gameIDInput.Text);
                    database.Command.Parameters.AddWithValue("@name", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@device", gameDeviceInput.Text);
                    database.Command.Parameters.AddWithValue("@type", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@numPlayers", Int32.Parse(gameNumberOfPlayersPerTeamInput.Text));*/
                }
                else if (database.ActiveTable == "Players")
                {

                }
                else if (database.ActiveTable == "Rosters")
                {

                }
                else if (database.ActiveTable == "Events")
                {

                }

                database.Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Data update failed");
            }

            ShowData(database.ActiveTable);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (database.ActiveTable == "Teams")
                {

                }
                else if (database.ActiveTable == "Games")
                {
                    database.Command.CommandText = "DELETE FROM Games WHERE GameID = @gameID";

                    /*database.Command.Parameters.AddWithValue("@gameID", gameIDInput.Text);*/
                }
                else if (database.ActiveTable == "Players")
                {

                }
                else if (database.ActiveTable == "Rosters")
                {

                }
                else if (database.ActiveTable == "Events")
                {

                }

                database.Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Data update failed");
            }

            ShowData(database.ActiveTable);
        }

        private void SelectTable_Selected(object sender, EventArgs e)
        {
            database.ActiveTable = this.SelectTable.SelectedTab.Text;
            ShowData(database.ActiveTable);
        }

        public static Database database;

    }
}
