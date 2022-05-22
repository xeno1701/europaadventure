
Module combat
    Public Sub Die(cause As String)
        Console.Clear()
        Threading.Thread.Sleep(400)
        WrtLnCentered("You Died!", 5)
        titledecor("You Died!", 5)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        Threading.Thread.Sleep(400)
        If cause.Length <> 0 Then
            WrtLnCentered("Cause of death: " + cause + ".", 5)
            titledecor("Cause of death: " + cause + ".", 5)
            Threading.Thread.Sleep(2000)
        End If
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Environment.Exit(0)
    End Sub
End Module
