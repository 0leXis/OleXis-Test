using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestirSystem
{
    class DBProcessor
    {
        string ConnectionString;
        SqlConnection Connection;

        public DBProcessor(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public bool OpenConnection(ref string Errormsg)
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            }
            catch(Exception e)
            {
                Errormsg = e.Message;
                return false;
            }
            return true;
        }

        public void CloseConnection()
        {
            if(Connection != null)
                Connection.Close();
        }

        public bool InsertItem(string FIO, string Group, int Ocenka, ref string Errormsg)
        {
            try
            {
                var command = new SqlCommand("INSERT dbo.Test VALUES ('"+ FIO + "', '" + Group + "', " + Ocenka+")", Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Errormsg = e.Message;
                return false;
            }
            return true;
        }

        public bool CreateTestTable(ref string Errormsg)
        {
            try
            {
                var command = new SqlCommand("SELECT * FROM Test", Connection);
                command.ExecuteNonQuery();
            }
            catch
            {
                try
                {
                    var command = new SqlCommand("CREATE TABLE [dbo].[Test] ([Id] INT IDENTITY PRIMARY KEY, [FIO] VARCHAR(MAX) NOT NULL, [Group] VARCHAR(MAX) NOT NULL, [Ocenka] INT NOT NULL)", Connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Errormsg = e.Message;
                    return false;
                }
            }
            return true;
        }

        public bool GetTestTable(out DataSet ds, ref string Errormsg)
        {
            try
            {
                string sql = "SELECT * FROM Test";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);

                ds = new DataSet();
                adapter.Fill(ds);
            }
            catch (Exception e)
            {
                Errormsg = e.Message;
                ds = null;
                return false;
            }
            return true;
        }
    }
}
