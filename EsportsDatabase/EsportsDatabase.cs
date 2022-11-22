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
        string path = "Esports.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\Esports.db";
        string table;

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public EsportsDatabase()
        {
            InitializeComponent();
        }

        private void DataShow(string table)
        {
            displayTable.Rows.Clear();
            con = new SQLiteConnection(cs);
            con.Open();

            string sql = "SELECT * FROM " + table;
            cmd = new SQLiteCommand(sql, con);
            dr = cmd.ExecuteReader();


            displayTable.ColumnCount = dr.FieldCount;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                displayTable.Columns[i].Name = dr.GetName(i);
            }

            object[] values;
            while (dr.Read())
            {
                values = new object[dr.FieldCount];
                for(int i = 0; i < dr.FieldCount; i++)
                {
                    values[i] = dr.GetValue(i);
                }
                displayTable.Rows.Add(values);            
            }

        }

        private void CreateDB()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE Teams(" +
                                 "TeamID INTEGER PRIMARY KEY NOT NULL," +
                                 "Name TEXT," +
                                 "GameID INTEGER," +
                                 "Location TEXT," +
                                 "FOREIGN KEY (GameID) REFERENCES Games(GameID)" +
                                 ");";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE Games(" +
                                 "GameID INTEGER PRIMARY KEY NOT NULL," +
                                 "Name TEXT," +
                                 "Device TEXT, " +
                                 "Type TEXT, " +
                                 "NumberOfPlayers INTEGER " +
                                 ");";
                    SQLiteCommand command2 = new SQLiteCommand(sql, sqlite);
                    command2.ExecuteNonQuery();
                    sql = "CREATE TABLE Players(" +
                                 "PlayerID INTEGER PRIMARY KEY NOT NULL, " +
                                 "GamerTag TEXT, " +
                                 "FirstName TEXT, " +
                                 "LastName TEXT, " +
                                 "GameID INTEGER, " +
                                 "Contracted INTEGER, " +
                                 "FOREIGN KEY (GameID) REFERENCES Games(GameID)" +
                                 ");";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                    sql = "CREATE TABLE Rosters(" +
                                 "RosterID INTEGER PRIMARY KEY NOT NULL, " +
                                 "Team TEXT, " +
                                 "GameID INTEGER, " +
                                 "ListOfPlayerIDs TEXT, " +
                                 "FOREIGN KEY (Team) REFERENCES Teams(TeamID), " +
                                 "FOREIGN KEY (GameID) REFERENCES Games(GameID), " +
                                 "FOREIGN KEY (ListOfPlayerIDs) REFERENCES Players(PlayerID)" +
                                 ");";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                    sql = "CREATE TABLE Events(" +
                                 "EventID INTEGER PRIMARY KEY NOT NULL, " +
                                 "Name TEXT, " +
                                 "Date TEXT, " +
                                 "GameID INTEGER, " +
                                 "Location TEXT, " +
                                 "PrizeMoney INTEGER, " +
                                 "Format TEXT, " +
                                 "FOREIGN KEY (GameID) REFERENCES Games(GameID)" +
                                 ");";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Database already created");
                return;
            }
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                
                if(table == "Teams")
                {

                }
                else if(table == "Games")
                {
                    cmd.CommandText = "INSERT INTO Games(Name, Device, Type, NumberOfPlayers) VALUES(@name, @device, @type, @numPlayers)";

                    cmd.Parameters.AddWithValue("@name", gameNameInput.Text);
                    cmd.Parameters.AddWithValue("@device", gameDeviceInput.Text);
                    cmd.Parameters.AddWithValue("@type", gameNameInput.Text);
                    cmd.Parameters.AddWithValue("@numPlayers", Int32.Parse(gameNumberOfPlayersPerTeamInput.Text));
                }
                else if (table == "Players")
                {

                }
                else if (table == "Rosters")
                {

                }
                else if (table == "Events")
                {

                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Data insert failed");
            }

            DataShow(table);
        }

        private void EsportsDatabase_Load(object sender, EventArgs e)
        {
            
            CreateDB();
            table = this.SelectTable.SelectedTab.Text;
            DataShow(table);

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
        private void SelectTable_Selected(object sender, EventArgs e)
        {
            table = this.SelectTable.SelectedTab.Text;
            DataShow(table);
        }
    }
}
