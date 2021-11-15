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
    public class CursoLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.CursoAdapter _CursoData;
        private Data.Database.MateriaAdapter _MateriaData;
        private Data.Database.ComisionAdapter _ComisionData;
        #endregion

        #region Constructores
        public CursoLogic() { }
        #endregion

        #region Propiedades
        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public Data.Database.MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public Data.Database.ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }
        #endregion

        #region Metodos
        public List<Curso> GetAll()
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetAll();
        }
        public void ActualizaCupo(int id)
        {
            this.CursoData = new Data.Database.CursoAdapter();
            this.CursoData.ActualizaCupo(id);
        }

        public List<Curso> GetAllDisponibles()
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetAllDisponibles();
        }

        public List<Materia> GetMaterias()
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
            return this.MateriaData.GetAll();
        }

        public List<Comision> GetComisiones()
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
            return this.ComisionData.GetAll();
        }
        public Curso GetOne(int ID)
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.CursoData = new Data.Database.CursoAdapter();
            this.CursoData.Delete(ID);
            
        }

        public void Save(Curso cur)
        {
            this.CursoData = new Data.Database.CursoAdapter();
            this.CursoData.Save(cur);
        }
        #endregion
    }
}
