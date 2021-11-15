using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        #region Variables
        private string _Descripcion;
        private int _IDEspecialidad;
        #endregion

        #region Propiedades
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int IDEspecialidad
        {
            get { return _IDEspecialidad; }
            set { _IDEspecialidad = value; }
        }
        #endregion
    }
}