//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace di.proyecto.clase.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class ticket_venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ticket_venta()
        {
            this.detalles_ticket = new HashSet<detalles_ticket>();
        }
    
        public int idTicket { get; set; }
        public int idCliente { get; set; }
        public Nullable<System.DateTime> FechaVenta { get; set; }
    
        public virtual cliente cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalles_ticket> detalles_ticket { get; set; }
    }
}
