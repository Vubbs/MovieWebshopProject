// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if (window.location.pathname == '/Movie/AddMovie') {
    $("#addMovie").click(function () {
        $("#addMovieSpinner").addClass("spinner-border");
        $("#addMovieSpinner").addClass("text-primary");
    });
}


function AddToCart(movieId) {
    $.ajax({
        type: 'post',
        url: '/Cart/AddToCart',
        dataType: 'json',
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count); // The id 'cartCount' refers to an HTML-element
        }
    })
}

function RemoveFromCart(movieId) {
    $.ajax({
        type: 'post',
        url: '/Cart/RemoveFromCart',
        dataType: 'json',
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count);
        }
    })
}

$(document).ajaxStop(function () {
    window.location.reload();
});


function billingFunction() {
    if (document.getElementById('checkForSameAddress').checked) {
        var billAddr = document.getElementById('bAddr').value;
        var billZip = document.getElementById('bZip').value;
        var billCity = document.getElementById('bCity').value;

        document.getElementById('dAddr').value = billAddr;
        document.getElementById('dZip').value = billZip;
        document.getElementById('dCity').value = billCity;
    } else {
        document.getElementById('dAddr').value = '';
        document.getElementById('dZip').value = '';
        document.getElementById('dCity').value = '';
    }
}

$("#showOrders").click(function () {
    const email = document.getElementById('email');
    window.location.href = "?email=" + email.value;
});  