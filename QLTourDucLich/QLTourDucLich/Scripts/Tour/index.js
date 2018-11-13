var noiCu;
$("#NoiDi").on('focus', function () {
    noiCu = this.value;
});
$(document).ready(function () {
    $('#NoiDi').change(function () {
        var value = $('#NoiDi').find(':selected').val();
        $.ajax({
            url: 'Tour/TimDiemDen',
            type: 'post',
            dataType: 'json',
            data: { maNoiDi: value },
            success: function (result) {
                if (Array.isArray(result) && result.length > 0) {
                    $des = $('#NoiDen');
                    $des.empty();
                    $.each(result, function (index, item) {
                        $des.append('<option value=' + item.Value + '>' + item.Text + '</option>');
                    });
                } else {
                    alert("Không có nơi đến nào cho địa điểm khởi hành này");
                    $('#NoiDi').val(noiCu);
                }
            },
            error: function () {
                var x = 1;
            }
        });
    });
})

