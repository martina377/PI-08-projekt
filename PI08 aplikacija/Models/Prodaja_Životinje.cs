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
    
    public partial class Prodaja_Životinje
    {
        public int ID { get; set; }
        public int ID_Prodaja { get; set; }
        public int ID_Životinje { get; set; }
    
        public virtual Prodaja Prodaja { get; set; }
        public virtual Životinja Životinja { get; set; }
    }
}
