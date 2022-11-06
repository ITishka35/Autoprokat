//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autoprokat
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            this.Issued_Cars = new HashSet<Issued_Cars>();
        }
    
        public string Marks { get; set; }
        public string MainImagePath { get; set; }
        public string Model { get; set; }
        public string Year_Release { get; set; }
        public string Color { get; set; }
        public Nullable<int> ID_Transmission { get; set; }
        public string Engine_Volume { get; set; }
        public Nullable<int> Deposit_Amount { get; set; }
        public Nullable<int> ID_Type { get; set; }
        public int ID_Car { get; set; }
        public string State_Number { get; set; }
        public Nullable<int> ID_Engine { get; set; }
    
        public virtual TypeCars TypeCars { get; set; }
        public virtual TypeEngineCars TypeEngineCars { get; set; }
        public virtual TypeTransmission TypeTransmission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Issued_Cars> Issued_Cars { get; set; }
    }
}
