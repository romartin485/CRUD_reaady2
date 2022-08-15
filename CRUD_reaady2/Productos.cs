using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_reaady2
{
    class Productos
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private double precio_publico;
        private int existencias;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio_publico { get => precio_publico; set => precio_publico = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public string Codigo { get => codigo; set => codigo = value; }
    }
}
