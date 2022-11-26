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

namespace EsportsDatabase
{
    public partial class EsportsDatabase : Form
    {
        public EsportsDatabase()
        {
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
                    Contracted INTEGER,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID)
                );",
                @"CREATE TABLE Rosters
                    RosterID INTEGER PRIMARY KEY NOT NULL,
                    Team TEXT,
                    GameID INTEGER,
                    ListOfPlayerIDs TEXT,
                    FOREIGN KEY (Team) REFERENCES Teams(TeamID),
                    FOREIGN KEY (GameID) REFERENCES Games(GameID),
                    FOREIGN KEY (ListOfPlayerIDs) REFERENCES Players(PlayerID)
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
            InitializeComponent();
            InitializeTabs();
        }

        public void InitializeTabs()
        {
            foreach (Table Table in database.Tables)
            {
                FlowLayoutPanel flow = new FlowLayoutPanel();
                Label label = new Label();
                label.Text = "stuff";
                flow.Controls.Add(label);
                TabPage tab = new TabPage();
                tab.Text = Table.Name;
                tab.Controls.Add(flow);
                Console.WriteLine(Table);
                this.SelectTable.TabPages.Add(tab);
            }
        }

        public class Database
        {
            public Database(string filename, params string[] creationSQL)
            {
                _filename = filename;
                _path = @"URI=file:" + Application.StartupPath + @"\" + _filename;
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

        private void EsportsDatabase_Load(object sender, EventArgs e)
        {
            ShowData(this.SelectTable.SelectedTab.Text);
        }

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

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(database.ActiveTable == "Teams")
                {

                }
                else if(database.ActiveTable == "Games")
                {
                    database.Command.CommandText = "INSERT INTO Games(Name, Device, Type, NumberOfPlayers) VALUES(@name, @device, @type, @numPlayers)";
                    database.Command.Parameters.AddWithValue("@name", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@device", gameDeviceInput.Text);
                    database.Command.Parameters.AddWithValue("@type", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@numPlayers", Int32.Parse(gameNumberOfPlayersPerTeamInput.Text));
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
                    database.Command.Parameters.AddWithValue("@gameID", gameIDInput.Text);
                    database.Command.Parameters.AddWithValue("@name", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@device", gameDeviceInput.Text);
                    database.Command.Parameters.AddWithValue("@type", gameNameInput.Text);
                    database.Command.Parameters.AddWithValue("@numPlayers", Int32.Parse(gameNumberOfPlayersPerTeamInput.Text));
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

                    database.Command.Parameters.AddWithValue("@gameID", gameIDInput.Text);
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
