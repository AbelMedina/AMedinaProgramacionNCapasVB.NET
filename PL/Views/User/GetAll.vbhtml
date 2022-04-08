@ModelType ML.User
@Code
    ViewData("Title") = "GetAll"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>GetAll</h2>
<div class="row">
    <div class="col-sm-12">
        <h5>Seleccione un usuario para editarlo o + para agregar...</h5>
        <hr />
    </div>
</div>

<div style="float:right;">
    @Html.ActionLink("+", "Form", "User", htmlAttributes:=New With {.class = "btn btn-success"})
</div>

<table class="table table-bordered table-responsive">
    <thead>
        <tr>
            <td>Editar</td>
            <td class="hidden">IdUsuario</td>
            <td>UserName</td>
            <td>Nombre</td>
            <td>Foto</td>
            <td>Password</td>
            <td>Eliminar</td>
        </tr>
    </thead>
    <tbody>
        @For Each usuario As ML.User In Model.Users
            @<tr>
                <td><a class="btn btn-warning glyphicon glyphicon-edit" href="@Url.Action("Form", "User", New With {.IdUsuario = usuario.IdUsuario})"></a></td>
                <td class="hidden">@usuario.IdUsuario</td>
                <td>@usuario.UserName</td>
                <td>@usuario.Nombre @usuario.ApellidoPaterno @usuario.ApellidoMaterno</td>
                @*<td>@usuario.Foto</td>*@
                @If usuario.Foto IsNot Nothing Then
                    @<td><img src="data:image/jpeg;base64,@Convert.ToBase64String(usuario.Foto)" style="height:150px;width:150px;" /></td>
                Else
                    @<td><img src="~/Content/IMG/icons8-user-not-found.png" style="height:150px;width:150px;" /></td>
                End If
                <td>@usuario.Password</td>
                <td><a class="btn btn-danger glyphicon glyphicon-trash" href="@Url.Action("Delete", "User", New With {.IdUsuario = usuario.IdUsuario})" onclick="return confirm('Estas seguro que deseas eliminar este registro');"></a></td>
            </tr>
        Next
    </tbody>
</table>