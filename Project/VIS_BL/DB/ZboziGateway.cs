using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace VIS_BL.DB
{
    class ZboziGateway
    {

        public static String TABLE_NAME = "Zbozi";

        public static String SQL_SELECT_IDkat = "SELECT * FROM Zbozi WHERE Kategorie_IDk=@IDk AND Sklad > 0";
        public static String SQL_SELECT_ID = "SELECT * FROM Zbozi WHERE IDz=@IDz";
        public static String SQL_INSERT = "INSERT INTO Zbozi VALUES (@nazev, @kratky, @dlouhy, @sklad, @cena, @IDk)";
        public static String SQL_UPDATE = "UPDATE Zbozi SET nazev=@nazev, kratky_popis=@kratky, dlouhy_popis=@dlouhy, sklad=@sklad, cena=@cena, Kategorie_IDk=@IDk  WHERE IDz=@IDz";
        public static String SQL_DELETE_ID = "DELETE FROM Zbozi WHERE IDz=@IDz";


        private static void PrepareCommand(SqlCommand command, List<object> zbozi)
        {
            command.Parameters.AddWithValue("@IDz", zbozi[0]);
            command.Parameters.AddWithValue("@nazev", zbozi[1]);
            command.Parameters.AddWithValue("@kratky", zbozi[2]);
            command.Parameters.AddWithValue("@dlouhy", zbozi[3]);
            command.Parameters.AddWithValue("@sklad", zbozi[4]);
            command.Parameters.AddWithValue("@cena", zbozi[5]);
            command.Parameters.AddWithValue("@IDk", zbozi[6]);

        }

        private static Collection<List<object>> Read(SqlDataReader reader)
        {
            Collection<List<object>> seznamzb = new Collection<List<object>>();

            while (reader.Read())
            {
                List<object> zbozi = new List<object>();
                int i = -1;
                zbozi.Add(reader.GetInt32(++i));  //Idz
                zbozi.Add(reader.GetString(++i)); //Nazev
                zbozi.Add(reader.GetString(++i)); //Kratky_popis
                zbozi.Add(reader.GetString(++i)); //Dlouhy_popis
                zbozi.Add(reader.GetInt32(++i)); //Sklad
                zbozi.Add(reader.GetInt32(++i)); //Cena
                zbozi.Add(reader.GetInt32(++i)); //Kategorie


                seznamzb.Add(zbozi);
            }
            return seznamzb;
        }

        //Vlozeni zaznamu
        public static int Insert(List<object> zbozi, Database pDb = null)
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
            PrepareCommand(command, zbozi);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //Update zaznamu
        public static int Update(List<object> zbozi, Database pDb = null)
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
            PrepareCommand(command, zbozi);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        //Vybere vsechno dostupne zbozi v kategorii
        public static Collection<List<object>> Select(int idk, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_IDkat);
            command.Parameters.AddWithValue("@IDk", idk);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamzb = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return seznamzb;
        }

        //Detail zbozi
        public static List<object> SelectID(int id, Database pDb = null)
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

            command.Parameters.AddWithValue("@IDz", id);
            SqlDataReader reader = db.Select(command);

            Collection<List<object>> seznamzb = Read(reader);
            List<object> zbozi = null;
            if (seznamzb.Count == 1)
            {
                zbozi = seznamzb[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zbozi;
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

            command.Parameters.AddWithValue("@IDz", id);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


    }
}
