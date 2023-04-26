﻿using ManageUsersInDatabase.Database;
using ManageUsersInDatabase.UserAPI;
using System.Data.SQLite;
using ManageUsersInDatabase.Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
              The API endoints used in this script are free to use.
              https://randomuser.me/api/

           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");

        // Create DB connection
        DatabaseManager databaseManager = new DatabaseManager();
        SQLiteConnection sqLiteConnection = databaseManager.generateDB("C:\\Users\\" + System.Environment.UserName + "\\Desktop", "usersDB");

        RequestUser requestUser = new RequestUser();

        string displayOptions = "Please select one of these options: \n" +
            "1 - Display users \n" +
            "2 - Add new user from API \n" +
            "3 - Display specific user based on user ID \n" +
            "4 - Display specific user based on name \n" +
            "5 - Delete user based on user ID \n" +
            "6 - Delete user based on first and last name \n" +
            "7 - EXIT";
        
        // User Input
        UserInput userInput = new UserInput();
        

        while (true)
        {
            Console.WriteLine(displayOptions);
            string input = userInput.getUserInput();
            int userID = 0;

            switch(input)
            {
                default:
                    Console.WriteLine(displayOptions);
                    input = userInput.getUserInput();
                    break;
                case "1":
                    Console.WriteLine("You have selected option: 1 - Display users");
                    SQLiteDataReader getDataUsers = databaseManager.getAllUsers(sqLiteConnection);
                    databaseManager.displayAllUsers(getDataUsers);
                    break;
                case "2":
                    Console.WriteLine("You have selected option: 2 - Add new user from API");
                    try
                    {
                        string response = requestUser.getNewUserFromAPI("https://randomuser.me/api/");
                        User user = requestUser.parseInfoUser(response);
                        databaseManager.insertData(sqLiteConnection, user);
                        Console.WriteLine("New User has been added to database");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("There was an exception: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
                    }
                    break;
                case "3":
                    Console.WriteLine("You have selected option: 3 - Display specific user based on user ID");
                    Console.WriteLine("Please enter user ID you want to display: ");
                    input = userInput.getUserInput();
                    userID = String.IsNullOrEmpty(input) ? 0 : int.Parse(input);
                    if (userID != 0)
                        databaseManager.displaySpecificUserUsingID(sqLiteConnection, userID);
                    break;
                case "4":
                    Console.WriteLine("You have selected option: 4 - Display specific user based on name");
                    Console.WriteLine("Please enter user name you want to display: ");
                    string name = userInput.getUserInput();
                    if (!string.IsNullOrEmpty(name))
                        databaseManager.displaySpecificUserUsingName(sqLiteConnection, name);
                    break;
                case "5":
                    Console.WriteLine("You have selected option: 5 - Delete user based on user ID");
                    Console.WriteLine("Please enter user ID you want to delete: ");
                    input = userInput.getUserInput();
                    userID = String.IsNullOrEmpty(input) ? 0 : int.Parse(input);
                    if (userID != 0)
                        databaseManager.deleteSpecifcUserUsingID(sqLiteConnection, userID);
                    break;
                case "6":
                    Console.WriteLine("You have selected option: 6 - Delete user based on first and last name");

                    Console.WriteLine("Please enter first name you want to delete: ");
                    string first_name = userInput.getUserInput();

                    Console.WriteLine("Please enter last name you want to delete: ");
                    string last_name = userInput.getUserInput();

                    if (!string.IsNullOrEmpty(first_name) && !string.IsNullOrEmpty(last_name))
                        databaseManager.deleteSpecificUserUsingName(sqLiteConnection, first_name, last_name);
                    break;
                case "7":
                    Console.WriteLine("You have selected option: 7 - EXIT");
                    databaseManager.closeConnection(sqLiteConnection);
                    return;
            }
        }
        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}
