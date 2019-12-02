var f = new Date();
hora = f.getHours()
minuto = f.getMinutes()
segundo = f.getSeconds()
let hr = [];
for (let i = hora + 1; i <= 24; i++) {
    hr.push(i);
}

//var newdate = new Date(f.getFullYear() + "/" + (f.getMonth()) + "/" + (f.getDate() + 1))


$('.dtpInicio').datetimepicker({
    format: 'YYYY/MM/DD',
    sideBySide: true,
    disabledHours: hr
})
//    .on('dp.show', function () {
//    $('a.btn[data-action="incrementMinutes"], a.btn[data-action="decrementMinutes"]').removeAttr('data-action').attr('disabled', true);
//    $('span.timepicker-minute[data-action="showMinutes"]').removeAttr('data-action');
//});
$('.dtpInicio').data("DateTimePicker").minDate(f);


$('.dtpFin').datetimepicker({
    format: 'YYYY/MM/DD',
    sideBySide: true,
 
});
$('.dtpFin').data("DateTimePicker").minDate(f);