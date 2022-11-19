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
        public static void makeRequestShowOneElement(SqlCommand com, SqlConnection con, string typeElement, string material, TextBox textBox, string nameElement)
        {
            makeRequestShow(com, con, typeElement, material, textBox, "select_1_element_witch_no_in_materials", nameElement);
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\select_1_element_witch_no_in_materials.sql")), typeElement, nameElement);
            com.CommandText = ComText;
            textBox.Text = ComText;
        }
        public static void makeRequestShowAllElements(SqlCommand com, SqlConnection con, string typeElement, string material, TextBox textBox)
        {
            makeRequestShow(com, con, typeElement, material, textBox, "select_all_elements_witch_no_in_materials", "");
        }
        public static void makeRequesInsertOneElement(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string nameElement)
        {
            //makeRequesInsert(com, con, typeElement, material, goodGroup, prefix, textBox, "insert_1_element_in_materials.sql", elementName);
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_1_element_in_materials.sql")), typeElement, material, goodGroup, prefix, nameElement);
            com.CommandText = ComText;
            textBox.Text = ComText;
        }
        public static void makeRequesInsertAllElements(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string nameElement)
        {
            makeRequesInsert(com, con, typeElement, material, goodGroup, prefix, textBox, "insert_all_elements_in_materials.sql", nameElement);
        }

        private static void makeRequestShow(SqlCommand com, SqlConnection con, string typeElement, string material, TextBox textBox, string sqlFile, string nameElement)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}.sql")), typeElement, nameElement);
            com.CommandText = ComText;
            con.Open();
            string result;
            if (com.ExecuteScalar() != null)
            {
                textBox.Text += $"Материал: {material}, недостающие элементы: {Environment.NewLine} {Environment.NewLine}";
                var reader = com.ExecuteReader();
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

        private static void makeRequesInsert(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string sqlFile, string nameElement)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, material, goodGroup, prefix, nameElement);
            com.CommandText = ComText;
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

            foreach (string id in idList)
            {
                con.Open();
                com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_element_in_materials.sql")), typeElement, goodGroup, prefix, id);
                string xxx = com.CommandText;
                com.ExecuteScalar();
                con.Close();
            };
            
            textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        }
    }
}
