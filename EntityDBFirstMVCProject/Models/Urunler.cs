//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityDBFirstMVCProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            this.SiparisDetays = new HashSet<SiparisDetay>();
        }
    
        public int ÜrünNo { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<int> TedarikciID { get; set; }
        public string ÜrünAdi { get; set; }
        public string ÜrünMarkasi { get; set; }
        public string ÜrünStokKodu { get; set; }
        public Nullable<int> ÜrünAdedi { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Tedarikciler Tedarikciler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
    }
}
