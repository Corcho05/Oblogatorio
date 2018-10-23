using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sistema
    {
        public List<Edificio> ColEdificios { get; private set; }
       // public List<Apartamento> ColApartamentos { get; private set; }  SE PASA PARA LA CLASE EDIFICIO

        public List<ClienteComprador> ColClientes { get; private set; }

        public Sistema()
        {
            
            this.ColEdificios = new List<Edificio>();
            //this.ColApartamentos = new List<Apartamento>();
        }


        public Edificio buscarEdificio(string nombreEdi)
        {
            Edificio objRet = null;
            for (int i = 0; i < ColEdificios.Count; i++)
            {
                if (ColEdificios[i].Nombre == nombreEdi)
                {
                    objRet = ColEdificios[i];
                }
            }
            return objRet;
        }

        //Método para dar de alta edificios
        public bool AgregarEdificio(Edificio nuevo)
        {

            if (!existeEdificio(nuevo))
            {
                this.ColEdificios.Add(nuevo);
                return true;
            }
            else
            {
                return false;
            }


        }
        //Método para ver que no exista el edificio a ingresar
        private bool existeEdificio(Edificio nuevo)
        {
            for (int i = 0; i < ColEdificios.Count; i++)
            {
                if (ColEdificios[i].Nombre == nuevo.Nombre || ColEdificios[i].Direccion == nuevo.Direccion)
                {
                    return true;
                }
            }
            return false;
        }

        /*public List<Apartamento> buscarAproRangoPrecio(decimal rangoMenor, decimal rangoMayor)
        {
            List<Apartamento> listaAux = new List<Apartamento>();
   

            foreach (var apto in ColEdificios)
            {
                if (apto.calcularPrecioVenta() > rangoMenor && apto.calcularPrecioVenta() < rangoMayor)
                {
                    listaAux.Add(apto);
                }
            }
             
            return listaAux;

        }*/
        public List<Edificio> buscarEdiXOriMetros(int rangoMenor, int rangoMayor, string orientacion)
        {
            List<Edificio> listaEdiAux = new List<Edificio>();
            Apartamento apto = null;

            foreach (var edif in ColEdificios)
            {
                apto = edif.filtroEdificios(rangoMenor, rangoMayor, orientacion);
                if (apto != null && !listaEdiAux.Contains(apto.EdifContenedor))
                {
                    listaEdiAux.Add(apto.EdifContenedor);
                }
            }

            return listaEdiAux;
        }

        /*public int  existenAptosRango(int rangoMenor, int rangoMayor)
        {
            int cantAptos = 0;

            for (int i = 0; i < ColApartamentos.Count; i++)
            {
               
                if (ColApartamentos[i].Metraje >= rangoMenor && ColApartamentos[i].Metraje <= rangoMayor)
                {
                    cantAptos++;

                }
            }

            return cantAptos;
        }  */

        

        public bool altaApartamento(Apartamento nuevo)
        {
            Edificio edif = nuevo.EdifContenedor;

            if (!edif.existeApartamento(nuevo))
            {
                edif.ColApartamentos.Add(nuevo);
                return true;
            }
            return false;
        }
      
    }
}
