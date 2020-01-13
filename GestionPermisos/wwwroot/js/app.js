var app = new Vue({
    el: '#app',
    data: {
        permisos: [{ id: 1, descripcion: "permiso 1" }, { id: 2, descripcion: "permiso 2" }],
        asignacionPermisos: [
            { id: 1, nombreEmpleado: "nombre 1", apellidoEmpleado: "apellido 1", fechaPermiso: "2015-01-01", permisoId: 1, permisoDescripcion: "Permiso 1" },
            { id: 2, nombreEmpleado: "nombre 2", apellidoEmpleado: "apellido 2", fechaPermiso: "2015-01-01", permisoId: 2, permisoDescripcion: "Permiso 2" }
        ]
    }
})