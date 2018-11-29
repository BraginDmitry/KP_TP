using Agentstvo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class StrSluDAO : DAO
    {
        public List<StrSl> GetAllStrSl()
        {
            Connect();
            List<StrSl> recordList = new List<StrSl>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM StrSl", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StrSl record = new StrSl();
                    record.Id = Convert.ToInt32(reader["Id"]);
                    record.IDKl = Convert.ToInt32(reader["IDKl"]);
                    record.IDDogv = Convert.ToInt32(reader["IDDogv"]);
                    record.Date = Convert.ToString(reader["Date"]);
                    record.Described = Convert.ToString(reader["Described"]);
                    recordList.Add(record);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return recordList;
        }

        /*        public bool AddRecord(Records record)
                {
                    bool result = true;
                    Connect();
                    try
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO  Biblo (FIO, Avtor, Book, Librarian, Date) " +
                            "VALUES (@FIO, @Avtor, @Book, @Librarian, @Date)", Connection
                            );
                        cmd.Parameters.AddWithValue("@FIO", record.FIO);
                        cmd.Parameters.AddWithValue("@Avtor", record.Avtor);
                        cmd.Parameters.AddWithValue("@Book", record.Book);
                        cmd.Parameters.AddWithValue("@Librarian", record.Librarian);
                        cmd.Parameters.AddWithValue("@Date", record.Date);

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception) { result = false; }
                    finally { Disconnect(); }
                    return result;
                }
                public void EditRecord(Records record)
                {
                    try
                    {
                        Connect();
                        string str = "UPDATE Biblo SET FIO = '" + record.FIO
                            + "', Avtor = '" + record.Avtor
                            + "', Book = '" + record.Book
                            + "', Librarian = '" + record.Librarian
                            + "', Date = '" + record.Date
                            + "'WHERE Id = " + record.Id;
                        SqlCommand com = new SqlCommand(str, Connection);
                        com.ExecuteNonQuery();
                    }
                    finally
                    {
                        Disconnect();
                    }
                }
                public void DeleteRecord(int id)
                {
                    try
                    {
                        Connect();
                        string str = "DELETE FROM Biblo WHERE Id=" + id;
                        SqlCommand com = new SqlCommand(str, Connection);
                        com.ExecuteNonQuery();
                    }
                    finally
                    {
                        Disconnect();
                    }
                }
                */
    }
}