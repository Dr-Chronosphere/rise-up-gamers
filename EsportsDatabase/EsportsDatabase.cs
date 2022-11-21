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

            string sql = "SELECT * FROM Games";
            cmd = new SQLiteCommand(sql, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                displayTable.ColumnCount = 5;
                displayTable.Columns[0].Name = "GameID";
                displayTable.Columns[1].Name = "Name";
                displayTable.Columns[2].Name = "Device";
                displayTable.Columns[3].Name = "Type";
                displayTable.Columns[4].Name = "Number of Players per Team";
                displayTable.Rows.Add(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4));            
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

        private void SelectTable_SelectedValueChanged(object sender, EventArgs e)
        {
            string table = (string)SelectTable.SelectedItem;
            DataShow(table);
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            string table = (string)SelectTable.SelectedItem;
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO Games(Name, Device, Type, NumberOfPlayers) VALUES(@name, @device, @type, @numPlayers)";

                cmd.Parameters.AddWithValue("@name", gameNameInput.Text);
                cmd.Parameters.AddWithValue("@device", gameDeviceInput.Text);
                cmd.Parameters.AddWithValue("@type", gameNameInput.Text);
                cmd.Parameters.AddWithValue("@numPlayers", Int32.Parse(gameNumberOfPlayersPerTeamInput.Text));

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
            
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
