<%@ page language="C#" autoeventwireup="true" codebehind="ShowServicesConfig.aspx.cs" inherits="Vanilla.DependencyInjection.Unity.sitecore.admin.ShowServicesConfig" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Services configuration</title>
    <link rel="shortcut icon" href="/sitecore/images/favicon.ico" />
    <link rel="Stylesheet" type="text/css" href="/sitecore/shell/themes/standard/default/WebFramework.css" />
</head>
<body>
    <form runat="server" class="wf-container" id="ServicesForm" style="width: 100%">
        <div class="wf-content" style="padding: 10px">
            <h2>Dependency Injection Configuration</h2>
            <p class="ws-subtitle">Shows the configured services. For detailed information use details=1 query.</p>
            <asp:Repeater ID="FinalRepeater" runat="server">
                <HeaderTemplate>
                    <h2>Unity configurations:</h2>
                    <table width="100%" border="1">
                        <caption></caption>
                        <tr>
                            <td><b>Service Type</b></td>
                            <td><b>Service Implementaion</b></td>
                            <td><b>Lifetime</b></td>
                            <td><b>Registration name</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem, "RegisteredType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MappedToType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "LifetimeManager")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "Name")%></td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Repeater ID="DeatailsRepeater" runat="server" Visible="False">
                <HeaderTemplate>
                    <h2>Details configuration:</h2>
                    <table width="100%" border="1">
                        <tr>
                            <td><b>Service Type</b></td>
                            <td><b>Service Implementaion</b></td>
                            <td><b>Lifetime</b></td>
                            <td><b>Source</b></td>
                            <td><b>Operation</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem, "RegisteredType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "MappedToType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "LifetimeManager")%></td>
                        <%--          <td><%#DataBinder.Eval(Container.DataItem, "source")%></td>--%>
                        <%--          <td><%#DataBinder.Eval(Container.DataItem, "operation")%></td>--%>
                        <td></td>
                        <td></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            
            <asp:Repeater id="SitecoreConfiguration" runat="server">
                <HeaderTemplate>
                    <h2>Sitecore configuration:</h2>
                    <table width="100%" border="1">
                    <caption></caption>
                    <tr>
                        <td><b>Service Type</b></td>
                        <td><b>Service Implementaion</b></td>
                        <td><b>Lifetime</b></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem, "serviceType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "implementation")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "lifetime")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Repeater id="Repeater2" runat="server" Visible="False">
                <HeaderTemplate>
                    <h2>Details configuration:</h2>
                    <table width="100%" border="1">
                    <tr>
                        <td><b>Service Type</b></td>
                        <td><b>Service Implementaion</b></td>
                        <td><b>Lifetime</b></td>
                        <td><b>Source</b></td>
                        <td><b>Operation</b></td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem, "serviceType")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "implementation")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "lifetime")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "source")%></td>
                        <td><%#DataBinder.Eval(Container.DataItem, "operation")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
