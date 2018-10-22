using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;
using System.Windows.Markup;
using Entidades;
using System.Web.Services;//PARA USAR EL MÉTODO WEB

namespace Oblogatorio_P2_V1
{
    public partial class AltaEdificios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sistema miSistema = retornarEdificio();

            if (miSistema.ColEdificios.Count != 0)
            {
                desplegarLista();
            }
        }

        protected void btnAltaEdificio_Click(object sender, EventArgs e)
        {
            //EN ESTA FUNCIÓN HAY QUE CONTROLAR LOS DATOS que ingresen 
            try { 
            //Capturo los datos ingresados  
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            
            Edificio objEdificio = new Edificio(nombre, direccion);

            Sistema miSistema = retornarEdificio();
            
           //Ingreso
            if (miSistema.AgregarEdificio(objEdificio))
            {
                lblResultado.Text = "Se ha ingresado correctamente el edificio ";
                //desplegarLista();
            }
            else
            {
                lblResultado.Text = "Ya existe un Edificio con ese nombre y/o dirección";
            }
            }
            catch (Exception ex)
            {
                lblResultado.Text = ex.Message;
            }

        }

        //ESTE MÉTODO DESPLIEGA EN LA GRID VIEW LOS DATOS  LOA EDIFICIOS
        public void desplegarLista()
        {
            //CREAMOS UN OBJETO QUE A SU VEZ CONTENGA LOS DATOS DE LA SESIÓN 
            Sistema miSistema = retornarEdificio();
            // System.Windows.Forms.MessageBox.Show(miSistema.ColEdificios.Count.ToString());

            if (miSistema != null)
            {
                //SI NO ES VACÍO LE INDICAMOS A LA GV DE DONDE SACA LOS DATOS
                GridView1.DataSource = miSistema.ColEdificios;// ESTA LLAMADA ACCEDE A LA PROPIEDAD GET(OBTENER DATOS) DEL OBJ EDIFICIO 
                GridView1.DataBind();
            }
            else
                lblResultado.Text = "No hay Edificios";

        }

        private Sistema retornarEdificio()
        {
            if (Session["Sistema"] == null)
            {
                Session["Sistema"] = new Sistema();
            }

            return Session["Sistema"] as Sistema;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
