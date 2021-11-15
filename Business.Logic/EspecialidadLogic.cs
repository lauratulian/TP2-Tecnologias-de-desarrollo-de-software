using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Business.Logic
{
    public class EspecialidadLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.EspecialidadAdapter _EspecialidadData;
        #endregion

        #region Constructores
        public EspecialidadLogic() { }
        #endregion

        #region Propiedades
        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }
        #endregion

        #region Metodos
        public List<Especialidad> GetAll()
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
            return this.EspecialidadData.GetAll();
        }
        public Especialidad GetOne(int ID)
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
            return this.EspecialidadData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
            this.EspecialidadData.Delete(ID);
        }

        public void Save(Especialidad esp)
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
            this.EspecialidadData.Save(esp);
        }
        #endregion
    }
}
