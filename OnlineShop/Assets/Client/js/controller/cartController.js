﻿var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        // Xử lý js button tiếp tục mua hàng
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/"
        });

        // Xử lý js button thanh toán 
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan"
        });

        // Xử lý js button cập nhật
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }
                }
            });
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang"
                    }
                }
            })
        });
    }
}
cart.init();