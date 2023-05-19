<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD_APLCIACIONWEB.Paginas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tittle" runat="server">
Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BODY" runat="server">
    <form runat="server">
       <br/>
       <div class="mx-auto" style="width:300px">
       
           <h2>Lista De Registros</h2>
       </div>
       <br/>
          <div class="container">
          <div class="row">
              <div class="col align-self-end">
                <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Create" OnClick="BtnCreate_Click"/>
              </div>
          </div>
       </div>
        <br />
            <div class="container row">
                <div class="table small">
                <asp:Gridview runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones de administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn form-control-sm btn-info" ID="BtnRead" OnClick="BtnRead_Click"/>
                                 <asp:Button runat="server" Text="Update" CssClass="btn form-contro-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                 <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:Gridview>
                </div>
            </div>
    </form>
</asp:Content>
