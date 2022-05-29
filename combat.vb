
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

    Function EnemyChoice() ' Returns enemy data of players chosen enemy
        If player.currentRoom.enemies.Count > 0 Then
            print("Which enemy would you like to attack?")
            For Each e In player.currentRoom.enemies
                itemlisting(e.name)
            Next
            Dim choice As textforprocessing
            choice.originaltext = read()
            choice.modifiedtext = capsfivecharmax(choice.originaltext)
            Dim enemychosen As enemy = Nothing
            For Each e In player.currentRoom.enemies
                If capsfivecharmax(e.name) = choice.modifiedtext Then
                    enemychosen = e
                End If
            Next
            If enemychosen.code = Nothing Then
                print("You cannot see " + choice.originaltext + " nearby.")
                Return Nothing
            Else
                Return enemychosen
            End If
        Else
            print("There are no enemies nearby")
            Return Nothing
        End If
    End Function

    Function WeaponChoice() ' Returns weaponitem data of players chosen weapon
        print("Which weapon would you like to use?")
        For Each i In playerinv
                If i.type > 1 Then
                    itemlisting(i.name)
                End If
            Next
        itemlisting("Melee")
        Dim choice As textforprocessing
            choice.originaltext = read()
            choice.modifiedtext = capsfivecharmax(choice.originaltext)
            Dim weaponchosen As item = Nothing
        For Each i In playerinv
            If capsfivecharmax(i.name) = choice.modifiedtext Then
                weaponchosen = i
            End If
        Next
        If capsfivecharmax("Melee") = choice.modifiedtext Then
            For Each i In ItemList
                If i.code = -1 Then
                    weaponchosen = i
                End If
            Next
        End If
        If weaponchosen.code = Nothing Then
                print("You cannot see " + choice.originaltext + " in your inventory.")
                Return Nothing
            Else
                Return weaponchosen
            End If
    End Function

    Sub Attack()
        Dim opponant As enemy = EnemyChoice()
        Dim weapon As item = WeaponChoice()

        If player.speed > opponant.speed Then

        End If
    End Sub

    Sub Defend()

    End Sub
    Public Function CombatLoop()
        Dim Iscombat As Boolean
        While Iscombat = True
            print("You are currently in combat.")
            print("Type a COMMAND to continue.")
            print("")

            Dim playerinput As String = capsfivecharmax(read())

            Select Case playerinput
                Case "ATTAC", "ATK", "FIGHT", "KILL", "HIT"
                    Attack()
                Case "DEFEN", "DEF", "SHIEL", "PROTE", "GUARD"
                    Defend()
                Case "RUN", "FLEE", "LEAVE", ""
            End Select
        End While
    End Function
End Module
