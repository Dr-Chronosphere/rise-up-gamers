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
            // WinForms Designer Generator
            InitializeComponent();

            // Put our modifications here:
            InitializeTabs();
            ShowData(SelectTable.SelectedTab.Text);
        }

        // A testing function for programmatically generating the tab headers and content.
        // TODO: expand FlowLayoutPanel so it doesn't cut off input fields
        public void InitializeTabs()
        {
            foreach (Table Table in database.Tables)
            {
                // TODO: make Table class store their attributes for easy manipulation
                
                FlowLayoutPanel flow = new FlowLayoutPanel();
                string sql = "SELECT * FROM " + Table.Name;
                database.Command = new SQLiteCommand(sql, database.Connection);
                database.Reader = database.Command.ExecuteReader();
                int numFields = database.Reader.FieldCount;
                for (int i = 0; i < numFields; i++)
                {
                    Label label = new Label();
                    label.Text = database.Reader.GetName(i);
                    flow.Controls.Add(label);
                    TextBox textbox = new TextBox();
                    textbox.Name = Table.Name + database.Reader.GetName(i) + "Input";
                    flow.Controls.Add(textbox);
                }
                
                TabPage tab = new TabPage();
                tab.Text = Table.Name;
                tab.Controls.Add(flow);
                Console.WriteLine(Table);
                this.SelectTable.TabPages.Add(tab);

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
                ExtractTables();
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

            public void ExtractTables()
            {
                Command = new SQLiteCommand("SELECT name FROM sqlite_schema", Connection);
                Reader = Command.ExecuteReader();
                Tables = new List<Table>();
                while (Reader.Read())
                {
                    for (int i = 0; i < Reader.FieldCount; i++)
                    {
                        Tables.Add(new Table((string) Reader.GetValue(i)));
                    }
                }
            }

            public SQLiteConnection Connection
            { get; private set; }

            public SQLiteCommand Command
            { get; set; }

            public SQLiteDataReader Reader
            { get; set; }

            public string ActiveTable
            { get; set; }

            public List<Table> Tables
            { get; set; }

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
                //this.CreationSQL = creationSQL;
            }

            public string Name { get; set; }
            public string CreationSQL { get; set; }

        }

        // I didn't touch this other than referencing the singleton database object.
        private void ShowData(string table)
        {
            displayTable.Rows.Clear();

            string sql = "SELECT * FROM " + table;
            database.Command = new SQLiteCommand(sql, database.Connection);
            database.Reader = database.Command.ExecuteReader();


            displayTable.ColumnCount = database.Reader.FieldCount;
            for (int i = 0; i < database.Reader.FieldCount; i++)
            {
                displayTable.Columns[i].Name = database.Reader.GetName(i);
            }

            object[] values;
            while (database.Reader.Read())
            {
                values = new object[database.Reader.FieldCount];
                for(int i = 0; i < database.Reader.FieldCount; i++)
                {
                    values[i] = database.Reader.GetValue(i);
                }
                displayTable.Rows.Add(values);            
            }
        }

        // All the following buttons will be greatly condensed by a generalized function call.
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            // TODO: These will not be if statements, but a function call to a generalized insert function
            try
            {
                if(database.ActiveTable == "Teams")
                {

                }
                else if(database.ActiveTable == "Games")
                {
                    database.Command.CommandText = "INSERT INTO Games(Name, Device, Type, NumberOfPlayers) VALUES(@name, @device, @type, @numPlayers)";
                    /*database.Command.Parameters.AddWithValue("@name", GamesNameInput.Text);
                    database.Command.Parameters.AddWithValue("@device", GamesDeviceInput.Text);
                    database.Command.Parameters.AddWithValue("@type", GamesNameInput.Text);
                    database.Command.Parameters.AddWithValue("@numPlayers", Int32.Parse(GamesNumberOfPlayersInput.Text));*/
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
                Console.WriteLine("Data insert failed");
            }

            ShowData(database.ActiveTable);
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
