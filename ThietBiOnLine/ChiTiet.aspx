<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="ThietBiOnLine.ChiTiet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="tbList" runat="server" ItemType="ThietBiOnLine.Models.ThietBi" SelectMethod ="GetDetails" RenderOuterTable="false">
 <ItemTemplate >
 <div >
 <h1><%#:Item.TenThietBi %></h1>
 </div>
 <br />
 <table>
 <tr>
 <td>
 <img src="/Images/<%#:Item.HinhAnh %>"
 style="border:solid; height:225px" alt="<%#:Item.TenThietBi %>"/>
 </td>
 <td>&nbsp;</td>
 <td style="vertical-align: top; text-align:left;">
 <b>Mô tả:</b><br /><%#:Item.MieuTa %>
 <br />
 <span><b>Giá:</b>&nbsp;<%#: String.Format("{0:c}",Item.GiaBan)%></span>
 <br />
 <span><b>Mã Thiết Bị:</b>&nbsp;<%#:Item.ThietBiID %></span>
 <br />
 <br />
 </td>
 </tr>
 </table>
 </ItemTemplate>
 </asp:FormView>
</asp:Content>
