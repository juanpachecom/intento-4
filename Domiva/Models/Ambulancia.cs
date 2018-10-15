//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domiva.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ambulancia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ambulancia()
        {
            this.ambulancia_estado = new HashSet<ambulancia_estado>();
            this.Chofer_ambulancia = new HashSet<Chofer_ambulancia>();
            this.insumos_ambulancia = new HashSet<insumos_ambulancia>();
            this.personal_ambulancia = new HashSet<personal_ambulancia>();
            this.Solicitud_ambulancia = new HashSet<Solicitud_ambulancia>();
        }
    
        public int Id_ambulancia { get; set; }
        public Nullable<int> id_tipo { get; set; }
        public string patente { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Nullable<int> año { get; set; }
        public Nullable<int> numero_telefono { get; set; }
        public Nullable<int> id_centro { get; set; }
    
        public virtual Ambulancia_tipo Ambulancia_tipo { get; set; }
        public virtual centro_asistencial centro_asistencial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ambulancia_estado> ambulancia_estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chofer_ambulancia> Chofer_ambulancia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<insumos_ambulancia> insumos_ambulancia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personal_ambulancia> personal_ambulancia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_ambulancia> Solicitud_ambulancia { get; set; }
    }
}
