$(document).ready(function () {
    $("#lblprin").html("Catálogo de Productos");
    $("#sldepatamentosbuscar").select2();
    $(".selectpicker").select2();
    document.getElementById("txtapartir").disabled = true;
    document.getElementById("btncatalogo").disabled = true;
    $(".ocultar").hide();
})


$("#btnpromociones").on("click", function () {
    window.location = fnBaseURLWeb("Departamentos/Departamentos");
})
$("#btnnewp").on("click", function () {
    document.getElementById("divcatalogo").style.display = "none";
    document.getElementById("divnewproduct").style.display = "block";
    document.getElementById("rdrbien").checked = true;
    document.getElementById("rdrserv").checked = false;
    document.getElementById("rdrunca").checked = true;
    $("#lblprin").html("Nuevo Producto");
    $("#lblpvenser").html("Precio Venta");
    document.getElementById("txtstock").disabled = false;
    document.getElementById("txtstockmin").disabled = false;
    document.getElementById("txtcodbarra").disabled = false;
})
$("#rdrbien").on("click", function () {
    document.getElementById("rdrbien").checked = true;
    document.getElementById("rdrserv").checked = false;
    document.getElementById("rdrunca").checked = false;
    document.getElementById("rdrkigra").checked = false;
    document.getElementById("txtpcosto").disabled = false;
    document.getElementById("txtganancia").disabled = false;
    document.getElementById("txtpvenser").disabled = true;
    document.getElementById("txtpmayoreo").disabled = false;
    document.getElementById("txtapartir").disabled = false;
    document.getElementById("txtfvenc").disabled = true;
    document.getElementById("rdrkigra").disabled = false;
    document.getElementById("chknoaplica").disabled = false;
    document.getElementById("chknoaplica").checked = false;
    document.getElementById("txtstock").disabled = false;
    document.getElementById("txtstockmin").disabled = false;
    document.getElementById("txtcodbarra").disabled = false;
    $("#lblpvenser").html("Precio Venta");
    $("#txtfvenc").val("dd/mm/aaaa");
    $("#txtcodbarra").val("");
    $("#txtdescripcion").val("");
    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");
    $("#txtpmayoreo").val("");
    $("#txtapartir").val("");
    $("#sldepartamento").val("0");
    $("#txtstock").val("");
    $("#txtstockmin").val("");

})
$("#rdrserv").on("click", function () {
    document.getElementById("rdrbien").checked = false;
    document.getElementById("rdrserv").checked = true;
    document.getElementById("rdrunca").checked = true;
    document.getElementById("rdrkigra").checked = false;
    document.getElementById("txtpcosto").disabled = true;
    document.getElementById("txtganancia").disabled = true;
    document.getElementById("txtpvenser").disabled = false;
    document.getElementById("txtpmayoreo").disabled = true;
    document.getElementById("txtapartir").disabled = true;
    document.getElementById("txtfvenc").disabled = true;
    document.getElementById("chknoaplica").disabled = true;
    document.getElementById("chknoaplica").checked = true;
    document.getElementById("rdrkigra").disabled = true;
    document.getElementById("txtstock").disabled = true;
    document.getElementById("txtstockmin").disabled = true;
    document.getElementById("txtcodbarra").disabled = true;
    $("#lblpvenser").html("Precio Servicio");
    $("#txtfvenc").val("dd/mm/aaaa");
    $("#txtcodbarra").val("");
    $("#txtdescripcion").val("");
    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");
    $("#txtpmayoreo").val("");
    $("#txtapartir").val("");
    $("#sldepartamento").val("0");
    $("#txtstock").val("");
    $("#txtstockmin").val("");


})
$("#rdrunca").on("click", function () {
    document.getElementById("rdrkigra").checked = false;
    document.getElementById("rdrunca").checked = true;
})
$("#rdrkigra").on("click", function () {
    document.getElementById("rdrkigra").checked = true;
    document.getElementById("rdrunca").checked = false;
})
$("#chknoaplica").on("click", function () {
    let chknoaplica = document.getElementById("chknoaplica").checked;
    if (chknoaplica) {

        $("txtfvenc").val("dd/mm/aaaa");
        document.getElementById("txtfvenc").disabled = true;
    } else {

        $("txtfvenc").val("dd/mm/aaaa");
        document.getElementById("txtfvenc").disabled = false;
    }
})
$("#txtganancia").keyup(function () {
     let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();
    if (pcosto != "") {
        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/CalcularPventaSinImpuestos", params).done(function (datos) {

            if (datos.dt != null) {
                $("#txtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#txtpvenser").val("");
            }
       

        })
    } else {
        alertify.error("el precio costo no debe estar vacio");
    }
})
$("#txtpcosto").keyup(function () {
    let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();
    if (pcosto.trim() != "") {
        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/CalcularPventaSinImpuestos", params).done(function (datos) {
            if (datos.dt != null) {
                $("#txtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#txtpvenser").val("");
            }
        })
    } else {
        alertify.error("el precio costo no debe estar vacio");
    }
})
$("#txtpmayoreo").keyup(function () {
    
    let pmayoreo = $("#txtpmayoreo").val();
    let pventa = $("#txtpvenser").val();

    let params = new Object();
    params.pmayoreo = pmayoreo;
    params.pventa = pventa;
    Post("Productos/calculoPrecios", params).done(function (datos) {
      
        if (datos.dt == "ok") {
            if (pmayoreo.trim() != "") {
                document.getElementById("txtapartir").disabled = false;
                $("#txtpmayoreo").css("border-color", "");
            } else {
                document.getElementById("txtapartir").disabled = true;
                $("#txtapartir").val("");
                $("#txtpmayoreo").css("border-color", "");
            }
        } else {

            alertify.error("El Precio mayoreo no debe ser mayor al precio de venta");
            $("#txtpmayoreo").css("border-color", "red");
        }

    })


})
$("#txtapartir").keyup(function () {
    
    let pmayoreo = $("#txtpmayoreo").val();
    let apartir = $("#txtapartir").val();

    if (pmayoreo.trim() == "") {
        document.getElementById("txtapartir").disabled = true;
        $("#txtapartir").val("");
    } else {
        //debugger;
        if (apartir < 2) {

            alertify.error("la cantidad de productos no debe ser menor a 2 para utilizar el precio de mayoreo");
            $("#txtapartir").val("");
            $("#txtapartir").focus();
            $("#txtapartir").css("border-color", "red");
        } else {
            $("#txtapartir").css("border-color", "");
        }

    }

})



