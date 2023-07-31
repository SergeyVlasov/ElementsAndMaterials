using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElementsAndMaterials
{
    public partial class Orders
    {
        public int Idorder { get; set; }
        public int? Idpeople { get; set; }
        public string Name { get; set; }
        public DateTime? Deleted { get; set; }
        public string Logincre { get; set; }
        public DateTime? Dtcre { get; set; }
        public DateTime? Dtdoc { get; set; }
        public int? Idordersgroup { get; set; }
        public decimal? Sm { get; set; }
        public int? Idversion { get; set; }
        public int? Idcustomer { get; set; }
        public int? Iddocoper { get; set; }
        public int? Qupos { get; set; }
        public int? Idvalut { get; set; }
        public string Agreename { get; set; }
        public DateTime? Agreedate { get; set; }
        public decimal? Valutrate { get; set; }
        public decimal? Smbase { get; set; }
        public int? Iddestanation { get; set; }
        public int? Idseller { get; set; }
        public string Address { get; set; }
        public short? Floor { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public Guid Guid { get; set; }
        public string Addtext { get; set; }
        public short? Saved { get; set; }
        public short? Saved2 { get; set; }
        public int? Idpeopleedit { get; set; }
        public DateTime? Dtedit { get; set; }
        public int? Idaddress { get; set; }
        public int? Iddiscard { get; set; }
        public int? Idcustomer2 { get; set; }
        public int? Idcustomer3 { get; set; }
        public int? Idpeople2 { get; set; }
        public int? Idpeople3 { get; set; }
        public int? Idpeople4 { get; set; }
        public string Comment { get; set; }
        public string Addinfo { get; set; }
        public string Supplyinfo { get; set; }
        public string Productinfo { get; set; }
        public string Transportinfo { get; set; }
        public string Installinfo { get; set; }
        public string Sizeinfo { get; set; }
        public int? Iddepartment { get; set; }
        public int? Idsourceinfo { get; set; }
        public int? Idadvertisingaction { get; set; }
        public int? Addint1 { get; set; }
        public int? Addint2 { get; set; }
        public int? Addint3 { get; set; }
        public string Addstr1 { get; set; }
        public string Addstr2 { get; set; }
        public string Addstr3 { get; set; }
        public DateTime? Adddt1 { get; set; }
        public DateTime? Adddt2 { get; set; }
        public DateTime? Adddt3 { get; set; }
        public decimal? Addnum1 { get; set; }
        public decimal? Addnum2 { get; set; }
        public decimal? Addnum3 { get; set; }
        public string Addstr4 { get; set; }
        public string Addstr5 { get; set; }
        public int? Idparent { get; set; }
        public int? Iddocstate { get; set; }
        public int? Idagree { get; set; }
        public int? Idpeopledesigner { get; set; }
        public int? Idagreement { get; set; }
    }
}
