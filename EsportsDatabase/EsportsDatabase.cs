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
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
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
                    FirstName TEXT,
                    LastName TEXT,
                    GameID INTEGER,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
                );",
                @"CREATE TABLE Rosters(
                    RosterID INTEGER PRIMARY KEY NOT NULL,
                    TeamID TEXT,
                    GameID INTEGER,
                    ListOfPlayers TEXT,
                    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID) ON DELETE CASCADE,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
                );",
                @"CREATE TABLE Events(
                    EventID INTEGER PRIMARY KEY NOT NULL,
                    Name TEXT,
                    Date TEXT,
                    GameID INTEGER,
                    Location TEXT,
                    PrizeMoney INTEGER,
                    Format TEXT,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
                );"
            );
            database.InitializeTables();
            // WinForms Designer Generator
            InitializeComponent();

            // Put our modifications here:
            InitializeTabs();
            database.ActiveTable = this.SelectTable.SelectedTab.Text;
            ShowData(database.ActiveTable);
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
                Create();
            }

            public bool Create()
            {
                if (!System.IO.File.Exists(_filename))
                { 
                    SQLiteConnection.CreateFile(_filename);
                    Connection.Open();
                    foreach (string sql in _creationSQL)
                    {
                        Command = new SQLiteCommand(sql, Connection);
                        Command.ExecuteNonQuery();
                    }
                    Command = new SQLiteCommand("PRAGMA foreign_keys=ON", Connection);
                    Command.ExecuteNonQuery();
                    return true;
                }
                Console.WriteLine("Database already created.");
                Connection.Open();
                Command = new SQLiteCommand("PRAGMA foreign_keys=ON", Connection);
                Command.ExecuteNonQuery();
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
                Fields = database.Query($"SELECT name FROM pragma_table_info('{name}') WHERE pk = 0");
                PrimaryKey = database.Query($"SELECT name FROM pragma_table_info('{name}') WHERE pk = 1")[0];
                AllFields = new List<string>();
                AllFields.Add(PrimaryKey);
                AllFields.AddRange(Fields);
                LinkedTab = new Tab(name);
            }

            public void Insert()
            {
                database.Command.CommandText = $"INSERT INTO {Name}({string.Join(", ", Fields)}) VALUES(@{string.Join(", @", Fields)})";
                foreach (KeyValuePair<string, TextBox> input in LinkedTab.Inputs)
                {
                    database.Command.Parameters.AddWithValue($"@{input.Key}", input.Value.Text);
                }
                database.Command.ExecuteNonQuery();
            }

            public void Update()
            {
                var activeFields = from field in Fields where !string.IsNullOrEmpty(LinkedTab.Inputs[field].Text) select field;
                var setters = activeFields.Select(field => field + " = @" + field.ToLower());
                database.Command.CommandText = $"UPDATE {Name} SET {string.Join(", ", setters)} WHERE {PrimaryKey} = {LinkedTab.Inputs[PrimaryKey].Text}";
                foreach (string field in activeFields)
                {
                    database.Command.Parameters.AddWithValue($"@{field.ToLower()}", LinkedTab.Inputs[field].Text);
                }
                database.Command.ExecuteNonQuery();
            }

            public void Delete()
            {
                database.Command.CommandText = $"DELETE FROM {Name} WHERE {PrimaryKey} = '{LinkedTab.Inputs[PrimaryKey].Text}'";
                database.Command.ExecuteNonQuery();
            }

            public string Name { get; set; }
            public List<string> Fields { get; set; }
            public Tab LinkedTab { get; set; }

            // new fields for storing primary key separately, all fields?, and external table references
            public string PrimaryKey { get; set; }
            public List<string> AllFields { get; set; }
            // may be unnecessary... use Exception raised by specifying non-existant key.
            public List<(string sourceField, string targetTable, string targetField)> References { get; set; }
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

                foreach (string field in database.Tables[LinkedTable].AllFields)
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

            var columnHeaders = database.Tables[table].AllFields;
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

        private void InsertBtn_Click(object sender, EventArgs e)
        { 
            try
            { 
                database.Tables[database.ActiveTable].Insert();
            }
            catch(Exception error)
            {
                ErrorLabel.Text = $"Data insert failed. Error code: {error}";
            }
            
            ShowData(database.ActiveTable);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                database.Tables[database.ActiveTable].Update();
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data update failed. Error code: {error}";
            }

            ShowData(database.ActiveTable);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                database.Tables[database.ActiveTable].Delete();
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data delete failed. Error code: {error}";
            }

            ShowData(database.ActiveTable);
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tablesToJoin = new List<string>();
                for (int i = 0; i < JoinTables.Items.Count; i++)
                {
                    if (JoinTables.GetItemChecked(i))
                    {
                        tablesToJoin.Add(JoinTables.GetItemText(i));
                    }
                }
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Table join failed. Error code: {error}";
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var Filters = new List<string>();
                foreach (KeyValuePair<string, TextBox> input in database.Tables[database.ActiveTable].LinkedTab.Inputs)
                {
                    if (!string.IsNullOrEmpty(input.Value.Text))
                    {
                        Filters.Add($"{input.Key} LIKE '%{input.Value.Text}%'");
                    }
                }
                string rowFilter = string.Join(" OR ", Filters);

                var data = database.Query($"SELECT * FROM {database.ActiveTable} WHERE {rowFilter}");
                var columnHeaders = database.Tables[database.ActiveTable].AllFields;

                displayTable.Rows.Clear();

                for (int i = 0; i < data.Count; i += (columnHeaders.Count))
                {
                    displayTable.Rows.Add(data.GetRange(i, columnHeaders.Count).ToArray());
                }
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data search failed. Error code: {error}";
            }
        }

        private void SelectTable_Selected(object sender, EventArgs e)
        {
            database.ActiveTable = this.SelectTable.SelectedTab.Text;
            ShowData(database.ActiveTable);
        }

        public static Database database;
    }
}
