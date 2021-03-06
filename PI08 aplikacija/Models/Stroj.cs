//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI08_aplikacija.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stroj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stroj()
        {
            this.Rad_za_drugoga = new HashSet<Rad_za_drugoga>();
        }
    
        public int ID_Stroj { get; set; }
        public string Ime { get; set; }
        public string Vlasnik { get; set; }
        public double Nabavna_vrijednost { get; set; }
        public double Trenutna_vrijednost { get; set; }
        public string Dodatna_oprema { get; set; }
        public System.DateTime Korištenje_od { get; set; }
        public System.DateTime Korištenje_do { get; set; }
        public string Lokacija_korištenja { get; set; }
        public double Zarada_od_rada_korištenja { get; set; }
        public int ID_Farma { get; set; }
        public int ID_Kupnja { get; set; }
    
        public virtual Farma Farma { get; set; }
        public virtual Kupnja Kupnja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rad_za_drugoga> Rad_za_drugoga { get; set; }
    }
}
