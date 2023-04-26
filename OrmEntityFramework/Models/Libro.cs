using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmEntityFramework.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string NombreLibro { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
    }
}
