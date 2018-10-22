<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaApartamentos.aspx.cs" Inherits="Oblogatorio_P2_V1.AltaApartamentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>Empresa Constructora</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h1>Primer Obligatorio P2 - POO </h1>
                <h2>Alta de Apartamentos</h2>
            </div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <ul class="nav navbar-nav">
                        <li><a href="Index.aspx">Página Principal</a></li>
                        <li><a href="AltaEdificios.aspx">Alta Edificios</a></li>
                        <li class="active"><a href="AltaApartamentos.aspx">Alta Apartamentos</a></li>
                        <li><a href="AltaClienteComprador.aspx">Alta Clientes Compradores </a></li>
                        <li><a href="Listados.aspx">Listados</a></li>
                    </ul>
                </div>
            </nav>
            <h4>Dar de alta Apartamentos</h4>
            <div class="form-group">
                <asp:Label runat="server">Seleccione el Edificio:</asp:Label>
                <asp:DropDownList ID="drpEdificio" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label runat="server">Tipo de Apartamento:</asp:Label>
                <asp:DropDownList ID="drpTipoApto" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpTipoApto_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Oficina</asp:ListItem>
                    <asp:ListItem>Vivienda</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label runat="server">Piso:</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtPiso" MaxLength="2" />
                <asp:RequiredFieldValidator id="requiredTxtPiso" ControlToValidate="txtPiso" ErrorMessage="El piso es ¡OBLIGATORIO!" runat="server"/>
            </div>
            <div class="form-group">
                <asp:Label runat="server">Número:</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumeroApto" />
                <asp:RequiredFieldValidator id="requiredTxtNumApto" ControlToValidate="txtNumeroApto" ErrorMessage="El número es ¡OBLIGATORIO!" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server">Metraje (m2):</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMetraje"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server">Precio Base:</asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecioBase" />
                 <asp:RequiredFieldValidator id="requiredPrecio" ControlToValidate="txtPrecioBase" ErrorMessage="El precio base es ¡OBLIGATORIO!" runat="server" />
            </div>
            <div>
                <div class="form-group">
                    <asp:Label runat="server">Orientación:</asp:Label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="drpOrientacion" AppendDataBoundItems="true">
                        <asp:ListItem Value="Norte">N</asp:ListItem>
                        <asp:ListItem Value="Sur">S</asp:ListItem>
                        <asp:ListItem Value="NorEste">NE</asp:ListItem>
                        <asp:ListItem Value="NorOeste">NO</asp:ListItem>
                        <asp:ListItem Value="SurEste">SE</asp:ListItem>
                        <asp:ListItem Value="SurOeste">SO</asp:ListItem>
                        <asp:ListItem Value="Oeste">O</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Panel runat="server" ID="vivienda">
                    <div class="form-group" id="dormitorios" runat="server">
                        <asp:Label runat="server">Cantidad de Dormitorios:</asp:Label>
                        <asp:TextBox runat="server" ID="txtCantDormitorios" CssClass="form-control" />
                         <asp:RequiredFieldValidator id="requiredCantDorm" ControlToValidate="txtCantDormitorios" ErrorMessage="La cantidad de dormitorios es ¡OBLIGATORIO!" runat="server" />
                    </div>
                    <div class="form-group" id="banios" runat="server">
                        <asp:Label runat="server">Cantidad de Baños:</asp:Label>
                        <asp:TextBox runat="server" ID="txtCantBanios" CssClass="form-control" />
                         <asp:RequiredFieldValidator id="requiredCantBanios" ControlToValidate="txtCantBanios" ErrorMessage="La cantidad de baños es ¡OBLIGATORIO!" runat="server" />
                    </div>
                    <asp:Label runat="server">Tiene Garaje:</asp:Label>
                    <asp:DropDownList ID="drpTieneGaraje" runat="server" CssClass="form-control">
                        <asp:ListItem>Si</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
                <asp:Panel runat="server" ID="oficina">
                    <div class="form-group" id="puestos" runat="server">
                        <asp:Label runat="server">Cantidad de Puestos de Trabajo:</asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPuestos" />
                         <asp:RequiredFieldValidator id="requiredPuestos" ControlToValidate="txtNumeroApto" ErrorMessage="La cantidad de puestos de trabajo es ¡OBLIGATORIO!" runat="server" />
                    </div>
                    <div class="form-group" id="equipamiento" runat="server">
                        <asp:Label runat="server">Tiene Equipamientos:</asp:Label>
                        <asp:DropDownList ID="drpEquipamiento" runat="server" CssClass="form-control">
                            <asp:ListItem Text="SI">Si</asp:ListItem>
                            <asp:ListItem Text="NO">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
            </div>
            <div class="bottom">
                <asp:Button runat="server" ID="btnAltaApartamento" OnClick="btnAltaApartamento_Click" CssClass="btn btn-success" Text="Enviar"></asp:Button>
            </div>
            <br />
            <div class="alert-success" id="resultado">
                <p>
                    <b>Resultado:</b><asp:Label runat="server" ID="lblResultado"></asp:Label>
                </p>
            </div>
            <br />
        </div>
    </form>
</body>
</html>
