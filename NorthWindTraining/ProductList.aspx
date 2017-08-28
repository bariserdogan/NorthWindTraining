<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="NorthWindTraining.ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="padding-left:500px">
            <asp:Repeater ID="RepeaterCategory" runat="server">
                <HeaderTemplate>
                <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <%#Eval("CategoryName")%>
                        <asp:Repeater ID="RepeaterProducts" runat="server" DataSource='<%#Eval("Products") %>'>
                            <ItemTemplate>
                                <p>
                                    <%#Eval("ProductName") %>
                                </p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                </ul>
                </FooterTemplate>
            </asp:Repeater>
            
        </div>       
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:GridView ID="GridView2" runat="server"></asp:GridView>

    </div>
    </form>
    
</body>
</html>
