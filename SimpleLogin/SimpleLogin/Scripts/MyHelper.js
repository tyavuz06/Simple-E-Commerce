
var AJAXTYPE = {
    POST: 'POST',
    GET: 'GET'

}

var ajaxPost = function (url, data, sucess, error, compelete) {

    doAjax(url, AJAXTYPE.POST, data, sucess, error, compelete);

}

var ajaxGet = function (url, data, sucess, error, compelete) {

    doAjax(url, AJAXTYPE.GET, data, sucess, error, compelete);

}

var doAjax = function (url, type, data, sucess, error, complete) {

    $.ajax({
        url: url,
        type: type,
        data: data,
        complete: function () {
            if (typeof (complete) == "function") {

                complete();
            }

        }, success: function (d) {
            if (typeof (sucess) == "function") {

                sucess(d);
            }

        }, error: function (d) {
            if (typeof (error) == "function") {

                error(d);
            }
        }

    });

}


var showAllloading = function () {
    var loadingcount = $(".allpageloading").length;
    if (loadingcount > 0) return;
    var loadinghtml = '<div class="allpageloading">' +
        '<span>' +
        '<img src="/Images/Loading/lg.circle-slack-loading-icon.gif"/>' +
        '</span></div>';
    $("body").append(loadinghtml);

}

var hideLoading = function () {

    $(".allpageloading").remove();

}