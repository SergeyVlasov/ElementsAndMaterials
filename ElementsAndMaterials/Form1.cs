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
            textBox1.Text += $"Используется подключение {ConfigHandler.GetConnString()} {Environment.NewLine}";
        }
        private void button6_Click(object sender, EventArgs e) => textBox1.Clear();
        private void button1_Click(object sender, EventArgs e) => makeRequestToShow("0", "стекло");
        private void button2_Click(object sender, EventArgs e) => makeRequestToShow("1", "рамки");
        private void button3_Click(object sender, EventArgs e) => makeRequestToShow("2", "шпроссы");
        private void button4_Click(object sender, EventArgs e) => makeRequestToShow("3", "пленки");
        private void button5_Click(object sender, EventArgs e) => makeRequestToShow("4", "ленты");

        private void button7_Click(object sender, EventArgs e) => makeRequestToInsert("0", "стекло нарезка", "732", "SN_");
        private void button13_Click(object sender, EventArgs e) => makeRequestToInsert("0", "стекло СП", "709", "S_");
        private void button8_Click(object sender, EventArgs e) => makeRequestToInsert("1", "рамки", "733", "R_");
        private void button9_Click(object sender, EventArgs e) => makeRequestToInsert("2", "шпроссы", "714", "SHP_S_");
        private void button10_Click(object sender, EventArgs e) => makeRequestToInsert("3", "пленки", "719", "П "); // или "PL_" 715???
        private void button11_Click(object sender, EventArgs e) => makeRequestToInsert("4", "ленты", "759", "KF_");

        private void makeRequestToShow(string type, string material)=>
            SQLhandler.makeRequestShowElements(com, con, type, material, textBox1);

        private void makeRequestToInsert(string type, string material, string goodGroup, string prefix ) =>
            SQLhandler.makeRequesInsertElements(com, con, type, material, goodGroup, prefix,  textBox1);

    }
}
