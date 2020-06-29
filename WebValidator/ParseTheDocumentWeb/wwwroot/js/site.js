function onSubmitEventSuccess(e) {
    //init errors
    $('#errors').remove();
    $('<div id="errors" class="container"></div>').appendTo('body');
    console.log(e.responseJSON);
    if (e.responseJSON.errors.length) {
        console.log(errors);
        e.responseJSON.errors.forEach(function (error, index) {
            if (error.message == "String doesn't start with number") {
                $('#errors').append(`<span style="color:#CD5C5C">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Nesting does't match previous") {
                $('#errors').append(`<span style="color:#008080">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Wrong numbering") {
                $('#errors').append(`<span style="color:#800080">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Line in the wrong format for children") {
                $('#errors').append(`<span style="color:#800000">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Line is not formatted correctly for concatenation") {
                $('#errors').append(`<span style="color:#808000">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Incorrect string") {
                $('#errors').append(`<span style="color:#FF0000">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Template is not valid!") {
                $('#errors').append(`<span style="color:#F39C12">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            }
            if (error.message == "Not unique content or invalid string") {
                $('#errors').append(`<span style="color:#000080">◉ line - ${error.row}. ${error.message}</span><br/><span>${error.line}</span><br/><hr/>`);
            } 
        });
    } else {
        $('#errors').append(`<span class="text-success">No errors</span><br/>`);
    }
    //init warnings
    $('#warnings').remove();
    $('<div id="warnings" class="container" style="color:#2c145d"></div>').appendTo('body');
    if (e.responseJSON.warnings.length) {
        console.log(warnings);
        e.responseJSON.warnings.forEach(function (warning, index) {
            if (warning.line.toLowerCase().indexOf('plus') !== -1 && warning.line.toLowerCase().indexOf('following') !== -1) {
                const htmlToAppend = warning.line.replace(/((\w*plus\b\w*)|(\w*Plus\b\w*)).*(following\b\w*)/, function (match, p1, p2) {
                    return `<span style="color: #39a20c;">${match}</span>`;
                })
                $('#warnings').append(`<span>◉ line - ${warning.row}. ${warning.message}</span><br/><span>${htmlToAppend}</span><br/><hr/>`);
            } else if ((warning.line.toLowerCase().indexOf('from') !== -1 || warning.line.toLowerCase().indexOf('of') !== -1) && warning.line.toLowerCase().indexOf('the') !== -1 && warning.line.toLowerCase().indexOf('following') !== -1) {
                const htmlToAppend = warning.line.replace(/((\w*from\b\w*)|(\w*of\b\w*)).*(the\b\w*).*(following\b\w*)/, function (match, p1, p2) {
                    return `<span style="color: #bd4d06f0;">${match}</span>`;
                })
                $('#warnings').append(`<span>◉ line - ${warning.row}. ${warning.message}</span><br/><span>${htmlToAppend}</span><br/><hr/>`);
            } else {
                $('#warnings').append(`<span>◉ line - ${warning.row}. ${warning.message}</span><br/><span>${warning.line}</span><br/><hr/>`);
            }
        });
    } else {
        $('#warnings').append(`<span class="text-success">No warnings</span><br/>`);
    }
}