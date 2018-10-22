using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Apartamento
    {
        #region Atributos 
        private int piso;
        private int numero;
        private int metraje;
        private decimal precioBase;
        private string orientacion;
        private string tipoApto;
        #endregion

        #region Asociaciones
        private Edificio edifContenedor;
        #endregion
        #region Propiedades
        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Metraje
        {
            get { return metraje; }
            set { metraje = value; }
        }

        public decimal PrecioBase
        {
            get
            { return precioBase; }
            set { precioBase = value; }
        }

        public string Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }

        public Edificio EdifContenedor
        {
            get
            {
                return edifContenedor;
            }

            set
            {
                edifContenedor = value;
            }
        }
        #endregion
        #region Métodos
        //Método que calcula el precio de venta
        public virtual decimal calcularPrecioVenta()
        {
            // LÓGICA PARA CÁLCULO DEPENDIENDO DE LAS VARIABLES DESCRITAS EN LA LETRA
            return this.Metraje * this.PrecioBase;
        }
        #endregion

        #region Constructores
        public Apartamento() { }

        public Apartamento(int piso, int numero, int metraje, decimal precioBase, string orientacion,Edificio edifContenedor)
        {

            this.Piso = piso;
            this.Numero = numero;
            this.Metraje = metraje;
            this.PrecioBase = precioBase;
            this.Orientacion = orientacion;
            this.EdifContenedor = edifContenedor;
            
        }

        #endregion
    }
}
