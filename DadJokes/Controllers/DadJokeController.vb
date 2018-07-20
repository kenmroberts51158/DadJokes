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
            Try
                If value.StartsWith("@@") Then
                    DadJoke.DeleteJoke(CInt(value.Replace("@@", "")))
                Else
                    DadJoke.AddJoke(value)
                End If
            Catch ex As Exception
                ' just smile and wave boys, smile and wave.
            End Try
        End Sub

    End Class
End Namespace