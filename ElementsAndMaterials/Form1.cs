using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Utils;
using ElementsAndMaterials.CodeBlocks;

namespace ElementsAndMaterials
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;
        DataTable dt;

        public Form1()
        {
            con = new SqlConnection(ConfigHandler.GetConnString());
            com = new SqlCommand("", con);
            da = new SqlDataAdapter(com);
            com.CommandTimeout = 9000;
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            label1.Text = $"Используется подключение {ConfigHandler.GetConnString()} {Environment.NewLine}";
        }
        private void button6_Click(object sender, EventArgs e) => textBox1.Clear();
        private void button1_Click(object sender, EventArgs e) => makeRequestToShowAll("0", "стекло");
        private void button2_Click(object sender, EventArgs e) => makeRequestToShowAll("1", "рамки");
        private void button3_Click(object sender, EventArgs e) => makeRequestToShowAll("2", "шпроссы");
        private void button4_Click(object sender, EventArgs e) => makeRequestToShowAll("3", "пленки");
        private void button5_Click(object sender, EventArgs e) => makeRequestToShowAll("4", "ленты");
        private void button12_Click(object sender, EventArgs e) => makeRequestToShowOneByName(textBox2.Text.Replace("\r\n", string.Empty));

        private void button7_Click(object sender, EventArgs e) => makeRequestToInsertAll("0", "стекло нарезка", "732", "SN_");
        private void button13_Click(object sender, EventArgs e) => makeRequestToInsertAll("0", "стекло СП", "709", "S_");
        private void button8_Click(object sender, EventArgs e) => makeRequestToInsertAll("1", "рамки", "733", "R_");
        private void button9_Click(object sender, EventArgs e) => makeRequestToInsertAll("2", "шпроссы", "714", "SHP_S_");
        private void button10_Click(object sender, EventArgs e) => makeRequestToInsertAll("3", "пленки", "719", "П "); // или "PL_" 715???
        private void button11_Click(object sender, EventArgs e) => makeRequestToInsertAll("4", "ленты", "759", "KF_");
        private void button14_Click(object sender, EventArgs e) => makeRequestToInsertOneByName(textBox2.Text.Replace("\r\n", string.Empty));

        private void makeRequestToShowAll(string type, string material) =>
            SQLhandler.makeRequestShowElements(com, con, type, material, textBox1, "select_all_elements_witch_no_in_materials.sql", "");
        private void makeRequestToShowOneByName(string nameElement) =>
            SQLhandler.makeRequestShowElements(com, con, "", "", textBox1, "select_1_element_witch_no_in_materials_by_name.sql", nameElement);
        private void makeRequestToInsertAll(string type, string material, string goodGroup, string prefix ) =>
            SQLhandler.makeRequesInsertElements(com, con, type, material, goodGroup, prefix,  textBox1, "select_all_elements_witch_no_in_materials.sql", "");
        private void makeRequestToInsertOneByName(string material)
        {
            selectData("select_1_element_witch_no_in_materials_by_name.sql");         
        }
        private void selectData(string sqlFile)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    SQLhandler.makeRequesInsertElements(com, con, "0", "стекло нарезка", "732", "SN_", textBox1, sqlFile, textBox2.Text);
                    break;
                case 1:
                    SQLhandler.makeRequesInsertElements(com, con, "0", "стекло СП", "709", "S_", textBox1, sqlFile, textBox2.Text);
                    break;
                case 2:
                    SQLhandler.makeRequesInsertElements(com, con, "1", "рамки", "733", "R_", textBox1, sqlFile, textBox2.Text);
                    break;
                case 3:
                    SQLhandler.makeRequesInsertElements(com, con, "2", "шпроссы", "714", "SHP_S_", textBox1, sqlFile, textBox2.Text);
                    break;
                case 4:
                    SQLhandler.makeRequesInsertElements(com, con, "3", "пленки", "719", "П_", textBox1, sqlFile, textBox2.Text);
                    break;
                case 5:
                    SQLhandler.makeRequesInsertElements(com, con, "4", "ленты", "759", "KF_", textBox1, sqlFile, textBox2.Text);
                    break;
                default:
                    textBox1.Text = " НЕ ВЫБРАН ТИП ЭЛЕМЕНТА ";
                    break;
            }
        }
    }
}
