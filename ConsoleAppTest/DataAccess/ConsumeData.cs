using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleAppTest.DataAccess
{
    // A single SQL database server can provide data storage to be shared between a large number of clients.The server can run on the same machine as the program
    // that is using the database or the server can be accessed via a network connection. Developers can work with development version of the database server running
    // on their machine, before creating a dedicated server for the published application
    public class ConsumeData
    {
        private string _connectionString = "Server=LAPTOP-2M0GJS3G\\SQLEXPRESS;Database=MusicTracksContext;Trusted_Connection=True;MultipleActiveResultSets=true";

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

        // 
        public void FilterWithSql()
        {

        }

        // 
        public void UpdateWithSql()
        {

        }

        // 
        public void SqlInjection()
        {

        }

        // 
        public void ParameterizedQuery()
        {

        }

        // 
        public void AsynchronousAccess()
        {

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
