using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace VIS_BL.DB
{
    public class KategorieGateway
    {


        private static String filename = "..\\..\\..\\kategorie.xml";

        //vyber vsech kategorii
        public static Collection<List<object>> Select()
        {

            Collection<List<object>> seznamkat = new Collection<List<object>>();

            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
            {
                List<object> kategorie = new List<object>();
                kategorie.Add(xmlNode.Attributes["id"].Value);
                kategorie.Add(xmlNode.ChildNodes[0].InnerText);
                kategorie.Add(xmlNode.ChildNodes[1].InnerText);
                seznamkat.Add(kategorie);

            }
               


            return seznamkat;
        }



        public static List<object> Select(int id)
        {
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            List<object> kategorie = new List<object>();
            foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes)
            {

                if (id == Int32.Parse(xmlNode.Attributes["id"].Value))
                {
                kategorie.Add(id);
                kategorie.Add(xmlNode.ChildNodes[0].InnerText);
                kategorie.Add(xmlNode.ChildNodes[1].InnerText);
                }

            }



            return kategorie;
        }



    }

}


