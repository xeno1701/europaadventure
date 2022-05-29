Module initalise
    Public IsDebugMode As Boolean = False
    Public IsInvunerable As Boolean = False
    Public Structure room
        'variables for room structure.
        Dim code As Integer
        Dim name As String
        Dim text As String
        Dim radiolevel As Double ' In counts per second
        Dim exitNorth As Integer
        Dim exitSouth As Integer
        Dim exitEast As Integer
        Dim exitWest As Integer
        Dim items As List(Of item)
        Dim enemies As List(Of enemy)
        Dim hotspots As List(Of hotspot)
    End Structure
    Public Structure hotspot
        ' variables for hotspot structure
        Dim code As Integer
        Dim name As String
        Dim text As String
        Dim location As Integer
        Dim searchText As String
        Dim searchEvent As _Event
        Dim interactsWith As Integer
        Dim interactionEvent As _Event
        Dim interactParameters As List(Of Integer)
    End Structure
    Public Structure enemy
        ' variables for enemy structure
        Dim code As Integer
        Dim type As Double
        Dim health As Double
        Dim atk As Double
        Dim def As Double
        Dim speed As Double
        Dim name As String
        Dim text As String
        Dim startlocation As Integer
        Dim probablilty As Double
        Dim enemysinv As List(Of item)
    End Structure
    Public Structure item
        ' variables for item structure
        Dim code As Integer
        Dim name As String
        Dim text As String
        Dim type As Integer ' 0 is generic, 1 is food, 2+ is weapon, -1 is effector
        Dim pickuptext As String
        Dim itemradiolevel As Double ' In counts per second
        Dim startlocation As Integer
        Dim active As Boolean
    End Structure
    Public Structure Combineditems
        Dim code As Integer
        Dim name As String
        Dim text As String
        Dim item1 As Integer ' Item Code
        Dim item2 As Integer ' Item Code
        Dim pickuptext As String
        Dim itemradiolevel As Double ' In counts per second
        Dim active As Boolean

    End Structure

    Public Sub initialiseall(Rooms As Boolean, Items As Boolean, Hotspots As Boolean, CombatEnemies As Boolean)
        If Rooms = True Then
            roominit() ' Creates rooms
        End If
        If Items = True Then
            iteminit() ' Creates items
            itemsInRooms() 'Puts items from itemlist into right room lists
        End If
        If Hotspots = True Then
            hotspotinit()
            hotspotsinrooms() 'Puts hotspots from hotspotlist into right room lists
        End If
        If CombatEnemies = True Then
            Enemyinit()
        End If
    End Sub

    Sub iteminit()
        'first section redeclares a tempitem objects properties to the items, adding them to a universal list as it goes
        'second section creates the rooms

        Dim tempItem As item

        tempItem.code = -1
        tempItem.name = "Melee"
        tempItem.type = 2
        tempItem.text = ""
        tempItem.pickuptext = ""
        tempItem.itemradiolevel = 0
        tempItem.startlocation = 99
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 1
        tempItem.name = "A Europan Pebble"
        tempItem.type = 4
        tempItem.text = "A dense, sparkly pebble with a slighly cystalized, sharp edge - this is a very good tool or weapon."
        tempItem.pickuptext = "The europan pebble had a smooth texture as you held it, as "
        tempItem.itemradiolevel = 0.1
        tempItem.startlocation = 1
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 2
        tempItem.name = "A Metal hull plating peice"
        tempItem.type = 0
        tempItem.text = "A sturdy, charred peice of your shuttle's hull. Too bad it crashed - so much for DIY engine repair at the space station."
        tempItem.pickuptext = "The charred hull peice was jagged edged, you nearly cur yourself a lot before "
        tempItem.itemradiolevel = 0.7
        tempItem.startlocation = 1
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 3
        tempItem.name = "A blue Energy Crystal"
        tempItem.type = 0
        tempItem.text = "A very rare mesmorisingly complex crystal from the dark side of Europa. Packed full of chemical energy according to your sensors; could be used as fuel for a ship."
        tempItem.pickuptext = "The crystal glowed so bright it lit up a wide area. Mesmorising as it was, "
        tempItem.itemradiolevel = 0.2
        tempItem.startlocation = 3
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 4
        tempItem.name = "A red Energy Crystal"
        tempItem.type = 0
        tempItem.text = "A very rare mesmorisingly complex crystal from the caves of Europa. Packed full of self regulating energy according to your sensors; could be used as a computer's power supply."
        tempItem.pickuptext = "The crystal glowed in complex pulses, one after another. Mesmorising as it was, "
        tempItem.itemradiolevel = 1.7
        tempItem.startlocation = 99 'Once torch found, updated to 6
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 5
        tempItem.name = "A SpaceQ Standard food ration pack."
        tempItem.type = 2
        tempItem.text = "The wrapper was overly hard to open, and the sawdust-like crumbs covering the abhorrent cracker looked more unappetising than a bowl of blood."
        tempItem.pickuptext = "You picked up the crinkly packet, "
        tempItem.itemradiolevel = 0.007
        tempItem.startlocation = 3
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 6
        tempItem.name = "A crewmate-cooked food ration pack."
        tempItem.type = 2
        tempItem.text = "The wrapper was overly hard to open, and the sawdust-like crumbs covering the abhorrent cracker looked more unappetising than a bowl of blood."
        tempItem.pickuptext = "You picked up the crinkly packet, "
        tempItem.itemradiolevel = 0.007
        tempItem.startlocation = 4
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 7
        tempItem.name = "A homemade lunch."
        tempItem.type = 2
        tempItem.text = "The wrapper was overly hard to open, and the sawdust-like crumbs covering the abhorrent cracker looked more unappetising than a bowl of blood."
        tempItem.pickuptext = "You picked up the crinkly packet, "
        tempItem.itemradiolevel = 0.007
        tempItem.startlocation = 99
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 8
        tempItem.name = "An Unknown Metal Ore"
        tempItem.type = 2
        tempItem.text = "A very heavy, weirdly textured metal, that according to your sensors is radioactve and has a very complex silicon matrix within the metal."
        tempItem.pickuptext = "The ore was loose enough to pull away, into your hands. Now the proud owner, "
        tempItem.itemradiolevel = 17
        tempItem.startlocation = 4
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 9
        tempItem.name = "A SpaceQ Standard LED flashlight"
        tempItem.type = 0
        tempItem.text = "A remarkably standard flashlight, except for the fact that it is covered by advertisments."
        tempItem.pickuptext = "The simple device was plastered with ads, but was sturdy. After testing it worked, "
        tempItem.itemradiolevel = 0.009
        tempItem.startlocation = 9
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 10
        tempItem.name = "A SpaceQ Anti-Radiation Pendant"
        tempItem.type = -1
        tempItem.text = "A small round stone on a string, with the SpaceQ logo on the label."
        tempItem.pickuptext = "This pendant would come in handy, so "
        tempItem.itemradiolevel = -5
        tempItem.startlocation = 1
        tempItem.active = False
        ItemList.Add(tempItem)

        tempItem.code = 10
        tempItem.name = "A Mysterious Alien Longsword"
        tempItem.type = 6
        tempItem.text = "A mysterious crystal embedded metal longsword that shimmered beautiful in the Sun."
        tempItem.pickuptext = "The pure and intricate beauty of the sword made you almost not want to put it away, however  "
        tempItem.itemradiolevel = 0.0002
        tempItem.startlocation = 6
        tempItem.active = False
        ItemList.Add(tempItem)

        ' ---------------- ------ START COMBINED ITEM INIT -------------------------

        Dim tempCombinedItemList As Combineditems

        tempCombinedItemList.code = 5
        tempCombinedItemList.name = "A Rudamentary Power Supply"
        tempCombinedItemList.text = "The red crystal and the psuedo-crystalline nature of the pebble has created a pretty good self sustaining power source."
        tempCombinedItemList.pickuptext = "You thought you should probably take this with you, "
        tempCombinedItemList.item1 = 1
        tempCombinedItemList.item1 = 4
        tempCombinedItemList.itemradiolevel = 2
        tempCombinedItemList.active = False
        Combineditemlist.Add(tempCombinedItemList)

        tempCombinedItemList.code = 12
        tempCombinedItemList.name = "A Rudamentary Navigation Computer"
        tempCombinedItemList.text = "The blue crystal and the silicon matrix of the ore make this computer satsfactory to navigate your ship home."
        tempCombinedItemList.pickuptext = "You thought you should probably take this with you, "
        tempCombinedItemList.item1 = 8
        tempCombinedItemList.item1 = 4
        tempCombinedItemList.itemradiolevel = 0.8
        tempCombinedItemList.active = False
        Combineditemlist.Add(tempCombinedItemList)

        tempCombinedItemList.code = 14
        tempCombinedItemList.name = "A Scrappy Shuttle Shell"
        tempCombinedItemList.text = "The thrusters from the old shuttle and most of the hull from it was patched up with metal peices you found."
        tempCombinedItemList.pickuptext = ""
        tempCombinedItemList.item1 = 2
        tempCombinedItemList.item1 = 11
        tempCombinedItemList.itemradiolevel = 0.8
        tempCombinedItemList.active = False
        Combineditemlist.Add(tempCombinedItemList)

        tempCombinedItemList.code = 25
        tempCombinedItemList.name = "A Working Shuttle"
        tempCombinedItemList.text = "The shuttle shell you made along with the navigation array make this shuttle just about functional enough to soar through space back to Earth."
        tempCombinedItemList.pickuptext = ""
        tempCombinedItemList.item1 = 13
        tempCombinedItemList.item1 = 12
        tempCombinedItemList.itemradiolevel = 0.8
        tempCombinedItemList.active = False
        Combineditemlist.Add(tempCombinedItemList)
    End Sub

    Sub roominit()

        rooms(0).code = 1
        rooms(0).name = "the Shuttle crash site/Crater"
        rooms(0).text = "You are in the giant crater made when your space shuttle crash-landed. It is about 50 metres deep, and about 150 metres across." &
            " "
        rooms(0).radiolevel = 0.2
        rooms(0).exitNorth = 2
        rooms(0).exitWest = 2
        rooms(0).exitSouth = 4
        rooms(0).exitEast = 3
        rooms(0).items = New List(Of item)
        rooms(0).enemies = New List(Of enemy)
        rooms(0).hotspots = New List(Of hotspot)

        rooms(1).code = 2
        rooms(1).name = "the Surface of Europa"
        rooms(1).text = "You are in a vast, cold desert or ice and rock. In the distance you can see hills and valleys. There are also humanoid figures in the distance." &
            " "
        rooms(1).radiolevel = 0.3
        rooms(1).exitNorth = 99
        rooms(1).exitWest = 1
        rooms(1).exitSouth = 4
        rooms(1).exitEast = 3
        rooms(1).items = New List(Of item)
        rooms(1).enemies = New List(Of enemy)
        rooms(1).hotspots = New List(Of hotspot)

        rooms(2).code = 3
        rooms(2).name = "the Dark Side of Europa"
        rooms(2).text = "You are in the shadow of Jupiter, the sun being blocked out means the radiation is lower here. That also means anything alive would want to hide here too..." &
            " "
        rooms(2).radiolevel = 1.6
        rooms(2).exitNorth = 99
        rooms(2).exitWest = 2
        rooms(2).exitSouth = 99
        rooms(2).exitEast = 9
        rooms(2).items = New List(Of item)
        rooms(2).enemies = New List(Of enemy)
        rooms(2).hotspots = New List(Of hotspot)

        rooms(3).code = 4
        rooms(3).name = "a Ravine"
        rooms(3).text = "You have climbed down into a deep and icy ravine. There are ores and mysterious scattered about and there is a cave entrance ahead." &
            " "
        rooms(3).radiolevel = 0.4
        rooms(3).exitNorth = 2
        rooms(3).exitWest = 99
        rooms(3).exitSouth = 5
        rooms(3).exitEast = 99
        rooms(3).items = New List(Of item)
        rooms(3).enemies = New List(Of enemy)
        rooms(3).hotspots = New List(Of hotspot)

        rooms(4).code = 5
        rooms(4).name = "a Shallow Tunnel"
        rooms(4).text = "This shallow cave you have entered is barely lit from the light from the ravine. A chill just ran down your spine." &
            " "
        rooms(4).radiolevel = 1.3
        rooms(4).exitNorth = 99
        rooms(4).exitWest = 4
        rooms(4).exitSouth = 99
        rooms(4).exitEast = 6
        rooms(4).items = New List(Of item)
        rooms(4).enemies = New List(Of enemy)
        rooms(4).hotspots = New List(Of hotspot)

        rooms(5).code = 6
        rooms(5).name = "a Dark Hollow"
        rooms(5).text = "You have climbed down even further into another cavern. There isn't enough light for you to see." &
            " "
        rooms(5).radiolevel = 1.8
        rooms(5).exitNorth = 99
        rooms(5).exitWest = 5
        rooms(5).exitSouth = 99
        rooms(5).exitEast = 99 ' Once torch found, this value will be updated to 7, along with the .text value
        rooms(5).items = New List(Of item)
        rooms(5).enemies = New List(Of enemy)
        rooms(5).hotspots = New List(Of hotspot)

        rooms(6).code = 7
        rooms(6).name = "a Hot, Mysterious Cavern"
        rooms(6).text = "You have climbed so deep that the temperature has risen. There is a smell of gas." &
            " "
        rooms(6).radiolevel = 2.7
        rooms(6).exitNorth = 3
        rooms(6).exitWest = 6
        rooms(6).exitSouth = 99 ' Once gas collector found, this value will be updated to 8, along with the .text value
        rooms(6).exitEast = 99
        rooms(6).items = New List(Of item)
        rooms(6).enemies = New List(Of enemy)
        rooms(6).hotspots = New List(Of hotspot)

        rooms(7).code = 8
        rooms(7).name = "a Gas Deposit"
        rooms(7).text = "The smell of gas was very strong." &
            " "
        rooms(7).radiolevel = 4.0
        rooms(7).exitNorth = 7
        rooms(7).exitWest = 99
        rooms(7).exitSouth = 99
        rooms(7).exitEast = 99
        rooms(7).items = New List(Of item)
        rooms(7).enemies = New List(Of enemy)
        rooms(7).hotspots = New List(Of hotspot)

        rooms(8).code = 9
        rooms(8).name = "your Infected Crewmates' base."
        rooms(8).text = "The base was made of scraps from you shuttle, you couldn't help but notice how badly the gasses and radiation had affected your former allies." &
            " "
        rooms(8).radiolevel = 15.0
        rooms(8).exitNorth = 3
        rooms(8).exitWest = 3
        rooms(8).exitSouth = 3
        rooms(8).exitEast = 99
        rooms(8).items = New List(Of item)
        rooms(8).enemies = New List(Of enemy)
        rooms(8).hotspots = New List(Of hotspot)

        rooms(9).code = 10
        rooms(9).name = "your Repaired shuttle."
        rooms(9).text = "The repairs were dire, but any way to get off of Europa is acceptable." &
            " "
        rooms(8).radiolevel = 0.003
        rooms(9).exitNorth = 1
        rooms(9).exitWest = 1
        rooms(9).exitSouth = 1
        rooms(9).exitEast = 1
        rooms(9).items = New List(Of item)
        rooms(9).enemies = New List(Of enemy)
        rooms(9).hotspots = New List(Of hotspot)

        rooms(10).code = 11
        rooms(10).name = "**DEBUG**"
        rooms(10).text = "Empty room." &
            " "
        rooms(8).radiolevel = 5
        rooms(10).exitNorth = 99
        rooms(10).exitWest = 99
        rooms(10).exitSouth = 99
        rooms(10).exitEast = 99
        rooms(10).items = New List(Of item)
        rooms(10).enemies = New List(Of enemy)
        rooms(10).hotspots = New List(Of hotspot)

        player.currentRoom = rooms(0) ' Puts player into right room

    End Sub

    Sub enemyinit()

        player.health = 20.0 ' Player health
        Dim enemies As enemy

        enemies.code = 1 'Individual identifier
        enemies.type = 1 'Used as a damage and defense multiplier - higher the number, better the combat skill
        enemies.health = (enemies.type * 10) 'Calculated by multiplying type by 10
        enemies.name = "Dying Corrupted Crewmate"
        enemies.text = "Horrid gasses and high radiation have caused this member of your crew to turn hostile toward others not like themselves."
        enemies.startlocation = 2
        enemies.probablilty = 1
        enemies.enemysinv = New List(Of item)

        enemies.code = 2 'Individual identifier
        enemies.type = 1 'Used as a damage and defense multiplier - higher the number, better the combat skill
        enemies.health = (enemies.type * 10) 'Calculated by multiplying type by 10
        enemies.name = "Bleeding Corrupted Crewmate"
        enemies.text = "Horrid gasses and high radiation have caused this member of your crew to turn hostile toward others not like themselves."
        enemies.startlocation = 2
        enemies.probablilty = 1
        enemies.enemysinv = New List(Of item)

        enemies.code = 3 'Individual identifier
        enemies.type = 2 'Used as a damage and defense multiplier - higher the number, better the combat skill
        enemies.health = (enemies.type * 10) 'Calculated by multiplying type by 10
        enemies.name = "Gaunt Corrupted Crewmate"
        enemies.text = "Horrid gasses and high radiation have caused this member of your crew to turn hostile toward others, and is a lot stronger."
        enemies.startlocation = 2
        enemies.probablilty = 1
        enemies.enemysinv = New List(Of item)

        enemies.code = 4 'Individual identifier
        enemies.type = 3 'Used as a damage and defense multiplier - higher the number, better the combat skill
        enemies.health = (enemies.type * 10) 'Calculated by multiplying type by 10
        enemies.name = "Undead Corrupted Crewmate"
        enemies.text = "Horrid gasses and high radiation have caused this member of your crew to turn hostile toward others, and is very strong - exposure to this creature induces radiation sickness."
        enemies.startlocation = 2
        enemies.probablilty = 1
        enemies.enemysinv = New List(Of item)


    End Sub

    Sub hotspotinit()
        Dim temphotspot As hotspot

        temphotspot.code = 1
        temphotspot.name = "debug"
        temphotspot.text = "debug"
        temphotspot.searchText = "debug"
        temphotspot.location = 1
        temphotspot.interactParameters = New List(Of Integer)
        hotspots.Add(temphotspot)
    End Sub


End Module
