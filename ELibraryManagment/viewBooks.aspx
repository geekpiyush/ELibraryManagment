<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewBooks.aspx.cs" Inherits="ELibraryManagment.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-sm-12" >
    <center>
        <h3> Book Inventory List</h3>
        
    </center>

    <div class="row">   
        <div class="col-sm-12 col-md-12">
            
            <asp:Panel runat="server" CssClass="alert alert-success" role="alert" ID="Pane11" Visible="false">
                <asp:Label ID="Labe11" Text="Label" runat="server" />
                </asp:Panel>
        </div>
    </div>
    <br />
    <div class="row">
         <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>

                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id"/>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">

                                                    <div class="row">

                                                        <div class="col-lg-10">

                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>

                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("language") %>' Font-Bold="True"></asp:Label>

                                                                </div>
                                                            </div>

                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| Publish Date -
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("publish_date") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("no_of_pages") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("edition") %>' Font-Bold="True"></asp:Label>

                                                                </div>
                                                            </div>

                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Cost -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                             <div class="row">
                                                                <div class="col-12">

                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>

                                                    </div>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
    </div>

</div>

</asp:Content>


