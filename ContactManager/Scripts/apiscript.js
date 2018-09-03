
$(document).ready(function () {
    get_Customers();
    get_Suppliers();
});

function validatecForm() {
    var x = document.forms["cus_form"]["cEmail"].value;
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
        alert("Not a valid e-mail address");
        return false;
    } else {
        add_Customer();

        }
}

function validatesForm() {
    var x = document.forms["sup_form"]["sTelephone"].value;
    var atpos = x.indexOf("@");
    var dotpos = x.lastIndexOf(".");
    if (x.length < 7 || x.length >11) {
        alert("Not a valid phone number");
        return false;
    } else {
        add_Supplier();

    }
}

function reset_Customer() {            
    $('#cus_form').trigger("reset");
}
function reset_Supplier() {
    $('#sup_form').trigger("reset");
}
function get_Supplier(supplierId) {
    $.ajax({
        type: 'GET',
        url: "api/contact/Supplier/" + supplierId,
        dataType: 'json',
        success: function (data) {
            //var id = val.Person.Id;
            $("#supplierId").val(supplierId);
            $("#sFirstName").val(data.Person.Name.First);
            $("#sLastName").val(data.Person.Name.Last);
            $("#sTelephone").val(data.Telephone);

        }
    });

}

function get_Suppliers() {
    var suppliers = $('#suppliers');
    var sid, sname, stel;
    var txt = "<table class=table table-sm table-hover>";
    txt += "<tr><th>ID</th><th>Name</th><th>Telephone No</th><th></th><th></th></tr>";
    $.ajax({
        type: 'GET',
        url: "api/contact/Suppliers",
        dataType: 'json',
        success: function (data) {
            suppliers.empty();
            $.each(data, function (index, val) {
                sid = val.Person.Id;
                sname = val.Person.Name.First + ' ' + val.Person.Name.Last;
                stel = val.Telephone;
                txt += "<tr><td>" + sid + "</td><td>" + sname + "</td><td>" + stel + "</td><td>";
                txt += "<a class='btn' onClick='get_Supplier(" + sid + ")'>";
                txt += "<i class='fa fa-pencil-square-o'></i></a>";
                txt += "<a class='btn text-danger' onClick='del_Supplier_Record(" + sid + ")'>";
                txt += "<i class='fa fa-trash-o'></i></a>";
                txt += "</td></tr>";
            });
            txt += "</table>";
            document.getElementById("suppliers").innerHTML = txt;
            $('#sup_form').trigger("reset");
        }
    });
}

function del_Supplier_Record(id) {
    if (confirm('Are you sure you want to delete supplier with Id:' + id + '?')) {
        $.ajax({
            type: 'DELETE',
            url: "api/contact/Supplier/" + id,
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                get_Suppliers();

            },
            error: function (x, e) {
                alert('Failed');
                alert(x.responseText);
                alert(x.status);
            }
        });
    }
}

function update_Supplier() {
    var cus = {
        "Person": {
            "Id": $('#supplierId').val(),
            "Name": {
                "First": $("#sFirstName").val(),
                "Last": $("#sLastName").val()
            }
        },
        "Telephone": $("#sTelephone").val(),
    };
    console.log(cus);

    $.ajax({
        url: "/api/Contact/Supplier",
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(cus),
        success: function (response) {
            //   window.location.href = "index1.html";
            get_Suppliers();
        },
        error: function (x, e) {
            alert('Failed');
            alert(x.responseText);
            alert(x.status);
        }
    });
}

function add_Supplier() {
    var supid = $("#supplierId").val()            
    if (supid > 0) {
        update_Supplier();
    }
    var sup = {
        "Person": {
            "Name": {
                "First": $("#sFirstName").val(),
                "Last": $("#sLastName").val()
            }
        },
        "Telephone": $("#sTelephone").val()
    };
    $.ajax({
        url: "/api/Contact/Supplier",
        type: "POST",
        contentType: "application/json;charset=utf-8",

        data: JSON.stringify(sup),
        success: function (response) {
            alert(response);
            get_Suppliers();
        },
        error: function (x, e) {
            alert('Failed');
            alert(x.responseText);
            alert(x.status);
        }
    });
}


