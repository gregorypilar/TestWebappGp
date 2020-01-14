var app = new Vue({
    el: '#app',
    data: {
        permisos: [],
        asignacionPermisos: [],
        nuevoTipoPermiso: {},
        nuevaAsignacion: {}
    },
    methods: {
        //Permisos
        showAsignacion: function (event) {
            this.nuevaAsignacion = {
                id: 0, nombreEmpleado: "", apellidoEmpleado: "",
                tipoPermisoId: 0, permisoDescripcion: "", fechaPermiso: new Date()
            };
            $('#modalAsignacionPermiso').modal('show');
        },
        editAsignacion: function (data) {
            this.nuevaAsignacion = data;
            $('#modalAsignacionPermiso').modal('show');
        },
        guardarasignacion: function (asignacion) {
            if (asignacion.id > 0) {
                axios.put('/api/permisos', asignacion);
            } else {
                axios.post('/api/permisos', asignacion);
            }
        },
        borrarAsignacion: function (asignacion) {
            console.log(asignacion);
            var self = this;
            axios.delete(`api/permisos/${asignacion.id}`)
                .then(function (response) {
                    self.getData();
                });
        },

        //Tipos de Permisos
        showPermisoModal: function (event) {
            this.nuevoTipoPermiso = { id: 0, descripcion: "" };
            $('#modalPermisos').modal('show');
        },
        editPermisoModal: function (data) {
            this.nuevoTipoPermiso = data;
            $('#modalPermisos').modal('show');
        },

        guardarPermiso: function (permiso) {
            if (permiso.id > 0) {
                axios.put('/api/tipopermiso', permiso);
            } else {
                axios.post('/api/tipopermiso', permiso);
            }
        },
        borrarPermiso: function (permiso) {
            console.log(permiso);
            var self = this;
            axios.delete(`api/tipopermiso/${permiso.id}`)
                .then(function (response) {
                    self.getData();
                });
        },
        // Generales
        getData: function () {
            var self = this;
            axios.get('/api/permisos')
                .then(function (response) {
                    self.asignacionPermisos = response.data.data;
                    console.log(response);
                })
                .catch(function (error) {
                    console.log(error);
                });

            axios.get('/api/tipopermiso')
                .then(function (response) {
                    self.permisos = response.data.data;
                    console.log(response);
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    },




    created: function () {
        //
        this.getData();
    }
});