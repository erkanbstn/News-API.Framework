
$(document).ready(function () {
    GetAllUsers();
});

// Get All

function GetAllUsers() {
    $.ajax({
        url: '../api/GetUsers',
        type: 'GET',
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.FullName + '</td>';
                html += '<td>' + item.UserName + '</td>';
                html += '<td>' + item.Password + '</td>';
                html += '<td>' + item.Slug + '</td>';
                html += '<td><a href="#" class="btn btn-success" data-toggle="modal" data-target="#myModal"  onclick="return GetUsersByID(' + item.Id + ')">Edit</a> | <a href="#" class="btn btn-danger"  onclick="DeleteUsers(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbodyforuser').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    });
}

// Find for Login
function GetUserByID() {
    var res = ValidateUser();
    if (res == false) {
        return false;
    }
    var NewsObject = {
        UserName: $('#email').val(),
        Password: $('#password').val(),
    };
    $.ajax({
        url: '../api/UserControl',
        type: "POST",
        data: JSON.stringify(NewsObject),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            FindUser();
            window.location.href = '/News/Index';
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    })
}

// Find for FullName
function FindUser() {
    $.ajax({
        url: '../api/FindUser',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('.logo_name').html(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    })
}

// Validation

function ValidateUser() {
    var isValid = true;
    if ($('#email').val() == "") {
        $('#email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#email').css('border-color', 'lightgrey');
    }
    if ($('#password').val() == "") {
        $('#password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#password').css('border-color', 'lightgrey');
    }
    return isValid;
}



