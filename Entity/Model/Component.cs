//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Component
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Component()
        {
            this.Connectors = new HashSet<Connector>();
        }
    
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public int CaloriesIn100g { get; set; }
        public string Manufacturer { get; set; }
        public int ProteinIn100g { get; set; }
        public int FatsIn100g { get; set; }
        public int CarbohydratesIn100g { get; set; }
        public Nullable<double> TempWeigth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connector> Connectors { get; set; }
    }
}
