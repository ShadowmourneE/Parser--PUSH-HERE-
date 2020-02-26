// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function onSubmitEventSuccess(e) {
    //init errors
    $('#errors').remove();
    $('<div id="errors" class="container text-danger"></div>').appendTo('body');
    if (e.responseJSON._errors.length) {
        e.responseJSON._errors.forEach(function (value, index) {
            $('#errors').append(`<span>${value}</span></br>`);
        });
    } else {
        $('#errors').append(`<span class="text-success">No errors</span></br>`);
    }
    //init warnings
    $('#warnings').remove();
    $('<div id="warnings" class="container text-warning"></div>').appendTo('body');
    if (e.responseJSON._warningsPairs.length) {
        e.responseJSON._warningsPairs.forEach(function (value, index) {
            $('#warnings').append(`<span>${value}</span></br>`);
        });
    } else {
        $('#warnings').append(`<span class="text-success">No warnings</span></br>`);
    }
}