function GetDate(dt) {
    var date = new Date(dt);
    return (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
}

function get_Customer(customerId) {
    $.ajax({
        type: 'GET',
        url: "api/contact/Customer/" + customerId,
        dataType: 'json',
        success: function (data) {
            //var id = val.Person.Id;
            $("#customerId").val(customerId);
            $("#cFirstName").val(data.Person.Name.First);
            $("#cLastName").val(data.Person.Name.Last);
            $("#cEmail").val(data.Email);
            $("#cDob").val(data.BirthDay);

        }
    });

}

function get_Customers() {
    var customers = $('#customers');           
    var cid, cname, cemail, cdob;
    var txt = "<table class=table table-sm table-hover>";
    txt += "<tr><th>ID</th><th>Name</th><th>Email</th><th>DOB</th><th></th></tr>";
    $.ajax({
        type: 'GET',
        url: "api/contact/Customers",
        dataType: 'json',
        success: function (data) {
            customers.empty();
            $.each(data, function (index, val) {
                cid = val.Person.Id;
                cname = val.Person.Name.First + ' ' + val.Person.Name.Last;
                        
                cemail = val.Email;
                cdob = GetDate(val.BirthDay);
                        
                txt += "<tr><td>" + cid + "</td><td>" + cname + "</td><td>" + cemail + "</td><td>" + cdob + "</td><td>";
                txt += "<a class='btn' onClick='get_Customer(" + cid + ")'>";
                txt += "<i class='fa fa-pencil-square-o'></i></a>";
                txt += "<a class='btn text-danger' onClick='del_Customer_Record(" + cid + ")'>";
                txt += "<i class='fa fa-trash-o'></i></a>";
                txt += "</td></tr>";
            });
            txt += "</table>";
            document.getElementById("customers").innerHTML = txt;
            $('#cus_form').trigger("reset");
        }
    });
}

function del_Customer_Record(id) {
    if (confirm('Are you sure you want to delete customer with Id:' + id + '?')) {
        $.ajax({
            type: 'DELETE',
            url: "api/contact/Customer/" + id,
            contentType: "application/json;charset=utf-8",
            success: function (response) {
                get_Customers();

            },
            error: function (x, e) {
                alert('Failed');
                alert(x.responseText);
                alert(x.status);
            }
        });
    }
}

function add_Customer() {
    var cusid = $("#customerId").val()
    if (cusid > 0) {
        update_Customer();
    }else{
        var cus = {
            "Person": {
                "Name": {
                    "First": $("#cFirstName").val(),
                    "Last": $("#cLastName").val()
                }
            },
            "BirthDay": $("#cDob").val(),
            "Email": $("#cEmail").val()
        };
        $.ajax({
            url: "/api/Contact/Customer",
            type: "POST",
            contentType: "application/json;charset=utf-8",

            data: JSON.stringify(cus),
            success: function (response) {
                alert(response);
                get_Customers();
            },
            error: function (x, e) {
                alert('Failed');
                alert(x.responseText);
                alert(x.status);
            }
        });

    }
}
        
function update_Customer() {
    var cus = {
        "Person": {
            "Id": $('#customerId').val(),
            "Name": {
                "First": $("#cFirstName").val(),
                "Last": $("#cLastName").val()
            }
        },
        "Email": $("#cEmail").val(),
        "BirthDay": $("#cDob").val(),
    };
    console.log(cus);
    $.ajax({
        url: "/api/Contact/Customer",
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(cus),
        success: function (response) {
            //   window.location.href = "index1.html";
            get_Customers();
        },
        error: function (x, e) {
            alert('Failed');
            alert(x.responseText);
            alert(x.status);
        }
    });
}
