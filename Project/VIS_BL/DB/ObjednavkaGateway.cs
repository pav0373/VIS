using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VIS_BL.DB
{
    public class ObjednavkaGateway
    {
        public static String TABLE_NAME = "Objednavka";
        public static String SQL_SELECT = "SELECT * FROM Objednavka";
        public static String SQL_SELECT_ID = "SELECT * FROM Objednavka WHERE Zakaznik_IDu=@IDu";
        public static String SQL_INSERT = "INSERT INTO Objednavka VALUES (@IDu,@datum)";
        public static String SQL_DELETE_ID = "DELETE FROM Objednavka WHERE IDo=@IDo";

        private static void PrepareCommand(SqlCommand command, List<object> objednavka)
        {
            command.Parameters.AddWithValue("@IDo", objednavka[0]);
            command.Parameters.AddWithValue("@IDu", objednavka[1]);
            command.Parameters.AddWithValue("@datum", objednavka[2]);


        }


        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> seznamobjednavek = new Collection<List<object>>();

            while (reader.Read())
            {
                int i = -1;
                List<object> objednavka = new List<object>();
                objednavka.Add(reader.GetInt32(++i)); //IDo
                objednavka.Add(reader.GetDateTime(++i)); //Datum
                objednavka.Add(reader.GetInt32(++i)); //ZakaznikID





                seznamobjednavek.Add(objednavka);
            }
            return seznamobjednavek;
        }

        //Vlozeni zaznamu
        public static int Insert(List<object> objednavka, Database pDb = null)
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
            PrepareCommand(command, objednavka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //vyber vsech objednavek uzivatele
        public static Collection<List<object>> Select(int idu, Database pDb = null)
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
            command.Parameters.AddWithValue("@IDu", idu);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamobjednavek = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamobjednavek;
        }

        //vyber vsech objednavek
        public static Collection<List<object>> SelectAll(Database pDb = null)
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

            Collection<List<object>> seznamobjednavek = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamobjednavek;
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

            command.Parameters.AddWithValue("@IDo", id);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


    }
}
