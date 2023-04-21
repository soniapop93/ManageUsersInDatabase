using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUsersInDatabase.Database
{
    public class CreateDB
    {
        public void generateDB(string path, string fileName)
        {
            string fileNamePath = path + @"\" + fileName + ".db";

            SQLiteConnection sqLiteConnection = createConnection(fileNamePath);

            Console.WriteLine("Database is created successfully");
            CreateTable(sqLiteConnection);
            
        }

        public SQLiteConnection createConnection(string fileNamePath)
        {
            string strConnection = String.Format("Data Source={0};Version=3;New=True;Compress=True;", fileNamePath);
            SQLiteConnection sqliteConnection;
            
            sqliteConnection = new SQLiteConnection(strConnection);

            sqliteConnection.Open();

            return sqliteConnection;
        }

        public void CreateTable(SQLiteConnection sqLiteConnection)
        {
            SQLiteCommand sqLiteCommand;
            string createSQL = "CREATE TABLE Users " +
                "(title_name TEXT," +
                "first_name TEXT," +
                "last_name TEXT, " +
                "location_street_number INT, " +
                "location_street_name TEXT, " +
                "city TEXT, " +
                "state TEXT, " +
                "country TEXT, " +
                "postcode INT, " +
                "latitude TEXT, " +
                "longitude TEXT, " +
                "timezone_offset TEXT, " +
                "timezone TEXT, " +
                "email TEXT, " +
                "login_uuid TEXT, " +
                "login_username TEXT, " +
                "login_password TEXT, " +
                "login_salt TEXT, " +
                "login_md5 TEXT, " +
                "login_sha1 TEXT, " +
                "login_sha256 TEXT, " +
                "date_of_birth_date TEXT, " +
                "age INT, " +
                "registered_date TEXT, " +
                "registered_age INT, " +
                "phone TEXT, " +
                "cell TEXT, " +
                "id_name TEXT, " +
                "id_value TEXT, " +
                "picture_large TEXT, " +
                "picture_medium TEXT, " +
                "picture thumbnail TEXT, " +
                "nationality TEXT)";
            sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = createSQL;
            sqLiteCommand.ExecuteNonQuery();
        }

        public void closeConnection(SQLiteConnection sqLiteConnection)
        {
            sqLiteConnection.Close();
        }
    }
}
