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
    
    public partial class Hrana
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hrana()
        {
            this.Hrana_Životinja = new HashSet<Hrana_Životinja>();
        }
    
        public int ID_Hrana { get; set; }
        public string Vrsta { get; set; }
        public int Količina { get; set; }
        public double Troškovi { get; set; }
        public System.DateTime Vrijeme_kupovine { get; set; }
        public int ID_Kupnja { get; set; }
    
        public virtual Kupnja Kupnja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hrana_Životinja> Hrana_Životinja { get; set; }
    }
}
