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
        public static void makeRequestShowElements(SqlCommand com, SqlConnection con, string typeElement, string material, TextBox textBox, string sqlFile, string nameElement)
        {
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, nameElement);
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

        public static void makeRequesInsertElements(SqlCommand com, SqlConnection con, string typeElement, string material, string goodGroup, string prefix, TextBox textBox, string sqlFile, string nameElement)
        {
            //textBox.Text = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, nameElement);
            string ComText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\{sqlFile}")), typeElement, nameElement);
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
                com.CommandText = string.Format(File.ReadAllText(FilePathFinder.GetPathToFile($"\\SQLRequests\\insert_all_elements_in_materials.sql")), typeElement, goodGroup, prefix, id);
                string xxx = com.CommandText;
                //textBox.Text += xxx;
                com.ExecuteScalar();
                con.Close();
            };

            textBox.Text += $"элементы занесены в материалы {Environment.NewLine}";
        }
    }
}
