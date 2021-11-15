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
    public class PersonaLogic: BusinessLogic
    {
        #region Variables

        private Data.Database.PersonaAdapter _PersonaData;
        private Data.Database.PlanAdapter _PlanData;
        #endregion

        #region Constructores
        public PersonaLogic() { }
        #endregion

        #region Propiedades

        public Data.Database.PersonaAdapter PersonaData
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }
        #endregion

        #region Metodos

        public List<Persona> GetAll()
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
            return this.PersonaData.GetAll();
        }

        public List<Plan> GetPlanes()
        {
            this.PlanData = new Data.Database.PlanAdapter();
            return this.PlanData.GetAll();
        }
        public Persona GetOne(int ID)
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
            return this.PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
            this.PersonaData.Delete(ID);
        }

        public void Save(Persona persona)
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
            this.PersonaData.Save(persona);
        }
        #endregion
    }
}
