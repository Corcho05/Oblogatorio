<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listados.aspx.cs" Inherits="Oblogatorio_P2_V1.Listados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>Empresa Construcción</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="jumbotron">
                <h1>Primer Obligatorio P2 - POO </h1>
                <h2>Listados</h2>
            </div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <ul class="nav navbar-nav">
                        <li><a href="Index.aspx">Página Principal</a></li>
                        <li><a href="AltaEdificios.aspx">Alta Edificios</a></li>
                        <li><a href="AltaApartamentos.aspx">Alta Apartamentos</a></li>
                        <li class="active"><a href="Listados.aspx">Listados</a></li>
                    </ul>
                </div>
            </nav>
            <div class="row">
                <div class="col-md-4">
                  <asp:label runat="server"> <h4> Listar los Edificios Filtrados </h4></asp:label>
                    <div class="form-group">
                        <asp:label runat="server">Rango menor a buscar en (M2)</asp:label>
                        <asp:TextBox ID="txtRangoMenorMetros" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                       <asp:label runat="server">Rango mayor a buscar en M2: </asp:label>
                        <asp:TextBox ID="txtRangoMayorMetros" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:label runat="server">Orientación:</asp:label>
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
                    <asp:Button runat="server" ID="btnBuscarEdificioRangoOri" ClsClass="btn btn-success" Text="Listar" OnClick="btnBuscarEdificioRangoOri_Click" />
                </div>
                <div class="col-md-4">
                   <asp:label runat="server"><h4> Buscar Apartamentos dentr de un rango de Precio(u$S)</h4></asp:label>
                    <div class="col-sm">
                       <asp:label runat="server"> Rango menor de precio a buscar(u$S)  </asp:label>
                        <asp:TextBox ID="txtRangoMenorPrecio" runat="server" CssClass="form-control" />
                    </div>
                     <div class="form-group">
                       <asp:label runat="server"> Rango mayor de precio a buscar (u$S)</asp:label>
                        <asp:TextBox ID="txtRangoMayorPrecio" runat="server" CssClass="form-control" />
                    </div>
                        <asp:Button runat="server" ID="btnBuscarAptoRangoPrecio" class="btn btn-success" Text="Listar" OnClick="btnBuscarAptoRangoPrecio_Click" />

                </div>
                <div class="col-md-4">
                   <asp:label runat="server"> <h4>Listar los Aartamentos dentro de un rango en metros</h4></asp:label>
                    <div class="form-group">
                        <asp:label runat="server">Rango menor a buscar en (M2)</asp:label>
                        <asp:TextBox ID="txtRangoMenorMetros2" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                       <asp:label runat="server">Rango mayor a buscar en M2: </asp:label>
                        <asp:TextBox ID="txtRangoMayorMetros2" runat="server" CssClass="form-control" />
                    </div>
                    <asp:Button runat="server" ID="btnBuscarAptoRangoMetros" class="btn btn-success" Text="Listar" OnClick="btnBuscarAptoRangoMetros_Click" />

                </div>
            </div>
             <br />
            <div class="alert-success" id="resultado">
                <p>
                    <b>Resultado:</b><asp:Label runat="server" ID="lblResultado"></asp:Label>
                </p>
            </div>
            <br />
            <div class="table-responsive">
                <asp:GridView ID="grdEdificios" runat="server" AutoGenerateColumns="False" CssClass="table table-responsive table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Edificio" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="table-responsive">
                <asp:GridView ID="grdApartamentos" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-bordered" >
                    <Columns>
                        <asp:boundfield datafield="NombreEdificio" readonly="true" headertext="Nombre Edificio"/>
                        <asp:BoundField DataField="Piso" ReadOnly="true" HeaderText="Piso" />
                        <asp:BoundField DataField="Numero" ReadOnly="true" HeaderText="Número Apto" />
                        <asp:BoundField DataField="Orientacion" ReadOnly="true" HeaderText="Orientación" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
