using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;


        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        #region Metodos
        public List<Usuario> GetAll()
        {

            //Instanciamos el objeto lista a retornar
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                //Abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /*
                 * creamos un objeto SqlComand que sera la sentencia de SQL
                 * que vamos a ejecutar contra la base de datos
                 * (los datos de la BD usuario, contraseña, servidor, etc.
                 * estan en el connection string)
                */
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios", sqlConn);

                /*
                 * instanciamos un objeto DataReader que sera 
                 * el que recupera los datos de la BD
                 *
                */
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();

                /*
                 *Read( lee una fila de las devueltas por el comando sql
                 *carga los datos en drUsuarios para poder accederlos,
                 *devuleve verdadero mientras haya podido leer datos
                 *y avanza a la fila siguiente para el proximo read
                 */
                while (drUsuarios.Read())
                {
                    /*
                     * creamos un objeto Usuario de la capa de entidades para copiar
                     * los datos de la fida del DataReader al objeto de entidades
                     */
                    Usuario usr = new Usuario();

                    //ahora copiamos los datos de la fila al objeto
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["Email"];

                    //agregamos el objeto con datos a la lista que devolveremos
                    usuarios.Add(usr);
                }
                //cerramos el DataReader y la conexion a la BD
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            //devolvemos el objeto
            return usuarios;
        }



        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["Email"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                // abrimos la conexion
                this.OpenConnection();

                //creamos la sentencia sql y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("Delete usuarios where id_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);

            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario= @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido =@apellido, email=@email " +
                    "WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona)" +
                    "values (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona)" +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el ID que asigno al BD automaticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        #region Metodos de Permiso
        public void InsertPermisos(int id, int tipoPersona)
        {



            switch (tipoPersona)
            {
                case 1:
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 1;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m2 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 2;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        m2.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m3 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 3;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m3.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m4 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 4;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m4.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m5 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 5;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m5.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m6 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 6;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m6.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m7 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 7;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m7.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario m8 = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 8;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        m8.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    break;


                case 2:
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 1;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 2;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 3;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 4;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 5;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 6;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 7;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 8;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 0;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 0;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    break;

                case 3:
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 1;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 2;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 3;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 4;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 5;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 6;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 7;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    try
                    {

                        this.OpenConnection();
                        ModuloUsuario ml = new ModuloUsuario();
                        SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                            "values (@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                            "select @@identity", sqlConn);
                        cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = 8;
                        cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
                        cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = 1;
                        cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = 1;

                        ml.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al crear la persona", Ex);
                        throw ExcepcionManejada;
                    }
                    finally
                    {
                        this.CloseConnection();
                    }
                    break;

            }
        }

        #endregion
        public Usuario Login(string user, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where (nombre_usuario = @nombre_usuario and clave = @clave)", sqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = user;
                cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = pass;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.HasRows)
                {
                    while (drUsuarios.Read())
                    {
                        usr.ID = (int)drUsuarios["id_usuario"];
                        usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                        usr.Clave = (string)drUsuarios["clave"];
                        usr.Habilitado = (bool)drUsuarios["habilitado"];
                        usr.Nombre = (string)drUsuarios["nombre"];
                        usr.Apellido = (string)drUsuarios["apellido"];
                        usr.Email = (string)drUsuarios["email"];
                        usr.IDPersona = (int)drUsuarios["id_persona"];

                    }
                    drUsuarios.Close();
                    return usr;
                }
                else 
                { 
                    return null;
                }
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al iniciar sesion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void UpdateUsuarioPersona(int id_persona, int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET id_persona=@id_persona " +
                    "WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = id_persona;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

       


        #endregion
    }

}

