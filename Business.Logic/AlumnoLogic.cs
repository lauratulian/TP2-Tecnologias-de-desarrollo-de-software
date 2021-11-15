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
    public class AlumnoLogic : BusinessLogic
    {
        #region Variables
        
        private Data.Database.AlumnoAdapter _AlumnoData;
        private Data.Database.CursoAdapter _CursoData;
        #endregion

        #region Constructores
        public AlumnoLogic() { }
        #endregion

        #region Propiedades
        public Data.Database.AlumnoAdapter AlumnoData
        {
            get { return _AlumnoData; }
            set { _AlumnoData = value; }
        }

        public Data.Database.CursoAdapter CursoData
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }
        #endregion

        #region Metodos
        public List<AlumnoInscripciones> GetAll()
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetAll();
        }

        
        
        public List<Curso> GetCursos()
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetAll();
        }

        public List<Curso> GetCursosAlumnos(int ID)
        {
            this.CursoData = new Data.Database.CursoAdapter();
            return this.CursoData.GetCursosAlumnos(ID);
        }

        public AlumnoInscripciones GetOne(int ID)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetOne(ID);
        }

        public List<AlumnoInscripciones> GetAlumnosDelCurso(int idCurso)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetAlumnosDelCurso(idCurso);
        }

        public List<AlumnoInscripciones> GetAlumnosDocente(int idDoc)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetAlumnosDocente(idDoc);
        }

        public List<AlumnoInscripciones> GetInscripciones(int idAlu)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetInscripciones(idAlu);
        }

        public List<Curso> GetCursoDocente(int idPersona)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            return this.AlumnoData.GetCursoDocente(idPersona);
        }

        public void Delete(int ID)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            this.AlumnoData.Delete(ID);
        }

        public void Save(AlumnoInscripciones alum)
        {
            this.AlumnoData = new Data.Database.AlumnoAdapter();
            this.AlumnoData.Save(alum);
        }

     
        #endregion

    }
}
