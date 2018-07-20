Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class DadJokeController
        Inherits ApiController

        Public Function GetValue() As String
            Dim myDadJoke As DadJoke = DadJoke.GetInstance
            Return myDadJoke.GetJoke()
        End Function

        Public Function GetValue(ByVal id As Integer) As String
            Dim myDadJoke As DadJoke = DadJoke.GetInstance
            Return myDadJoke.GetJoke(id)
        End Function

        Public Sub PostValue(<FromBody()> ByVal value As String)
            DadJoke.AddJoke(value)
        End Sub

    End Class
End Namespace