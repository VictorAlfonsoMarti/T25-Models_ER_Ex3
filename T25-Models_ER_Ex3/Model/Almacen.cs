using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T25_Models_ER_Ex3.Model
{
    public class Almacen
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string Lugar { get; set; }
        public int Capacidad { get; set; }
        public ICollection<Caja> Cajas { get; set; }

        // CONSTRUCTOR
        public Almacen()
        {
            Cajas = new HashSet<Caja>();
        }
    }
}
