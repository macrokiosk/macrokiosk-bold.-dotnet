<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BOLD.Pay._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h2>BOLD.Pay</h2>
    <p>A multi-channel payment solution to facilitate dynamic billing across digital devices and formats.</p>
    <div class="row">
        <div class="col-75">
            <div class="container">
                <div class="row">
                    <div class="col-50">
                        <h3></h3>
                        <label for="fname"><i class="fa fa-user"></i>First Name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" Text="Jone"></asp:TextBox>
                        <label for="email"><i class="fa fa-envelope"></i>Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" Text="jone@email.com"></asp:TextBox>
                        <label for="adr"><i class="fa fa-address-card-o"></i>Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" Text="No. 123, Street 9/3, Section 9"></asp:TextBox>
                        <label for="city"><i class="fa fa-institution"></i>City</label>
                        <asp:TextBox ID="txtCity" runat="server" Text="Petaling Jaya"></asp:TextBox>
                    </div>

                    <div class="col-50">
                        <h3></h3>
                        <label for="lname">Last Name</label>
                        <asp:TextBox ID="txtLastName" runat="server" Text="Smith"></asp:TextBox>
                        <label for="pnum">Phone Number</label>
                        <asp:TextBox ID="txtPhoneNumber" runat="server" Text="0123456789"></asp:TextBox>
                        <label for="state">State</label>
                        <asp:TextBox ID="txtState" runat="server" Text="Selangor"></asp:TextBox>
                        <label for="zip">Postcode</label>
                        <asp:TextBox ID="txtPostcode" runat="server" Text="46000"></asp:TextBox>
                    </div>

                </div>
                <asp:Button ID="btnCheckout" Text="Continue to checkout" CssClass="btn" runat="server" OnClick="btnCheckout_Click" />
            </div>
        </div>
        <div class="col-25">
            <div class="container">
                <h4>Cart <span class="price" style="color: black"><i class="fa fa-shopping-cart"></i><b>4</b></span></h4>
                <p><a href="#">Product 1</a> <span class="price">MYR15.00</span></p>
                <p><a href="#">Product 2</a> <span class="price">MYR5.00</span></p>
                <p><a href="#">Product 3</a> <span class="price">MYR8.00</span></p>
                <p><a href="#">Product 4</a> <span class="price">MYR2.00</span></p>
                <hr>
                <p>Total <span class="price" style="color: black"><b>MYR<asp:Label ID="lblTotal" runat="server" Text="30.00" ></asp:Label></b></span></p>
                <p id="pResult" runat="server" style="text-align:center;"><b><asp:Label ID="lblPaymentResult" runat="server" ForeColor="White"></asp:Label></b></p>
            </div>
        </div>
    </div>

</asp:Content>