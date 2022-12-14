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
using System.Text.RegularExpressions;

namespace EsportsDatabase
{
    public partial class EsportsDatabase : Form
    {
        public EsportsDatabase()
        {
            // Much easier constructor-based database initialization.
            // Consider making database constructor alter/add to existing database object.
            database = new Database("Esports.db",
                @"CREATE TABLE Games(
                    GameID INTEGER PRIMARY KEY NOT NULL,
                    GameName TEXT,
                    Device TEXT,
                    Type TEXT,
                    NumberOfPlayers INTEGER
                );",
                @"CREATE TABLE Organizations(
                    OrganizationID INTEGER PRIMARY KEY NOT NULL,
                    OrganizationName TEXT, 
                    OrganizationLocation TEXT,
                    YearFounded INTEGER            
                );",
                @"CREATE TABLE Teams(
                    TeamID INTEGER PRIMARY KEY NOT NULL,
                    OrganizationID INTEGER,
                    GameID INTEGER,
                    FOREIGN KEY (OrganizationID) REFERENCES Organizations(OrganizationID) ON DELETE CASCADE,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
                );",
                @"CREATE TABLE Players(
                    PlayerID INTEGER PRIMARY KEY NOT NULL,
                    GamerTag TEXT,
                    FirstName TEXT,
                    LastName TEXT,
                    GameID INTEGER,
                    TeamID INTEGER,
                    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE,
                    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID) ON DELETE CASCADE
                );",
                @"CREATE TABLE Events(
                    EventID INTEGER PRIMARY KEY NOT NULL,
                    EventName TEXT,
                    EventDate TEXT,
                    GameID INTEGER,
                    EventLocation TEXT,
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

                    // Initialize data
                    List<List<string>> initialData = new List<List<string>>();
                    initialData.Add(new List<string> { "INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('League of Legends', 'PC', 'MOBA', 5)", "INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('CS:GO', 'PC', 'Tactical Shooter', 5)", "INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Rocket League', 'Cross-Platform', 'Sports', 3)", "INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Fortnite', 'Cross-Platform', 'Battle Royale', 4)", "INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Hearthstone', 'PC', 'Card', 1)" });
                    initialData.Add(new List<string> { "INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES ('Cloud 9', 'California, USA', 2013)", "INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES ('Fnatic', 'London, UK', 2004)", "INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES ('Tempo Storm', 'Los Angeles, California, USA', 2014)", "INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES ('Wichita State', 'Wichita, Kansas, USA', 2019)", "INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES ('Team Liquid', 'California, USA', 2000)" });
                    initialData.Add(new List<string> { "INSERT INTO Teams (OrganizationID, GameID) VALUES (1, 1)", "INSERT INTO Teams (OrganizationID, GameID) VALUES (1, 2)", "INSERT INTO Teams (OrganizationID, GameID) VALUES (2, 1)", "INSERT INTO Teams (OrganizationID, GameID) VALUES (4, 3)", "INSERT INTO Teams (OrganizationID, GameID) VALUES (3, 5)" });
                    initialData.Add(new List<string> { "INSERT INTO Players (GamerTag, FirstName, LastName, GameID, TeamID) VALUES ('Sneaky', 'Zachary', 'Scuderi', 1, 1)", "INSERT INTO Players (GamerTag, FirstName, LastName, GameID, TeamID) VALUES ('MrGopher', 'Tobin', 'Hushower', 3, 4)", "INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('S1mple', 'Natus', 'Vincere', 2)", "INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('Mero', 'Matthew', 'Faitel', 4)", "INSERT INTO Players (GamerTag, FirstName, LastName, GameID, TeamID) VALUES ('Reynad', 'Andrey', 'Yanyuk', 5, 3)" });
                    initialData.Add(new List<string> { "INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('LOL Worlds Championship', 'September 29, 2022', 1, 'New York City, New York, USA', 2230000, 'Single Elimination')", "INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('LOL MSI', 'May 10, 2022', 1, 'Busan, South Korea', 250000, 'Single Elimination')", "INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('RLCS Worlds Championship', 'August 4, 2022', 3, 'Fort Worth, Texas, USA', 2085000, 'Double Elimination into Single Elimination')", "INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('Fortnite World Cup', 'November 12, 2022', 4, 'Raleigh, North Carolina, USA', 1000000, 'Points System into Single Elimination')", "INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('BLAST Premier: Fall Finals 2022', 'November 23, 2022', 2, 'Copenhagen, Denmark', 425000, 'Single Elimination')" });
                    foreach (var tableData in initialData)
                    {
                        foreach (var insertStatement in tableData)
                        {
                            Command.CommandText = insertStatement;
                            Command.ExecuteNonQuery();
                        }
                    }
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
                foreach (string tableName in lastQueryResults)
                {
                    Tables[tableName] = new Table(tableName);
                }

            }

            public List<string> Query(string sql)
            {
                currQuery = sql;
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

            public string currQuery;
            public List<string> currHeaders;
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
                //flow.AutoScroll = true;
                flow.Dock = DockStyle.Fill;
                flow.FlowDirection = FlowDirection.TopDown;

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
            database.currHeaders = columnHeaders;
            JoinBtn.Enabled = true;
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                database.Tables[database.ActiveTable].Insert();
                ErrorLabel.Text = $"Data insert succeeded!";
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data insert failed.";
            }

            ShowData(database.ActiveTable);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                database.Tables[database.ActiveTable].Update();
                ErrorLabel.Text = $"Data update succeeded!";
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data update failed.";
            }

            ShowData(database.ActiveTable);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                database.Tables[database.ActiveTable].Delete();
                ErrorLabel.Text = $"Data delete succeeded!";
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data delete failed.";
            }

            ShowData(database.ActiveTable);
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> tablesToJoin = new List<string>();
                for (int i = 0; i < JoinTables.CheckedItems.Count; i++)
                {
                    tablesToJoin.Add(JoinTables.CheckedItems[i].ToString());
                }
                List<List<string>> allColumnHeaders = new List<List<string>>();
                allColumnHeaders.Add(database.currHeaders);
                foreach (var table in tablesToJoin)
                {
                    var columnHeaders = database.Tables[table].AllFields;
                    allColumnHeaders.Add(columnHeaders);
                }
                List<string> joinTableHeaders = new List<string>();
                foreach (var headerList in allColumnHeaders)
                {
                    foreach (var header in headerList)
                    {
                        if (!joinTableHeaders.Contains(header))
                        {
                            joinTableHeaders.Add(header);
                        }
                    }
                }
                var sql = "";
                bool teamIDChecker = false;
                bool orgChecker = false;
                bool firstJoinOnOrgChecker = false;
                if (database.currQuery.IndexOf("WHERE", 0) != -1)
                {
                    var sql1 = database.currQuery.Substring(0, database.currQuery.IndexOf("WHERE", 0));
                    var sql2 = database.currQuery.Substring(database.currQuery.IndexOf("WHERE", 0));
                    sql1 = sql1.TrimEnd();
                    if(database.ActiveTable == "Teams" || database.ActiveTable == "Players")
                    {
                        teamIDChecker = true;
                    }
                    foreach (var table in tablesToJoin)
                    {
                        if (table == database.ActiveTable)
                        {

                        }
                        else if (database.ActiveTable == "Organizations")
                        {
                            if (!firstJoinOnOrgChecker && table != "Teams")
                            {
                                if (table == "Players")
                                {
                                    sql1 += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (TeamID)) USING (OrganizationID)";
                                }
                                else
                                {
                                    sql1 += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (GameID)) USING (OrganizationID)";
                                }
                                firstJoinOnOrgChecker = true;
                                joinTableHeaders.Add("TeamID");
                            }
                            else if (!firstJoinOnOrgChecker && table == "Teams")
                            {
                                sql1 += " INNER JOIN " + table + " USING (OrganizationID)";
                                firstJoinOnOrgChecker = true;
                            }
                            else if (table == "Players")
                            {
                                sql1 += " INNER JOIN " + table + " USING (TeamID, GameID)";
                            }
                            else if (table == "Teams")
                            {
                                sql1 += " INNER JOIN " + table + " USING (OrganizationID)";
                            }
                            else
                            {
                                sql1 += " INNER JOIN " + table + " USING (GameID)";
                            }

                        }
                        else
                        {
                            if (teamIDChecker && table == "Teams" || table == "Players")
                            {
                                sql1 += " INNER JOIN " + table + " USING (GameID, TeamID)";
                            }
                            else if (table == "Teams" || table == "Players")
                            {
                                if (orgChecker && table == "Teams")
                                {
                                    sql1 += " INNER JOIN " + table + " USING (GameID, TeamID, OrganizationID)";
                                }
                                else if (teamIDChecker)
                                {
                                    sql1 += " INNER JOIN " + table + " USING (GameID, TeamID)";
                                }
                                else
                                {
                                    sql1 += " INNER JOIN " + table + " USING (GameID)";
                                    teamIDChecker = true;
                                }
                            }
                            else if (table == "Organizations")
                            {
                                if (database.ActiveTable == "Teams")
                                {
                                    sql1 += " INNER JOIN Organizations USING (OrganizationID)";
                                    teamIDChecker = true;
                                }
                                else
                                {
                                    if (teamIDChecker)
                                    {
                                        sql1 += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (OrganizationID)) USING (GameID, TeamID)";

                                    }
                                    else
                                    {
                                        sql1 += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (OrganizationID)) USING (GameID)";

                                    }
                                }
                                if (!joinTableHeaders.Contains("TeamID"))
                                {
                                    joinTableHeaders.Add("TeamID");
                                }
                                orgChecker = true;
                            }
                            else
                            {
                                sql1 += " INNER JOIN " + table + " USING (GameID)";

                            }
                        }
                    }

                    sql = sql1 + " " + sql2;
                }
                else
                {
                    sql = database.currQuery;
                    foreach (var table in tablesToJoin)
                    {
                        if (table == database.ActiveTable)
                        {

                        }
                        else if (database.ActiveTable == "Organizations")
                        {
                            if(!firstJoinOnOrgChecker && table != "Teams")
                            {
                                if(table == "Players")
                                {
                                    sql += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (TeamID)) USING (OrganizationID)";
                                }
                                else
                                {
                                    sql += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (GameID)) USING (OrganizationID)";
                                }
                                firstJoinOnOrgChecker = true;
                                joinTableHeaders.Add("TeamID");
                            }
                            else if (!firstJoinOnOrgChecker && table == "Teams")
                            {
                                sql += " INNER JOIN " + table + " USING (OrganizationID)";
                                firstJoinOnOrgChecker = true;
                            }
                            else if (table == "Players")
                            {
                                sql += " INNER JOIN " + table + " USING (TeamID, GameID)";
                            }
                            else if (table == "Teams")
                            {
                                sql += " INNER JOIN " + table + " USING (OrganizationID)";
                            }
                            else
                            {
                                sql += " INNER JOIN " + table + " USING (GameID)";
                            }

                        }
                        else
                        {
                            if (teamIDChecker && table == "Teams" || table == "Players")
                            {
                                sql += " INNER JOIN " + table + " USING (GameID, TeamID)";
                            }
                            else if (table == "Teams" || table == "Players")
                            {
                                if (orgChecker && table == "Teams")
                                {
                                    sql += " INNER JOIN " + table + " USING (GameID, TeamID, OrganizationID)";
                                }
                                else if (teamIDChecker)
                                {
                                    sql += " INNER JOIN " + table + " USING (GameID, TeamID)";
                                }
                                else
                                {
                                    sql += " INNER JOIN " + table + " USING (GameID)";
                                    teamIDChecker = true;
                                }
                            }
                            else if (table == "Organizations")
                            {
                                if (database.ActiveTable == "Teams")
                                {
                                    sql += " INNER JOIN Organizations USING (OrganizationID)";
                                    teamIDChecker = true;
                                }
                                else
                                {
                                    if (teamIDChecker)
                                    {
                                        sql += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (OrganizationID)) USING (GameID, TeamID)";

                                    }
                                    else
                                    {
                                        sql += " INNER JOIN (SELECT * FROM " + table + " INNER JOIN Teams USING (OrganizationID)) USING (GameID)";
                                    }
                                }
                                if (!joinTableHeaders.Contains("TeamID"))
                                {
                                    joinTableHeaders.Add("TeamID");
                                }
                                orgChecker = true;
                            }
                            else
                            {
                                sql += " INNER JOIN " + table + " USING (GameID)";

                            }
                        }
                    }
                }
                if(tablesToJoin.Count == 1 && tablesToJoin.Contains(database.ActiveTable))
                {
                    sql = database.currQuery;
                }

                var data = database.Query($"" + sql);

                displayTable.Rows.Clear();
                displayTable.ColumnCount = joinTableHeaders.Count;

                for (int i = 0; i < joinTableHeaders.Count; i++)
                {
                    displayTable.Columns[i].Name = joinTableHeaders[i];
                }
                for (int i = 0; i < data.Count; i += (joinTableHeaders.Count))
                {
                    displayTable.Rows.Add(data.GetRange(i, joinTableHeaders.Count).ToArray());
                }
                database.currHeaders = joinTableHeaders;
                ErrorLabel.Text = $"Table join succeeded!";
                JoinBtn.Enabled = false;
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Table join failed.";
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
                database.currHeaders = columnHeaders;
                ErrorLabel.Text = $"Data search succeeded!";
                JoinBtn.Enabled = true;
            }
            catch (Exception error)
            {
                ErrorLabel.Text = $"Data search failed.";
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
