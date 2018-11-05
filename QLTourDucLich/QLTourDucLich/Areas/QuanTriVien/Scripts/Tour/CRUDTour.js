
var noiCu;
$("#Tour_MaDiaDiemDi").on('focus', function () {
    noiCu = this.value;
});
$(document).ready(function () {
    $('#Tour_MaDiaDiemDi').change(function () {
        var value = $('#Tour_MaDiaDiemDi').find(':selected').val();
        $.ajax({
            url: '/QuanTriVien/Tour/TimDiemDen',
            type: 'post',
            dataType: 'json',
            data: { maNoiDi: value },
            success: function (result) {
                if (Array.isArray(result) && result.length > 0) {
                    $des = $('#Tour_MaDiaDiemDen');
                    $des.empty();
                    $.each(result, function (index, item) {
                        $des.append('<option value=' + item.Value + '>' + item.Text + '</option>');
                    });
                } else {
                    alert("Không có nơi đến nào cho địa điểm khởi hành này");
                    $('#Tour_MaDiaDiemDi').val(noiCu);
                }
            },
            error: function () {
                var x = 1;
            }
        });
    });
})


/*----------------Thêm hành trình-------------------------*/
$(document).ready(function () {
    //$('#them-HT').click(function () {
    //    var model = {
    //        MaNoiDi: $('#NoiDi').val(),
    //        MaNoiDen: $('#NoiDen').val()
    //    };
    //    $('#form-action-hanhtrinh').submit();
    //});
});