$(document).ready(function () {
    $('#FuImgProducto').change(function (event) {
        validarArchivo(event);
    });
});

// Validar archivo al seleccionarlo
function validarArchivo(event) {
    var archivoInput = event.target;
    var archivo = archivoInput.files[0];
    var formatoValido = /\.(jpg|jpeg|png)$/i.test(archivo.name);
    var tamañoValido = archivo.size <= 100 * 1024; // 65 KB en bytes

    if (!formatoValido) {
        var errorMessage = 'Solo se admiten archivos con formato .jpg, .png o .jpeg';
        var errorElementSet = $('#Imagen-error');
        errorElementSet.text(errorMessage);
        archivoInput.value = ''; // Limpiar el campo de archivo seleccionado
    } else if (!tamañoValido) {
        var errorMessage = 'El archivo debe ser menor a 60 KB.';
        var errorElementSet = $('#Imagen-error');
        errorElementSet.text(errorMessage);
        archivoInput.value = ''; // Limpiar el campo de archivo seleccionado
    } else {
        // El archivo cumple con el formato y tamaño válido
        var errorElementSet = $('#Imagen-error');
        errorElementSet.text('');
        mostrarImagen(archivo);
    }
}

// Mostrar imagen previa
function mostrarImagen(archivo) {
    var reader = new FileReader();
    reader.onload = function (e) {
        $('#Img').attr('src', e.target.result);
    };
    reader.readAsDataURL(archivo);
}