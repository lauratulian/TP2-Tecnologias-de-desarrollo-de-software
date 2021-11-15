using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripciones : BusinessEntity
    {
        #region Variables
        private string _Condicion;
        private int _IDCurso;
        private int _Nota;
        private int _IDAlumno;
        #endregion

        #region Propiedades
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        public int IDAlumno
        {
            get { return _IDAlumno; }
            set { _IDAlumno = value; }
        }

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }
        #endregion
    }
}