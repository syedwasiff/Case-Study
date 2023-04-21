$(document).ready(function () {
    getallprod();
    $("#tbl_Products").dataTable();

});


function AddProducts() {
    var product = {
        ID: $("#hdnId").val(),
        Product_Title: $("#txtProductTitle").val(),
        Price: $("#txtPrice").val(),
        Stock: $("#txtStock").val(),
        Image: $("#txtImage").val(),
    }

    $.post("/Home/CreateProduct", product).done(function () {
        alert("Success");
        getallprod();
    }).fail(function (xhr) {
        console.log(xhr);
    });
}


function getallprod() {
    $("#tbl_Products tbody").empty();
    $.get("/Home/GetAllProd").done(function (result) {
        /*console.log(result);*/
        for (var i = 0; i < result.length; i++) {
            $("#tbl_Products tbody").append('<tr> <td>' + result[i].Product_Title + '</td> <td>' + result[i].Price + '</td> <td>' + result[i].Stock + '</td> <td><a onclick="UpdateEntry(' + result[i].ID + ' ,this)"><i class="fa fa-edit"></i></a> <a onclick="DeleteProduct(' + result[i].ID + ')"><i class="fa fa-trash" aria-hidden="true"></a></i></td> <tr/>')
        };        
    }).fail(function (xhr) {
        console.log(xhr);
    });
}

function UpdateEntry(ID, e) {
    var currentRow = $(e).closest("tr");
    var obj = {
        ID: ID,
        Product_Title: currentRow.find("td:eq(0)").text(),
        Price: currentRow.find("td:eq(1)").text(),
        Stock: currentRow.find("td:eq(2)").text()
    }
    $("#hdnId").val(obj.ID);
    $("#txtProductTitle").val(obj.Product_Title);
    $("#txtPrice").val(obj.Price);
    $("#txtStock").val(obj.Stock);    
}

function DeleteProduct(ID) {
    var obj = {
        ID: ID
    }
    $.post("/Home/DeleteProduct", obj).done(function (result) {
        alert("Deleted");
        getallprod();
    })
}