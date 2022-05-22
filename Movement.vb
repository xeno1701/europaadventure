Module Movement
    Public Sub CurrentLocation()
        print("Your positioning system reports you are in " & player.currentRoom.name & ".")
    End Sub

    Public Sub LookAround()
        print("Your positioning system reports you are in " & player.currentRoom.name & ".")
        print(player.currentRoom.text)

    End Sub

    Public Sub Travel()
        If IsDebugMode = True Then
            debugp("Where would you like to teleport. (And by that I mean a room code..)")
            Try
                Dim inputstr As Integer = read()
                player.currentRoom = rooms(inputstr)
            Catch
                debugp("Something went a bit wrong then.")
                print("Type a COMMAND to continue.")
                print("")
            End Try

            LookAround()
        Else
            print("Unfortunately, that command is not understood.")
            print("Type a COMMAND to continue.")
            print("")
        End If

    End Sub
    Public Sub goNorth()
        If player.currentRoom.exitNorth = 99 Then
            errorLocation()
        Else
            player.currentRoom = rooms(player.currentRoom.exitNorth - 1)

            LookAround()
        End If

    End Sub

    Public Sub errorLocation()
        print("Unfortunately, That direction is blocked.")
    End Sub

    Public Sub goSouth()
        If player.currentRoom.exitSouth = 99 Then
            errorLocation()
        Else
            player.currentRoom = rooms(player.currentRoom.exitSouth - 1)

            LookAround()
        End If

    End Sub

    Public Sub goEast()
        If player.currentRoom.exitEast = 99 Then
            errorLocation()
        Else
            player.currentRoom = rooms(player.currentRoom.exitEast - 1)

            LookAround()
        End If

    End Sub

    Public Sub goWest()
        If player.currentRoom.exitWest = 99 Then
            errorLocation()
        Else
            player.currentRoom = rooms(player.currentRoom.exitWest - 1)

            LookAround()
        End If

    End Sub

End Module
