<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaEdificios.aspx.cs" Inherits="Oblogatorio_P2_V1.AltaEdificios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.css" />
    <title>Empresa Constructora</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h1>Primer Obligatorio P2 - POO </h1>
                <h2>Alta de Edificios</h2>
            </div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <ul class="nav navbar-nav">
                        <li><a href="Index.aspx">Página Principal</a></li>
                        <li class="active"><a href="AltaEdificios.aspx">Alta Edificios</a></li>
                        <li><a href="AltaApartamentos.aspx">Alta Apartamentos</a></li>
                        <li><a href="AltaClienteComprador.aspx">Alta Clientes Compradores </a></li>
                        <li><a href="Listados.aspx">Listados</a></li>
                    </ul>
                </div>
            </nav>
            <h4>Dar de alta Edificios</h4>
            <div class="form-group">
                <asp:Label runat="server" >Nombre:</asp:Label>
                <asp:TextBox Cssclass="form-control" runat="server" ID="txtNombre" />
                <asp:RequiredFieldValidator id="requiredPrecio" ControlToValidate="txtNombre" ErrorMessage="El nombre es ¡OBLIGATORIO!" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" >Dirección:</asp:Label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtDireccion" />
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="txtDireccion" ErrorMessage="La dirección es ¡OBLIGATORIO!" runat="server" />
            </div>
            <div class="bottom">
                <asp:Button runat="server" ID="btnAltaEdificio" OnClick="btnAltaEdificio_Click" CssClass="btn btn-success" Text="Enviar"></asp:Button>
            </div>
            <br />

            <div class="alert-success" id="resultado">
                <p>
                    <b>Resultado:</b><asp:Label runat="server" ID="lblResultado"></asp:Label>
                </p>
            </div>
            <br />
            <div class="table-responsive">
                  <asp:GridView ID="GridView1" runat="server" CssClass="table table-responsive table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </div>
    </form>
    <!-- Última versión de jQuery minified -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Boostrap ES PARA LOS ESTILOS CSS de la Página -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" ></script>
    <!--Esta importación es para usar el plugin de datatable de jQuery-->
    <script type="text/javascript" src="https://cdn.datatables.net/v/bs/dt-1.10.15/datatables.min.js"></script>
    
</body>
</html>
