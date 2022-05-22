Imports System

Module Program
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

    Public Structure item
        ' variables for item structure
        Dim code As Integer
        Dim name As String
        Dim text As String
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
    Public Structure hotspot
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
        Dim name As String
        Dim text As String
        Dim startlocation As Integer
        Dim probablilty As Double
        Dim enemysinv As List(Of item)
    End Structure

    Public Structure textforprocessing
        ' variables for processing textobject
        Dim originaltext As String
        Dim modifiedtext As String
    End Structure
    Public Structure _Event

    End Structure

    Public Structure playablecharacter
        Dim health As Double
        Dim currentRoom As room
    End Structure


    'variables for rooms and which room player is in.
    Public rooms(20) As room

    Public playerinv As New List(Of item)
    Public playercombinv As New List(Of Combineditems)
    Public ItemList As New List(Of item)
    Public EnemyList As New List(Of enemy)
    Public Combineditemlist As New List(Of Combineditems)
    Public hotspots As New List(Of hotspot)

    Public activeItem As New item
    Public player As playablecharacter
    Public countspermin As Double

    Sub Main(args As String())
        initialiseall(True, True, True, True) ' run the initalisation subroutine
        OpeningTitle(True)

        Dim key As ConsoleKeyInfo
        While key.Key <> ConsoleKey.Enter 'makes enter the only key you can press to continue
            OpeningTitle(False)
            print("") ' Makes some space 
            key = Console.ReadKey()
        End While
Reload:
        print("")
        MainGameLoop()
        Console.Clear()
        print("Are you sure you want to exit? Progress is not saved. (Press ANY to exit, or ESC to cancel.)")
        key = Console.ReadKey()
        If key.Key = ConsoleKey.Escape Then
            Console.Clear()
            Console.Write("Y")
            LookAround()
            highlightcol()
            Console.WriteLine("Press ENTER to start and then type a COMMAND.")
            GoTo Reload
        Else
        End If
    End Sub

    Sub MainGameLoop()
        Dim inMainLoop As Boolean = True
        While inMainLoop = True
            Dim input As String = read()
            inMainLoop = parser(input)
        End While
    End Sub



End Module




