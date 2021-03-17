const DetailsBtnClick = (id, controllerName, actionName, displayId) => {
    var urlTr = `/${controllerName}/${actionName}/${id}`;
    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById(`${displayId}`).style.display = 'block';
        $(`#${displayId}`).html(result);
        })
        .fail(function (xhr, status) {
            alert(status);
        }) 
}

const EditBtnClick = (id) => {
    var urlTr = `/Transport/EditTransport/${id}`;
    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById('dvEdit').style.display = 'block';
        $('#dvEdit').html(result);
    })
        .fail(function (xhr, status) {
            alert(status);
        })
}

const Edit = () => {
    var model = {
        Id: JsonModel.Id,
        Date: JsonModel.Date,
        SelectedTransportType: JsonModel.SelectedTransportType,
        ShipmentAmount: JsonModel.ShipmentAmount,
        VehicleType: JsonModel.VehicleType
    };
    var urlTr = `/Transport/EditTransport/`;
    $.ajax({
        url: urlTr,
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        data: JSON.stringify(model),
        dataType: 'json'
    }).fail(function (xhr, status) {
        alert(status);
    })
}

const FillEditFileds = (id) => {
    //document.getElementById(`edit-${id}`).addEventListener("click", function () {
          var urlTr = `/Transport/FillEditTransport/${id}`;
          //document.getElementById("createTransport").style.display = 'none';
          //document.getElementById("editTransport").style.display = 'block';
          //document.getElementById("discardTransport").style.display = 'block';
                        $.ajax({
                            url: urlTr,
                            contentType: 'application/html; charset=utf-8',
                            type: 'GET',
                            dataType: 'html',
                        }).done(function (result) {
                            //document.getElementById('dvEdit').style.display = 'block';
                            $('#dvEdit').html(result);
                        })
                            .fail(function (xhr, status) {
                                alert(status);
                            })
                    }
//}

document.getElementById(`edit-${id}`).addEventListener("click", function () {
    var urlTr = `/Transport/FillEditTransport/${id}`;

    document.getElementById("createTransport").style.display = 'none';
    document.getElementById("editTransport").style.display = 'block';
    document.getElementById("discardTransport").style.display = 'block';

    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById('dvEdit').style.display = 'block';
        $('#dvEdit').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    })
})