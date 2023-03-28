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

        public Usuario UsuarioIndividual(int id) {
            using (OrmEntityFrameworkContext bd = new OrmEntityFrameworkContext()) {
            
            var buscar = bd.Usuarios.FirstOrDefault(x=>x.Id == id);
               
                    return buscar;
            }
        }
        public void ActualizarUsuario(Usuario ParamentrosUsuario, int Lector) {
            using (OrmEntityFrameworkContext db =
                new OrmEntityFrameworkContext()) {

                var buscar = UsuarioIndividual(ParamentrosUsuario.Id);
                if (buscar == null) {
                    Console.WriteLine("El id no existe");
                 }
                else 
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParamentrosUsuario.Nombre;
                    }
                    else{
                        //Bug
                        buscar.Apellido = ParamentrosUsuario.Apellido;
                    }

                //buscar.Edad = ParamentrosUsuario.Edad;
                db.Update(buscar);
                db.SaveChanges();
               
            }

        }
        }
        public string EliminarUsuario(int id) {
            using (OrmEntityFrameworkContext db =
                    new OrmEntityFrameworkContext())
            { 
            var buscar = UsuarioIndividual(id);
                if (buscar == null)
                {
                    return "El usuario no existe";
                }
                else {
                    db.Usuarios.Remove(buscar);
                    db.SaveChanges();
                    return "El usuario se elimino";
                }
            
                }
            }

        public List<Usuario> ListarUsuarios()
        {
            using (OrmEntityFrameworkContext db =
                   new OrmEntityFrameworkContext())
            {
                return db.Usuarios.ToList();
            }

            }

    }
}
