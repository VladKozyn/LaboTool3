using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LaboTool_3
{
    class Databeheer
    {
        private string connectionString;
        public Databeheer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = Labo; Integrated Security = True");
            return connection;
        }

        public List<string> vraagStraatNaamGebasseerdOpGemeente(string gemeenteNaam)
        {
            SqlConnection connection = GetConnection();
            List<string> lstStraten = new List<string>();

            string queryString = "SELECT straatNaam " +
                                 "FROM Straat s " +
                                 "JOIN dbo.Gemeente g ON s.gemeenteId = g.gemeenteId " +
                                 "WHERE gemeenteNaam = @gemeenteNaam "+
                                 "ORDER BY s.straatNaam ASC";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@gemeenteNaam";
                paramId.DbType = System.Data.DbType.String;
                paramId.Value = gemeenteNaam;

                command.Parameters.Add(paramId);
                connection.Open();

                try
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string id = (string)dataReader["straatNaam"];
                        lstStraten.Add(id);

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                        return null;
                }
                finally
                {
                    connection.Close();
                }
                
            }
            return lstStraten;
        }
        public List<int> vraagStraatIdsGebasseerdOpGemeente(string gemeenteNaam)
        {
            SqlConnection connection = GetConnection();
            List<int> lstStratenIds = new List<int>();

            string queryString = "SELECT s.straatId " +
            "FROM Straat s " +
            "JOIN dbo.Gemeente g ON s.gemeenteId = g.gemeenteId " +
            "WHERE g.gemeenteNaam = @gemeenteNaam " +
            "ORDER BY s.straatId ASC";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@gemeenteNaam";
                paramId.DbType = System.Data.DbType.String;
                paramId.Value = gemeenteNaam;

                command.Parameters.Add(paramId);
                connection.Open();

                try
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["straatId"];
                        lstStratenIds.Add(id);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
            return lstStratenIds;
        }
        public List<int> overZicht(string gemeenteNaam)
        {
            SqlConnection connection = GetConnection();
            List<int> lstStratenIds = new List<int>();

            string queryString = "SELECT s.straatId " +
            "FROM Straat s " +
            "JOIN dbo.Gemeente g ON s.gemeenteId = g.gemeenteId " +
            "WHERE g.gemeenteNaam = @gemeenteNaam " +
            "ORDER BY s.straatId ASC";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@gemeenteNaam";
                paramId.DbType = System.Data.DbType.String;
                paramId.Value = gemeenteNaam;

                command.Parameters.Add(paramId);
                connection.Open();

                try
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int id = (int)dataReader["straatId"];
                        lstStratenIds.Add(id);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }
            return lstStratenIds;
        }
    }
}
