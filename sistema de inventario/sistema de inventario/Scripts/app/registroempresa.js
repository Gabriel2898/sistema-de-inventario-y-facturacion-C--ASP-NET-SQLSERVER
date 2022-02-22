
$(document).ready(function () {

    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();

})


/*visualizar imagen*/
$("#imagen").change(function () {

    let imagen = this.files[0];

    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("Debe subir una imagen en formato jpeg o png");
    } else if (imagen["size"] > 2000000) {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("La imagen debe tener como maximo 2MB");
    } else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".previsualizar").attr("src", rutaImagen);
        })
    }

})


$("#rdsi").on("click", function () {
    document.getElementById("rdno").checked = false;
    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();
})

$("#rdno").on("click", function () {
    document.getElementById("rdno").checked = true;
    document.getElementById("rdsi").checked = false;
    $("#divvendeimpuestos").hide();
})

$("#btnsiguiente").on("click", function () {

    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtcorreo").val();


    if (razonsocial == "") {
        $("#msjrazonsocial").html("* El campo razon social no debe estar vacio").css("color", "red");
        $("#txtrazonsocial").css("border-color", "red");
        $("#txtrazonsocial").focus();
    } else if (ruc == "") {
        $("#msjruc").html("* El campo ruc no debe estar vacio").css("color", "red");
        $("#txtruc").css("border-color", "red");
        $("#txtruc").focus();
    } else if (email == "") {
        $("#msjemail").html("* El campo email no debe estar vacio").css("color", "red");
        $("#txtcorreo").css("border-color", "red");
        $("#txtcorreo").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* Debe ingresar un email valido").css("color", "red");
        $("#txtcorreo").css("border-color", "red");
    }  else {
                    debugger;
                    var paramss = new Object();
                    paramss.razonsocial = razonsocial;
                    paramss.ruc = ruc;
                    paramss.email = email;

                    Post("RegistroEmpresa/validarRegistro", paramss).done(function (datos) {
                        if (datos.dt.response == "ok") {
                            $(".divregistroempresa").hide();
                            $(".divregistrousersuperadmin").show();
                            document.getElementById("btnregistrar").disabled = true;
                        } else {
                            swal({
                                position: "top-end",
                                type: "error",
                                title: datos.dt.response,
                                text: 'Por favor valida el campo solicitado',
                                showConfirmButton: true,
                                timer: 60000,
                                confirmButtonText: 'Cerrar'
                            })
                        }
                    })
                }
    $("#txtrazonsocial").keyup(function () {
        let razonsocial = $("#txtrazonsocial").val();
        if (razonsocial == "") {
            $("#msjrazonsocial").html("* El campo razon social no debe estar vacio").css("color", "red");
            $("#txtrazonsocial").css("border-color", "red");
        } else {
            $("#msjrazonsocial").html("").css("color", "red");
            $("#txtrazonsocial").css("border-color", "");
        }
    })
    $("#txtruc").keyup(function () {
        let ruc = $("#txtruc").val();
        if (ruc == "") {
            $("#msjruc").html("* El campo ruc no debe estar vacio").css("color", "red");
            $("#txtruc").css("border-color", "red");
        } else {
            $("#msjruc").html("").css("color", "red");
            $("#txtruc").css("border-color", "");
        }
    })

    $("#txtcorreo").keyup(function () {
        let email = $("#txtcorreo").val();
        if (email == "") {
            $("#msjemail").html("* El campo email no debe estar vacio").css("color", "red");
            $("#txtcorreo").css("border-color", "red");

        } else {
            if (!validaEmail(email)) {
                $("#msjemail").html("* Debe ingresar un email valido").css("color", "red");
                $("#txtcorreo").css("border-color", "red");
            } else {
                $("#msjemail").html("").css("color", "red");
                $("#txtcorreo").css("border-color", "");
            }

        }
    })



})


$("#btnregistrar").on("click", function () {

    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtcorreo").val();
    let idpais = $("#slpais").val();
    let idmoneda = $("#slmoneda").val();
    let direccion = $("#txtdireccion").val();

    let idimpuesto = 0;
    let idporcentaje = 0;
    let vendeimpuesto = 0;

    let username = $("#txtusername").val();
    let usuario = $("#txtusuario").val();
    let contraseña = $("#txtcontraseña").val();
    let confircontraseña = $("#txtconfircontraseña").val();

    if ($("#rdsi").is(":checked") == true) {
        idimpuesto = $("#sltipoimpuesto").val();
        idporcentaje = $("#slporcentaje").val();
        vendeimpuesto = 1;
    }

    if (username == "") {
        $("#msjusername").html("*El campo nombre de administrador no debe estar vacio").css("color", "red");
        $("#txtusername").css("borde-color", "red");
        $("#txtusername").facus();
    } else if (usuario == "") {
        $("#msjusuario").html("*El campo usuario no debe estar vacio").css("color", "red");
        $("#txtusuario").css("borde-color", "red");
        $("#txtusuario").facus();
    } else if (contraseña == "") {
        $("#msjpassword").html("*El campo contraseña no debe estar vacio").css("color", "red");
        $("#txtcontraseña").css("borde-color", "red");
        $("#txtcontraseña").facus();
    } else if (confircontraseña == "") {
        $("#msjconfirpassword").html("*El campo confirmar contraseña no debe estar vacio").css("color", "red");
        $("#txtconfircontraseña").css("borde-color", "red");
        $("#txtconfircontraseña").facus();
    } else {

        let params = new FormData();
        let slfile = ($("#imagen"))[0].files[0];
        params.append("file", slfile);
        params.append("razonsocial", razonsocial);
        params.append("ruc", ruc);
        params.append("email", email);
        params.append("idpais", idpais);
        params.append("idmoneda", idmoneda);
        params.append("direccion", direccion);
        params.append("idimpuesto", idimpuesto);
        params.append("idporcentaje", idporcentaje);
        params.append("vendeimpuesto", vendeimpuesto);
        params.append("username", username);
        params.append("usuario", usuario);
        params.append("contraseña", contraseña);

        PostImg("RegistroEmpresa/insertarEmpresa", params).done(function (datos) {

            if (datos.dt.response == "ok") {

                swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Empresa guardada correctamente',
                    text: 'Se envio un correo con sus accesos',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }).then((result) => {
                    if (result.value) {
                         window.location = fnBaseURLWeb("Home/Index");
                    } else {
                         window.location = fnBaseURLWeb("Home/Index");
                    }
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'No se guardo la empresa',
                    text: 'Contacte con el administrador del sistema',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        })

    }


    $("#btncancelar").on("click", function () {
        window.location = fnBaseURLWeb("Home/Index");
    })
    $("#btnatras").on("click", function () {
        $(".divregistroempresa").show();
        $(".divregistrousersuperadmin").hide();
    })



})