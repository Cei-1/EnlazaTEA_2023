function CorreoValido(event, textbox) {
    var id = textbox.id;
    var input = event.target.value;
    var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;

    if (regex.test(input)) {
        $("#" + id).css('border', '2px solid #28a745');
        $("#lblEmailErrorMessage").text('');
        return true;
    }
    else if (id === "txtEmail") {
        $("#" + id).css('border', '2px solid #a94442');
        $("#lblEmailErrorMessage").text('No es un formato de Correo valido');
        event.preventDefault();

        return false;
    }
}


function ValidarPassword() {
    var input = document.getElementById('txtPassword');
    input.addEventListener('copy', function (event) {
        event.preventDefault();
    });
    input.addEventListener('paste', function (event) {
        event.preventDefault();
    });

    var passwordValue = input.value;
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])([A-Za-z\d$@$!%*?&]|[^ ]){8,15}$/;

    if (regex.test(passwordValue)) {
        $("#txtPassword").css('border', '2px solid #28a745');
        $("#lblPasswordErrorMessage").text('');
        return true;
    } else {
        $("#txtPassword").css('border', '2px solid #a94442');
        $("#lblPasswordErrorMessage").text('Debe contener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial ($@$!%*?&)');
        event.preventDefault();

        return false;

    }
}


function SoloLetras(event, textbox) {
    var id = textbox.id;
    var input = event.key;
    var inputlength = input.length;

    if (/^[a-zA-ZñÑ ]+$/.test(input) || input === " ") {
        if (id == "txtNombre") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblNombreErrorMessage").text('');
        } else if (id == "txtApellidoPaterno") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblApellidoPaternoErrorMessage").text('');
        } else if (id == "txtApellidoMaterno") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblApellidoMaternoErrorMessage").text('');
        } else if (id == "txtParentesco") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblParentescoErrorMessage").text('');
        } else if (id == "txtColonia") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblColoniaErrorMessage").text('');
        } else if (id == "txtMunicipio") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblMunicipioErrorMessage").text('');
        } else if (id == "txtEstado") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblEstadoErrorMessage").text('');
        } else if (id == "txtEscolaridad") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblEscolaridadMessage").text('');
        } else if (id == "txtEspecialidad") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblEspecialidadErrorMessage").text('');
        } else if (id == "txtEscolaridad") {
            $("#" + id).css('border', '2px solid #28a745');
            $("#lblEscolaridadMessage").text('');
        }
        return true;
    } else {
        if (id == "txtNombre") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblNombreErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtApellidoPaterno") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblApellidoPaternoErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtApellidoMaterno") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblApellidoMaternoErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtParentesco") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblParentescoErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtColonia") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblColoniaErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtMunicipio") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblMunicipioErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtEstado") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblEstadoErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtEscolaridad") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblEscolaridadMessage").text('Solo se permiten letras');
        } else if (id == "txtEspecialidad") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblEspecialidadErrorMessage").text('Solo se permiten letras');
        } else if (id == "txtEscolaridad") {
            $("#" + id).css('border', '2px solid #a94442');
            $("#lblEscolaridadMessage").text('Solo se permiten letras');
        }
        return false;
    }
}


function SoloNumeros(event, textbox) {
    var id = textbox.id;
    var input = event.key;
    // Convertir el input a mayúsculas
    input = input.toUpperCase();

    if (/^[0-9]+$/.test(input)) {

        $("#" + id).css('border', '2px solid #28a745');
        $("#" + id + "ErrorMessage").text('');

        if (id == "txtTelefono") {
            $("#lblTelefonoErrorMessage").text('');
        } else if (id == "txtCelular") {
            $("#lblCelularErrorMessage").text('');
        } else if (id == "txtEdad") {
            $("#lblEdadErrorMessage").text('');
        } else if (id == "txtCP") {
            $("#lblCPErrorMessage").text('');
        } else if (id == "txtNoCedula") {
            $("#lblNoCedulaErrorMessage").text('');
        }
        return true;
    } else {
        $("#" + id).css('border', '2px solid #a94442');
        if (id == "txtTelefono") {
            $("#lblTelefonoErrorMessage").text('Solo se permiten números'); //jQuery
        } else if (id == "txtCelular") {
            $("#lblCelularErrorMessage").text('Solo se permiten números'); //jQuery
        } else if (id == "txtEdad") {
            $("#lblEdadErrorMessage").text('Solo se permiten números'); //jQuery
        } else if (id == "txtCP") {
            $("#lblCPErrorMessage").text('Solo se permiten números'); //jQuery
        } else if (id == "txtNoCedula") {
            $("#lblNoCedulaErrorMessage").text('Solo se permiten números'); //jQuery
        }
        return false;
    }
}


function NumerosLetras(event, textbox) {
    var id = textbox.id;
    var input = event.key;

    input = input.toUpperCase(); // Convertir el input a mayúsculas

    if (/^[a-zA-Z0-9\/\s]+$/.test(input)) {
        $("#" + id).css('border', '2px solid #28a745');
        $("#" + id + "ErrorMessage").text('');
        if (id == "txtCalle") {
            $("#lblCalleErrorMessage").text('');
        } else if (id == "txtNumeroExterior") {
            $("#lblNumeroExteriorErrorMessage").text('');
        } else if (id == "txtNumeroInterior") {
            $("#lblNumeroInteriorErrorMessage").text('');
        }
        return true;
    } else {
        $("#" + id).css('border', '2px solid #a94442');
        if (id == "txtCalle") {
            $("#lblCalleErrorMessage").text('Solo se permiten letras y números'); //jQuery
        } else if (id == "txtNumeroExterior") {
            $("#lblNumeroExteriorErrorMessage").text('Solo se permiten letras y números'); //jQuery
        } else if (id == "txtNumeroInterior") {
            $("#lblNumeroInteriorErrorMessage").text('Solo se permiten letras y números'); //jQuery
        }
        return false;
    }
}



function ConfirmarPassword() {
    var password = document.getElementById("txtPassword").value;
    var confirmarPassword = document.getElementById("txtConfirmPassword").value;

    if (password !== confirmarPassword) {
        $("#lblConfirmPasswordErrorMessage").text('Las contraseñas no coinciden. Por favor, inténtalo de nuevo.') //jQuery
        $("#txtConfirmPassword").css('border', '2px solid #a94442');
        return false;
    } else {
        $("#lblConfirmPasswordErrorMessage").text('') //jQuery
        $("#txtConfirmPassword").css('border', '2px solid #28a745');
        //$("#txtConfirmPassword").css('border', '2px solid #23C552');


    }

    return true;
}
