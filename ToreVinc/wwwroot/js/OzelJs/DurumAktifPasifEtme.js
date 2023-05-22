$(document).ready(function () {
    $("input[type='checkbox']").change(function () {
        debugger;
        if (this.name == 'durumMenuchk') {
            if (this.checked) {
                //  alert(this.value+ " True")
                DurumGunceleMenu(this.value, true)
            }
            else {

                DurumGunceleMenu(this.value, false)
            }
        }

        if (this.name == 'durumAdminMenusuMuchk') {
            if (this.checked) {
                //  alert(this.value+ " True")
                DurumGunceleAdminMenu(this.value, true)
            }
            else {

                DurumGunceleAdminMenu(this.value, false)
            }
        }
        if (this.name == 'durumAltMenuchk') {
            if (this.checked) {
                //  alert(this.value+ " True")
                MenuAltMenuDurumDegis(this.value, true)
            }
            else {

                MenuAltMenuDurumDegis(this.value, false)
            }
        }
        if (this.name == 'durumilanchk') {
            if (this.checked) {
                //  alert(this.value+ " True")
                ilanDurumDegis(this.value, true)
            }
            else {

                ilanDurumDegis(this.value, false)
            }
        }
    }
    );


});
//https://sweetalert.js.org/docs/   https://sweetalert2.github.io/   https://sweetalert2.github.io/#input-types

function DurumGunceleMenu(id, Durum) {
    $.ajax({
        type: "POST",
        url: "/Menu/MenuDurumDegis",
        data: {
            "id": id,
            "durum": Durum
        },
        success: function
            (response) {
           //  alert(response)
            //toastr.success("Sonuç","İşlem yapıldı");
            if (response == 1) {
                Swal.fire(
                    {
                        "icon": "success",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapıldı."
                    }
                )
            } else {
                Swal.fire(
                    {
                        "icon": "error",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapılamadı!"
                    }
                )
            }

        },
        failure: function
            (response) {
            Swal.fire(
                {
                    "icon": "warning",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "İşlem Başarısız!"
                }
            )
        },
        error: function
            (response) {
            Swal.fire(
                {
                    "icon": "error",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "Hatalı Kayıt!"
                }
            )
        }
    }
    );
}
function DurumGunceleAdminMenu(id, Durum) {
    $.ajax({
        type: "POST",
        url: "/Menu/MenuAdminDurumDegis",
        data: {
            "id": id,
            "durum": Durum
        },
        success: function
            (response) {
            // alert(response)
            //toastr.success("Sonuç","İşlem yapıldı");
            if (response == 1) {
                Swal.fire(
                    {
                        "icon": "success",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapıldı."
                    }
                )
            } else {
                Swal.fire(
                    {
                        "icon": "error",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapılamadı!"
                    }
                )
            }

        },
        failure: function
            (response) {
            Swal.fire(
                {
                    "icon": "warning",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "İşlem Başarısız!"
                }
            )
        },
        error: function
            (response) {
            Swal.fire(
                {
                    "icon": "error",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "Hatalı Kayıt!"
                }
            )
        }
    }
    );
}
function MenuAltMenuDurumDegis(id, Durum) {
    $.ajax({
        type: "POST",
        url: "/Menu/MenuAltMenuDurumDegis",
        data: {
            "id": id,
            "durum": Durum
        },
        success: function
            (response) {
            // alert(response)
            //toastr.success("Sonuç","İşlem yapıldı");
            if (response == 1) {
                Swal.fire(
                    {
                        "icon": "success",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapıldı."
                    }
                )
            } else {
                Swal.fire(
                    {
                        "icon": "error",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İşlem Yapılamadı!"
                    }
                )
            }

        },
        failure: function
            (response) {
            Swal.fire(
                {
                    "icon": "warning",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "İşlem Başarısız!"
                }
            )
        },
        error: function
            (response) {
            Swal.fire(
                {
                    "icon": "error",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "Hatalı Kayıt!"
                }
            )
        }
    }
    );
}
function ilanDurumDegis(id, Durum) {
    $.ajax({
        type: "POST",
        url: "/AracBilgisis/DurumDegis",
        data: {
            "id": id,
            "durum": Durum
        },
        success: function
            (response) {
            //  alert(response)
            //toastr.success("Sonuç","İşlem yapıldı");
            if (response == 1) {
                Swal.fire(
                    {
                        "icon": "success",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İlan Yayına Alındı."
                    }
                )
            } else {
                Swal.fire(
                    {
                        "icon": "error",
                        "position": "left top",
                        "background": "#0090e7",
                        "showConfirmButton": false,
                        "timer": 1500,
                        "title": "İlan Yayından Kaldırıldı!"
                    }
                )
            }

        },
        failure: function
            (response) {
            Swal.fire(
                {
                    "icon": "warning",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "İşlem Başarısız!"
                }
            )
        },
        error: function
            (response) {
            Swal.fire(
                {
                    "icon": "error",
                    "position": "left top",
                    "background": "#0090e7",
                    "showConfirmButton": false,
                    "timer": 1500,
                    "title": "Hatalı Kayıt!"
                }
            )
        }
    }
    );
}