/***************************************
        GUARDAR PRODUCTO
***************************************/

$("#btnguardar").on("click", function () {
    
    let rdbien = document.getElementById('rdrbien').checked;
    let rdservicio = document.getElementById('rdrserv').checked;

    let tipo = 0;

    let codbarra = $("#txtcodbarra").val();
    let desc = $("#txtdescripcion").val();

    let rdrunca = document.getElementById('rdrunca').checked;
    let rdrkigra = document.getElementById('rdrkigra').checked;

    let tproduct = 0;

    let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();
    let pventa = $("#txtpvenser").val();
    let pmayoreo = $("#txtpmayoreo").val();
    let apartir = $("#txtapartir").val();
    let sldepart = $("#sldepartamento").val();
    let existen = $("#txtstock").val();
    let minexisten = $("#txtstockmin").val();
    let fvenci = $("#txtfvenc").val();

    let sinoaplica = document.getElementById('chknoaplica').checked;
    let faplica = 0;

    if (rdservicio) {
        tipo = 2;
        if (desc.trim() == "") {
            alertify.error("Ingrese la descripción del producto");
            $("#txtdescripcion").val("");
            $("#txtdescripcion").focus();
            $("#txtdescripcion").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#txtdescripcion").css("border-color", "");
            alertify.error("Ingrese el precio del servicio del producto");
            $("#txtpvenser").val("");
            $("#txtpvenser").focus();
            $("#txtpvenser").css("border-color", "red");
            return false;
        } else if (sldepart.trim() == 0) {
            $("#txtpvenser").css("border-color", "");
            alertify.error("Seleccione un departamento");
            $("#sldepartamento").val(0);
            $("#sldepartamento").css("border-color", "red");
            return false;
        } else if (rdrunca) {

            tproduct = 1;

        } else if (rdrkigra) {
            tproduct = 2;

        } else {
            $("#txtpvenser").css("border-color", "");
            $("#sldepartamento").css("border-color", "");
            $("#txtdescripcion").css("border-color", "");
        }
    }


    if (rdbien) {
        tipo = 1;

        if (codbarra.trim() == "") {

            alertify.error("Ingrese el codigo de barrar del producto");
            $("#txtcodbarra").val("");
            $("#txtcodbarra").focus();
            $("#txtcodbarra").css("border-color", "red");
            return false;
        } else if (desc.trim() == "") {
            $("#txtcodbarra").css("border-color", "");
            alertify.error("Ingrese la descripción del producto");
            $("#txtdescripcion").val("");
            $("#txtdescripcion").focus();
            $("#txtdescripcion").css("border-color", "red");
            return false;
        } else if (pcosto.trim() == "") {
            $("#txtdescripcion").css("border-color", "");
            alertify.error("Ingrese el precio costo del producto");
            $("#txtpcosto").val("");
            $("#txtpcosto").focus();
            $("#txtpcosto").css("border-color", "red");
            return false;
        } else if (ganancia.trim() == "") {
            $("#txtpcosto").css("border-color", "");
            alertify.error("Ingrese el precio costo del producto");
            $("#txtganancia").val("");
            $("#txtganancia").focus();
            $("#txtganancia").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#txtganancia").css("border-color", "");
            alertify.error("Ingrese el precio de venta del producto");
            $("#txtpvenser").val("");
            $("#txtpvenser").focus();
            $("#txtpvenser").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() == "") {
            $("#txtpvenser").css("border-color", "");
            alertify.error("Ingrese el precio mayoreo del producto");
            $("#txtpmayoreo").val("");
            $("#txtpmayoreo").focus();
            $("#txtpmayoreo").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() != "") {
            if (apartir.trim() == "") {
                $("#txtpmayoreo").css("border-color", "");
                alertify.error("Ingrese la cantidad de productos para el precio mayoreo");
                $("#txtapartir").val("");
                $("#txtapartir").focus();
                $("#txtapartir").css("border-color", "red");
                return false;
            } else if (sldepart.trim() == 0) {
                $("#txtapartir").css("border-color", "");
                alertify.error("Seleccione un departamento");
                $("#sldepartamento").val(0);
                $("#sldepartamento").css("border-color", "red");
                return false;
            } else if (existen.trim() == "") {
                $("#sldepartamento").css("border-color", "");
                alertify.error("Ingrese la cantidad de existencias del producto");
                $("#txtstock").val("");
                $("#txtstock").focus();
                $("#txtstock").css("border-color", "red");
                return false;
            } else if (rdrunca) {
                $("#txtdescripcion").css("border-color", "");
                tproduct = 1;

            } else if (rdrkigra) {
                tproduct = 2;

            }
        }
    }


    if (sinoaplica) {
        faplica = 1
    } else {
        if (fvenci.trim() == "") {
            alertify.error("Ingrese la fecha de vencimiento");
            $("#txtfvenc").val("");
            $("#txtfvenc").css("border-color", "red");
            return false;
        } else {
            $("#txtfvenc").css("border-color", "");
        }
    }



    let params = new Object();
    params.tipo = tipo;
    params.codbarra = codbarra;
    params.desc = desc;
    params.tproduct = tproduct;
    params.pcosto = pcosto;
    params.ganancia = ganancia;
    params.pventa = pventa;
    params.pmayoreo = pmayoreo;
    params.apartir = apartir;
    params.sldepart = sldepart;
    params.existen = existen;
    params.minexisten = minexisten;
    params.fvenci = fvenci;
    params.faplica = faplica;
    Post("Productos/guardarProduct", params).done(function (datos) {

        if (datos.dt.response == 'ok') {
            swal({
                position: 'top-end',
                type: 'success',
                title: "Producto registrado correctamente",
                text: 'Guardado',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            }, function () {
                window.location = fnBaseURLWeb("Productos/Productos");
            })
        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: datos.dt.response,
                text: 'Valide los campos o contacte con el administrador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }

    })


})


$("#txtcodbarra").keyup(function () {
    $("#txtcodbarra").css("border-color", "");
})

$("#txtdescripcion").keyup(function () {
    $("#txtdescripcion").css("border-color", "");
})

$("#txtpcosto").keyup(function () {
    $("#txtpcosto").css("border-color", "");
})

$("#txtganancia").keyup(function () {
    $("#txtganancia").css("border-color", "");
})

$("#txtpvenser").keyup(function () {
    $("#txtpvenser").css("border-color", "");
})


$("#sldepartamento").keyup(function () {
    $("#sldepartamento").css("border-color", "");
})

$("#txtstock").keyup(function () {
    $("#txtstock").css("border-color", "");
})


$("#txtbuscadorp").keyup(function () {

    let buscar = $("#txtbuscadorp").val();
    var params = new Object();
    params.buscarp = buscar;
    Post("Productos/buscarProducto", params).done(function (datos) {

        if (datos.dt != null) {
            $("#bdlistprod").empty();
            for (var i = 0; i < datos.total; i++) {

                $("#bdlistprod").append('<tr>' +
                    '<td id="row_' + datos.dt[i].row + '" >' + datos.dt[i].idproducto + '</td>' +
                    '<td><input type="checkbox" id="cbox_' + datos.dt[i].row + '" /></td>' +
                    '<td>' + datos.dt[i].tipo + '</td>' +
                    '<td>' + datos.dt[i].codbarra + '</td>' +
                    '<td>' + datos.dt[i].desc + '</td>' +
                    '<td>' + datos.dt[i].tproduct + '</td>' +
                    '<td>' + datos.dt[i].depart + '</td>' +
                    '<td>' + datos.dt[i].pcosto + '</td>' +
                    '<td>' + datos.dt[i].pventa + '</td>' +
                    '<td>' + datos.dt[i].pmayoreo + '</td>' +

                    ((datos.dt[i].minexisten < datos.dt[i].existen) ? '<td style="color:#004501">' + datos.dt[i].existen + '</td>' :
                        (datos.dt[i].existen == 0) ? '<td style="color:#ff0000">' + datos.dt[i].existen + '</td>' :
                            (datos.dt[i].minexisten >= datos.dt[i].existen) ? '<td style="color:#ff6a00">' + datos.dt[i].existen + '</td>' : '') +

                    '<td>' + datos.dt[i].fvenci + '</td>' +

                    ((datos.dt[i].status == 1) ? '<td><span style="background:#004501; color:#fff">Activo</span></td>' :
                        (datos.dt[i].status == 0) ? '<td><span style="background:#ff0000; color:#fff">Desactivado</span></td>' :
                            (datos.dt[i].status == 2) ? '<td><span style="background:#ff6a00; color:#fff">Vencido</span></td>' : '') +

                    '</tr>')
            }
        }

    })

})


$("#sldepatamentosbuscar").change(function () {
    let slbuscar = $("#sldepatamentosbuscar").val();

    var params = new Object();
    params.slbuscar = slbuscar;
    Post("Productos/buscarProductodepart", params).done(function (datos) {

        if (datos.dt != null) {
            $("#bdlistprod").empty();
            for (var i = 0; i < datos.total; i++) {

                $("#bdlistprod").append('<tr>' +
                    '<td id="row_' + datos.dt[i].row + '" >' + datos.dt[i].idproducto + '</td>' +
                    '<td><input type="checkbox" id="cbox_' + datos.dt[i].row + '" /></td>' +
                    '<td>' + datos.dt[i].tipo + '</td>' +
                    '<td>' + datos.dt[i].codbarra + '</td>' +
                    '<td>' + datos.dt[i].desc + '</td>' +
                    '<td>' + datos.dt[i].tproduct + '</td>' +
                    '<td>' + datos.dt[i].depart + '</td>' +
                    '<td>' + datos.dt[i].pcosto + '</td>' +
                    '<td>' + datos.dt[i].pventa + '</td>' +
                    '<td>' + datos.dt[i].pmayoreo + '</td>' +

                    ((datos.dt[i].minexisten < datos.dt[i].existen) ? '<td style="color:#004501">' + datos.dt[i].existen + '</td>' :
                        (datos.dt[i].existen == 0) ? '<td style="color:#ff0000">' + datos.dt[i].existen + '</td>' :
                            (datos.dt[i].minexisten >= datos.dt[i].existen) ? '<td style="color:#ff6a00">' + datos.dt[i].existen + '</td>' : '') +

                    '<td>' + datos.dt[i].fvenci + '</td>' +

                    ((datos.dt[i].status == 1) ? '<td><span style="background:#004501; color:#fff">Activo</span></td>' :
                        (datos.dt[i].status == 0) ? '<td><span style="background:#ff0000; color:#fff">Desactivado</span></td>' :
                            (datos.dt[i].status == 2) ? '<td><span style="background:#ff6a00; color:#fff">Vencido</span></td>' : '') +

                    '</tr>')
            }
        }

    })

})


$("#btneliminar").on("click", function () {


    swal({
        title: '¿Esta seguro de eliminar el producto?',
        text: '¡Si no lo esta puede cancelar la accion!',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Si, Eliminar',
        closeOnConfirm: false
    }, function (isConfirm) {
        //debugger;
        if (isConfirm) {


            let tabla = $('.tab').DataTable();
            let data = tabla.rows().data();

            let hayseleccion = 0;
            let datos = "";

            for (var i = 1; i <= data.length; i++) {
                if ($('#cbox_' + i).is(":checked")) {
                    datos = datos + $.trim($("#row_" + i).text()) + "|";
                    hayseleccion = 1;
                }
            }

            if (hayseleccion == 1) {

                let params = new Object();
                params.datos = datos;
                Post("Productos/eliminarProducto", params).done(function (datos) {

                    if (datos.dt.response == "ok") {

                        swal({
                            position: 'top-end',
                            type: 'success',
                            title: "Se elimino el producto correctamente",
                            text: 'Producto eliminado',
                            showConfirmButton: true,
                            timer: 60000,
                            confirmButtonText: 'Cerrar'
                        }, function () {
                            window.location = fnBaseURLWeb("Productos/Productos");
                        })


                    }

                })


            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'No a seleccionado ningun producto',
                    text: 'debe seleccionar almenos un producto para eliminarlo.',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }

        }

    })

})

$("#btnvolver").on("click", function () {
    window.location = fnBaseURLWeb("Productos/Productos");
})

///**********************
//  MODIFICAR PRODUCTOS
//  **********************/

$("#btnModificar").on("click", function () {

  

    let tabla = $('.tab').DataTable();
    let data = tabla.rows().data();

    let hayseleccion = 0;
    let datos = "";

    for (var i = 1; i <= data.length; i++) {
        if ($('#cbox_' + i).is(":checked")) {
            datos = datos + $.trim($("#row_" + i).text()) + "|";
            hayseleccion = 1;
        }
    }


    if (hayseleccion == 1) {

        let params = new Object();
        params.datos = datos;
        Post("Productos/obtEditarProducto", params).done(function (datos) {

            if (datos.dt.response != "Error") {
                $("#lblprin").html("EDITAR PRODUCTO");
                document.getElementById("diveditproduct").style.display = "block";
                document.getElementById("divcatalogo").style.display = "none";

                $("#idproductos").val(datos.dt.idproducto);
                $("#obtsl").append("<option value=" + datos.dt.iddepartamento + ">" + datos.dt.departamento + "</option>");

                $("#edittxtiddepartamentos").val(datos.dt.iddepartamento);

                document.getElementById("edittxtstock").disabled = true;


                if (datos.dt.tipo1 == 1) {

                    $("#lblmensaje").html("Para modificar el inventario de un producto existente. Hazlo desde el modulo de inventarios.").css("color", "red");

                    document.getElementById('editrdrbien').checked = true;
                    document.getElementById("editrdrserv").disabled = true;

                    $("#edittxtcodbarra").val(datos.dt.codbarra);
                    $("#edittxtdescripcion").val(datos.dt.desc);

                    if (datos.dt.sevende == 1) {
                        document.getElementById('editrdrunca').checked = true;

                    } else {
                        document.getElementById('editrdrkigra').checked = true;
                    }

                    $("#edittxtpcosto").val(datos.dt.pcosto);
                    $("#edittxtganancia").val(datos.dt.ganancia);
                    $("#editlblpvenser").html("Precio venta");
                    $("#edittxtpvenser").val(datos.dt.pventa);
                    $("#edittxtpmayoreo").val(datos.dt.pmayoreo);
                    $("#edittxtapartir").val(datos.dt.apartir);
                    $("#edittxtstock").val(datos.dt.existen);
                    $("#edittxtstockmin").val(datos.dt.minexisten);

                    if (datos.dt.faplica == 0) {
                        
                        document.getElementById('editchknoaplica').checked = false;
                        document.getElementById("edittxtfvenc").value = datos.dt.fvenci;


                    } else {
                        document.getElementById('editchknoaplica').checked = true;
                        $("#edittxtfvenc").val("dd/mm/aaaa");
                    }

                    document.getElementById("edittxtstockmin").disabled = false;

                }


                if (datos.dt.tipo1 == 2) {
                    document.getElementById('editrdrserv').checked = true;

                    document.getElementById("editrdrbien").disabled = true;

                    $("#edittxtcodbarra").val(datos.dt.codbarra);
                    $("#edittxtdescripcion").val(datos.dt.desc);

                    if (datos.dt.sevende == 1) {
                        document.getElementById('editrdrunca').checked = true;
                        document.getElementById('editrdrkigra').disabled = true;
                    }
                    document.getElementById("rdrkigra").disabled = true;
                    document.getElementById("rdrkigra").checked = false;
                    document.getElementById("edittxtpcosto").disabled = true;
                    document.getElementById("edittxtganancia").disabled = true;


                    $("#editlblpvenser").html("Precio servicio");
                    $("#edittxtpvenser").val(datos.dt.pventa);
                    document.getElementById("edittxtpvenser").disabled = false;
                    document.getElementById("edittxtpmayoreo").disabled = true;
                    document.getElementById("edittxtapartir").disabled = true;
                    document.getElementById('editchknoaplica').checked = true;
                    document.getElementById("edittxtfvenc").disabled = true;
                    document.getElementById("editchknoaplica").disabled = true;
                    document.getElementById("edittxtcodbarra").disabled = true;
                    document.getElementById("edittxtstockmin").disabled = true;

                }




            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'Solo debe seleccionar un producto para editar',
                    text: 'No debe seleccionar mas de un producto.',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }

        })


    } else {
        swal({
            position: 'top-end',
            type: 'error',
            title: 'Seleccione almenos 1 producto',
            text: 'no a seleccionado un producto.',
            showConfirmButton: true,
            timer: 60000,
            confirmButtonText: 'Cerrar'
        })
    }




})


$("#editrdrunca").on("click", function () {
    document.getElementById("editrdrunca").checked = true;
    document.getElementById("editrdrkigra").checked = false;
})

$("#editrdrkigra").on("click", function () {
    document.getElementById("editrdrunca").checked = false;
    document.getElementById("editrdrkigra").checked = true;
})


$("#edittxtganancia").keyup(function () {
    debugger;
    let pcosto = $("#edittxtpcosto").val();
    let ganancia = $("#edittxtganancia").val();

    if (pcosto != "") {

        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/calcularPventaSinImpuestos", params).done(function (datos) {

            if (datos.dt != null) {
                $("#edittxtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#edittxtpvenser").val("");
            }


        })

    } else {

        alertify.error("El precio de costo no debe estar vacio");
    }



})

