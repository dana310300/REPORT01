<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Viwer01.aspx.cs" Inherits="REPORT01.Web.SimpleReports.ReportView.Viwer01" %>
<%@ Register assembly="DevExpress.XtraReports.v12.1.Web, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <dx:ReportDocumentMap ID="ReportDocumentMap1" runat="server" ReportViewerID="ReportViewer1">
    </dx:ReportDocumentMap>
    
    <dx:ReportParametersPanel ID="ReportParametersPanel1" runat="server" ReportViewerID="ReportViewer1">
    </dx:ReportParametersPanel>
    
    <dx:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False" 
        ReportViewerID="ReportViewer1" Width="100%">
        <Items>
            <dx:ReportToolbarButton ItemKind="Search" />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton ItemKind="PrintReport" />
            <dx:ReportToolbarButton ItemKind="PrintPage" />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
            <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
            <dx:ReportToolbarLabel ItemKind="PageLabel" />
            <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
            </dx:ReportToolbarComboBox>
            <dx:ReportToolbarLabel ItemKind="OfLabel" />
            <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
            <dx:ReportToolbarButton ItemKind="NextPage" />
            <dx:ReportToolbarButton ItemKind="LastPage" />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton ItemKind="SaveToDisk" />
            <dx:ReportToolbarButton ItemKind="SaveToWindow" />
            <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                <Elements>
                    <dx:ListElement Value="pdf" />
                    <dx:ListElement Value="xls" />
                    <dx:ListElement Value="xlsx" />
                    <dx:ListElement Value="rtf" />
                    <dx:ListElement Value="mht" />
                    <dx:ListElement Value="html" />
                    <dx:ListElement Value="txt" />
                    <dx:ListElement Value="csv" />
                    <dx:ListElement Value="png" />
                </Elements>
            </dx:ReportToolbarComboBox>
        </Items>
        <Styles>
            <LabelStyle>
            <Margins MarginLeft="3px" MarginRight="3px" />
            </LabelStyle>
        </Styles>
    </dx:ReportToolbar>
    
    <dx:ReportViewer ID="ReportViewer1" runat="server" 
        onunload="ReportViewer1_Unload" Width="906px">
    </dx:ReportViewer>
    </asp:Content>
