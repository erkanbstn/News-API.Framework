


$(document).ready(function () {
    GetAllNews();
});

// Get All

function GetAllNews() {
    $.ajax({
        url: '../api/GetNews',
        type: 'GET',
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Title + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.UserID + '</td>';
                html += '<td>' + item.Slug + '</td>';
                if (item.Status == 0) {
                    html += '<td>' + '<input  class="form-control" type="checkbox" checked=false disabled=true></input>' + '</td>';
                } else {
                    html += '<td>' + '<input class="form-control" type="checkbox" checked=true disabled=true></input>' + '</td>';
                }
                html += '<td><a href="#" class="btn btn-success" data-toggle="modal" data-target="#myModal"  onclick="return GetNewsByID(' + item.Id + ')">Edit</a> | <a href="#" class="btn btn-danger"  onclick="DeleteNews(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


// Find

function GetNewsByID(NewsId) {
    $.ajax({
        url: '../api/GetNews/' + NewsId,
        type: "get",
        dataType: "json",
        success: function (data) {
            $('#TitleTxt').val(data.Title);
            $('#DescriptionTxt').val(data.Description);
            $('#UserTxt').val(data.UserID);
            $('#SlugTxt').val(data.Slug);
            $('#NewsID').val(data.Id);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    })
}


// Insert

function AddNews() {
    var res = Validate();
    if (res == false) {
        return false;
    }

    var NewsObject = {
        Title: $('#TitleTxt').val(),
        Description: $('#DescriptionTxt').val(),
        UserID: $('#UserTxt').val(),
        Slug: $('#SlugTxt').val(),
    };

    $.ajax({
        url: '../api/AddNews',
        type: 'POST',
        data: JSON.stringify(NewsObject),
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            GetAllNews();
            $('#myModal').modal('hide');
            $('.modal-backdrop').remove();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    });
}


// Update

function UpdateNews() {
    var res = Validate();
    if (res == false) {
        return false;
    }

    var NewsObject = {
        Id: $('#NewsID').val(),
        Title: $('#TitleTxt').val(),
        Description: $('#DescriptionTxt').val(),
        UserID: $('#UserTxt').val(),
        Slug: $('#SlugTxt').val(),
    };
    $.ajax({
        url: '../api/UpdateNews',
        type: 'PUT',
        contentType: "application/json;charset=utf-8",
        dataType:'json',
        data: JSON.stringify(NewsObject),
        success: function (result) {
            GetAllNews();
            $('#myModal').modal('hide');
            $('#NewsID').val("");
            $('#TitleTxt').val("");
            $('#DescriptionTxt').val("");
            $('#UserTxt').val("");
            $('#SlugTxt').val("");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    });
}


// Delete

function DeleteNews(NewsId) {
    $.ajax({
        url: '../api/DeleteNews/' + NewsId,
        type: 'DELETE',
        success: function (data) {
            GetAllNews();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.status + ' ' + textStatus);
        }
    })
}

// Validation

function Validate() {
    var isValid = true;
    if ($('#TitleTxt').val() == "") {
        $('#TitleTxt').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#TitleTxt').css('border-color', 'lightgrey');
    }
    if ($('#DescriptionTxt').val() == "") {
        $('#DescriptionTxt').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UserTxt').css('border-color', 'lightgrey');
    }
    if ($('#UserTxt').val() == "") {
        $('#UserTxt').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UserTxt').css('border-color', 'lightgrey');
    }
    if ($('#SlugTxt').val() == "") {
        $('#SlugTxt').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SlugTxt').css('border-color', 'lightgrey');
    }
    return isValid;
}



function clearTextBox() {
    $('#NewsID').val("");
    $('#TitleTxt').val("");
    $('#DescriptionTxt').val("");
    $('#UserTxt').val("");
    $('#SlugTxt').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#TitleTxt').css('border-color', 'lightgrey');
    $('#DescriptionTxt').css('border-color', 'lightgrey');
    $('#UserTxt').css('border-color', 'lightgrey');
    $('#SlugTxt').css('border-color', 'lightgrey');
}