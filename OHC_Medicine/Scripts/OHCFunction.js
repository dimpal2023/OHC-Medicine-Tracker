function GetDepartment(UnitId) {
    debugger;
    try {
        $('#DDLDepartmentName').empty();
        var params = { UnitId: UnitId, IsAll: false }
        $.ajax({
            type: "POST",
            url: "/utility/GetDepartment",
            data: JSON.stringify(params),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $.each(data, function () {
                    debugger;
                    $('#DDLDepartmentName').append("<option value=" + this.Value + ">" + this.Text + "</option>");
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('4300: ' + errorThrown);
                //  alert(jqXHR.responseText + ' Error:' + errorThrown);
            }
        });
    }
    catch (ex) {
        console.log('4301: ' + ex.message);
    }
}
function GetLocation(DepartmentId) {
    try {
        $('#DDLLocationName').empty();
        var params = { DepartmentId: DepartmentId, IsAll: false }
        $.ajax({
            type: "POST",
            url: "/utility/GetLocation",
            data: JSON.stringify(params),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $.each(data, function () {
                    $('#DDLLocationName').append("<option value=" + this.Value + ">" + this.Text + "</option>");
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('4300: ' + errorThrown);
                //  alert(jqXHR.responseText + ' Error:' + errorThrown);
            }
        });
    }
    catch (ex) {
        console.log('4301: ' + ex.message);
    }
}
function GetMedicineDetail(e) {
    debugger;
    try {
        var row = $(e).closest("tr");
        var MedicineID = $(row).find('.req1 option:selected').val();
        var params = { MedicineID: MedicineID, IsAll: false }
        $.ajax({
            type: "POST",
            url: "/utility/GetMedicineDetail",
            data: JSON.stringify(params),
            async: false,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                debugger;
                $(row).find('.medavlqty').val('');
                $(row).find('.medbatch').val('');
                $(row).find('.medavlqty').val(data.AvailableQty);
                $(row).find('.medbatch').val(data.BatchNo);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log('4300: ' + errorThrown);
                //  alert(jqXHR.responseText + ' Error:' + errorThrown);
            }
        });
    }
    catch (ex) {
        console.log('4301: ' + ex.message);
    }
}
$(document).on('change', '#ddlUnit', function () {
    GetDepartment($('#ddlUnit').val());
});
$(document).on('change', '#DDLDepartmentName', function () {
    GetLocation($('#DDLDepartmentName').val());
})
//$(document).on('change', '#ddlMedicine', function () {
//    GetMedicineDetail($('#ddlMedicine').val(), this);
//})
//$(document).on('change', '.req1', function () {
//    GetMedicineDetail($('.req1').val(), this);
//})
