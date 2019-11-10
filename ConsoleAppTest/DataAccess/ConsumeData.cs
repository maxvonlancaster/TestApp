using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.DataAccess
{
    // A single SQL database server can provide data storage to be shared between a large number of clients.The server can run on the same machine as the program
    // that is using the database or the server can be accessed via a network connection. Developers can work with development version of the database server running
    // on their machine, before creating a dedicated server for the published application
    public class ConsumeData
    {
        private string _connectionString = "Server=localhost\\SQLEXPRESS;Database=MusicTracksContext;Trusted_Connection=True;MultipleActiveResultSets=true";

        // To make a connection to a database a program must create a SqlConnection object. The constructor for the SqlConnection class is
        //given a connection string that identifies the database that is to be opened.Before we can begin to read from the database we need to consider how the connection
        //string is used to manage the connection. The connection string contains a number of items expressed as name-value
        //pairs.For a server on a remote machine the connection string will contain the address of the server, the port on which the server is listening and a
        //username/password pair that can authenticate the connection.
        public void ReadWithSql()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from MusicTrack", connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string artist = reader["Artist"].ToString();
                    string title = reader["Title"].ToString();
                    int length = (int)reader["Length"];

                    Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}", artist, title, length);
                }
            }
        }

        // The first SQL command selected all of the elements in a table. You can change this so that you can filter the contents of the table using a query.
        public void FilterWithSql()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from MusicTrack where Artist = 'Artist'", connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string artist = reader["Artist"].ToString();
                    string title = reader["Title"].ToString();
                    int length = (int)reader["Length"];

                    Console.WriteLine("Artist: {0}, Title: {1}, Length: {2}", artist, title, length);
                }
            }
        }

        // A program can use the SQL UPDATE command to update the contents of an entry in the database
        // When the update is performed it is possible to determine how many elements  are updated.
        public void UpdateWithSql()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("update MusicTrack SET Artist='Kanye West' WHERE ID='1'", connection);

                int result = command.ExecuteNonQuery();
                Console.WriteLine("Number of entries updated: {0}", result);
            }
        }

        // Suppose you want to allow the user of your program to update the name of a
        // particular track.Your program can read the information from the user and then construct an SQL command to perform the update.
        public void SqlInjection()
        {
            Console.Write("Enter the title of the track to update: ");            string searchTitle = Console.ReadLine();
            Console.Write("Enter the new artist name: ");
            string newName = Console.ReadLine();
            string sqlCommand = "update MusicTrack SET Artist=" + newName + " WHERE Title=" + searchTitle;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);

                int result = command.ExecuteNonQuery();
                Console.WriteLine("Number of entries updated: {0}", result);
            }
            // Enter the new artist name: Fred'); DELETE FROM MusicTrack; 
            // user of the program has done is injected another SQL command after the
            // UPDATE command. The command would set the new artist name to Fred and then perform an SQL DELETE command. 

        }

        // For this reason, you should never construct SQL commands directly from user input.You must use parameterized SQL statements instead.
        // The SQL command contains markers that identify the points in the query where text is to be inserted.The program then adds the parameter
        // values that correspond to the marker points.The SQL server now knows exactly where each element starts and ends, making SQL injection impossible.
        public void ParameterizedQuery()
        {
            Console.Write("Enter the title of the track to update: ");            string searchTitle = Console.ReadLine();
            Console.Write("Enter the new artist name: ");
            string newName = Console.ReadLine();
            string sqlCommand = "update MusicTrack SET Artist = @newName WHERE Title = @searchTitle";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);

                command.Parameters.AddWithValue("@searchTitle", searchTitle);
                command.Parameters.AddWithValue("@newName", newName);

                int result = command.ExecuteNonQuery();
                Console.WriteLine("Number of entries updated: {0}", result);
            }
        }

        // There are also asynchronous versions of the methods.A program can use the async/await mechanism with these
        // versions of the methods so that database queries can run asynchronously.This is particularly important if your program is interacting with the user via a
        // windowed interface.
        async Task AsynchronousAccess()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                StringBuilder databaseList = new StringBuilder();
                while (await reader.ReadAsync())
                {
                    string id = reader["ID"].ToString();
                    string artist = reader["Artist"].ToString();
                    string title = reader["Title"].ToString();
                    string row = string.Format("ID: {0} Artist: {1} Title: {2}", id, artist, title);
                    databaseList.AppendLine(row);
                }
                Console.WriteLine(databaseList.ToString());
            }
        }

        // 
        public void ConsumeJsonData()
        {

        }

        // 
        public void XmlElements()
        {

        }

        // 
        public void XmlDom()
        {

        }

        // 
        public void WebService()
        {

        }
    }
}
