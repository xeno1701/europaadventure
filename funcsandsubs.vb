Module funcsandsubs
    Public Function VariableTrim(source As String, starttrim As Integer, endtrim As Integer)
        If endtrim > source.Length Then
            Return source
        Else
            Return source.Substring(starttrim, endtrim)
        End If
    End Function

    Public Function userItemChoice(message As String, hotinvorscav As Integer) ' Function for getting users choice of item and processing it into caps with only 5 chars
        Dim tempmsg As textforprocessing
        print(message) ' Ask user (e.g. "What item do you want to grab?")
        If hotinvorscav = 0 Then ' Allows user to see choices of picking up or inv
            showHotspots()
        ElseIf hotinvorscav = 1 Then
            showInventory()
        ElseIf hotinvorscav = 2 Then
            Scavenge()
        End If
        tempmsg.originaltext = read()
        tempmsg.modifiedtext = capsfivecharmax(tempmsg.originaltext)
        Return tempmsg
    End Function

    Public Sub WrtLnCentered(inputstring As String, Ypos As Integer) ' Centered text function
        Dim Xpos As Integer = Math.Abs((Console.WindowWidth / 2) - (inputstring.Length / 2))
        Console.SetCursorPosition(Xpos, Ypos) 'Calced xPos and inputted yPos used to set cursor pos.
        Console.WriteLine(inputstring)
    End Sub

    Public Sub titledecor(inputstring As String, ypos As Integer) ' Fancy lines above and below centered title
        Dim outputstring As String = ""
        For n = 1 To inputstring.Length + 20
            outputstring = outputstring & "═"
        Next
        WrtLnCentered(outputstring, ypos - 2)
        WrtLnCentered(outputstring, ypos + 2)
    End Sub

    Public Function capsfivecharmax(text As String) ' Takes string and makes it caps and only 5 chars
        Dim fixedval As String
        If text.Length > 4 Then
            fixedval = (text.Substring(0, 5).ToUpper)
        Else
            fixedval = text.ToUpper
        End If
        Return fixedval
    End Function

    Function parser(Input As String) ' Parser for main game loop
        checkifalive()
        radiation()
        Dim keepPlaying = True
        Input = capsfivecharmax(Input)
        Select Case Input
            Case "SV_CH", "SV_CHEATS = 1", "DEBUG"
                Debug()
            Case "GO"
                Travel()
            Case "NORTH", "N"
                goNorth()
            Case "SOUTH", "S"
                goSouth()
            Case "EAST", "E"
                goEast()
            Case "WEST", "W"
                goWest()
            Case "QUIT", "EXIT", "Q", "LEAVE"
                keepPlaying = False
            Case "GPS", "LOOK", "L"
                LookAround()
            Case "HUNT", "H", "ITEMS"
                Scavenge()
            Case "TAKE", "T", "GET", "G"
                takeItem()
            Case "BAG", "B", "INVEN", "I", "INV"
                showInventory()
            Case "D", "DROP", "TRASH"
                dropItem()
            Case "INSPE", "EXAM", "EXAMI"
                examineChoice()
            Case "STAT", "STATS", "HEALT", "HP"
                printplayerstats()
            Case "DIE"
                Die("Debug")
            Case "CRAFT", "COMBI", "COMB", "MAKE"
                CombineItem()
            Case "GOD"
                IsInvunerable = IsDebugMode
            Case Else
                print("Unfortunately, that command is not understood.")
                print("Type a COMMAND to continue.")
                print("")
        End Select
        Return keepPlaying ' nearly always true, if false (when quit typed) game will terminate
    End Function

    Sub Debug() ' turns on debugging
        IsDebugMode = True
        debugp("READY.")
    End Sub

    Public Function read() ' shorthand user input function with coloring and indentation
        Dim readline As String
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write("     @>   ")
        Console.ForegroundColor = ConsoleColor.Magenta
        readline = Console.ReadLine()
        Console.ForegroundColor = ConsoleColor.White
        Return readline
    End Function
    Public Sub playercol() ' makes the colour magenta for player
        Console.ForegroundColor = ConsoleColor.Magenta
    End Sub
    Public Sub speakercol() ' makes the colour cyan for computer
        Console.ForegroundColor = ConsoleColor.Cyan
    End Sub
    Public Sub highlightcol() ' makes the colour cyan for computer
        Console.ForegroundColor = ConsoleColor.Yellow
    End Sub
    Public Sub Defaultcolour() ' makes the colour cyan for computer
        Console.ForegroundColor = ConsoleColor.White
    End Sub
    Public Sub debugCol()
        Console.ForegroundColor = ConsoleColor.Green
    End Sub


    Public Sub print(writeline As String) ' shorthand system output function with coloring 
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(writeline)
        Console.ForegroundColor = ConsoleColor.White
    End Sub
    Public Sub debugp(writeline As String) ' shorthand system output function with coloring 
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(writeline)
        Console.ForegroundColor = ConsoleColor.White
    End Sub

    Public Sub examineChoice()
        print("What would you like to examine? (An item or your surroundings)")
        Dim examinechoice As String = capsfivecharmax(read())
        Select Case examinechoice
            Case "ITEM", "AN IT"
                ExamineItem()
            Case "ROOM", "SURRO", "YOUR "
                examineHotspot()
            Case Else
                print("Unfortunately, that command is not understood.")
                print("Type a COMMAND to continue.")
                print("")
        End Select
    End Sub
    Public Sub itemlisting(itemname As String)
        highlightcol()
        Console.Write("  * ")
        speakercol()
        Console.Write(itemname)
        Console.WriteLine("")
        Defaultcolour()
    End Sub

End Module
