using OrmEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmEntityFramework.DAO
{
    public class CrudUsuarios
    {
        public void AgregarUsuario(Usuario ParamentrosUsuario) {

            using (OrmEntityFrameworkContext db = 
                new OrmEntityFrameworkContext()) {
               Usuario usuario = new Usuario();
                usuario.Nombre = ParamentrosUsuario.Nombre;
                usuario.Apellido = ParamentrosUsuario.Apellido;
                usuario.Edad = ParamentrosUsuario.Edad;
                db.Add(usuario);
                db.SaveChanges();
            }
        
        }

        private Usuario UsuarioIndividual(int id) {
            using (OrmEntityFrameworkContext bd = new OrmEntityFrameworkContext()) {
            
            var buscar = bd.Usuarios.FirstOrDefault(x=>x.Id == id);
               
                    return buscar;
            }
        }
        public void ActualizarUsuario(Usuario ParamentrosUsuario) {
            using (OrmEntityFrameworkContext db =
                new OrmEntityFrameworkContext()) {

                var buscar = UsuarioIndividual(ParamentrosUsuario.Id);
                if (buscar == null) {
                    Console.WriteLine("El id no existe");
                 }
                else 
                {
                buscar.Edad = ParamentrosUsuario.Edad;
                db.Update(buscar);
                db.SaveChanges();
               
            }

        }
        }
    }
}
