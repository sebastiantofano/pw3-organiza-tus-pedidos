$('.sweet-confirm').click(function () {
    let articuloAEliminar = $(this);
    swal({
        title: "Esta seguro que desea eliminar el artículo ?",
        text: "Usted no podrá volver a restaurar el artículo !!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, deseo eliminarlo !!",
        closeOnConfirm: false,
        cancelButtonText: "Cancelar"

    },
        function () {
            //Select the parent form and submit
            console.log(articuloAEliminar)
            articuloAEliminar.parent("form").submit();
            swal("Eliminado !!", "El artículo ha sido eliminado correctamente !!", "success");
        });
});