using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        #region Variables
        private string _NombreUsuario;
        private string _Clave;
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private bool _Habilitado;
        private int _IDPersona;
        #endregion

        #region Propiedades
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        public int IDPersona
        {
            get { return _IDPersona; }
            set { _IDPersona = value; }
        }
        #endregion
    }
}