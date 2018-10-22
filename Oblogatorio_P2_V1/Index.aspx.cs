using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Oblogatorio_P2_V1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Edificio obEdi1 = new Edificio("Vitta", "Jose P Varela");
                Edificio obEdi2 = new Edificio("Vitta2", "Jose P Varela2");

                Sistema miSistema = retornarEdificio();
                miSistema.AgregarEdificio(obEdi1);
                miSistema.AgregarEdificio(obEdi2);
              
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
    }

}
