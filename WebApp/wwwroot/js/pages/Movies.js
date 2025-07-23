function MoviesViewController() {
    this.ViewName = "Movies";
    this.ApiEndpointName = "Movie";

    this.InitView = function () {
        console.log("Movie init view --> ok");
        this.LoadTable();
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

        $("#tblMovies").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            columns: columns
        });
    };
}

$(document).ready(function () {
    var vc = new MoviesViewController();
    vc.InitView();
});
