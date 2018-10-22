using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entidades;

namespace Oblogatorio_P2_V1
{
    public partial class AltaApartamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (drpTipoApto.Text == "Oficina")
                {
                    vivienda.Visible = false;
                    oficina.Visible = true;
                }
                else
                {
                    vivienda.Visible = true;
                    oficina.Visible = false;
                }
            }

            if (IsPostBack)
            {
                if (Session["Edificio"] != null)
                {
                    Sistema edi = Session["Edificio"] as Sistema;
                }
            }
            else
            {
                cargarDrpEdificios();
            }

        }
        public void cargarDrpEdificios()
        {
            //CREAMOS UN OBJETO QUE A SU VEZ CONTENGA LOS DATOS DE LA SESIÓN 
            Sistema miSistema = retornarEdificio();
            //string ret = (miSitema != null) ? "No es null " : "es null";
            //System.Windows.Forms.MessageBox.Show(ret);

            if (miSistema.ColEdificios.Count != 0)
            {
                //   System.Windows.Forms.MessageBox.Show(miSitema.ColEdificios.Count.ToString());
                //Cargamos el DRP de Edifios 

                drpEdificio.DataSource = miSistema.ColEdificios;
                drpEdificio.DataTextField = "Nombre";
                drpEdificio.DataValueField = "Nombre";
                drpEdificio.DataBind();
            }
            else
            {
                //Redireccionamos al form para dar de alta el edificio
                System.Windows.Forms.MessageBox.Show("No hay edificios cargados");
                Response.Redirect("AltaEdificios.aspx");
                //lblResultado.Text = "No hay Edificios Cargados ";
            }


        }


        protected void btnAltaApartamento_Click(object sender, EventArgs e)
        {
            //Capturo los datos generales

            int piso = Convert.ToInt32(txtPiso.Text);
            int numero = Convert.ToInt32(txtNumeroApto.Text);
            int metraje = Convert.ToInt32(txtMetraje.Text);
            decimal precioBase = Convert.ToDecimal(txtPrecioBase.Text);
            string orientacion = drpOrientacion.Text;
            // System.Windows.Forms.MessageBox.Show(drpEdificio.Text);
            Sistema miSistema = retornarEdificio();

            Edificio edifContenedor = miSistema.buscarEdificio(drpEdificio.Text);

            //System.Windows.Forms.MessageBox.Show(edifContenedor.Nombre);
            //Lógica para dar de alta apartamentos
            if (drpTipoApto.Text == "Oficina")
            {
                try
                {
                    //Lógica para dar de alta una Oficina 
                    int puestos = Convert.ToInt32(txtPuestos.Text);
                    string txtEquipamiento = drpEquipamiento.Text.ToUpper();
                    //  System.Windows.Forms.MessageBox.Show(puestos.ToString());
                    //System.Windows.Forms.MessageBox.Show(drpEquipamiento.Text.ToUpper());
                    bool tieneEquipamiento = (txtEquipamiento.Trim() == "SI") ? true : false;
                    // System.Windows.Forms.MessageBox.Show(tieneEquipamiento.ToString());
                    Oficina apto = new Oficina(piso, numero, metraje, precioBase, orientacion, puestos, tieneEquipamiento, edifContenedor);
                  
                    if (miSistema.altaApartamento(apto))
                    {
                        //Muestro resultado
                        lblResultado.Text = "Se agrego la Oficina correctamente";
                        //System.Diagnostics.Debug.WriteLine( ofi );
                        //Limpio los campos
                        txtPiso.Text = "";
                        txtNumeroApto.Text = "";
                        txtMetraje.Text = "";
                        txtPrecioBase.Text = "";
                        drpOrientacion.SelectedIndex = 0;
                        txtPuestos.Text = "";
                        drpEquipamiento.SelectedIndex = 0;
                    }
                    else
                    {
                        //Muestro mensaje de error
                        lblResultado.Text = "No se pudo agregar, revise los datos ingresados";
                    }
                }
                catch (Exception ex)
                {
                    //Si hay un error de tipeo se lo devuelvo al usuario como error
                    lblResultado.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    //lógica para dar de alta Vivienda
                  //  System.Windows.Forms.MessageBox.Show(txtCantDormitorios.Text);
                    int canDormitorios = Convert.ToInt32(txtCantDormitorios.Text);
                    int canBanios = Convert.ToInt32(txtCantBanios.Text);
                    bool tieneGaraje = (drpTieneGaraje.Text == "Si") ? true : false;
                    Vivienda apto = new Vivienda(piso, numero, metraje, precioBase, orientacion, canDormitorios, canBanios, tieneGaraje, edifContenedor);
                    if (miSistema.altaApartamento(apto))
                    {
                        //Muestro resultado
                        lblResultado.Text = "Se agrego la Vivienda correctamente";
                        //Limpio los campos
                        txtPiso.Text = "";
                        txtNumeroApto.Text = "";
                        txtMetraje.Text = "";
                        txtPrecioBase.Text = "";
                        drpOrientacion.SelectedIndex = 0;
                        txtCantDormitorios.Text = "";
                        txtCantBanios.Text = "";
                        drpTieneGaraje.SelectedIndex = 0;

                    }
                    else
                    {
                        //Muestro mensaje de error
                        lblResultado.Text = "No se pudo agregar, revise los datos aregados";
                    }
                }
                catch (Exception ex)
                {
                    //Si hay un error de tipeo se lo devuelvo al usuario como error
                    lblResultado.Text = ex.Message;
                }
            }

        }

        private Sistema retornarEdificio()
        {
            if (Session["Sistema"] == null)
            {
                Session["Sistema"] = new Sistema();
            }

            return Session["Sistema"] as Sistema;
        }
        protected void grdEdificios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdApartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpTipoApto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpTipoApto.Text == "Oficina")
            {
                vivienda.Visible = false;
                oficina.Visible = true;
            }
            else
            {
                vivienda.Visible = true;
                oficina.Visible = false;
            }
        }
    }
}