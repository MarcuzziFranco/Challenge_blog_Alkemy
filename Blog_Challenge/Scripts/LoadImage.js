﻿
$(document).ready(function () {
    $("#imgLoad").change(function () {
        console.log("Ejecuto");
    });
});


$(document).ready(function ()
{
    $("#imgLoad").change(function ()
    {
        if (this.files && this.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgShow').attr('src', e.target.result);
            }
            reader.readAsDataURL(this.files[0]);
        }
    });
});
