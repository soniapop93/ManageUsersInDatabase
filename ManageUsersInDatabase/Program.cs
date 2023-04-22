using ManageUsersInDatabase.Database;
using ManageUsersInDatabase.UserAPI;
using System.Net;

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

        //RequestUser requestUser = new RequestUser();
        //string response = requestUser.getNewUserFromAPI("https://randomuser.me/api/");
        //User user = requestUser.parseInfoUser(response);

        DatabaseManager databaseManager = new DatabaseManager();
        databaseManager.generateDB("C:\\Users\\" + System.Environment.UserName + "\\Desktop", "testdb");



        //try
        //{


        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("There was an exception: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
        //}

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}
