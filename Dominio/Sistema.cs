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
        public List<Apartamento> ColApartamentos { get; private set; }

        public List<Oficina> listaOficina { get; private set; }

        public List<ClienteComprador> ColClientes { get; private set; }

        public Sistema()
        {
            this.ColEdificios = new List<Edificio>();
            this.ColApartamentos = new List<Apartamento>();
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
        //MÉTODO INCOMPLETO NO SE LOGRO FUNCIONAMIENTO
        public List<Apartamento> buscarAproRangoPrecio(decimal rangoMenor, decimal rangoMayor)
        {
            List<Apartamento> listaAux = new List<Apartamento>();


               

            foreach (var apto in ColApartamentos)
            {
                if (apto.calcularPrecioVenta() > rangoMenor && apto.calcularPrecioVenta() < rangoMayor)
                {
                    listaAux.Add(apto);
                }
            }
             /*  for (int i = 0; i < ColApartamentos.Count; i++)
               {
                   if (ColApartamentos[i].TipoApto == "Oficina") { 
                    apto = (Oficina) ColApartamentos[i];
                       if (apto.CostoTotal > rangoMenor && apto. .CostoTotal < rangoMayor)
                       {
                           listaAux.Add(ColApartamentos[i]);
                       }
                   }
                   else
                   {
                       apto = (Vivienda) ColApartamentos[i];
                       if (apto.CostoTotal > rangoMenor && apto. .CostoTotal < rangoMayor)
                       {
                           listaAux.Add(ColApartamentos[i]);
                       }
                   }



               }
               */
            return listaAux;

        }

        public List<Edificio> buscarEdiXOriMetros(int rangoMenor, int rangoMayor, string orientacion)
        {
            List<Edificio> listaEdiAux = new List<Edificio>();

            for (int i = 0; i < ColApartamentos.Count; i++)
            {
                if (ColApartamentos[i].Metraje >= rangoMenor && ColApartamentos[i].Metraje <= rangoMayor && ColApartamentos[i].Orientacion == orientacion)
                {
                    if (!listaEdiAux.Contains(ColApartamentos[i].EdifContenedor))
                        listaEdiAux.Add(ColApartamentos[i].EdifContenedor);

                }

            }

            return listaEdiAux;
        }

        public int  existenAptosRango(int rangoMenor, int rangoMayor)
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
        }

        public bool altaApartamento(Apartamento nuevo)
        {

            if (!existeApartamento(nuevo))
            {
                this.ColApartamentos.Add(nuevo);
                return true;
            }
            return false;
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
    }
}
