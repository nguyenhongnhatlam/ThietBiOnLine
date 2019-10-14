<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="danhsachthietbi.aspx.cs" Inherits="ThietBiOnLine.danhsachthietbi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section style="margin-top:100px">
         <div>
         <hgroup>
         <h2><%: Page.Title %></h2>
         </hgroup>
         <asp:ListView ID="tbList" runat="server" DataKeyNames="ThietBiID" GroupItemCount="4" ItemType="ThietBiOnLine.Models.ThietBi" SelectMethod="GetBooks">
         <EmptyDataTemplate>
             <table >
                 <tr>
                     <td>Không tìm thấy thiết bị</td>
                 </tr>
             </table>
         </EmptyDataTemplate>
         <EmptyItemTemplate>
         <td/>
         </EmptyItemTemplate>
         <GroupTemplate>
             <tr id="itemPlaceholderContainer" runat="server">
             <td id="itemPlaceholder" runat="server"></td>
          </tr>
         </GroupTemplate>
        <ItemTemplate>
              <td runat="server">
                  <table>
                     <tr>
                     <td>
                         <a href="ChiTiet.aspx?bookID=<%#:Item.ThietBiID%>">
                         <img src ="/Images/<%#:Item.HinhAnh%>" width="150" height="225" style="border:solid" /></a>
                    </td>
                     </tr>
             <tr>
          <td>
         <a href="ChiTiet.aspx?bookID=<%#:Item.ThietBiID%>">
         <span>
         <%#:Item.TenThietBi%>
             </span>
             </a>
             <br />
             <span>
         <b>Giá: </b><%#:String.Format("{0:c}",Item.GiaBan)%>
          </span>

             <br />
              <a href="AddToCart.aspx?ThietBiID=<%#:Item.ThietBiID%>">
     <span>
         <b>Thêm vào giỏ sách<b>
            </span>
             </a>
        
             </td>
             </tr>
            <tr>
         <td>&nbsp;</td>
         </tr>
         </table>
         </p>
         </td>
         </ItemTemplate>
         <LayoutTemplate>
                  <table style="width:100%;">
                  <tbody>
                      <tr>
                      <td>
                          <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                            <tr id="groupPlaceholder"></tr>
                     </table>
              </td>
                 </tr>
                 <tr>
             <td></td>
             </tr>
         <tr></tr>
         </tbody>
         </table>
         </LayoutTemplate>
         </asp:ListView>
         </div>
         </section>
</asp:Content>
