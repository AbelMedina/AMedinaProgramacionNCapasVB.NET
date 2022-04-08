@ModelType ML.User
@Code
    ViewData("Title") = "Form"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@*<h2>Form</h2>*@
<div class="container">
    <div class="row">
        <div class="col-md-12">
            <h2>Usuarios</h2>
            <h5>Ingrese los datos del Usuario:</h5>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            @Using Html.BeginForm("Form", "User", FormMethod.Post, New With {.enctype = "multipart/form-data"})
                @<fieldset>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-12">
                                @Html.LabelFor(Function(model) model.IdUsuario, New With {.class = "hidden"})
                                @Html.TextBoxFor(Function(model) model.IdUsuario, New With {.class = "hidden form-control"})
                                @Html.ValidationMessageFor(Function(model) model.IdUsuario)
                            </div>
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.UserName)
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    @Html.TextBoxFor(Function(model) model.UserName, New With {.class = "form-control"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.UserName, Nothing, New With {.class = "text-danger"})
                            </div>
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.Nombre)
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    @Html.TextBoxFor(Function(model) model.Nombre, New With {.class = "form-control"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.Nombre, Nothing, New With {.class = "text-danger"})
                            </div>
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.ApellidoPaterno)
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    @Html.TextBoxFor(Function(model) model.ApellidoPaterno, New With {.class = "form-control"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.ApellidoPaterno, Nothing, New With {.class = "text-danger"})
                            </div>
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.ApellidoMaterno)
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    @Html.TextBoxFor(Function(model) model.ApellidoMaterno, New With {.class = "form-control"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.ApellidoMaterno, Nothing, New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.Foto)
                                <input type="file" name="UserFoto" onchange="readURL(this);" />
                                @If Model.Foto IsNot Nothing Then
                                    @<img id="UserFoto" src="data:image/jpeg;base64,@Convert.ToBase64String(Model.Foto)" width="100" height="100" />
                                Else
                                    @<img id="UserFoto" src="~/Content/IMG/icons8-user-not-found.png" style="height:150px;width:150px" />
                                End If
                            </div>
                            @Html.HiddenFor(Function(model) model.Foto)
                            <div class="col-md-3 col-sm-6">
                                @Html.LabelFor(Function(model) model.Password)
                                <div class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    @Html.TextBoxFor(Function(model) model.Password, New With {.class = "form-control"})
                                </div>
                                @Html.ValidationMessageFor(Function(model) model.Password, Nothing, New With {.class = "text-danger"})
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3 col-sm-6 ">
                                <input type="submit" value="Guardar" class="btn btn-success" />
                                @Html.ActionLink("Regresar", "GetAll", "User", htmlAttributes:=New With {.class = "btn btn-danger"})
                            </div>
                        </div>
                    </div>
                </fieldset>
            End Using
        </div>
    </div>
</div>

@Scripts.Render("~/Bundles/jquery")
<script type="text/javascript">
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#UserFoto').attr('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0])
        }
    }
</script>