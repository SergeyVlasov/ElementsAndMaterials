using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Utils;

namespace ElementsAndMaterials.CodeBlocks
{
    class SQLhandler
    {
        public static void makeRequestShowElementsаFromElements(SqlCommand com, SqlConnection con, string typeElement, string material, TextBox textBox, string sqlFile, string identifiatorElement)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, identifiatorElement);
            com.CommandText = ComText;
            //textBox.Text = ComText;
            con.Open();
            string result;
            if (com.ExecuteScalar() != null)
            {
                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                var reader = com.ExecuteReader();
                textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";
                while (reader.Read())
                {
                    string marking = reader["marking_glasselement"].ToString();
                    string name = reader["name_glasselement"].ToString();
                    string id = reader["id_glasselement"].ToString();
                    textBox.Text += $"{id}             {marking}                 {name} {Environment.NewLine}";
                }
            }
            else
            {
                textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
                con.Close();
            }
            con.Close();
        }

        public static void makeRequestShowElementsFromGoods(SqlCommand com, SqlConnection con, string material, TextBox textBox, string sqlFile, string prefixMarking, string postfixMarking, string nameElement, string typeOfElament)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), prefixMarking, postfixMarking, nameElement, typeOfElament);
            com.CommandText = ComText;
            textBox.Text += ComText;
            con.Open();
            string result;
            if (com.ExecuteScalar() != null)
            {
                textBox.Text += $"Материал: {material}, есть такие материалы: {Environment.NewLine} {Environment.NewLine}";
                var reader = com.ExecuteReader();
                textBox.Text += $"id             marking                 name {Environment.NewLine}{Environment.NewLine}";
                while (reader.Read())
                {
                    string id = reader["id_glasselement"].ToString();
                    string marking = reader["marking_glasselement"].ToString();
                    string name = reader["name_glasselement"].ToString();
                    textBox.Text += $"{id}             {marking}                 {name} {Environment.NewLine}";
                }
            }
            else
            {
                textBox.Text += $"нет элементов в материалах {Environment.NewLine}";
                con.Close();
            }
            con.Close();
        }

        public static void makeRequesInsertElements(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string sqlFile, string identificatorElement)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, identificatorElement);
            com.CommandText = ComText;
            textBox.Text = ComText;
            con.Open();
            string result;
            List<string> idList = new List<string>();
            if (com.ExecuteScalar() != null)
            {
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    idList.Add(reader["id_glasselement"].ToString());
                }
            }
            else
            {
                textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
                con.Close();
                return;
            }
            con.Close();

            string CommandTextAll = "";
            foreach (string id in idList)
            {
                //con.Open();
                //com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_all_elements_in_materials.sql")), typeElement, goodGroup, prefix, id);
                //string xxx = com.CommandText;
                ////textBox.Text += xxx;
                //com.ExecuteScalar();
                //con.Close();
                com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_all_elements_in_materials.sql")), typeElement, goodGroup, prefix, id);
                CommandTextAll += com.CommandText;
                CommandTextAll += "\n\n";
            };

            textBox.Text += CommandTextAll;
            con.Open();
            com.CommandText = CommandTextAll;
            textBox.Text += CommandTextAll;
            com.ExecuteScalar();
            con.Close();
            textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        }

        //----------------------------------------
        public static void makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(SqlCommand com, 
                                                                                          SqlConnection con,
                                                                                          string typeElement,
                                                                                          string sqlFile,
                                                                                          string goodGroup,
                                                                                          string prefixMarking,
                                                                                          string postfixMarking,
                                                                                          string postfixName,
                                                                                          TextBox textBox,
                                                                                          string identificatorElement)
        {
            //textBox.Text = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, nameElement);
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), prefixMarking, postfixMarking, identificatorElement, typeElement);
            com.CommandText = ComText;
            textBox.Text += ComText;
            con.Open();
            Dictionary<string, string> elements = new Dictionary<string, string>();
            if (com.ExecuteScalar() != null)
            {
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    elements.Add(reader["id_glasselement"].ToString(), reader["name_glasselement"].ToString());
                    //textBox.Text += "\n";
                    //textBox.Text += reader["id_glasselement"].ToString() + "         " + reader["name_glasselement"].ToString();
                    //textBox.Text += "-----------------------------------------";
                    //textBox.Text += "\n";
                }
            }
            else
            {
                textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
                con.Close();
                return;
            }
            con.Close();

            string CommandTextAll = "";

            con.Open();
            foreach (var element in elements)
            {
                com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_all_elements_in_materials_new_handle_materials_remove_double_insert_in_goods.sql")), typeElement, goodGroup, prefixMarking, element.Key, postfixMarking, postfixName, element.Value, postfixName);
                CommandTextAll = com.CommandText;
                //CommandTextAll += "\n\n";
                //textBox.Text += CommandTextAll;
                com.ExecuteScalar();
            };

            //textBox.Text += CommandTextAll;
            //con.Open();
            //com.CommandText = CommandTextAll;
            //textBox.Text += CommandTextAll;
            //com.ExecuteScalar();
            con.Close();

            textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        }

        //public static void makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods_old(SqlCommand com,
        //                                                                                  SqlConnection con,
        //                                                                                  string typeElement,
        //                                                                                  string sqlFile,
        //                                                                                  string goodGroup,
        //                                                                                  string prefixMarking,
        //                                                                                  string postfixMarking,
        //                                                                                  string postfixName,
        //                                                                                  TextBox textBox,
        //                                                                                  string identificatorElement)
        //{
        //    //textBox.Text = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, nameElement);
        //    string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), prefixMarking, postfixMarking, identificatorElement, typeElement);
        //    com.CommandText = ComText;
        //    textBox.Text += ComText;
        //    con.Open();
        //    Dictionary<string, string> elements = new Dictionary<string, string>();
        //    if (com.ExecuteScalar() != null)
        //    {
        //        var reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            elements.Add(reader["id_glasselement"].ToString(), reader["name_glasselement"].ToString());
        //            //textBox.Text += "\n";
        //            //textBox.Text += reader["id_glasselement"].ToString() + "         " + reader["name_glasselement"].ToString();
        //            //textBox.Text += "-----------------------------------------";
        //            //textBox.Text += "\n";
        //        }
        //    }
        //    else
        //    {
        //        textBox.Text += $"нет элементов для вставки {Environment.NewLine}";
        //        con.Close();
        //        return;
        //    }
        //    con.Close();

        //    string CommandTextAll = "";

        //    con.Open();
        //    foreach (var element in elements)
        //    {
        //        com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_all_elements_in_materials_new_handle_materials_remove_double_insert_in_goods.sql")), typeElement, goodGroup, prefixMarking, element.Key, postfixMarking, postfixName, element.Value, postfixName);
        //        CommandTextAll = com.CommandText;
        //        CommandTextAll += "\n\n";
        //        textBox.Text += CommandTextAll;
        //        com.ExecuteScalar();
        //    };

        //    //textBox.Text += CommandTextAll;
        //    //con.Open();
        //    //com.CommandText = CommandTextAll;
        //    //textBox.Text += CommandTextAll;
        //    //com.ExecuteScalar();
        //    con.Close();

        //    textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        //}

        public static string makeRequestoShowNamePartToAddAsync(SqlCommand com, SqlConnection con, string typeElement, string sqlFile, TextBox textBox, string typeOfname)
        {
            string ComText;
            int idPrefixMarking;
            string addPartName = "";
            switch (typeElement)
            {
                case "Закалка":
                    idPrefixMarking = 637;
                    break;
                case "Полировка":
                    idPrefixMarking = 638; 
                    break;
                case "Шлифовка":
                    idPrefixMarking = 639; 
                    break;
                default:
                    idPrefixMarking = 0;
                    break;
            }
            ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), idPrefixMarking);


            com.CommandText = ComText;
            //textBox.Text += ComText;
            con.Open();
            if (com.ExecuteScalar() != null)
            {
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    addPartName = reader[typeOfname].ToString();
                    textBox.Text += addPartName;
                    //textBox.Text += "-----------------------------------------";
                    textBox.Text += "_";
                }
            }
            else
            {
                textBox.Text += $"в базе нет приставок к имени и маркингу";
                con.Close();
            }
            con.Close();
            return addPartName;
        }
    }
}
