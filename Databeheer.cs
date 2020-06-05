using LaboTool_3.Model;
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
                                 "WHERE gemeenteNaam = @gemeenteNaam " +
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
   /*     public List<Gemeente> overZichtProvincie(string provincieNaam)
        {
            SqlConnection connection = GetConnection();
            List<Gemeente> lstGemeente = new List<Gemeente>();

             string queryString = "SELECT g.gemeenteNaam,g.totaalAantalStraten,s.straatNaam,s.lengteStraat " +
                "FROM provincie p " +
                "JOIN dbo.Gemeente g ON p.provincieId = g.provincieId " +
                "JOIN dbo.Straat s ON g.gemeenteId = s.gemeenteId " +
                "WHERE p.provincieNaam = @provincieNaam " +
                "ORDER BY g.gemeenteNaam ASC, s.lengteStraat ASC ";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@provincieNaam";
                paramId.DbType = System.Data.DbType.String;
                paramId.Value = provincieNaam;

                command.Parameters.Add(paramId);
                connection.Open();

                try
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                      //  g.gemeenteNaam,g.totaalAantalStraten,s.straatNaam,s.lengteStraat

                        string gemeenteNaam = (string)dataReader["g.gemeenteNaam"];
                        int totaalAantalStraten = (int)dataReader["g.totaalAantalStraten"];
                        string straatNaam = (string)dataReader["s.straatNaam"];
                        int lengteStraat = (int)dataReader["s.lengteStraat"];
                        for (int i = 0; i < lstGemeente.Count; i++)
                        {
                            if (!lstGemeente.Contains(g => g.gemeenteNaam == gemeenteNaam))
                            {
                                lstGemeente.Add(new Gemeente(gemeenteNaam, totaalAantalStraten));
                                lstGemeente[i].voegStraatToe(new Straat(straatNaam, lengteStraat));
                            }
                            else
                            {
                                lstGemeente[i].voegStraatToe(new Straat(straatNaam, lengteStraat));
                            }
                        }
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
            return lstGemeente;
        }
        */
        public string vraagStraatOpBasisVanStraatId(int straatId)
            {
                SqlConnection connection = GetConnection();
                string opgebouwdString = "";

            string queryString = "SELECT s.straatId,s.straatNaam,g.gemeenteNaam,p.provincieNaam,gr.graafId " +
          "FROM Straat s " +
           "JOIN dbo.Gemeente g ON s.gemeenteId = g.gemeenteId " +
          "JOIN dbo.Provincie p ON g.provincieId = p.provincieId " +
           "JOIN dbo.Graaf gr ON s.straatId = gr.graafId " +
           "WHERE s.straatId = @straatId";
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = queryString;
                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@straatId";
                    paramId.DbType = System.Data.DbType.Int32;
                    paramId.Value = straatId;

                    command.Parameters.Add(paramId);
                    connection.Open();


                    try
                    {
                        SqlDataReader dataReader = command.ExecuteReader();
                        while (dataReader.Read())
                        {
                       
                        int straatId2 = (int)dataReader["s.straatId"];
                        string straatNaam = (string)dataReader["s.straatNaam"];
                        string gemeenteNaam = (string)dataReader["g.gemeenteNaam"];
                        string provincieNaam = (string)dataReader["p.provincieNaam"];
                        int graafId = (int)dataReader["gr.graafId"];

                        opgebouwdString = $"{straatId2};{straatNaam};{gemeenteNaam}+{provincieNaam}\n" +"Graaf: "+graafId;
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
                return opgebouwdString;
            }
        public string vraagStraatOpBasisVanStraatNaamEnGemeenteNaam(string gemeenteNaam,string straatNaam)
        {
            SqlConnection connection = GetConnection();
            string opgebouwdString = "";

            string queryString = "SELECT s.straatId,s.straatNaam,g.gemeenteNaam,p.provincieNaam,gr.graafId " +
          "FROM Gemeente g " +
           "JOIN dbo.Straat s ON s.gemeenteId = g.gemeenteId " +
          "JOIN dbo.Provincie p ON g.provincieId = p.provincieId " +
           "JOIN dbo.Graaf gr ON s.straatId = gr.graafId " +
           "WHERE s.straatNaam = @straatNaam AND g.gemeenteNaam = @gemeenteNaam";
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = queryString;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@straatNaam";
                paramId.DbType = System.Data.DbType.String;
                paramId.Value = straatNaam;

                SqlParameter paramId2 = new SqlParameter();
                paramId2.ParameterName = "@gemeenteNaam";
                paramId2.DbType = System.Data.DbType.String;
                paramId2.Value = gemeenteNaam;

                command.Parameters.Add(paramId);
                command.Parameters.Add(paramId2);
                connection.Open();


                try
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {

                        string straatId2 = (string)dataReader["s.straatId"];
                        string straatNaam2 = (string)dataReader["s.straatNaam"];
                        string gemeenteNaam2 = (string)dataReader["g.gemeenteNaam"];
                        string provincieNaam = (string)dataReader["p.provincieNaam"];
                        string graafId = (string)dataReader["gr.graafId"];

                        opgebouwdString = $"{straatId2};{straatNaam2};{gemeenteNaam2}+{provincieNaam}\n" + "Graaf: " + graafId;
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
            return opgebouwdString;
        }
    }
}
