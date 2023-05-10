using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Utils;
using ElementsAndMaterials.CodeBlocks;
using System.Linq;

namespace ElementsAndMaterials
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataAdapter da;
        DataTable dt;
        string postfixMarkingZakalka;
        string postfixMarkingPolirovka;
        string postfixMarkingShlifovka;
        string postfixNameZakalka;
        string postfixNamePolirovka;
        string postfixNameShlifovka;        
        public Form1()
        {
            con = new SqlConnection(ConfigHandler.GetConnString());
            com = new SqlCommand("", con);
            da = new SqlDataAdapter(com);
            com.CommandTimeout = 9000;
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            label1.Text = $"Используется подключение {ConfigHandler.GetConnString()} {Environment.NewLine}";
            //postfixMarkingZakalka = SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Закалка", "select_good_marking_prefix_from_materials.sql", textBox1, "marking");
            //postfixMarkingPolirovka = SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Полировка", "select_good_marking_prefix_from_materials.sql", textBox1, "marking");
            //postfixMarkingShlifovka = SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Шлифовка", "select_good_marking_prefix_from_materials.sql", textBox1, "marking");
            //postfixNameZakalka = " " + SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Закалка", "select_good_name_postfix_from_materials.sql", textBox1, "name");
            //postfixNamePolirovka = " " + SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Полировка", "select_good_name_postfix_from_materials.sql", textBox1, "name");
            //postfixNameShlifovka = " " + SQLhandler.makeRequestoShowNamePartToAddAsync(com, con, "Шлифовка", "select_good_name_postfix_from_materials.sql", textBox1, "name");

            postfixMarkingZakalka = "зак";
            postfixMarkingPolirovka = "П";
            postfixMarkingShlifovka = "Ш";
            postfixNameZakalka = "закалка";
            postfixNamePolirovka = "полировка";
            postfixNameShlifovka = "шлифовка";
        }
        private void button6_Click(object sender, EventArgs e) => textBox1.Clear();
        private void button1_Click(object sender, EventArgs e) => makeRequestToShowAll("0", "стекло");
        private void button2_Click(object sender, EventArgs e) => makeRequestToShowAll("1", "рамки");
        private void button3_Click(object sender, EventArgs e) => makeRequestToShowAll("2", "шпроссы");
        private void button4_Click(object sender, EventArgs e) => makeRequestToShowAll("3", "пленки");
        private void button5_Click(object sender, EventArgs e) => makeRequestToShowAll("4", "ленты");
        private void button19_Click(object sender, EventArgs e) => makeRequestToShowAll_newName("стекло", "select_all_elements_witch_no_in_materials_with_new_names_universal.sql", "O_", postfixMarkingZakalka,  " ", "0"); // имя не нужно, ищем все select_all_elements_witch_no_in_materials_with_new_names_universal.sql
        private void button20_Click(object sender, EventArgs e) => makeRequestToShowAll_newName("стекло", "select_all_elements_witch_no_in_materials_with_new_names_universal.sql", "O_", postfixMarkingPolirovka, " ", "0"); // имя не нужно, ищем все select_all_elements_witch_no_in_materials_with_new_names_universal.sql
        private void button21_Click(object sender, EventArgs e) => makeRequestToShowAll_newName("стекло", "select_all_elements_witch_no_in_materials_with_new_names_universal.sql", "O_", postfixMarkingShlifovka, " ", "0"); // имя не нужно, ищем все select_all_elements_witch_no_in_materials_with_new_names_universal.sql

        private void button12_Click(object sender, EventArgs e) => makeRequestToShowOneElementFromMaterials((textBox2.Text.Replace("\r\n", string.Empty)).Trim());
        private void button16_Click(object sender, EventArgs e) => makeRequestToShowOneElementFromGoods((textBox2.Text.Replace("\r\n", string.Empty)).Trim());

        private void button7_Click(object sender, EventArgs e) => makeRequestToInsertAll("0", "стекло нарезка", "732", "SN_");
        private void button13_Click(object sender, EventArgs e) => makeRequestToInsertAll("0", "стекло СП", "709", "S_");
        private void button8_Click(object sender, EventArgs e) => makeRequestToInsertAll("1", "рамки", "733", "R_");
        private void button9_Click(object sender, EventArgs e) => makeRequestToInsertAll("2", "шпроссы", "714", "SHP_S_");
        private void button10_Click(object sender, EventArgs e) => makeRequestToInsertAll("3", "пленки", "719", "П "); // или "PL_" 715???
        private void button11_Click(object sender, EventArgs e) => makeRequestToInsertAll("4", "ленты", "759", "KF_");
        private void button15_Click(object sender, EventArgs e) => makeRequestToInsertAll_NewGoods("0", "стекло закалка", "765", "O_", postfixMarkingZakalka, " " + postfixNameZakalka, "Закалка"); // вместо 'зак'  и 'эакалка' вставить рез-т запроса
        private void button17_Click(object sender, EventArgs e) => makeRequestToInsertAll_NewGoods("0", "стекло полировка", "765", "O_", postfixMarkingPolirovka, " " + postfixNamePolirovka, "Полировка");
        private void button18_Click(object sender, EventArgs e) => makeRequestToInsertAll_NewGoods("0", "стекло шлифовка", "765", "O_", postfixMarkingShlifovka, " " + postfixNameShlifovka, "Шлифовка");
        private void button14_Click(object sender, EventArgs e) => makeRequestToInsertOneElement(textBox2.Text.Replace("\r\n", string.Empty));
     


        private void makeRequestToShowAll(string type, string material) =>
            SQLhandler.makeRequestShowElementsаFromElements(com, con, type, material, textBox1, "select_all_elements_witch_no_in_materials.sql", "");
        private void makeRequestToShowAll_newName(string material, string sqlFile, string prefixMarking, string postfixMarking, string identificatorElement, string typeOfElement) =>
            SQLhandler.makeRequestShowElementsFromGoods(com, con, material, textBox1, sqlFile, prefixMarking, postfixMarking, identificatorElement, typeOfElement);

        private void makeRequestToShowOneElementFromMaterials(string nameElement) => selectSearchType(textBox2.Text, "search in materials", "O_", nameElement);
        private void makeRequestToShowOneElementFromGoods(string nameElement) => selectSearchType(textBox2.Text, "search in goods", "O_", nameElement);
        private void makeRequestToInsertAll(string type, string material, string goodGroup, string prefix ) =>
            SQLhandler.makeRequesInsertElements(com, con, type, material, goodGroup, prefix,  textBox1, "select_all_elements_witch_no_in_materials.sql", "");
        //private void makeRequestToInsertAll_NewGoods(string type, string material, string goodGroup, string prefix, string postfixMarking, string postfixName) =>
        //    SQLhandler.makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(com, con, type, material, goodGroup, prefix, textBox1, "select_all_elements_witch_no_in_materials_new_goods_with_new_names.sql", "", postfixMarking, postfixName);
        private void makeRequestToInsertAll_NewGoods(string type, string material, string goodGroup, string prefixMarking, string postfixMarking, string postfixName, string typeElement)
        {
            string addPartOfName = "";
            switch (typeElement)
            {
                case "Закалка":
                    addPartOfName = postfixNameZakalka;
                    break;
                case "Полировка":
                    addPartOfName = postfixNamePolirovka;
                    break;
                case "Шлифовка":
                    addPartOfName = postfixNameShlifovka;
                    break;
                default:
                    addPartOfName = "";
                    break;
            }
            SQLhandler.makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(com,
                                                                                      con,
                                                                                      type,
                                                                                      "select_all_elements_witch_no_in_materials_with_new_names_universal.sql",
                                                                                      goodGroup,
                                                                                      prefixMarking,
                                                                                      postfixMarking,
                                                                                      "" + addPartOfName,
                                                                                      textBox1,
                                                                                      postfixName);
        }


        private void makeRequestToInsertOneElement(string identificatorElement)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    selectDataToInsert("select_1_element_witch_no_in_materials_by_name.sql", identificatorElement);
                    break;
                case 1:
                    if (textBox2.Text.All(char.IsDigit))
                        selectDataToInsert("select_1_element_witch_no_in_materials_by_ID.sql", identificatorElement);
                    else
                        textBox1.Text = " НЕПРАВИЛЬНО ВЫБРАН ТИП ПОИСКА ";
                    break;
                default:
                    textBox1.Text = " НЕ ВЫБРАН ТИП ПОИСКА ";
                    break;
            }
        }
               
        private void selectDataToInsert(string sqlFile, string textBox)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    SQLhandler.makeRequesInsertElements(com, con, "0", "стекло нарезка", "732", "SN_", textBox1, sqlFile, textBox);
                    break;
                case 1:
                    SQLhandler.makeRequesInsertElements(com, con, "0", "стекло СП", "709", "S_", textBox1, sqlFile, textBox);
                    break;
                case 2:
                    SQLhandler.makeRequesInsertElements(com, con, "1", "рамки", "733", "R_", textBox1, sqlFile, textBox);
                    break;
                case 3:
                    SQLhandler.makeRequesInsertElements(com, con, "2", "шпроссы", "714", "SHP_S_", textBox1, sqlFile, textBox);
                    break;
                case 4:
                    SQLhandler.makeRequesInsertElements(com, con, "3", "пленки", "719", "П_", textBox1, sqlFile, textBox);
                    break;
                case 5:
                    SQLhandler.makeRequesInsertElements(com, con, "4", "ленты", "759", "KF_", textBox1, sqlFile, textBox);
                    break;
                case 6:
                    SQLhandler.makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(com, 
                                                                                              con, 
                                                                                              "0",
                                                                                              "select_ONE_elements_witch_no_in_materials_with_new_names_universal.sql",
                                                                                              "765",  //765 - для нового цеха стекла 
                                                                                              "O_",
                                                                                              postfixMarkingZakalka,
                                                                                              " " + postfixNameZakalka,
                                                                                              textBox1,
                                                                                              textBox
                                                                                              );
                    break;
                case 7:
                    SQLhandler.makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(com,
                                                                                              con,
                                                                                              "0",
                                                                                              "select_ONE_elements_witch_no_in_materials_with_new_names_universal.sql",
                                                                                              "765",
                                                                                              "O_",                                                                                                                                                                                              
                                                                                              postfixMarkingPolirovka,
                                                                                              " " + postfixNamePolirovka,
                                                                                              textBox1,
                                                                                              textBox
                                                                                               );
                    break;
                case 8:
                    SQLhandler.makeRequesInsertElementsNew_NewGoods_removeDoubleInsertInGoods(com,
                                                                                               con,
                                                                                               "0",
                                                                                               "select_ONE_elements_witch_no_in_materials_with_new_names_universal.sql",
                                                                                               "765",
                                                                                               "O_",                                                                                                                                                                                              
                                                                                               postfixMarkingShlifovka,
                                                                                               " " + postfixNameShlifovka,
                                                                                               textBox1,
                                                                                               textBox
                                                                                               );
                    break;
                default:
                    textBox1.Text = " НЕ ВЫБРАН ТИП ЭЛЕМЕНТА  ДЛЯ ВСТАВКИ";
                    break;
            }
        }
        private void selectSearchType(string identificatorElement, string typeSearch, string prefixMarking, string postfixMarking)
        {
            string sqlFileSerachByName = "";
            string sqlFileSerachByID = "";
            switch (typeSearch)
            {
                case "search in materials":
                    sqlFileSerachByName = "select_1_element_witch_no_in_materials_by_name.sql";
                    sqlFileSerachByID = "select_1_element_witch_no_in_materials_by_ID.sql";
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            SQLhandler.makeRequestShowElementsаFromElements(com, con, "", "", textBox1, sqlFileSerachByName, identificatorElement);
                            break;
                        case 1:
                            if (identificatorElement.All(char.IsDigit))
                                SQLhandler.makeRequestShowElementsаFromElements(com, con, "", "", textBox1, sqlFileSerachByID, identificatorElement);
                            else
                                textBox1.Text = " НЕПРАВИЛЬНО ВЫБРАН ТИП ПОИСКА ";
                            break;
                        default:
                            textBox1.Text = " НЕ ВЫБРАН ТИП ПОИСКА ";
                            break;
                    }
                    break;
                case "search in goods":
                    //sqlFileSerachByName = "select_1_element_from_goods_by_name.sql";
                    //sqlFileSerachByID = "select_1_element_from_goods_by_ID.sql";
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0:
                            //SQLhandler.makeRequestShowElementsFromGoods(com, con,  "", textBox1, "select_ONE_elements_witch_no_in_materials_with_new_names_universal.sql", prefixMarking, postfixMarking, identificatorElement, "0");
                            SQLhandler.makeRequestShowElementsFromGoods(com, con,  "", textBox1, "select_1_element_from_goods_by_name.sql", prefixMarking, postfixMarking, identificatorElement, "0");
                            break;
                        case 1:
                            if (identificatorElement.All(char.IsDigit))
                                //SQLhandler.makeRequestShowElementsFromGoods(com, con, "", textBox1, "select_ONE_elements_witch_no_in_materials_with_new_names_universal.sql", prefixMarking, postfixMarking, identificatorElement, "0");
                            SQLhandler.makeRequestShowElementsFromGoods(com, con, "", textBox1, "select_1_element_from_goods_by_ID.sql", prefixMarking, postfixMarking, identificatorElement, "0");
                            else
                                textBox1.Text = " НЕПРАВИЛЬНО ВЫБРАН ТИП ПОИСКА ";
                            break;
                        default:
                            textBox1.Text = " НЕ ВЫБРАН ТИП ПОИСКА ";
                            break;
                    }
                    break;
            }
            
        }
    }
}
