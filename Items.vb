Module Items


    Public Sub itemsInRooms() ' takes items in "itemlist" (just a universal "census" for all items) and places them in their respective rooms
        For Each i In ItemList
            For Each r In rooms
                If i.startlocation = r.code Then
                    r.items.Add(i)
                End If
            Next
        Next
    End Sub


    Public Sub Scavenge() ' search room for items
        If player.currentRoom.items.Count > 0 Then
            print("You notice in your vicinity some items:")
            For n = 0 To player.currentRoom.items.Count - 1
                itemlisting(player.currentRoom.items(n).name)
            Next
        Else
            print("According to your eyes and sensors, there is nothing of consequence.")
        End If
    End Sub
    Public Sub takeItem() ' take an item from current room
        If player.currentRoom.items.Count > 0 Then
            Dim chosentake As textforprocessing = userItemChoice("What do you want to take?", 2)
            Dim revoke As Integer
            Dim counter As Integer = 0
            Dim Itemlocated As Boolean = False

            For Each i In player.currentRoom.items
                Dim itemname As String = capsfivecharmax(i.name)
                If chosentake.modifiedtext = itemname And i.startlocation <> 99 Then
                    i.startlocation = 99
                    playerinv.Add(i)
                    Itemlocated = True
                    print(i.pickuptext + "you then placed it in your bag. (" + i.name + " added to inventory.)")
                    revoke = (counter)
                    For Each ii In ItemList
                        If ii.code = i.code Then
                            ii.startlocation = 99
                        End If
                    Next
                End If
                counter = counter + 1
            Next

            If Itemlocated = False Then
                print("You can't see any " + chosentake.originaltext + " in this area.")
            Else
                player.currentRoom.items.RemoveAt(revoke)
            End If
        Else
            print("According to your eyes and sensors, there is nothing to pick up.")
        End If
    End Sub
    Public Sub dropItem() ' put an item down
        Dim chosendrop As textforprocessing = userItemChoice("What do you want to drop?", 1)
        Dim revoke As Integer
        Dim counter As Integer = 0
        Dim Itemlocated As Boolean = False

        For Each i In playerinv
            Dim itemname As String = capsfivecharmax(i.name)
            If chosendrop.modifiedtext = itemname Then
                revoke = counter
                Itemlocated = True
                print("You have dropped " + i.name + ".")
                i.startlocation = player.currentRoom.code
                player.currentRoom.items.Add(i)
            End If
            counter = counter + 1
        Next

        If Itemlocated = False Then
            print("You can't see " + chosendrop.originaltext + " in your bag.")
        Else
            playerinv.RemoveAt(revoke)
        End If
    End Sub
    Public Sub showInventory() ' look at user inventory
        Dim alreadyprinted As Boolean = False
        If playerinv.Count > 0 Then
            print("Your inventory is as follows:")
            alreadyprinted = True
            For Each i In playerinv
                itemlisting(i.name)
            Next
        ElseIf playercombinv.Count > 0 Then
            If alreadyprinted = False Then
                print("Your inventory is as follows:")
            End If
            For Each i In playercombinv
                itemlisting(i.name)
            Next
        Else
            print("You check your bag, and it is empty. Go find some treasure.")
        End If
    End Sub


    Public Sub ExamineItem() ' inspect an item (prints tempitem.text)
        Dim chosenexam As textforprocessing = userItemChoice("What do you want to examine?", 1)
        Dim revoke As Integer
        Dim counter As Integer = 0
        Dim Itemlocated As Boolean = False

        For Each i In playerinv
            Dim itemname As String = capsfivecharmax(i.name)
            If chosenexam.modifiedtext = itemname Then
                revoke = counter
                Itemlocated = True
                print(i.text)
            End If
            counter = counter + 1
        Next

        If Itemlocated = False Then
            print("You can't see " + chosenexam.originaltext + " in your bag to inspect.")
        End If
    End Sub

    Public Sub CombineItem() ' combines or crafts items

        If playerinv.Count > 1 Then

            Dim item1 As item = Nothing
            Dim item2 As item = Nothing
            Dim firstitemfound As Boolean = False
            Dim seconditemfound As Boolean = False
            Dim alreadyused As Boolean = True
            Dim firstOption As textforprocessing = userItemChoice("Enter the name of the first object", 1)
            Dim secondOption As textforprocessing
            secondOption.modifiedtext = ""

            For Each i In playerinv
                If firstOption.modifiedtext = capsfivecharmax(i.name) Then
                    item1 = i
                    firstitemfound = True
                End If
            Next

            If item1.type = 2 Then
                print("You can't craft things with food!")
            End If

            If firstitemfound = False Then
                    print("You cant see " + firstOption.originaltext + " in your bag.")
                Else
                While alreadyused = True
                    secondOption = userItemChoice("Enter the name of the second object", 1)
                    For Each i In playerinv
                        If secondOption.modifiedtext = capsfivecharmax(i.name) Then
                            item2 = i
                        End If
                    Next
                    If item2.code = item1.code Then
                        print("You have already chosen this item!")
                        alreadyused = True
                    ElseIf item2.type = 2 Then
                        print("You can't craft things with food!.")
                    Else
                        seconditemfound = True
                        alreadyused = False
                    End If
                    If alreadyused = False Then
                        Dim counter As Integer = 0
                        For Each c In Combineditemlist
                            If item1.code + item2.code = c.code Then
                                Combineditemlist.RemoveAt(counter)
                                playercombinv.Add(c)
                                playerinv.Remove(item1)
                                playerinv.Remove(item2)
                            End If
                            counter = counter + 1
                        Next
                        print("You tried for a while, and eventually created a useful item, which is now in your bag. (Item crafted.)")
                    Else
                        print("You tried for a while, but could not find a useful combination of the items. (Not a correct crafting combo.)")
                    End If
                End While
            End If

            Else
                If playerinv.Count = 1 Then
                print("You have only one item in your bag.")
            End If
            If playerinv.Count < 1 Then
                print("You have no items in your bag.")
            End If

        End If
    End Sub
End Module
