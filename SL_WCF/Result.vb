<DataContract>
Public Class Result
    <DataMember>
    Public Property Correct As Boolean
    <DataMember>
    Public Property ErrorMessage As String
    <DataMember>
    Public Property Obj As Object
    <DataMember>
    Public Property Objs As List(Of Object)
    <DataMember>
    Public Property Ex As Exception

End Class
