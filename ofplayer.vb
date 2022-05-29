Module ofplayer
    Public Structure playablecharacter
        Dim health As Double
        Dim currentRoom As room
        Dim atk As Double
        Dim def As Double
        Dim speed As Double
    End Structure

    Public Sub radiation()
        countspermin = (player.currentRoom.radiolevel + Averageinventoryradiation()) * 60
        If countspermin > 10 Then
            player.health = player.health - (countspermin / 16)
            If IsDebugMode = True Then
                debugp("CPS: " + Convert.ToString(countspermin) + ", Absorbed Dose: " + Convert.ToString(countspermin / 16))
            End If
        End If
    End Sub
    Public Sub printplayerstats()

        print("Your health is: " + Convert.ToString(player.health) + "/20")
        print("The radiation level (per second) is: " + Convert.ToString(countspermin / 60) + ".")
    End Sub

    Function Averageinventoryradiation()
        Dim averageinvradiation As Double
        If playerinv.Count >= 1 Then
            For Each i In playerinv
                averageinvradiation = averageinvradiation + i.itemradiolevel
            Next
            averageinvradiation = averageinvradiation / playerinv.Count
            Return averageinvradiation
        Else
            Return 0
        End If
    End Function

    Public Sub checkifalive()
        If IsDebugMode = True Then
            player.health = 20
        End If
        If player.health <= 0 Then
            If countspermin / 16 > 1 Then
                Die("Most likely radiation poisoning.")
            End If
            Die("Multiple factors.")
        Else

        End If
    End Sub
End Module
