using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Oficina : Apartamento
    {
        private int puestos;
        private bool tieneEquipamientos;
        private decimal costoTotal;
        private const decimal costoFijo = 100;//Este es el costo fijo aplicable a cada puesto de trabajo expresado en dólares

        public int Puestos
        {
            get { return puestos; }
            set { puestos = value; }
        }

        public bool TieneEquipamientos
        {
            get { return tieneEquipamientos; }
            set { tieneEquipamientos = value; }
        }

        public decimal CostoTotal
        {
            get
            {
                return costoTotal;
            }

            set
            {
                costoTotal = this.calcularPrecioVenta();
            }
        }
         public string TipoApto
        {
            get { return "Oficina"; }
        }
        public string NombreEdificio
        {
            get { return EdifContenedor.Nombre; }
        }
        public Oficina() { }
        //Constructor completo o Sobrecaragado
        //Recibe todos los parametros de cada propiedad tanto de la clase base como las propiedades particulares de
        //la clase derivada
        public Oficina(int piso, int numero, int metraje, decimal precioBase, string orientacion, int puestos, bool tieneEquipamiento, Edificio edifContenedor)
           : base(piso, numero, metraje, precioBase, orientacion, edifContenedor)//indican cuales son los parametros que son de la clase base
        {
            this.Puestos = puestos;
            this.TieneEquipamientos = tieneEquipamientos;
            this.CostoTotal = CostoTotal;
        }
        public override decimal calcularPrecioVenta()
        {
            decimal costoTotalVenta = base.calcularPrecioVenta() + (costoFijo * this.Puestos);
            if (this.TieneEquipamientos)
            {

                costoTotalVenta += costoTotalVenta * new decimal(1.10); 
            }

            return costoTotalVenta;
        }
    }
}
