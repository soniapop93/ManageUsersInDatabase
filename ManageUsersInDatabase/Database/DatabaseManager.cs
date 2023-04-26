using ManageUsersInDatabase.UserAPI;
using System.Data.SQLite;

namespace ManageUsersInDatabase.Database
{
    public class DatabaseManager
    {
        public SQLiteConnection generateDB(string path, string fileName)
        {
            string fileNamePath = path + @"\" + fileName + ".db";
            SQLiteConnection sqLiteConnection = createConnection(fileNamePath);

            Console.WriteLine("Database is created successfully");
            CreateTable(sqLiteConnection);
            
            return sqLiteConnection;
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
            string createSQL = "CREATE TABLE IF NOT EXISTS Users " +
                "(title_name TEXT," +
                "first_name TEXT," +
                "last_name TEXT, " +
                "location_street_number INT, " +
                "location_street_name TEXT, " +
                "city TEXT, " +
                "state TEXT, " +
                "country TEXT, " +
                "postcode TEXT, " +
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
                "picture_thumbnail TEXT, " +
                "nationality TEXT)";
            sqLiteCommand = sqLiteConnection.CreateCommand();
            sqLiteCommand.CommandText = createSQL;
            sqLiteCommand.ExecuteNonQuery();
        }

        public void closeConnection(SQLiteConnection sqLiteConnection)
        {
            sqLiteConnection.Close();
        }

        public void insertData(SQLiteConnection sqLiteConnection, User user)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "INSERT INTO Users " +
                "(title_name, " +
                "first_name, " +
                "last_name, " +
                "location_street_number, " +
                "location_street_name, " +
                "city, " +
                "state, " +
                "country, " +
                "postcode, " +
                "latitude, " +
                "longitude, " +
                "timezone_offset, " +
                "timezone, " +
                "email, " +
                "login_uuid, " +
                "login_username, " +
                "login_password, " +
                "login_salt, " +
                "login_md5, " +
                "login_sha1, " +
                "login_sha256, " +
                "date_of_birth_date, " +
                "age, " +
                "registered_date, " +
                "registered_age, " +
                "phone, " +
                "cell, " +
                "id_name, " +
                "id_value, " +
                "picture_large, " +
                "picture_medium, " +
                "picture_thumbnail, " +
                "nationality) " +
                "VALUES " +
                "('" +
                user.name.title + "','"  +
                user.name.firstName + "','" +
                user.name.lastName + "'," +
                user.location.street.number + ",'" +
                user.location.street.name + "','" +
                user.location.city + "','" +
                user.location.state + "','" +
                user.location.country + "','" +
                user.location.postcode.ToString() + "','" +
                user.location.coordinates.latitude + "','" +
                user.location.coordinates.longitude + "','" +
                user.location.timezone.offset + "','" +
                user.location.timezone.description + "','" +
                user.email + "','" +
                user.login.uuid + "','" +
                user.login.username + "','" +
                user.login.password + "','" +
                user.login.salt + "','" +
                user.login.md5 + "','" +
                user.login.sha1 + "','" +
                user.login.sha256 + "','" +
                user.dob.date + "'," +
                user.dob.age + ",'" +
                user.registered.date + "'," +
                user.registered.age + ",'" +
                user.phone + "','" +
                user.cell + "','" +
                (string.IsNullOrEmpty(user.id.name) ? "-" : user.id.name) + "','" +
                (string.IsNullOrEmpty(user.id.value) ? "-" : user.id.value) + "','" +
                user.picture.large + "','" +
                user.picture.medium + "','" +
                user.picture.thumbnail + "','" +
                user.nat +"');";


            sqLiteCommand.CommandText = strData;
            sqLiteCommand.ExecuteNonQuery();
        }

        public SQLiteDataReader getAllUsers(SQLiteConnection sqLiteConnection)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "SELECT * FROM Users;";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            return allDBdata;
        }

        public void displayAllUsers(SQLiteDataReader allDBdata)
        {
            while(allDBdata.Read())
            {
                for (int i = 0; i < allDBdata.FieldCount; i++)
                {
                    Console.WriteLine(allDBdata.GetName(i) + " --> " + allDBdata[i]);
                }
                Console.WriteLine("*******************************************************");
            }
        }

        public void displaySpecificUserUsingID(SQLiteConnection sqLiteConnection, int userID)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "SELECT * FROM Users WHERE ROWID = " + userID.ToString() + ";";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            displayAllUsers(allDBdata);

        }

        public void displaySpecificUserUsingName(SQLiteConnection sqLiteConnection, string name)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "SELECT * FROM Users WHERE first_name = " + name + " OR last_name = " + name + ";";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            displayAllUsers(allDBdata);
        }

        public void deleteSpecifcUserUsingID(SQLiteConnection sqLiteConnection, int userID)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "DELETE FROM Users WHERE ROWID = " + userID.ToString() + ";";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            Console.WriteLine("User with ID: " + userID + " has been deleted from the database.");
        }

        public void deleteSpecificUserUsingName(SQLiteConnection sqLiteConnection, string first_name, string last_name)
        {
            SQLiteCommand sqLiteCommand;
            sqLiteCommand = sqLiteConnection.CreateCommand();

            string strData = "DElETE FROM Users WHERE first_name = " + first_name + " AND last_name = " + last_name + ";";
            sqLiteCommand.CommandText = strData;
            SQLiteDataReader allDBdata = sqLiteCommand.ExecuteReader();

            Console.WriteLine("User with first name: " + first_name + " and last name: " + last_name + " has been deleteted from the database.");
        }
    }
}
