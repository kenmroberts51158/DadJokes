Imports System.Web.Hosting

Public Class DadJoke

    Private Const myFilePath As String = "\App_Data\dadjokes.txt"
    Private Shared myJokeArray As String() = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath))
    Private Shared myRandomGenerator As Random = New Random()

    Public Shared ReadOnly Property GetInstance As DadJoke
        Get
            Static Instance As DadJoke = New DadJoke
            Return Instance
        End Get
    End Property

    Private Sub New()
        ' prevents object creation
    End Sub

    Public Function GetJoke() As String
        Return myJokeArray(myRandomGenerator.Next(0, myJokeArray.Count))
    End Function

    Public Function GetJoke(ByVal id As Integer) As String
        Try
            Return myJokeArray(id)
        Catch ex As Exception
            Return "Hey this ain't no joke, I don't have dadjoke # " & id & "!"
        End Try
    End Function

    Public Function GetJokes() As String()
        Return myJokeArray
    End Function

    Public Shared Sub AddJoke(ByVal newJoke As String)

        ' update the file if we have somthing
        If IsNothing(newJoke) = False And Len(newJoke.Trim) > 0 Then
            newJoke = newJoke.Replace(Chr(34), Chr(39)) ' replace " with '
            System.IO.File.AppendAllText(HostingEnvironment.MapPath(myFilePath), Environment.NewLine & newJoke)
            ' refresh the singleton array
            myJokeArray = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath))
        End If

    End Sub

End Class
