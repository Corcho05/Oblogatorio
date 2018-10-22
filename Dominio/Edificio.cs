using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Edificio
    {
        #region Atributos
        private string nombre;
        private string direccion;
        #endregion
        #region Propiedades 
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }
        #endregion
        #region Constructores

        public Edificio() { }
        public Edificio(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
        }
        #endregion
        #region Métodods
      
        #endregion
    }
}
