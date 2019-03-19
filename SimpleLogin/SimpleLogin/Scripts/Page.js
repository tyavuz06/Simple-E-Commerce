var ERRORCODES = {
    SUCCESS: 0,
    GOURL: 5


}

$(function () {


    $("body").on("hide.bs.modal", ".wmodal", function () {

        $(this).remove();
    })



    $(".addtobasket").click(function () {
        var productid = $(this).data("productid");

        var data = {
            id: productid
        }

        showAllloading();

        ajaxPost("/Product/OpenBasketPoup", data, function (d) {
            if (d.ErrorCode == ERRORCODES.GOURL) {
                location.href = d.GoUrl;
                return;
            }
            $("#extraoperationArea").append(d);
            $('#basketModal').modal('show');

            hideLoading();

        });



    });





});

function addproducttobasket() {
    var color = $("#select_color").val();
    var count = $("#txt_productcount").val();
    var productID = $("#basketpoup").attr("data-productid");

    var data = {

        productID: parseInt(productID),
        count: parseInt(count),
        color: parseInt(color)
    }

    $("#addproducttobasketbtn").addwrapdiv();
    ajaxPost("/Product/AddToBasket", data, function (d) {

        if (d.ErrorCode == ERRORCODES.SUCCESS) {
            $("#basketcountspan").text(d.Count);
            $('#basketModal').modal('hide');
            $("#addproducttobasketbtn").removewrapdiv();
        }




    })

}




$.fn.addwrapdiv = function () {

    var newelem = $("<div class='loaderwrapper'></div>");
    $(this).wrap(newelem);

    $(this).parent(".loaderwrapper").append('<span class="loaderarea"><img src ="/Images/Loading/Loading-gif-transparent-background-11.gif" style="width:22px;"/></span>');


}


$.fn.removewrapdiv = function () {

    var wrapper = $(this).parent(".loaderwrapper");

    $(this).insertBefore(wrapper);

    wrapper.remove();

} 