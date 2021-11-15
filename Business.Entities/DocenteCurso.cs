using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        #region Variables
        private int _Cargo;
        private int _IDCurso;
        private int _IDDocente;
        #endregion

        #region Propiedades
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }

        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }
        #endregion
    }
}