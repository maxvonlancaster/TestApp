using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace KnowledgeModel.DbAccess
{
    public class DbAccessQ
    {
        // Manage connection strings and objects
        // Application configuration files contain settings that are specific to a particular application. For example, an 
        // ASP.NET application can have one or more web.config files, and a Windows application can have an optional app.config file. 
        // Configuration files share common elements, although the name and location of a configuration file vary depending on the 
        // application's host.
        // The connectionStrings Section. Connection strings can be stored as key/value pairs in the connectionStrings section of the 
        // configuration element of an application configuration file.Child elements include add, clear, and remove.
        public static class MyCachedSettings
        {
            public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString;

            public static SqlConnection Connection = new SqlConnection(ConnectionString);
        }

        public void GetStuff() 
        {
            SqlConnection sqlconn = new SqlConnection(MyCachedSettings.ConnectionString);
        }



        // Working with data providers


        // Connect to a data source by using a generic data access interface


        // Handle and diagnose database connection exceptions


        // Manage exceptions when selecting, modifying data


        // Build command objects and query data from data sources


        // Retrieve data source by using the DataReader


        // Manage data by using the DataAdapter and TableAdapter


        // Updating data


        // Query data sources by using EF


        // Code First to existing DB


        // Entity Data Modeling Fundamentals


        // Creating a Model


        // Including & excluding types/properties


        // Keys


        // Modeling a Many-to-Many Relationship


        // Querying Data


        // Basic queries


        // Load related data(joins, include vs thenInclude)


        // Client vs server query evaluation


        // Tracking vs.No-Tracking


        // Raw SQL


        // How query works(when execution of query performed)


        // Tagging Query


        // Data modification


        // Save data


        // Related data


        // Cascade delete


        // Disconnected entities




    }
}
