using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


public class DataConnection
{
    static SqlConnection con;
    static SqlCommand cmd;

    //public DataConnection()
    //{
    //    String mycon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
    //    con = new SqlConnection(mycon);
    //}
    
    public static SqlDataReader selectQuery(String query)
    {
        String mycon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
        con = new SqlConnection(mycon);
        con.Open();

        cmd = new SqlCommand(query, con);
        return cmd.ExecuteReader();
    }

    public static void insertQuery(String query)
    {
        String mycon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
        con = new SqlConnection(mycon);
        con.Open();
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public static void updateQuery(String query)
    {
        String mycon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
        con = new SqlConnection(mycon);
        con.Open();
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public static void createConnection()
    {
        if (con != null && con.State == System.Data.ConnectionState.Closed)
        {
            String mycon = System.Configuration.ConfigurationManager.ConnectionStrings["revenueConnectionString1"].ConnectionString;
            con = new SqlConnection(mycon);
        }
    }

    public static void closeConnection()
    {
        if (con == null && con.State == System.Data.ConnectionState.Open)
        {
            con.Close();
        }
    }
}