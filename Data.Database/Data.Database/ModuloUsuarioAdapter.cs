using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {

        public Business.Entities.ModuloUsuario GetOne(int ID, int modulo)
        {
            ModuloUsuario mu = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("select * from modulos_usuarios where id_usuario=@id and id_modulo = @modulo", sqlConn);
                cmdModulo.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdModulo.Parameters.Add("@modulo", SqlDbType.Int).Value = modulo;
                SqlDataReader drModuloUsu = cmdModulo.ExecuteReader();
                if (drModuloUsu.Read())
                {
                    mu.PermiteAlta = (bool)drModuloUsu["alta"];
                    mu.PermiteBaja = (bool)drModuloUsu["baja"];
                    mu.PermiteConsulta = (bool)drModuloUsu["consulta"];
                    mu.PermiteModificacion = (bool)drModuloUsu["modificacion"];
                    
                }
                drModuloUsu.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mu;
        }
    }
}
