using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VIS_BL.DB
{
    class ObsahGateway
    {
        public static String TABLE_NAME = "ObsahObjednavky";
        public static String SQL_INSERT = "INSERT INTO ObsahObjednavky VALUES (@IDz, @IDo,@pocet)";
        public static String SQL_SELECT_ID = "SELECT * FROM ObsahObjednavky WHERE Objednavka_IDo=@IDo";
        public static String SQL_DELETE_ID = "DELETE FROM ObsahObjednavky WHERE Objednavka_IDo=@IDo";

        private static void PrepareCommand(SqlCommand command, List<object> obsah)
        {
            command.Parameters.AddWithValue("@IDz", obsah[0]);
            command.Parameters.AddWithValue("@IDo", obsah[1]);
            command.Parameters.AddWithValue("@pocet", obsah[2]);


        }


        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> seznamobsah = new Collection<List<object>>();

            while (reader.Read())
            {
                int i = -1;
                List<object> obsah = new List<object>();

                obsah.Add(reader.GetInt32(++i)); //ZakaznikID
                obsah.Add(reader.GetInt32(++i)); //ObjednavkaID
                obsah.Add(reader.GetInt32(++i)); //Pocet



                seznamobsah.Add(obsah);
            }
            return seznamobsah;
        }

        //Vlozeni zaznamu
        public static int Insert(List<object> obsah, Database pDb = null)
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
            PrepareCommand(command, obsah);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Collection<List<object>> Select(int id, Database pDb = null)
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
            command.Parameters.AddWithValue("@IDo", id);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamobsah = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamobsah;
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
