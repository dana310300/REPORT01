<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="REPORT01.Web.SimpleReports._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<h2>
        ASP.NET
    </h2>
    <p>
        Para obtener más información acerca de ASP.NET, visite <a href="http://www.asp.net" title="Sitio web de ASP.NET">www.asp.net</a>.
    </p>
    <p>
        También puede encontrar <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="Documentación de ASP.NET en MSDN">documentación sobre ASP.NET en MSDN</a>.
    </p>--%>
    <ul>
        <li>
            <a href="~/ReportView/Viwer01.aspx?id=2">Lección 1:Runtime Reporte Simple</a>   
                 
        </li>
        <li>
            <a href="~/ReportView/Viwer01.aspx?id=3">Lección 2:Reporte Simple</a>   
                 
        </li>
        <li>
            <a href="/ReportView/Viwer01.aspx?id=4">Lección 3:Reporte Agrupaciones</a>   
                 
        </li>
        <li>
            <a href="/ReportView/Viwer01.aspx?id=5">Lección 4:Repote con Detalle V1</a>   
                 
        </li>
        <li>
            <a href="/ReportView/Viwer01.aspx?id=6">Lección 5:Runtime Reporte Agrupaciones</a>   
                 
        </li>
         <li>
            <a href="/ReportView/Viwer01.aspx?id=7">Lección 6:Reporte con Detalle V2</a>   
                 
        </li>
         <li>
            <a href="/ReportView/Viwer01.aspx?id=8">Lección 7:Eventos y Agregaciones Personalizadas </a>   
                 
        </li>
        <li>
            <a href="/ReportView/Viwer01.aspx?id=9">Lección 8:Reportes Graficas </a>   
                 
        </li>
        <li>
            <a href="/ReportView/Viwer01.aspx?id=10">Lección 8:Reportes con Datos y Graficas </a>   
                 
        </li>
    </ul>
</asp:Content>
