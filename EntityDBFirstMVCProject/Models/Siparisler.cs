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
    
    public partial class Siparisler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparisler()
        {
            this.SiparisDetays = new HashSet<SiparisDetay>();
        }
    
        public int SiparisNo { get; set; }
        public Nullable<int> MüsteriID { get; set; }
        public Nullable<System.DateTime> SiparisTarihi { get; set; }
        public Nullable<int> LojistikID { get; set; }
    
        public virtual Lojistik Lojistik { get; set; }
        public virtual Müsteriler Müsteriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
    }
}
