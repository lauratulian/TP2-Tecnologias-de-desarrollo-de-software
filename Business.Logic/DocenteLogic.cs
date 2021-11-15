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
    public class DocenteLogic : BusinessLogic
    {
        #region Variables

        private Data.Database.DocenteAdapter _DocenteData;
        private Data.Database.CursoAdapter _CursoData;
        #endregion

        #region Constructores
        public DocenteLogic() { }
        #endregion

        #region Propiedades
        public Data.Database.DocenteAdapter DocenteData
        {
            get { return _DocenteData; }
            set { _DocenteData = value; }
        }

        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }
        #endregion

        #region Metodos
        public List<DocenteCurso> GetAll()
        {
            this.DocenteData = new Data.Database.DocenteAdapter();
            return this.DocenteData.GetAll();
        }

        public List<Curso> GetCursos()
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetAll();
        }
        public DocenteCurso GetOne(int ID)
        {
            this.DocenteData = new Data.Database.DocenteAdapter();
            return this.DocenteData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.DocenteData = new Data.Database.DocenteAdapter();
            this.DocenteData.Delete(ID);
        }

        public void Save(DocenteCurso doc)
        {
            this.DocenteData = new Data.Database.DocenteAdapter();
            this.DocenteData.Save(doc);
        }
        #endregion
    }
}