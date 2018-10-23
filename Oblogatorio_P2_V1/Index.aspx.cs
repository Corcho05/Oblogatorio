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
                //Datos de prueba pre cargados
                Edificio obEdi1 = new Edificio("Vitta", "Jose P Varela");
                Edificio obEdi2 = new Edificio("Vitta2", "Jose P Varela2");
                Edificio obEdi3 = new Edificio("Edificio Uno", "8 de Octubre");
                Oficina ofi1 = new Oficina(10, 1010, 70, 1000, "Norte", 4, true, obEdi1);
                Oficina ofi2 = new Oficina(11, 1110, 60, 1100, "Norte", 2, true, obEdi1);
                Oficina ofi3 = new Oficina(10, 1010, 70, 1000, "Norte", 4, true, obEdi2);
                Oficina ofi4 = new Oficina(12, 1210, 80, 1100, "Sur", 4, false, obEdi2);
                Oficina ofi5 = new Oficina(12, 1210, 80, 1100, "SurEste", 4, false, obEdi3);
                Oficina ofi6 = new Oficina(10, 1010, 60, 1100, "Norte", 4, true, obEdi3);
                Vivienda viv = new Vivienda(1, 10, 60, 1000, "Norte", 4, 2, false, obEdi1);
                Vivienda viv1 = new Vivienda(2, 210, 70, 1000, "Norte", 4, 2, false, obEdi1);
                Vivienda viv2 = new Vivienda(3, 310, 100, 1000, "Norte", 3, 1, true, obEdi2);
                Vivienda viv3 = new Vivienda(4, 410, 40, 1000, "Sur", 2, 1, false, obEdi2);
                Vivienda viv4 = new Vivienda(5, 510, 30, 1000, "Este", 1, 1, false, obEdi3);
                Vivienda viv5 = new Vivienda(6, 610, 70, 1000, "Sur", 3, 2, false, obEdi3);

                Sistema miSistema = retornarEdificio();


                miSistema.AgregarEdificio(obEdi1);
                miSistema.AgregarEdificio(obEdi2);
                miSistema.AgregarEdificio(obEdi3);

                miSistema.altaApartamento(ofi1);
                miSistema.altaApartamento(ofi2);
                miSistema.altaApartamento(ofi3);
                miSistema.altaApartamento(ofi4);
                miSistema.altaApartamento(ofi5);
                miSistema.altaApartamento(ofi6);
                miSistema.altaApartamento(viv);
                miSistema.altaApartamento(viv1);
                miSistema.altaApartamento(viv2);
                miSistema.altaApartamento(viv3);
                miSistema.altaApartamento(viv4);
                miSistema.altaApartamento(viv5);

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
