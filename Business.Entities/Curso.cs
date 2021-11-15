using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        #region Variables
        private int _AnioCalendario;
        private int _Cupo;
        private int _IDComision;
        private int _IDMateria;
        private string _Descripcion;
  
        #endregion

        #region Propiedades
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        #endregion
    }
}