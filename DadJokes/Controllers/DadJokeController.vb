Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class DadJokeController
        Inherits ApiController

        ''' <summary>
        ''' Returns a randon DadJoke
        ''' </summary>
        ''' <returns>String</returns>
        Public Function GetValue() As String
            Return DadJoke.GetJoke()
        End Function

        ''' <summary>
        ''' Returns a specific DadJoke
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>String</returns>
        Public Function GetValue(ByVal id As Integer) As String
            Return DadJoke.GetJoke(id)
        End Function

        ''' <summary>
        ''' Top Secret
        ''' </summary>
        ''' <param name="value"></param>
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