using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;


namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        #region Variables 
        private Data.Database.UsuarioAdapter _UsuarioData;
        private Data.Database.PersonaAdapter _PersonaData;
        #endregion

        #region Constructores
        public UsuarioLogic()
        {
        }

        public UsuarioLogic(Data.Database.UsuarioAdapter x)
        {
            this.UsuarioData = x;
        }
        #endregion

        #region Propiedades
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public Data.Database.PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }
        #endregion

        #region Metodos
        public List<Usuario> GetAll()
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            return this.UsuarioData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            return this.UsuarioData.GetOne(ID);
        }
        public Persona GetPersona(int ID)
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
            return this.PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            this.UsuarioData.Delete(ID);
        }

        public void Save(Usuario usu)
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            this.UsuarioData.Save(usu);
        }

        public void InsertPermisos(int id, int tipodepersona)
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            this.UsuarioData.InsertPermisos(id, tipodepersona);
        }
        public Usuario Login(string user, string pass)
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
            return UsuarioData.Login(user, pass);
          
        }
        #endregion
    }
}
