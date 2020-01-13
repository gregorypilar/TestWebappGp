var app = new Vue({
    el: '#app',
    data: {
        permisos: [],
        asignacionPermisos: []
    },





    created: function () {
        var self = this;
        //
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
});