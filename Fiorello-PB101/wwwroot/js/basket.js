$(function () {




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
    function updateCart(data) {
        $(".total-basket-count").text(`You have ${data.basketCount} items in your cart`);
        $(".cart-grand-total").text(`$${data.totalPrice}`);
        $(`[data-product-id="${data.productId}"] .count`).text(data.productCount);
    }
    $(document).on("click", ".increment", function () {
        var id = $(this).data("id");
        $.ajax({
            url: `cart/IncrementProductCount?id=${id}`,
            type: 'POST',
            data: { id: id },
            success: function (data) {
                updateCart({ ...data, productId: id });
            }
        });
    });
    $(document).on("click", ".decrement", function () {
        var id = $(this).data("id");
        $.ajax({
            url: `cart/DecrementProductCount?id=${id}`,
            type: 'POST',
            data: { id: id },
            success: function (data) {
                updateCart({ ...data, productId: id });
            }
        });
    });
});
    




