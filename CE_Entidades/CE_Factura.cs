using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Entidades
{
    public class CE_Factura
    {
        public DateTime Fecha_Factura { get; set; }
        public int Doc_Cliente { get; set; }
        public int Cod_Vendedor { get; set; }
    }
}