$("#edittxtpcosto").keyup(function () {
    //debugger;
    let pcosto = $("#edittxtpcosto").val();
    let ganancia = $("#edittxtganancia").val();

    if (pcosto.trim() != "") {

        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/CalcularPventaSinImpuestos", params).done(function (datos) {

            if (datos.dt != null) {
                $("#edittxtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#edittxtpvenser").val("");
            }



        })

    } else {
        alertify.error("El precio de costo no debe estar vacio");
    }



})

$("#edittxtpmayoreo").keyup(function () {

    let pmayoreo = $("#edittxtpmayoreo").val();
    let pventa = $("#edittxtpvenser").val();

    let params = new Object();
    params.pmayoreo = pmayoreo;
    params.pventa = pventa;
    Post("Productos/calculoPrecios", params).done(function (datos) {

        if (datos.dt == "ok") {
            if (pmayoreo.trim() != "") {
                document.getElementById("edittxtapartir").disabled = false;
                $("#edittxtpmayoreo").css("border-color", "");
            } else {
                document.getElementById("edittxtapartir").disabled = true;
                $("#edittxtapartir").val("");
                $("#edittxtpmayoreo").css("border-color", "");
            }
        } else {

            alertify.error("El Precio mayoreo no debe ser mayor al precio de venta");
            $("#edittxtpmayoreo").css("border-color", "red");
        }

    })



})

