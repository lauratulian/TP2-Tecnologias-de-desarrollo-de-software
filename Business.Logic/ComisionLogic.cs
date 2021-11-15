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
    public class ComisionLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.ComisionAdapter _ComisionData;
        private Data.Database.PlanAdapter _PlanData;
        #endregion

        #region Constructores
        public ComisionLogic() { }
        #endregion

        #region Propiedades

        public Data.Database.ComisionAdapter ComisionData
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }

        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        #endregion

        #region Metodos

        public List<Comision> GetAll()
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
            return this.ComisionData.GetAll();
        }

        public List<Plan> GetPlanes()
        {
            this.PlanData = new Data.Database.PlanAdapter();
            return this.PlanData.GetAll();
        }

        public Comision GetOne(int ID)
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
            return this.ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
            this.ComisionData.Delete(ID);
        }

        public void Save(Comision comision)
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
            this.ComisionData.Save(comision);
        }
        #endregion
    }
}
