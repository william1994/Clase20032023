﻿using Microsoft.EntityFrameworkCore;
using OrmEntityFramework.Models;
using OrmEntityFramework.ViewModels;
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
        public bool Acceso(Usuario usuario) {
            using (OrmEntityFrameworkContext db =
                       new OrmEntityFrameworkContext())
            {
                var Acceder = db.Usuarios.Where(x => x.UsuarioN == usuario.UsuarioN &&
                x.Contrasena == usuario.Contrasena
                ).ToList();

                return Acceder.Any() ? true : false;
                //if (Acceder.Any())
                //{
                //    return true;
                //}
                //else { 
                //    return false; 
                //}

            }


        }

        public List<UsuarioLibroVM> UsuarioLibroVM()
        {
            OrmEntityFrameworkContext db = new OrmEntityFrameworkContext();
            var IdUsuario = 1003;
            var ListadoDeUsurioConLibros = db.UsuarioLibroVMs.FromSqlRaw($"select us.Nombre,us.Apellido,ls.NombreLibro from Usuario as us inner join Libro as ls on us.Id = ls.IdUsuario where us.Id = {IdUsuario}").ToList();
            return ListadoDeUsurioConLibros;

        }
    }
}
