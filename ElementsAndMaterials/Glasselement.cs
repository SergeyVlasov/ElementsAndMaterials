using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElementsAndMaterials
{
    public partial class Glasselement
    {
        public int Idglasselement { get; set; }
        public string Name { get; set; }
        public string Marking { get; set; }
        public DateTime? Deleted { get; set; }
        public short? Typ { get; set; }
        public string Comment { get; set; }
        public int? Thick { get; set; }
        public int? Idglasselementgroup { get; set; }
        public Guid Guid { get; set; }
        public int? Ramkaoffset { get; set; }
        public int? Color { get; set; }
        public int? Numpos { get; set; }
    }
}
