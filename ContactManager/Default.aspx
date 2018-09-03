<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ContactManager.Default" %>

<!DOCTYPE html>  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <title>Web Service for Customer&Supplier</title>  
    <script src="jquery-1.7.1.js" type="text/javascript"></script>  
      
    <script type="text/javascript">  
        window.onload = GetAllCus();

        function GetAllCus() {
            
            $(document).ready(function () {
                
                $.getJSON("api/contact/Customers", function (data) {
                    $('#bindcus').empty();
                    $.each(data, function (key, val) {

                        var row = "<tr><td>11" + val.Id + "</td> <td></td>  <td>" + val.FirstName + "  " + val.LastName + "</td> <td></td> <td>" + val.Email +
                            "</td></tr>";

                        $(row).appendTo($('#bindcus'));

                    });

                });
            });
            }
        function AddEmp() {  
            
            var Emp = {};  
            Emp.FirstName = $("#txtFirstName").val();  
            Emp.LastName = $("#txtLastName").val();           
            Emp.Company = $("#txtCompany").val();  
  
            $.ajax({  
                url:"<%=Page.ResolveUrl("/api/Contact/AddCustomers")%>",   
                type: "POST",  
                contentType: "application/json;charset=utf-8",  
                data: JSON.stringify(Emp),  
                dataType: "json",  
                success: function (response) {  
  
                    alert(response);  
                 GetAllCus();       
  
                },  
                error: function (x, e) {  
                    alert('Failed');  
                    alert(x.responseText);  
                    alert(x.status);  
                }  
            });
  
        }
  
        $(document).ready(function ()  
         {
           GetAllCus();
            $("#btnSave").click(function (e) {      
  
                AddEmp();  
                e.preventDefault();
            });
        });
    </script>  
</head>  
<body style="background-color:navy;color:White">  
    <form id="form1" runat="server">  
    <br /><br />  
    <table>  
        <tr>  
            <td>  
                First Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtFirstName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Last Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtLastName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Company  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtCompany" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
            </td>  
            <td>  
                <asp:Button Text="Save" runat="server" ID="btnSave" />  
            </td>  
        </tr>  
        </table>  
        <br />  
        <table>  
        
        <thead>  
            <tr>  
                <td>  
                    Id  
                </td>  
               <td></td>  
               
                <td>  
                  Name  
                </td>  
                 <td></td>  
                <td>  
                    Company  
                </td>  
            </tr>  
        </thead>  
       
        <tbody id="bindcus">  
        </tbody>  
    </table>  
    
    </form>  
</body>  
</html>  