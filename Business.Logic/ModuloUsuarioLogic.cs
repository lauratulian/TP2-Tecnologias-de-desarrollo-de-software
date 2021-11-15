using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;


namespace Business.Logic
{
    public class ModuloUsuarioLogic
    {
        private Data.Database.ModuloUsuarioAdapter _ModuloUsuarioData;

        public Data.Database.ModuloUsuarioAdapter ModuloUsuarioData
        {
            get { return _ModuloUsuarioData; }
            set { _ModuloUsuarioData = value;  }
        }

        public ModuloUsuario GetOne(int ID, int modulo)
        {
            this.ModuloUsuarioData = new ModuloUsuarioAdapter();
            return ModuloUsuarioData.GetOne(ID, modulo);
        }
    }
}
