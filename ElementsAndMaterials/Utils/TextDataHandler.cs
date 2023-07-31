using System.Linq;

namespace ElementsAndMaterials.Utils
{
    class TextDataHandler
    {
        public static string makeRequestoShowNamePartToAddAsync_EF(string typeElement, string typeOfname)
        {

            int idPrefixMarking;
            string addPartText = "";

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

            using (var dbwdtempContext = new DB_wd_temp_Context())
            {

                switch (typeOfname)
                {
                    case "name":
                        var elementNamePostfix = from ge in dbwdtempContext.Glasselement
                                                   where ge.Idglasselement == idPrefixMarking
                                                   select new
                                                   {
                                                       ElementNamePostfix = ge.Name
                                                   };
                        addPartText = elementNamePostfix.FirstOrDefault().ToString().Replace("{ ElementNamePostfix = ", "").Replace(" }", "");
                        break;
                    case "marking":
                        var elementMarkingPostfix = from ge in dbwdtempContext.Glasselement
                                                    where ge.Idglasselement == idPrefixMarking
                                                    select new
                                                    {
                                                        ElementMarkingPostfix = ge.Marking
                                                    };

                        addPartText = elementMarkingPostfix.FirstOrDefault().ToString().Replace("{ ElementMarkingPostfix = ", "").Replace(" }", "");
                        break;
                    default:
                        break;

                }
            }
            return addPartText;
        }
    }
}
