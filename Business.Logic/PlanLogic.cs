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
    public class PlanLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.PlanAdapter _PlanData;
        private Data.Database.EspecialidadAdapter _EspecialidadData;
        #endregion

        #region Constructores
        public PlanLogic() { }
        #endregion

        #region Propiedades
        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }
        #endregion

        #region Metodos
        public List<Plan> GetAll()
        {
            this.PlanData = new Data.Database.PlanAdapter();
            return this.PlanData.GetAll();
        }

        public List<Especialidad> GetEspecialidades()
        {
            this.EspecialidadData = new Data.Database.EspecialidadAdapter();
            return this.EspecialidadData.GetAll();
        }
        public Plan GetOne(int ID)
        {
            this.PlanData = new Data.Database.PlanAdapter();
            return this.PlanData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.PlanData = new Data.Database.PlanAdapter();
            this.PlanData.Delete(ID);
        }

        public void Save(Plan plan)
        {
            this.PlanData = new Data.Database.PlanAdapter();
            this.PlanData.Save(plan);
        }
        #endregion
    }
}
