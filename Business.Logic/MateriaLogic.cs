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
    public class MateriaLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.MateriaAdapter _MateriaData;
        private Data.Database.PlanAdapter _PlanData;
        #endregion

        #region Constructores
        public MateriaLogic() { }
        #endregion

        #region Propiedades
     
        public Data.Database.MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }
        #endregion

        #region Metodos
   
        public List<Materia> GetAll()
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
            return this.MateriaData.GetAll();
        }

        public List<Plan> GetPlanes()
        {
            this.PlanData = new Data.Database.PlanAdapter();
            return this.PlanData.GetAll();
        }
        public Materia GetOne(int ID)
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
            return this.MateriaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
            this.MateriaData.Delete(ID);
        }

        public void Save(Materia materia)
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
            this.MateriaData.Save(materia);
        }
        #endregion
    }
}
