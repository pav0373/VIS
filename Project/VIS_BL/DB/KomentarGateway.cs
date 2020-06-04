using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VIS_BL.DB
{
    class KomentarGateway
    {
        public static String TABLE_NAME = "Komentar";

        public static String SQL_SELECT_ID = "SELECT * FROM Komentar WHERE Idc=@IDc";
        public static String SQL_SELECT_IDz = "SELECT * FROM Komentar WHERE Zbozi_IDz=@IDz";
        public static String SQL_INSERT = "INSERT INTO Komentar VALUES (@predmet, @text,@IDu,@IDz)";
        public static String SQL_DELETE_ID = "DELETE FROM Komentar WHERE IDc=@IDc";

        private static void PrepareCommand(SqlCommand command, List<object> komentar)
        {
            command.Parameters.AddWithValue("@IDc", komentar[0]);
            command.Parameters.AddWithValue("@predmet", komentar[1]);
            command.Parameters.AddWithValue("@text", komentar[2]);
            command.Parameters.AddWithValue("@IDu", komentar[3]);
            command.Parameters.AddWithValue("@IDz", komentar[4]);


        }

        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> seznamkoment = new Collection<List<object>>();

            while (reader.Read())
            {
                int i = -1;
                List<object> komentar = new List<object>();

                komentar.Add(reader.GetInt32(++i)); //IDc
                komentar.Add(reader.GetString(++i)); //Predmet
                komentar.Add(reader.GetString(++i)); //Text
                komentar.Add(reader.GetInt32(++i)); //ZakaznikID
                komentar.Add(reader.GetInt32(++i)); //ZboziID


                seznamkoment.Add(komentar);
            }
            return seznamkoment;
        }

        //Vlozeni zaznamu
        public static int Insert(List<object> komentar, Database pDb = null)
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
            PrepareCommand(command, komentar);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //vyber urciteho komentare
        public static List<object> SelectID(int idc, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_IDz);
            command.Parameters.AddWithValue("@IDz", idc);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamkoment = Read(reader);
            List<object> komentar = null;
            if (seznamkoment.Count == 1)
            {
                komentar = seznamkoment[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return komentar;
        }




        //vyber vsech komentaru urciteho zbozi
        public static Collection<List<object>> Select(int idz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_IDz);
            command.Parameters.AddWithValue("@IDz", idz);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamkoment = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamkoment;
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

            command.Parameters.AddWithValue("@IDc", id);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

    }
}
