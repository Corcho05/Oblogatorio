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
        private List<Apartamento> colApartamentos = new List<Apartamento>();
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

        public List<Apartamento> ColApartamentos
        {
            get
            {
                return colApartamentos;
            }

           private set
            {
                colApartamentos = value;
            }
        }
        #endregion
        #region Constructores

        public Edificio()
        {
            //this.ColApartamentos = new List<Apartamento>();
        }
        public Edificio(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            //this.ColApartamentos = new List<Apartamento>();
        }
        #endregion
        #region Métodods
        public Apartamento filtroEdificios(int rangoMenor, int rangoMayor, string orientacion)
        {
            Apartamento apto = null;
            int i = 0;
            bool flag = false;
            while (i < this.ColApartamentos.Count && !flag)
            {
                if (ColApartamentos[i].Metraje >= rangoMenor && ColApartamentos[i].Metraje <= rangoMayor && ColApartamentos[i].Orientacion == orientacion)
                {
                    apto = ColApartamentos[i];
                    flag = true;
                }
                i++;
            }
            return apto;
        }

        public bool existeApartamento(Apartamento nuevo)
        {
            //Lógica para buscar el apartamento dentro de la lista de los mismos
            for (int i = 0; i < ColApartamentos.Count; i++)
            {
                if (ColApartamentos[i].EdifContenedor.Nombre == nuevo.EdifContenedor.Nombre)
                {
                    if (ColApartamentos[i].Numero == nuevo.Numero)
                    {
                        return true;
                    }
                    else if (ColApartamentos[i].Piso == nuevo.Piso && ColApartamentos[i].Orientacion == nuevo.Orientacion)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
