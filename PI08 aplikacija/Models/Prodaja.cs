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
    
    public partial class Prodaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodaja()
        {
            this.Prodaja_Životinje = new HashSet<Prodaja_Životinje>();
            this.Prod_biljke = new HashSet<Prod_biljke>();
        }
    
        public int ID_Prodaja { get; set; }
        public string Lokacija { get; set; }
        public int Količina { get; set; }
        public double Zarada { get; set; }
        public string Proizvod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodaja_Životinje> Prodaja_Životinje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prod_biljke> Prod_biljke { get; set; }
    }
}