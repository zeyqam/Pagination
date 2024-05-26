﻿$(function () {




    $(document).on("click", "#products .add-basket", function () {
        let id = parseInt($(this).attr("data-id"));


        $.ajax({
            type: "POST",
            url: `home/addproducttobasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.count);
                $(".rounded-circle").next().text(`CART ($ ${response.totalPrice})`)
            }
        })

    })
    $(document).on("click", "#cart-page .fa-trash-alt", function () {
        let id = parseInt($(this).attr("data-id"));
      


        $.ajax({
            type: "post",
            url: `cart/DeleteProductFromBasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.totalCount);
                $(".rounded-circle").next().text(`CART ($ ${response.totalPrice})`);
                $(".cart-grand-total").text(`$${response.totalPrice}` );
                $(".total-basket-count").text(`You have${response.basketCount} items in your cart`);
                $(`[data-id=${id}]`).closest(".card").remove();
            }
        })

    })
    

})


