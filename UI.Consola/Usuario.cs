using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _UsuarioNegocio;

        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }

        }
        public Usuarios()
        {
        }

        public Usuarios(Business.Logic.UsuarioLogic x)
        {
            this.UsuarioNegocio = x;
        }

        public void Menu()
        {
            Boolean band = true;
            while (band)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1- Listo General");
                Console.WriteLine("2- Consulta");
                Console.WriteLine("3- Agregar");
                Console.WriteLine("4- Modificacar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                ConsoleKeyInfo opcion = Console.ReadKey();
                switch (opcion.Key)
                {
                    case (ConsoleKey.D1):
                        {
                            ListadoGeneral();
                            break;
                        }
                    case (ConsoleKey.D2):
                        {
                            Consultar();
                            break;
                        }
                    case (ConsoleKey.D3):
                        {
                            Agregar();
                            break;
                        }
                    case (ConsoleKey.D4):
                        {
                            Modificar();
                            break;
                        }
                    case (ConsoleKey.D5):
                        {
                            Eliminar();
                            break;
                        }
                    case (ConsoleKey.D6):
                        {
                            band = false;
                            break;
                        }
                }
                Console.ReadKey();
            }
        }


        public void ListadoGeneral()
        {
            this.UsuarioNegocio = new UsuarioLogic();
            Console.Clear();
            foreach (Usuario usr in this.UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                this.UsuarioNegocio = new UsuarioLogic();
                Console.Write("Ingrese el ID del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(this.UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            this.UsuarioNegocio = new UsuarioLogic();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingresar Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingresar Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingresar Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            this.UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }
        public void Modificar()
        {
            try
            {
                this.UsuarioNegocio = new UsuarioLogic();
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitacion de Usuario (1-Si/otro - No)");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                this.UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }
        public void Eliminar()
        {
            try
            {
                this.UsuarioNegocio = new UsuarioLogic();
                Console.Clear();
                Console.Write("Ingrese el ID del usuario e eliminar:");
                int ID = int.Parse(Console.ReadLine());
                this.UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}
