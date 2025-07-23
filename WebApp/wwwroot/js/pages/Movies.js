function MoviesViewController() {
    this.ViewName = "Movies";
    this.ApiEndpointName = "Movie";

    this.InitView = function () {
        console.log("Movie init view --> ok");
        this.LoadTable();

        $("#btnCreate").click(function () {
            var vc = new MoviesViewController();
            vc.Create();
        });
        $("#btnUpdate").click(function () {
            var vc = new MoviesViewController();
            vc.Update();
        });
        $("#btnDelete").click(function () {
            var vc = new MoviesViewController();
            vc.Delete();
        });
    };

    this.LoadTable = function () {
        var ca = new ControlActions();
        var service = this.ApiEndpointName + "/RetriveAll";
        var urlService = ca.GetUrlApiService(service);

        var columns = [];
        columns.push({ 'data': 'id' });
        columns.push({ 'data': 'title' });
        columns.push({ 'data': 'description' });
        columns.push({ 'data': 'releaseDate' });
        columns.push({ 'data': 'genre' });
        columns.push({ 'data': 'director' });

        $('#tblMovies').DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            columns: columns
        });

        $('#tblMovies tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');
            var movieDTO = $('#tblMovies').DataTable().row(row).data();

            $("#txtId").val(movieDTO.id);
            $("#txtTitle").val(movieDTO.title);
            $("#txtDescription").val(movieDTO.description);
            $("#txtReleaseDate").val(movieDTO.releaseDate.split("T")[0]);
            $("#txtGenre").val(movieDTO.genre);
            $("#txtDirector").val(movieDTO.director);
        });
    };

    this.Create = function () {
        var movieDTO = {};
        movieDTO.id = 0;
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01!";

        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndpointName + "/Create";

        ca.PostToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();
        });
    };

    this.Update = function () {
        var movieDTO = {};
        movieDTO.id = $("#txtId").val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01!";

        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndpointName + "/Update";

        ca.PutToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();
        });
    };

    this.Delete = function () {
        var movieDTO = {};
        movieDTO.id = $("#txtId").val();
        movieDTO.created = "2025-01-01";
        movieDTO.updated = "2025-01-01!";

        movieDTO.title = $("#txtTitle").val();
        movieDTO.description = $("#txtDescription").val();
        movieDTO.releaseDate = $("#txtReleaseDate").val();
        movieDTO.genre = $("#txtGenre").val();
        movieDTO.director = $("#txtDirector").val();

        var ca = new ControlActions();
        var urlService = this.ApiEndpointName + "/Delete";

        ca.DeleteToAPI(urlService, movieDTO, function () {
            $('#tblMovies').DataTable().ajax.reload();
        });
    };
}

// Documento listo
$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
});
