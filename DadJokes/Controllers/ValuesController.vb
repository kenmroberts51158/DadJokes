Imports System.Net
Imports System.Web.Http

Public Class ValuesController
    Inherits ApiController

    ''' <summary>
    ''' Returns all DadJokes
    ''' </summary>
    ''' <returns>String()</returns>
    Public Function GetValues() As IEnumerable(Of String)
        Return DadJoke.GetJokes()
    End Function

    ''' <summary>
    ''' Top Secret
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns>???</returns>
    Public Function GetValue(ByVal id As Integer) As String
        Return "go away"
    End Function

    '' POST api/values
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub

    '' PUT api/values/5
    'Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    'End Sub

    '' DELETE api/values/5
    'Public Sub DeleteValue(ByVal id As Integer)

    'End Sub
End Class
