// See https://aka.ms/new-console-template for more information

using OrmEntityFramework.DAO;
using OrmEntityFramework.Models;

CrudUsuarios CrudUsuarios = new CrudUsuarios();
Usuario Usuario = new Usuario();


Console.WriteLine("Menu");
Console.WriteLine("Pulse 1 para realizar insertar usuarios");
Console.WriteLine("Pulse 2 para realizar una actualizacion de usuarios");
var Menu = Convert.ToInt32(Console.ReadLine());


switch (Menu) { 

    case 1:
        int bucle = 1;
        while (bucle == 1) {
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
        bucle= Convert.ToInt32(Console.ReadLine());
        }
        break;
    case 2:
        Console.WriteLine("Actualizar datos");
        Console.WriteLine("Ingresa el ID del usuario a actualizar");
        var UsuarioIndividual = CrudUsuarios.UsuarioIndividual(Convert.ToInt32(Console.ReadLine()));
        if (UsuarioIndividual == null)
        {
            Console.WriteLine("El usuario no existe");
        }
        else {
            Console.WriteLine($"Nombre {UsuarioIndividual.Nombre} , Apellido {UsuarioIndividual.Apellido}");


            Console.WriteLine("Para actulizar nombre coloca el # 1");

            Console.WriteLine("Para actulizar el apellido coloca el # 2");

            var Lector = Convert.ToInt32(Console.ReadLine());
            if (Lector == 1)
            {
                UsuarioIndividual.Nombre = Console.ReadLine();
            }
            else {
                UsuarioIndividual.Apellido= Console.ReadLine();
            }
            CrudUsuarios.ActualizarUsuario(UsuarioIndividual, Lector);

        }
        break;
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