Imports System.Web.Hosting

''' <summary>
''' Handles all DadJoke functions
''' (c) Kamikaze Software 2018 - All Rights Reserved.
''' Portions developed by Wet Floor (r)
''' Technical assistance provided by Sullivan Tire and Auto Service, Inc. 
''' Inspired by Mr. Horn's Halo Hour and ItsMrsPenguin2U
''' </summary>
Public Class DadJoke

    Private Const myFilePath As String = "\App_Data\dadjokes.txt"
    Private Shared myJokeArray As String() = IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath))
    Private Shared myRandomGenerator As Random = New Random()

    Private Sub New()
        ' prevents object creation
    End Sub

    Public Shared Function GetJoke() As String
        Try
            Return myJokeArray(myRandomGenerator.Next(0, myJokeArray.Count))
        Catch ex As Exception
            Return "Hey this ain't no joke; " & ex.Message
        End Try
    End Function

    Public Shared Function GetJoke(ByVal id As Integer) As String
        Try
            Return myJokeArray(id)
        Catch ex As Exception
            Return "Hey this ain't no joke; " & ex.Message
        End Try
    End Function

    Public Shared Function GetJokes() As String()
        Return myJokeArray
    End Function

    Public Shared Sub AddJoke(ByVal newJoke As String)
        Try
            If IsNothing(newJoke) = False And Len(newJoke.Trim) > 0 Then
                ' update the file if we have somthing
                Dim lines As List(Of String) = IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath)).ToList
                lines.Add(newJoke.Replace(Chr(34), Chr(39))) ' replace " with '
                IO.File.WriteAllLines(HostingEnvironment.MapPath(myFilePath), lines)
                ' refresh the singleton array
                myJokeArray = IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath))
            End If
        Catch ex As Exception
            ' just smile and wave boys, smile and wave.
        End Try
    End Sub

    Public Shared Sub DeleteJoke(ByVal id As Integer)
        Try
            If (id) > 0 Then
                ' update the file if we have somthing
                Dim lines As List(Of String) = IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath)).ToList
                lines.RemoveAt(id)
                IO.File.WriteAllLines(HostingEnvironment.MapPath(myFilePath), lines)
                ' refresh the singleton array
                myJokeArray = IO.File.ReadAllLines(HostingEnvironment.MapPath(myFilePath))
            End If
        Catch ex As Exception
            ' just smile and wave boys, smile and wave.
        End Try
    End Sub

End Class
