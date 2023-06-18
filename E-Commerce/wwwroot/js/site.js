// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#addToBasketButton').click(function () {
        $.ajax({
            type: "POST",
            url: "./AddToBasket_Click",
            //data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            success: function (response) {
                // Here you can assign response to tags.
                // If response was empty, try response.d.
                $("#id").html(response);

            }
        });
    });
});