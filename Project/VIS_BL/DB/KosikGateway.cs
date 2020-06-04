using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VIS_BL.DB
{
    public class KosikGateway
    {
        public static String TABLE_NAME = "Kosik";

        public static String SQL_SELECT_IDu = "SELECT * FROM Kosik WHERE Zakaznik_IDu=@IDu";
        public static String SQL_DELETE_IDu = "DELETE FROM Kosik WHERE Zakaznik_IDu=@IDu";



        private static void PrepareCommand(SqlCommand command, List<object> kosik)
        {
            command.Parameters.AddWithValue("@IDu", kosik[0]);
            command.Parameters.AddWithValue("@IDz", kosik[1]);
            command.Parameters.AddWithValue("@pocet", kosik[2]);


        }


        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> seznamkosik = new Collection<List<object>>();

            while (reader.Read())
            {
                int i = -1;
                List<object> kosik = new List<object>();


                kosik.Add(reader.GetInt32(++i)); //ZakaznikID
                kosik.Add(reader.GetInt32(++i)); //ZboziID
                kosik.Add(reader.GetInt32(++i)); //Pocet

                seznamkosik.Add(kosik);
            }
            return seznamkosik;
        }

        //vyber vseho zbozi v kosiku uzivatele
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_IDu);
            command.Parameters.AddWithValue("@IDu", idu);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamkosik = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamkosik;
        }

        //Smazani vseho zbozi v kosiku uzivatele
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_IDu);

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
