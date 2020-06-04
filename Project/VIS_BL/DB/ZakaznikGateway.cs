using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VIS_BL.DB
{
    public class ZakaznikGateway
    {
        public static String TABLE_NAME = "Zakaznik";

        public static String SQL_SELECT = "SELECT * FROM Zakaznik";
        public static String SQL_SELECT_ID = "SELECT * FROM Zakaznik WHERE IDu=@IDu";
        public static String SQL_INSERT = "INSERT INTO Zakaznik VALUES (@login, @email, @heslo, @krestni, " +
            "@prijmeni, @ulice, @mesto, @psc, @tel)";
        public static String SQL_UPDATE = "UPDATE Zakaznik SET krestni=@krestni, prijmeni=@prijmeni,ulice=@ulice,mesto=@mesto,psc=@psc,tel=@tel WHERE IDu=@IDu";
        public static String SQL_DELETE_ID = "DELETE FROM Zakaznik WHERE IDu=@IDu";


        private static void PrepareCommand(SqlCommand command, List<object> zakaznik)
        {
            command.Parameters.AddWithValue("@IDu", zakaznik[0]);
            command.Parameters.AddWithValue("@login", zakaznik[1]);
            command.Parameters.AddWithValue("@email", zakaznik[2]);
            command.Parameters.AddWithValue("@heslo", zakaznik[3]);
            command.Parameters.AddWithValue("@krestni", zakaznik[4]);
            command.Parameters.AddWithValue("@prijmeni", zakaznik[5]);
            command.Parameters.AddWithValue("@ulice", zakaznik[6]);
            command.Parameters.AddWithValue("@mesto", zakaznik[7]);
            command.Parameters.AddWithValue("@psc", zakaznik[8]);
            command.Parameters.AddWithValue("@tel", zakaznik[9]);
        }

        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> zakaznici = new Collection<List<object>>();

            while (reader.Read())
            {

                List<object> zakaznik = new List<object>();
                int i = -1;

                zakaznik.Add(reader.GetInt32(++i));  //Idu
                zakaznik.Add(reader.GetString(++i)); //Login
                zakaznik.Add(reader.GetString(++i)); //Email
                zakaznik.Add(reader.GetString(++i)); //Heslo
                zakaznik.Add(reader.GetString(++i)); //Krestni
                zakaznik.Add(reader.GetString(++i)); //Prijmeni
                zakaznik.Add(reader.GetString(++i)); //Ulice
                zakaznik.Add(reader.GetString(++i)); //Mesto
                zakaznik.Add(reader.GetString(++i)); //PSC
                zakaznik.Add(reader.GetString(++i)); //Tel

                zakaznici.Add(zakaznik);
            }
            return zakaznici;
        }



        //Vlozeni zaznamu
        public static int Insert(List<object> zakaznik, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //Update zaznamu
        public static int Update(List<object> zakaznik, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //Seznam zakazniku
        public static Collection<List<object>> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> zakaznici = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznici;
        }

        //Detail uzivatele
        public static List<object> Select(int id, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@IDu", id);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> zakaznici = Read(reader);
            List<object> zakaznik = null;
            if (zakaznici.Count == 1)
            {
                zakaznik = zakaznici[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznik;
        }

        public static int Delete(int id, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IDu", id);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


    }
}
