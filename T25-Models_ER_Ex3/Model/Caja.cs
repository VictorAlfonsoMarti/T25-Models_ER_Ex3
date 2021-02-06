using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T25_Models_ER_Ex3.Model
{
    public class Caja
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string NumReferencia { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public int Almacen { get; set; }
        public Almacen Almacenes { get; set; }
    }
}
