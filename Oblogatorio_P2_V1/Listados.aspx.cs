using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Oblogatorio_P2_V1
{
    public partial class Listados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private Sistema retornarEdificio()
        {
            if (Session["Sistema"] == null)
            {
                Session["Sistema"] = new Sistema();
            }

            return Session["Sistema"] as Sistema;
        }

        protected void btnBuscarEdificioRangoOri_Click(object sender, EventArgs e)
        {
            Sistema miSistema = retornarEdificio();

            try
            {
                int rangoMenor = Convert.ToInt32(txtRangoMenorMetros.Text);
                int rangoMayor = Convert.ToInt32(txtRangoMayorMetros.Text);
                string orientacion = drpOrientacion.Text;

                //Se carga la gried view con los datos

                grdEdificios.DataSource = miSistema.buscarEdiXOriMetros(rangoMenor,rangoMayor,orientacion);// ESTA LLAMADA ACCEDE A LA PROPIEDAD GET(OBTENER DATOS) DEL OBJ EDIFICIO 
                grdEdificios.DataBind();


            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message;
            }

        }


        protected void btnBuscarAptoRangoPrecio_Click(object sender, EventArgs e)
        {
            Sistema miSistema = retornarEdificio();

            try
            {
                //Capturo los datos
                decimal rangoMenor = Convert.ToDecimal(txtRangoMenorPrecio.Text);
                decimal rangoMayor = Convert.ToDecimal(txtRangoMayorPrecio.Text);

                grdApartamentos.DataSource = miSistema.buscarAproRangoPrecio(rangoMenor,rangoMayor);
                grdApartamentos.DataBind();


            }
            catch(Exception ex)
            {

            }
        }
        protected void btnBuscarAptoRangoMetros_Click(object sender, EventArgs e)
        {
            Sistema miSistema = retornarEdificio();

            try
            {
                //Capturo los datos
                int rangoMenor = Convert.ToInt32(txtRangoMenorMetros2.Text);
                int rangoMayor = Convert.ToInt32(txtRangoMayorMetros2.Text);

                //llamo al método que me devuelve la cantidad de apartamentos que cumplen las condiciones

                int ret = miSistema.existenAptosRango(rangoMenor, rangoMayor);

                if (ret > 0)
                {
                    lblResultado.Text = "Existen " + ret + " apartamentos que cumplen las condiciones.";

                }
                else
                {
                    lblResultado.Text = "No existe apartametos con esos parámetros de búsqueda";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message;
            }
        }
    }
}