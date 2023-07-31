using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace ElementsAndMaterials.CodeBlocks
{
    class SQLhandler_EF
    {
        public static void makeRequestShowElementsFromElements_EF(string material, TextBox textBox, int identifiatorElement)
        {
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on ge.Name equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Typ == identifiatorElement
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };


                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";


                foreach (var element in elementsWichInElementsButNoInGoods)
                {
                    textBox.Text += $"{element.GEName}                                                   {element.GOODName}   {Environment.NewLine}";
                }           
            }
        }

        public static void makeRequestShowOneElementFromElementsByName_EF(string material, TextBox textBox, string identifiatorElement)
        {
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on ge.Name equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Name == identifiatorElement
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };


                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";


                foreach (var element in elementsWichInElementsButNoInGoods)
                {
                    textBox.Text += $"{element.GEID}         {element.GEMarking}         {element.GEName}        {Environment.NewLine}";
                }

            }
        }


        public static void makeRequestShowOneElementFromElementsByID_EF(string material, TextBox textBox, int identifiatorElement)
        {
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on ge.Name equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Idglasselement == identifiatorElement
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };


                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";


                foreach (var element in elementsWichInElementsButNoInGoods)
                {
                    textBox.Text += $"{element.GEID}         {element.GEMarking}         {element.GEName}        {Environment.NewLine}";
                }

            }
        }


        public static void makeRequestShowElementsFromGoods_EF( string material, TextBox textBox, string prefixMarking, string postfixMarking, string nameElement, int typeOfElament, string postfixName)
        {
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                //IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                //                                                         join gd in dbwdtempContext.Good
                //                                                         on ge.Marking equals (prefixMarking + gd.Marking + postfixMarking ) into elementsInElementsButNoInGoods
                //                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                //                                                         where subTable.Name == null
                //                                                         where ge.Typ == typeOfElament
                //                                                         where ge.Deleted == null
                //                                                         select new
                //                                                         {
                //                                                             GEType = ge.Typ,
                //                                                             GEName = ge.Name,
                //                                                             GEMarking = ge.Marking,
                //                                                             GEID = ge.Idglasselement,
                //                                                             GOODName = subTable.Name,
                //                                                             GOODMarking = subTable.Marking
                //                                                         };

                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on (ge.Name + postfixName) equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Typ == typeOfElament
                                                                         where ge.Deleted == null
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };

                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                textBox.Text += $"id             marking                 name {Environment.NewLine} {Environment.NewLine}";

                foreach (var element in elementsWichInElementsButNoInGoods)
                {
                    textBox.Text += $"{element.GEID}         {element.GEMarking}         {element.GEName}        {Environment.NewLine}";
                }
            }
        }

        public static void makeRequesInsertElements_EF(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string sqlFile, string identificatorElement)
        {
            List<string> idList = new List<string>();
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on ge.Name equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Typ == Int32.Parse(typeElement)
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };

                if (elementsWichInElementsButNoInGoods.Any())
                {
                    foreach (var element in elementsWichInElementsButNoInGoods)
                    {
                        idList.Add(element.GEID.ToString());
                    }
                }
                else
                {
                    textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
                    con.Close();
                    return;
                }

                foreach (var id in idList)
                {
                    textBox.Text += generateID(com, con, textBox);
                    textBox.Text += Environment.NewLine;
                    textBox.Text += goodGroup;
                    textBox.Text += Environment.NewLine;
                    //textBox.Text += elementsWichInElementsButNoInGoods.Where(x => x.GEType == id).Select(x => x.GEType).FirstOrDefault(); // .Where(u => u.GEType == int.Parse(id)).Select(u => u.GEName).SingleOrDefault();

                    foreach (var element in elementsWichInElementsButNoInGoods)
                    {
                        if (element.GEID.ToString() == id)
                        {
                            textBox.Text += element.GEType;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GEName;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += (prefix + element.GEMarking);
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GEID;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GOODName;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GOODMarking;
                            textBox.Text += Environment.NewLine;
                        }
                    }

                    textBox.Text += Environment.NewLine;

                    //dbwdtempContext_.Good.Add(new Good()
                    //{
                    //    Idgood = generateID(com, con, textBox),
                    //    Idgoodgroup = Int32.Parse(goodGroup),
                    //    Name = elementsWichInElementsButNoInGoods_.FirstOrDefault(),
                    //    Marking =
                    //});
                    //dbwdtempContext_.SaveChanges();

                }
            }
        }

        private static int generateID(SqlCommand com, SqlConnection con, TextBox textBox)
        {
            com.CommandText = File.ReadAllText(FilePathFinder.GetPathToFile("\\SQLRequests\\generate_id_stored_procedure.sql"));

            try
            {
                con.Open();
                int result = Int32.Parse(com.ExecuteScalar().ToString());
                con.Close();
                return result;
            }
            catch
            {
                textBox.Text += "stored procedure generate id problem";
                return 0;
            }
        }        

        public static void makeRequestShowOneElementFromGoods_EF(string material, TextBox textBox, string nameElement, string typeSearch)
        {
            textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
            textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";

            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                switch (typeSearch)
                {
                    case "Name":
                        {
                            IQueryable<dynamic> elementsWichInElementsButNoInGoods = from g in dbwdtempContext.Good
                                                                                     where g.Name.Contains(nameElement)
                                                                                     select new
                                                                                     {
                                                                                         GID = g.Idgood,
                                                                                         GMarking = g.Marking,
                                                                                         GName = g.Name
                                                                                     };

                            if (elementsWichInElementsButNoInGoods.Any())
                            {
                                foreach (var element in elementsWichInElementsButNoInGoods)
                                {
                                    textBox.Text += $"{element.GID}                       {element.GMarking}                            {element.GName}   {Environment.NewLine}";
                                }
                            }
                            else
                            {
                                textBox.Text += "Не найдено";
                            }
                        }
                        break;
                    case "ID":
                        {
                            IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                                     where ge.Idglasselement.ToString() == nameElement
                                                                                     select new
                                                                                     {
                                                                                         GEID = ge.Idglasselement,
                                                                                         GEMarking = ge.Marking,
                                                                                         GEName = ge.Name
                                                                                     };

                            if (elementsWichInElementsButNoInGoods.Any())
                            {
                                foreach (var element in elementsWichInElementsButNoInGoods)
                                {
                                    textBox.Text += $"{element.GEID}                {element.GEMarking}             {element.GEName}   {Environment.NewLine}";
                                }
                            }
                            else
                            {
                                textBox.Text += "Не найдено";
                            }
                        }
                        break;
                    default:
                        textBox.Text = " НЕ ВЫБРАН ТИП ПОИСКА ";
                        break;                       
                }
            }
        }


        //----------------------------------------
    

        public static void makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods_EF(SqlCommand com,
                                                                                          SqlConnection con,
                                                                                          string typeElement,
                                                                                          string sqlFile,
                                                                                          string goodGroup,
                                                                                          string prefixMarking,
                                                                                          string postfixMarking,
                                                                                          string postfixName,
                                                                                          TextBox textBox,
                                                                                          string identificatorElement,
                                                                                          int typeOfElement,
                                                                                          string material)
        {
            List<string> idList = new List<string>();
            using (var dbwdtempContext = new DB_wd_temp_Context())
            {
                IQueryable<dynamic> elementsWichInElementsButNoInGoods = from ge in dbwdtempContext.Glasselement
                                                                         join gd in dbwdtempContext.Good
                                                                         on (ge.Name + postfixName) equals gd.Name into elementsInElementsButNoInGoods
                                                                         from subTable in elementsInElementsButNoInGoods.DefaultIfEmpty() // <- LEFT JOIN
                                                                         where subTable.Name == null
                                                                         where ge.Typ == typeOfElement
                                                                         where ge.Deleted == null
                                                                         select new
                                                                         {
                                                                             GEType = ge.Typ,
                                                                             GEName = ge.Name,
                                                                             GEMarking = ge.Marking,
                                                                             GEID = ge.Idglasselement,
                                                                             GOODName = subTable.Name,
                                                                             GOODMarking = subTable.Marking
                                                                         };

                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                textBox.Text += $"id             marking                 name {Environment.NewLine} {Environment.NewLine}";

                foreach (var element in elementsWichInElementsButNoInGoods)
                {
                    textBox.Text += $"{element.GEID}         {element.GEMarking}         {element.GEName}        {Environment.NewLine}";
                }

                if (elementsWichInElementsButNoInGoods.Any())
                {
                    foreach (var element in elementsWichInElementsButNoInGoods)
                    {
                        idList.Add(element.GEID.ToString());
                    }
                }
                else
                {
                    textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
                    con.Close();
                    return;
                }

                foreach (var id in idList)
                {
                    textBox.Text += generateID(com, con, textBox);
                    textBox.Text += Environment.NewLine;
                    textBox.Text += goodGroup;
                    textBox.Text += Environment.NewLine;
                    //textBox.Text += elementsWichInElementsButNoInGoods.Where(x => x.GEType == id).Select(x => x.GEType).FirstOrDefault(); // .Where(u => u.GEType == int.Parse(id)).Select(u => u.GEName).SingleOrDefault();

                    foreach (var element in elementsWichInElementsButNoInGoods)
                    {
                        if (element.GEID.ToString() == id)
                        {
                            textBox.Text += element.GEType;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GEName;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += (prefixMarking + element.GEMarking + postfixMarking);
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GEID;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GOODName;
                            textBox.Text += Environment.NewLine;
                            textBox.Text += element.GOODMarking;
                            textBox.Text += Environment.NewLine;
                        }
                    }

                    textBox.Text += Environment.NewLine;

                    //dbwdtempContext_.Good.Add(new Good()
                    //{
                    //    Idgood = generateID(com, con, textBox),
                    //    Idgoodgroup = Int32.Parse(goodGroup),
                    //    Name = elementsWichInElementsButNoInGoods_.FirstOrDefault(),
                    //    Marking =
                    //});
                    //dbwdtempContext_.SaveChanges();

                }


            }

            textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        }
    }
}
