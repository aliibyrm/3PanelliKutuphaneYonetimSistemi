//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutupphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblCezalar
    {
        public int Id { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<System.DateTime> Baslangic { get; set; }
        public Nullable<System.DateTime> Bitis { get; set; }
        public Nullable<decimal> Para { get; set; }
        public Nullable<int> Hareket { get; set; }
    
        public virtual TblHareket TblHareket { get; set; }
        public virtual TblUyeler TblUyeler { get; set; }
    }
}
