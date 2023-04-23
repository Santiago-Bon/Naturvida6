using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Entidades
{
    public class CE_Detalle_Factura
    {
        public int Id_Factura { get; set; }
        public int Cod_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Valor_Unidad { get; set; }
    }
}
