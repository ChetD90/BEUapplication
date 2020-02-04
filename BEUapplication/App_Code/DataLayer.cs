using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq; 
using System.Data.OleDb;
using System.Net;
/// <summary>
/// Summary description for clsDataLayer
/// </summary>
public class DataLayer
{
    public static dsActivity GetUserActivity(string Database)
    {

        dsActivity DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;


        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;;" +
            "Data Source=(C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");

        
        sqlDA = new OleDbDataAdapter("select * from UserActivity", sqlConn);

        
        DS = new dsActivity();

        
        sqlDA.Fill(DS.UserActivity);

        
        return DS;

    }
        
    public static void SaveUserActivity(string Database, string FormAccessed)
    {

        OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=(C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");
        conn.Open();
        OleDbCommand command = conn.CreateCommand();
        string strSQL;

        strSQL = "Insert into UserActivity (UserIP, FormAccessed) values ('" +
            GetIP4Address() + "', '" + FormAccessed + "')";

        command.CommandType = CommandType.Text;
        command.CommandText = strSQL;
        command.ExecuteNonQuery();
        conn.Close();
    }

    
    public static string GetIP4Address()
    {
        string IP4Address = string.Empty;

        foreach (IPAddress IPA in
                    Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != string.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }

    public static bool SaveBusiness(string Companyname, string SuiteNumber, string description,
                                     string hours)
    {

        bool recordSaved;

        OleDbTransaction myTransaction = null;
        try
        {

            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;;" +
                 "Data Source= (C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
            myTransaction = conn.BeginTransaction();
            command.Transaction = myTransaction;
            strSQL = "Insert into listings " +
                     "(suite, businessname, description, hours) values ('" +
                     SuiteNumber + "', '" + Companyname + "', " + description + ", '" + hours + "')";
            
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            command.ExecuteNonQuery();

            strSQL = "Update listings " +

                     "Set suite=" + suite + ", " +

                     "businessname='" + businessname + "', " +

                     "description='" + description + "', " +
                     
                     "hours='" + hours + "' " +

                     "Where ID=(Select Max(ID) From listings)";

            command.CommandType = CommandType.Text;

            command.CommandText = strSQL;

            command.ExecuteNonQuery();
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            recordSaved = false;

        }

        return recordSaved;
    }

    public static dsbusinesses GetBusinesses(string Database, string strSearch) 
    {
        dsbusinesses DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;

        OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=(C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");

        if (strSearch == null || strSearch.Trim() == "")
        {
            sqlDA = new OleDbDataAdapter("select * from listings", sqlConn);
        }
        else 
        {
            sqlDA = new OleDbDataAdapter("select * from listings where businessname = '" + strSearch + ",", sqlConn);
        }
        DS = new dsbusinesses();

        sqlDA.Fill(DS.listings);

        return DS;
    }

    public static dsUser VerifyUser(string Database, string UserName, string UserPassword)
    {
        dsUser DS;
        OleDbConnection sqlConn;
        OleDbDataAdapter sqlDA;


        sqlConn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=(C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");

        
        sqlDA = new OleDbDataAdapter("select * SecurityLevel from admin " +
                                      "where username like '" + username + "' " +
                                      "and password like '" + password + "'", sqlConn);

        
        DS = new dsUser();

        
        sqlDA.Fill(DS.admin);

        
        return DS;

    } 

    public static bool deleteBusiness(string Companyname, string SuiteNumber, string description, string hours)                                
    {
        bool recordremoved;

        OleDbTransaction Transaction = null;
        try
        {

            OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
               "Data Source= (C:\\xxampp\\htdocs\\beuwebsite\\BEUapplication\\BEUapplication\\BEUapplication\\App_Data\\BEUbusinessBB1.mdb");
            conn.Open();
            OleDbCommand command = conn.CreateCommand();
            string strSQL;
            Transaction = conn.BeginTransaction();
            command.Transaction = Transaction;
            strSQL = "Delete from listings " +
                     "(suite, businessname, description, hours) values ('" +
                     SuiteNumber + "', '" + Companyname + "', " + description + ", '" + hours + "')";
            
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;
            command.ExecuteNonQuery();

            strSQL = "Update listings " +

                     "Set suite=" + suite + ", " +

                     "businessname='" + businessname + "', " +

                     "description='" + description + "', " +
                     
                     "hours='" + hours + "' " +

                     "Where ID=(Select Max(ID) From listings)";

            command.CommandType = CommandType.Text;

            command.CommandText = strSQL;

            command.ExecuteNonQuery();
            conn.Close();
            recordSaved = true;
        }
        catch (Exception ex)
        {
            recordremoved = false;

        }

        return recordremoved;
     }
}