$("#edittxtapartir").keyup(function () {
    let pmayoreo = $("#edittxtpmayoreo").val();
    let apartir = $("#edittxtapartir").val();

    if (pmayoreo.trim() == "") {
        document.getElementById("edittxtapartir").disabled = true;
        $("#edittxtapartir").val("");
    } else {
        //debugger;
        if (apartir < 2) {

            alertify.error("la cantidad de productos no debe ser menor a 2 para utilizar el precio de mayoreo");
            $("#edittxtapartir").val("");
            $("#edittxtapartir").focus();
            $("#edittxtapartir").css("border-color", "red");
        } else {
            $("#edittxtapartir").css("border-color", "");
        }

    }

})


$("#btneditar").on("click", function () {
   

    let idproducto = $("#idproductos").val();

    let rdbien = document.getElementById('editrdrbien').checked;
    let rdservicio = document.getElementById('editrdrserv').checked;

    let tipo = 0;

    let codbarra = $("#edittxtcodbarra").val();
    let desc = $("#edittxtdescripcion").val();

    let rdrunca = document.getElementById('editrdrunca').checked;
    let rdrkigra = document.getElementById('editrdrkigra').checked;

    let tproduct = 0;

    let pcosto = $("#edittxtpcosto").val();
    let ganancia = $("#edittxtganancia").val();
    let pventa = $("#edittxtpvenser").val();
    let pmayoreo = $("#edittxtpmayoreo").val();
    let apartir = $("#edittxtapartir").val();
    let sldepart = $("#edittxtiddepartamentos").val();  //$("#editsldepart").val();
    let existen = $("#edittxtstock").val();
    let minexisten = $("#edittxtstockmin").val();
    let fvenci = $("#edittxtfvenc").val();

    let sinoaplica = document.getElementById('editchknoaplica').checked;
    let faplica = 0;

    if (rdservicio) {
        tipo = 2;
        if (desc.trim() == "") {
            alertify.error("Ingrese la descripción del producto");
            $("#edittxtdescripcion").val("");
            $("#edittxtdescripcion").focus();
            $("#edittxtdescripcion").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#edittxtdescripcion").css("border-color", "");
            alertify.error("Ingrese el precio del servicio del producto");
            $("#edittxtpvenser").val("");
            $("#edittxtpvenser").focus();
            $("#edittxtpvenser").css("border-color", "red");
            return false;
        } else if (sldepart.trim() == 0) {
            $("#edittxtpvenser").css("border-color", "");
            alertify.error("Seleccione un departamento");
            $("#editsldepartamento").val(0);
            $("#editsldepartamento").css("border-color", "red");
            return false;
        } else if (rdrunca) {

            tproduct = 1;

        } else if (rdrkigra) {
            tproduct = 2;

        } else {
            $("#edittxtpvenser").css("border-color", "");
            $("#editsldepartamento").css("border-color", "");
            $("#edittxtdescripcion").css("border-color", "");
        }
    }


    if (rdbien) {
        tipo = 1;

        if (codbarra.trim() == "") {

            alertify.error("Ingrese el codigo de barrar del producto");
            $("#edittxtcodbarra").val("");
            $("#edittxtcodbarra").focus();
            $("#edittxtcodbarra").css("border-color", "red");
            return false;
        } else if (desc.trim() == "") {
            $("#edittxtcodbarra").css("border-color", "");
            alertify.error("Ingrese la descripción del producto");
            $("#edittxtdescripcion").val("");
            $("#edittxtdescripcion").focus();
            $("#edittxtdescripcion").css("border-color", "red");
            return false;
        } else if (pcosto.trim() == "") {
            $("#edittxtdescripcion").css("border-color", "");
            alertify.error("Ingrese el precio costo del producto");
            $("#edittxtpcosto").val("");
            $("#edittxtpcosto").focus();
            $("#edittxtpcosto").css("border-color", "red");
            return false;
        } else if (ganancia.trim() == "") {
            $("#edittxtpcosto").css("border-color", "");
            alertify.error("Ingrese el precio costo del producto");
            $("#edittxtganancia").val("");
            $("#edittxtganancia").focus();
            $("#edittxtganancia").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#txtganancia").css("border-color", "");
            alertify.error("Ingrese el precio de venta del producto");
            $("#edittxtpvenser").val("");
            $("#edittxtpvenser").focus();
            $("#edittxtpvenser").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() == "") {
            $("#edittxtpvenser").css("border-color", "");
            alertify.error("Ingrese el precio mayoreo del producto");
            $("#edittxtpmayoreo").val("");
            $("#edittxtpmayoreo").focus();
            $("#edittxtpmayoreo").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() != "") {
            if (apartir.trim() == "") {
                $("#edittxtpmayoreo").css("border-color", "");
                alertify.error("Ingrese la cantidad de productos para el precio mayoreo");
                $("#edittxtapartir").val("");
                $("#edittxtapartir").focus();
                $("#edittxtapartir").css("border-color", "red");
                return false;
            } else if (sldepart.trim() == 0) {
                $("#edittxtapartir").css("border-color", "");
                alertify.error("Seleccione un departamento");
                $("#editsldepartamento").val(0);
                $("#editsldepartamento").css("border-color", "red");
                return false;
            } else if (existen.trim() == "") {
                $("#editsldepart").css("border-color", "");
                alertify.error("Ingrese la cantidad de existencias del producto");
                $("#edittxtstock").val("");
                $("#edittxtstock").focus();
                $("#edittxtstock").css("border-color", "red");
                return false;
            } else if (rdrunca) {
                $("#edittxtdescripcion").css("border-color", "");
                tproduct = 1;

            } else if (rdrkigra) {
                tproduct = 2;

            }
        }
    }


    if (sinoaplica) {
        faplica = 1
    } else {
        if (fvenci.trim() == "") {
            alertify.error("Ingrese la fecha de vencimiento");
            $("#edittxtfvenc").val("");
            $("#edittxtfvenc").css("border-color", "red");
            return false;
        } else {
            $("#edittxtfvenc").css("border-color", "");
        }
    }



    let params = new Object();
    params.idproducto = idproducto;
    params.tipo = tipo;
    params.codbarra = codbarra;
    params.desc = desc;
    params.tproduct = tproduct;
    params.pcosto = pcosto;
    params.ganancia = ganancia;
    params.pventa = pventa;
    params.pmayoreo = pmayoreo;
    params.apartir = apartir;
    params.sldepart = sldepart;
    params.existen = existen;
    params.minexisten = minexisten;
    params.fvenci = fvenci;
    params.faplica = faplica;
    Post("Productos/editarProduct", params).done(function (datos) {

        if (datos.dt.response == 'ok') {
            swal({
                position: 'top-end',
                type: 'success',
                title: "Producto editado correctamente",
                text: 'Editado',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            }, function () {
                window.location = fnBaseURLWeb("Productos/Productos");
            })
        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: datos.dt.response,
                text: 'Valide los campos o contacte con el administrador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }

    })


})


$("#editbtnvolver").on("click", function () {
    window.location = fnBaseURLWeb("Productos/Productos");
})


$("#editsldepartamento").change(function () {
    let id = $("#editsldepartamento").val();
    $("#edittxtiddepartamentos").val(id);
})

///*****************************************************/

$("#btndepartamentos").on("click", function () {
    window.location = fnBaseURLWeb("Departamentos/Departamentos");
})

$("#cerrarModulo").on("click", function () {
    window.location = fnBaseURLWeb("Panel/Panel");
})