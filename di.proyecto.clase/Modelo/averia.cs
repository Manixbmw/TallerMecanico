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
    using di.proyecto.clase.MVVM;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class averia : MVBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public averia()
        {
            this.factura = new HashSet<factura>();
            this.piezas_averia = new HashSet<piezas_averia>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public Nullable<float> horas { get; set; }
        
        public int tipo { get; set; }
        
        public int estado { get; set; }
        public int idEmpleado { get; set; }
        public string solucion { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner la fecha de entrada")]
        public Nullable<System.DateTime> fechaRecepcion { get; set; }
        public Nullable<System.DateTime> fechaSolucion { get; set; }
        public int idCliente { get; set; }
        public string observaciones { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el IVA")]
        public Nullable<float> IVA { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el tipo de averia")]
        public virtual tipoaveria tipoaveria { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner estado del coche")]
        public virtual estado estado1 { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el empleado")]
        public virtual empleado empleado { get; set; }
        [Required(ErrorMessage = "Es obligatorio poner el cliente del vehiculo")]
        public virtual cliente cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factura> factura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<piezas_averia> piezas_averia { get; set; }
    }
}
