using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        #region Variables
        private int _IdUsuario;
        private int _IdModulo;
        private Boolean _PermiteAlta;
        private Boolean _PermiteBaja;
        private Boolean _PermiteModificacion;
        private Boolean _PermiteConsulta;
        #endregion

        #region Propiedades
        public int Usuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }
        public int Modulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        public Boolean PermiteAlta
        {
            get { return _PermiteAlta; }
            set { _PermiteAlta = value; }
        }
        public Boolean PermiteBaja
        {
            get { return _PermiteBaja; }
            set { _PermiteBaja = value; }
        }
        public Boolean PermiteModificacion
        {
            get { return _PermiteModificacion; }
            set { _PermiteModificacion = value; }
        }
        public Boolean PermiteConsulta
        {
            get { return _PermiteConsulta; }
            set { _PermiteConsulta = value; }
        }
        #endregion
    }
}