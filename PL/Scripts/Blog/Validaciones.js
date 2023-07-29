var ValidarImagen = function (event, fileInput) {

    const maxSizeInBytes = 10 * 1024 * 1024; // 2MB
    //const maxSizeInBytes = 2 * 1024 * 1024; // 2MB
    const file = fileInput.files[0];//files contiene una lista de lo seleccionado y selecciona solo el primero 

    // Verificar el tamaño del archivo
    if (file.size > maxSizeInBytes) {
        $("#lblImagenErrorMessage").text('El tamaño máximo permitido es de 10MB') //jQuery
        $("#fuimgBlog").css('border', '2px solid #a94442');
        fileInput.value = ''; // Limpiar el campo de entrada
        return false;
    }

    // Verificar el tipo de archivo
    const regex = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
    if (!regex.test(file.name)) {
        $("#lblImagenErrorMessage").text('Por favor, selecciona un archivo de imagen válido (JPEG, JPG, PNG o GIF).') //jQuery
        $("#fuimgBlog").css('border', '2px solid #a94442');
        fileInput.value = ''; // Limpiar el campo de entrada
        return false;
    }

    //Mostrar una visualizacion previa de la imagen
    var output = document.getElementById('imgBlog');
    output.src = URL.createObjectURL(event.target.files[0]);

    output.onload = function () {
        URL.revokeObjectURL(output.src) // free memory
    }
};