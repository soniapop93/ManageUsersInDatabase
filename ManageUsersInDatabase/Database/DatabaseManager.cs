﻿using ManageUsersInDatabase.UserAPI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                user.location.country + "'," +
                user.location.postcode + ",'" +
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
                user.id.name + "','" +
                user.id.value + "','" +
                user.picture.large + "','" +
                user.picture.medium + "','" +
                user.picture.thumbnail + "','" +
                user.nat +"');";


            sqLiteCommand.CommandText = strData;
            sqLiteCommand.ExecuteNonQuery();
        }
    }
}
