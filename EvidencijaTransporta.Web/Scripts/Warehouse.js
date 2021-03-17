const ShowInfo = (id) => {
    var urlTr = `/Warehouse/OpenStoreItems/${id}`;
    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById('warehouseInfo').style.display = 'block';
        $('#warehouseInfo').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    }) 
}