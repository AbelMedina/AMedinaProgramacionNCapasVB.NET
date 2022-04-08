@ModelType ML.User
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>
    @Styles.Render("~/Content/bootstrap.css")
</head>
<body>
    <style>
        html, body {
            
            height: 100vh;
            
            margin: 0;
            padding: 0;
        }
    </style>
    @Using Html.BeginForm("Login", "Login", FormMethod.Post, New With {.enctype = "multipart/form-data"})
        @<fieldset>
            <div class="container" style="margin-top: calc((100% / 4) - 200px);">
                <h2 class="text-center">Login</h2>
                <div class="text-center" style="display: flex;justify-content:center;align-items:center">
                    <div class="jumbotron col-lg-4">
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.UserName)
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                @Html.TextBoxFor(Function(model) model.UserName, New With {.class = "form-control"})
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.UserName, Nothing, New With {.class = "text-danger"})
                        </div>
                        <div class="form-group">
                            @Html.LabelFor(Function(model) model.Password)
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                @Html.TextBoxFor(Function(model) model.Password, New With {.class = "form-control", .type = "password"})
                            </div>
                            @Html.ValidationMessageFor(Function(model) model.Password, Nothing, New With {.class = "text-danger"})
                        </div>
                        <div class="form-group">
                            <button class="btn btn-primary">Iniciar sesión</button>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    End Using
    <div>
    </div>
</body>
</html>
