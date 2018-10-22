using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteComprador : Cliente
    {
        private DateTime fechaCompra;
        private decimal costoTotal;
        private string vendedor;
        private List<Apartamento> misAptosComprados;

        public DateTime FechaCompra

        {
            get
            { return fechaCompra; }
            set { fechaCompra = value; }
        }

        public decimal CostoTotal
        {
            get { return costoTotal; }
            set { costoTotal = value; }
        }

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        public List<Apartamento> MisAptosComprados
        {
            get { return misAptosComprados; }
            private set { misAptosComprados = value; }
        }
        public ClienteComprador()
        {
            misAptosComprados = new List<Apartamento>();
        }

        public ClienteComprador(string nombre, string apellido, int documento, string direccion, int telefono,
            DateTime fechaCompra, string vendedor,Apartamento aptoComprado):
            base(nombre,apellido,documento,direccion,telefono, aptoComprado)
        {
            FechaCompra = fechaCompra;
            CostoTotal = CostoTotal;
            MisAptosComprados = new List<Apartamento>();
        }
    }
}
