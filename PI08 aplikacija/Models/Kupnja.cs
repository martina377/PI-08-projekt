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
    
    public partial class Kupnja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kupnja()
        {
            this.Hranas = new HashSet<Hrana>();
            this.Strojs = new HashSet<Stroj>();
        }
    
        public int ID_Kupnja { get; set; }
        public string Vrsta_proizvoda { get; set; }
        public int Količina { get; set; }
        public double Cijena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hrana> Hranas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stroj> Strojs { get; set; }
    }
}
