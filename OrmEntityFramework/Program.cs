// See https://aka.ms/new-console-template for more information

using OrmEntityFramework.DAO;
using OrmEntityFramework.Models;

CrudUsuarios CrudUsuarios = new CrudUsuarios();
Usuario Usuario = new Usuario();

var ListadoDeUsuarioConLibros =CrudUsuarios.UsuarioLibroVM();

Console.WriteLine("Listado de libros del usuario william");
foreach (var indice in ListadoDeUsuarioConLibros) {
        
        Console.WriteLine(indice.Nombre);
        Console.WriteLine(indice.Apellido);
        Console.WriteLine(indice.NombreLibro);
}

bool Continuar = true;
while (Continuar)
{
    Console.WriteLine("Menu");
    Console.WriteLine("Pulse 1 para realizar insertar usuarios");
    Console.WriteLine("Pulse 2 para realizar una actualizacion de usuarios");
    Console.WriteLine("Pulse 3 para realizar una eliminacion de usuarios");
    Console.WriteLine("Pulse 4 para obtener un listado de usuarios");
    var Menu = Convert.ToInt32(Console.ReadLine());


    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa tu nombre");
                Usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa tu apellido");
                Usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingresa tu edad");
                Usuario.Edad = Convert.ToInt32(Console.ReadLine());
                CrudUsuarios.AgregarUsuario(Usuario);
                Console.WriteLine("El usuario se ingreso correctamente");
                Console.WriteLine("Pulsa 1 para continuar insertando usuarios");
                Console.WriteLine("Pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Ingresa el ID del usuario a actualizar");
            var UsuarioIndividualU = CrudUsuarios.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
            if (UsuarioIndividualU == null)
            {
                Console.WriteLine("El usuario no existe");
            }
            else
            {
                Console.WriteLine($"Nombre {UsuarioIndividualU.Nombre} , Apellido {UsuarioIndividualU.Apellido}");


                Console.WriteLine("Para actulizar nombre coloca el # 1");

                Console.WriteLine("Para actulizar el apellido coloca el # 2");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Ingrese el nombre");
                    UsuarioIndividualU.Nombre = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingrese el apellido");
                    UsuarioIndividualU.Apellido = Console.ReadLine();
                }
                CrudUsuarios.ActualizarUsuario(UsuarioIndividualU, Lector);
                Console.WriteLine("Actualizacion correcta");
            }
            break;
        case 3:
            Console.WriteLine("Ingresa el ID del usuario a eliminar");
            var UsuarioIndividualD = CrudUsuarios.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
            if (UsuarioIndividualD == null)
            {
                Console.WriteLine("Este usuario no existe");
            }
            else
            {
                Console.WriteLine("Eliminar usuario");
                Console.WriteLine($"Nombre {UsuarioIndividualD.Nombre} , Apellido {UsuarioIndividualD.Apellido}");
                Console.WriteLine("El usuario encontrado es el correcto?");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(UsuarioIndividualD.Id);
                    Console.WriteLine(CrudUsuarios.EliminarUsuario(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }

            }
            break;
        case 4:
            Console.WriteLine("Lista de usuarios");
            var ListarUsuario = CrudUsuarios.ListarUsuarios();
            foreach (var iteracionUsuario in ListarUsuario)
            {
                Console.WriteLine($"{iteracionUsuario.Id} , {iteracionUsuario.Nombre} , {iteracionUsuario.Apellido}");
            }
            break;
    }
    Console.WriteLine("Desea continuar ?");
    var cont = Console.ReadLine();
    if (cont.Equals("N")) {
    Continuar= false;
    }
}
//Usuario.Id = 3;



//CrudUsuarios.AgregarUsuario(Usuario);
//CrudUsuarios.ActualizarUsuario(Usuario);




//OrmEntityFrameworkContext db = new OrmEntityFrameworkContext();

//var buscar = db.Usuarios.FirstOrDefault(x => x.Id == 1);

//db.Usuarios.Remove(buscar);
//db.SaveChanges();
#region Actualizar
//buscar.Nombre = "Efrain";
//buscar.Apellido = "Villacorta";

//db.Usuarios.Update(buscar);
//db.SaveChanges();
#endregion
//Console.WriteLine(buscar);
#region Listar
//var ListUsuarios = db.Usuarios.ToList();

//        foreach (var usu in ListUsuarios) {
//            Console.WriteLine(usu.Nombre);
//        }

#endregion
#region Insertar
//Usuario usuario = new Usuario();
//usuario.Nombre = "Mario";
//usuario.Apellido = "Alas";
//usuario.Edad = 18;

//db.Usuarios.Add(usuario);
//db.SaveChanges();
#endregion