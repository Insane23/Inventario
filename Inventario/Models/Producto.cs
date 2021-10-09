//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.Stock_tienda = new HashSet<Stock_tienda>();
        }
    
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string codigo_producto { get; set; }
        public int precio_compra { get; set; }
        public int precio_venta { get; set; }
        public string descripcion_producto { get; set; }
        public int id_marca { get; set; }
        public int id_categoria { get; set; }
        public int id_tienda { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Tienda Tienda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock_tienda> Stock_tienda { get; set; }
    }
}
