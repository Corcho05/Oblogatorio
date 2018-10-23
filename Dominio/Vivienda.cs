using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vivienda : Apartamento
    {
        private int cantDormitorios;
        private int cantBanios;
        private bool tieneGaraje;
        private const decimal costoFijo = 3000;//Este es el costo fijo aplicable si cuenta con garaje y está expresado en dólares
        private decimal costoTotal;

        public int CantDormitorios
        {
            get { return cantDormitorios; }
            set { cantDormitorios = value; }
        }
        public int CantBanios
        {
            get { return cantBanios; }
            set { cantBanios = value; }
        }

        public decimal CostoTotal
        {
            get
            {
                return costoTotal;
            }

            private set
            {
                costoTotal = this.calcularPrecioVenta();
            }
        }

        public bool TieneGaraje
        {
            get
            {
                return tieneGaraje;
            }

            set
            {
                tieneGaraje = value;
            }
        }

        public string NombreEdificio
        {
            get { return EdifContenedor.Nombre; }
        }

        public string TipoApto
        {
            get { return "Vivienda"; }
        }
        public Vivienda() { }
        //Constructor completo o Sobrecaragado
        //Recibe todos los parametros de cada propiedad tanto de la clase base como las propiedades particulares de
        //la clase derivada
        public Vivienda(int piso, int numero, int metraje, decimal precioBase, string orientacion, int cantdormitorios, int cantBanios, bool tieneGaraje, Edificio edifContenedor)
           : base(piso, numero, metraje, precioBase, orientacion, edifContenedor)//indican cuales son los parametros que son de la clase base
        {
            this.CantDormitorios = cantdormitorios;
            this.CantBanios = cantBanios;
            this.TieneGaraje = tieneGaraje;
            this.CostoTotal = CostoTotal;

        }
        //suma un 5% si tienen entre 1 y 2 dormitorios, un 10% si tienen entre 3 y 4 y 
        // un 20% si tienen más de 4  dormitorios.
        // Sobreescribimos el método de la clase padre y le sumamos un porcentaje 
        //dependiendo de la cantidad de dormitorios 
        public override decimal calcularPrecioVenta()
        {
            int cantDorm = this.CantDormitorios;

            decimal totalPrecioVenta = base.calcularPrecioVenta();

            if (cantDorm >= 1 && cantDorm <= 2)
            {
                totalPrecioVenta += totalPrecioVenta * new decimal(1.05);
            }
            else if (cantDorm > 4)
            {
                totalPrecioVenta += totalPrecioVenta * new decimal(2.0); ;
            }
            else
            {
                totalPrecioVenta += totalPrecioVenta * new decimal(1.10);
            }

            if (this.Orientacion == "Norte" || this.Orientacion == "NorEste" || this.Orientacion == "NorOeste")
            {
                totalPrecioVenta += totalPrecioVenta * new decimal(1.15);
            }

            if (this.TieneGaraje)
            {
                totalPrecioVenta += costoFijo;
            }

            return totalPrecioVenta;
        }
    }
}
