Module ofhotspot
    Public Sub hotspotsinrooms()
        For Each h In hotspots
            For Each r In rooms
                If h.location = r.code Then
                    r.hotspots.Add(h)
                End If
            Next
        Next
    End Sub
    Public Sub showHotspots()
        For Each h In player.currentRoom.hotspots
            itemlisting(h.name)
        Next
    End Sub

    Public Sub examineHotspot()
        If player.currentRoom.hotspots.Count > 0 Then
            Dim hotspotexamchoice As textforprocessing = userItemChoice("What do you want to loom at more closely", 0)
            Dim isfound As Boolean = False
            For Each h In player.currentRoom.hotspots
                If hotspotexamchoice.modifiedtext = capsfivecharmax(h.name) Then
                    print(h.searchText)
                    isfound = True
                End If
            Next
            If isfound = False Then
                print("You can't seem to see " + hotspotexamchoice.originaltext + " nearby.")
            End If
        Else
            print("It doesn't look like there is anything of conseqence nearby.")
        End If
    End Sub
End Module
