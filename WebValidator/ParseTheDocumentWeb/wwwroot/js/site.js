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
    $('<div id="warnings" class="container" style="color:#2c145d"></div>').appendTo('body');
    if (e.responseJSON._warningsPairs.length) {
        e.responseJSON._warningsPairs.forEach(function (value, index) {
            if (value.toLowerCase().indexOf('plus') !== -1 && value.toLowerCase().indexOf('following') !== -1) {
                const htmlToAppend = value.replace(/((\w*plus\b\w*)|(\w*Plus\b\w*)).*(following\b\w*)/, function (match, p1, p2) {
                    return `<span style="color: #39a20c;">${match}</span>`;
                })
                $('#warnings').append(`<span>${htmlToAppend}</span></br>`);
            } else if ((value.toLowerCase().indexOf('from') !== -1 || value.toLowerCase().indexOf('of') !== -1) && value.toLowerCase().indexOf('the') !== -1 && value.toLowerCase().indexOf('following') !== -1) {
                const htmlToAppend = value.replace(/((\w*from\b\w*)|(\w*of\b\w*)).*(the\b\w*).*(following\b\w*)/, function (match, p1, p2) {
                    return `<span style="color: #bd4d06f0;">${match}</span>`;
                })
                $('#warnings').append(`<span>${htmlToAppend}</span></br>`);
            } else {
                $('#warnings').append(`<span>${value}</span></br>`);
            }

        });
    } else {
        $('#warnings').append(`<span class="text-success">No warnings</span></br>`);
    }
}