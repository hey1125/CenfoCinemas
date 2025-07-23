function UsersViewController() {
    this.ViewName = "Users";
    this.ApiEndpointName = "User";



    this.InitView = function () {
        console.log("User init view --> ok");
        this.LoadTable();

        $("#btnCreate").click(function () {
            var vc = new UsersViewController();
            vc.create();
        });
        $("#btnUpdate").click(function () {
            var vc = new UsersViewController();
            vc.Update();
        });
        $("#btnDelete").click(function () {
            var vc = new UsersViewController();
            vc.Delete();
        });

        /*
        {
            "usercode": "dv",
            "name": "jose",
            "email": "valeriocdaniel@gmail.com",
            "password": "12345678",
            "dateOfBirth": "2004-11-25T00:00:00",
            "status": "AC",
            "id": 3,
            "createdAt": "2025-06-16T23:50:12.95",
            "updatedAt": "0001-01-01T00:00:00"
        }
        */
    };

    this.LoadTable = function () {
        var ca = new ControlActions();
        var service = this.ApiEndpointName + "/RetriveAll";
        var urlService = ca.GetUrlApiService(service);

        var columns = [];
        columns[0] = { 'data': "id" };
        columns[1] = { 'data': "usercode" };
        columns[2] = { 'data': "name" };
        columns[3] = { 'data': "email" };
        columns[4] = { 'data': "dateOfBirth" }; 
        columns[5] = { 'data': "status" };


        $('#tblUsers').DataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            columns: columns
        });

        $('#tblUsers tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            $("#txtId").val(userDTO.id);
            $("#txtUserCode").val(userDTO.usercode);
            $("#txtName").val(userDTO.name);
            $("#txtEmail").val(userDTO.email);
            $("#txtBDate").val(userDTO.dateOfBirth);
            $("#txtStatus").val(userDTO.status);
            $("#txtPassword").val(userDTO.password)

            var onlyDate = userDTO.dateOfBirth.split("T");
            $("#txtBDate").val(onlyDate[0]);
        });
    }; 
    this.create = function () {
        var userDTO = {};
        userDTO.id = 0;
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01!"

        userDTO.usercode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.dateOfBirth = $("#txtBDate").val();
        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlservice = this.ApiEndpointName + "/Create";

        ca.PostToAPI(urlservice, userDTO, function () {
          
            $('#tblUsers').DataTable().ajax.reload();

        }
        )

    }

    this.Update = function () {
        var userDTO = {};
        userDTO.id =$("#txtId").val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01!"

        userDTO.usercode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.dateOfBirth = $("#txtBDate").val();
        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlservice = this.ApiEndpointName + "/Update";
        ca.PutToAPI(urlservice, userDTO, function (){
            $('#tblUsers').DataTable().ajax.reload();
        })
    }
    this.Delete = function () {
        var userDTO = {};
        userDTO.id= $("#txtId").val();
        userDTO.created = "2025-01-01";
        userDTO.updated = "2025-01-01!"

        userDTO.usercode = $("#txtUserCode").val();
        userDTO.name = $("#txtName").val();
        userDTO.email = $("#txtEmail").val();
        userDTO.status = $("#txtStatus").val();
        userDTO.dateOfBirth = $("#txtBDate").val();
        userDTO.password = $("#txtPassword").val();

        var ca = new ControlActions();
        var urlservice = this.ApiEndpointName + "/Delete";

        ca.DeleteToAPI(urlservice, userDTO, function () {
            $('#tblUsers').DataTable().ajax.reload();
        })
    }
} 


// Documento listo
$(document).ready(function () {
    var vc = new UsersViewController();
    vc.InitView();
});
