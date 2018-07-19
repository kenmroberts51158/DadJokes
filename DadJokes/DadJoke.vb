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

End Class
