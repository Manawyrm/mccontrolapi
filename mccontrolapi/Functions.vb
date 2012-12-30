Imports JsonExSerializer

Public Class Functions


    ''' <summary>
    ''' Holt Informationen über einen Spieler
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPlayers(ByVal connection As Connection) As List(Of Player)
        Dim al As New ArrayList()

        Dim jsonresult As String = connection.CallMethod("getPlayers", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        If DirectCast(t, Dictionary(Of Object, Object)).Item("result") = "success" Then
            Dim PlayerList As New List(Of Player)

            For Each i As System.Collections.Hashtable In DirectCast(t, Dictionary(Of Object, Object)).Item("success")
                Dim playerjson As System.Collections.Hashtable = i
                Dim worldinfojson As System.Collections.Hashtable = playerjson("worldInfo")
                Dim locationjson As System.Collections.Hashtable = playerjson("location")
                Dim itemInHandjson As System.Collections.Hashtable = playerjson("itemInHand")

                Dim playerret As New Player
                playerret.whitelisted = playerjson("whitelisted")
                playerret.firstPlayed = playerjson("firstPlayed")
                playerret.op = playerjson("op")
                playerret.exhaustion = playerjson("exhaustion")
                playerret.lastPlayed = playerjson("lastPlayed")
                playerret.sleeping = playerjson("sleeping")
                playerret.health = playerjson("health")
                playerret.banned = playerjson("banned")
                playerret.ip = playerjson("ip")
                playerret.gameMode = playerjson("gameMode")
                playerret.inVehicle = playerjson("inVehicle")
                playerret.level = playerjson("level")
                playerret.name = playerjson("name")
                playerret.foodLevel = playerjson("foodLevel")
                playerret.experience = playerjson("experience")
                playerret.sneaking = playerjson("sneaking")
                playerret.world = playerjson("world")
                playerret.sprinting = playerjson("sprinting")


                Dim worldret As New worldInfo
                worldret.name = worldinfojson("name")
                worldret.environment = worldinfojson("environment")
                worldret.fullTime = worldinfojson("fullTime")
                worldret.hasStorm = worldinfojson("hasStorm")
                worldret.isThundering = worldinfojson("isThundering")
                worldret.remainingWeatherTicks = worldinfojson("remainingWeatherTicks")
                worldret.time = worldinfojson("time")
                playerret.worldInfo = worldret

                Dim locationret As New location
                locationret.pitch = locationjson("pitch")
                locationret.x = locationjson("x")
                locationret.y = locationjson("y")
                locationret.z = locationjson("z")
                locationret.yaw = locationjson("yaw")
                playerret.location = locationret

                Dim iteminhandret As New Item
                iteminhandret.amount = itemInHandjson("amount")
                iteminhandret.dataValue = itemInHandjson("dataValue")
                iteminhandret.durability = itemInHandjson("durability")
                iteminhandret.type = itemInHandjson("type")
                playerret.itemInHand = iteminhandret

                PlayerList.Add(playerret)
            Next
            Return PlayerList
        Else

        End If
    End Function

    ''' <summary>
    ''' Holt Informationen über einen Spieler
    ''' </summary>
    ''' <param name="user">Der Nutzername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPlayer(ByVal user As String, ByVal connection As Connection) As Player
        Dim al As New ArrayList()
        al.Add(user)
        Dim jsonresult As String = connection.CallMethod("getPlayer", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        If DirectCast(t, Dictionary(Of Object, Object)).Item("result") = "success" Then
            Dim playerjson As System.Collections.Hashtable = DirectCast(t, Dictionary(Of Object, Object)).Item("success")
            Dim worldinfojson As System.Collections.Hashtable = playerjson("worldInfo")
            Dim locationjson As System.Collections.Hashtable = playerjson("location")
            Dim itemInHandjson As System.Collections.Hashtable = playerjson("itemInHand")

            Dim playerret As New Player
            playerret.whitelisted = playerjson("whitelisted")
            playerret.firstPlayed = playerjson("firstPlayed")
            playerret.op = playerjson("op")
            playerret.exhaustion = playerjson("exhaustion")
            playerret.lastPlayed = playerjson("lastPlayed")
            playerret.sleeping = playerjson("sleeping")
            playerret.health = playerjson("health")
            playerret.banned = playerjson("banned")
            playerret.ip = playerjson("ip")
            playerret.gameMode = playerjson("gameMode")
            playerret.inVehicle = playerjson("inVehicle")
            playerret.level = playerjson("level")
            playerret.name = playerjson("name")
            playerret.foodLevel = playerjson("foodLevel")
            playerret.experience = playerjson("experience")
            playerret.sneaking = playerjson("sneaking")
            playerret.world = playerjson("world")
            playerret.sprinting = playerjson("sprinting")


            Dim worldret As New worldInfo
            worldret.name = worldinfojson("name")
            worldret.environment = worldinfojson("environment")
            worldret.fullTime = worldinfojson("fullTime")
            worldret.hasStorm = worldinfojson("hasStorm")
            worldret.isThundering = worldinfojson("isThundering")
            worldret.remainingWeatherTicks = worldinfojson("remainingWeatherTicks")
            worldret.time = worldinfojson("time")
            playerret.worldInfo = worldret

            Dim locationret As New location
            locationret.pitch = locationjson("pitch")
            locationret.x = locationjson("x")
            locationret.y = locationjson("y")
            locationret.z = locationjson("z")
            locationret.yaw = locationjson("yaw")
            playerret.location = locationret

            Dim iteminhandret As New Item
            iteminhandret.amount = itemInHandjson("amount")
            iteminhandret.dataValue = itemInHandjson("dataValue")
            iteminhandret.durability = itemInHandjson("durability")
            iteminhandret.type = itemInHandjson("type")
            playerret.itemInHand = iteminhandret


            Return (playerret)
        Else

        End If
    End Function

    ''' <summary>
    ''' Fügt einen Spieler der Whitelist hinzu
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function addToWhitelist(ByVal username As String, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("addToWhitelist", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Bannt einen Spieler
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ban(ByVal username As String, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("ban", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function
 
    ''' <summary>
    ''' Bannt einen Spieler mit Grund
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="reason">Der Grund des Banns</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function banWithReason(ByVal username As String, ByVal reason As String, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(reason)
        Dim jsonresult As String = connection.CallMethod("banWithReason", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Schickt eine Nachricht an jeden Spieler
    ''' </summary>
    ''' <param name="text">Die Nachricht</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns>Anzahl der Empfänger (Console auch!)</returns>
    ''' <remarks></remarks>
    Public Shared Function broadcast(ByVal text As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(text)
        Dim jsonresult As String = connection.CallMethod("broadcast", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Schickt eine Nachricht an jeden Spieler mit Name
    ''' </summary>
    ''' <param name="username">Ausgabename</param>
    ''' <param name="message">Die Nachricht</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function broadcastWithName(ByVal username As String, ByVal message As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(message)
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("broadcastWithName", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Löscht das Item an angegebener Slot ID
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="slot">Die Slotnummer (Liste auf: http://media-mcw.cursecdn.com/8/8c/Items_slot_number.JPG). </param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function clearPlayerInventorySlot(ByVal username As String, ByVal slot As Integer, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(slot)
        Dim jsonresult As String = connection.CallMethod("clearPlayerInventorySlot", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Entfernt OP Rechte des angegebenen Spielers.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function deopPlayer(ByVal username As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("deopPlayer", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Deaktiviert das angegebene Plugin
    ''' </summary>
    ''' <param name="pluginname">Name der .JAR des Plugins.</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function disablePlugin(ByVal pluginname As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(pluginname)
        Dim jsonresult As String = connection.CallMethod("disablePlugin", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Deaktiviert alle installierten, aktivierten Plugins.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function disablePlugins(ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("disablePlugins", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Editiert einen Key in der .properties Datei des Servers
    ''' </summary>
    ''' <param name="PropertiesFileWithoutExtension">Dateiname der .properties ohne Endung!!! (Standart: server)</param>
    ''' <param name="ValueType">Gibt den Datentyp an welcher die .properties Datei enthält. (Z.B. level-name=world -> world = String, Zur Auswahl steht Boolean,Long,Integer,String und Double.)</param>
    ''' <param name="Key">Der Key der verändert werden soll. Z.B. level-name</param>
    ''' <param name="Value">Der Wert der vom Key geändert werden soll.</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function editPropertiesFile(ByVal PropertiesFileWithoutExtension As String, ByVal ValueType As String, ByVal Key As String, ByVal Value As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(PropertiesFileWithoutExtension)
        al.Add(ValueType)
        al.Add(Key)
        al.Add(Value)
        Dim jsonresult As String = connection.CallMethod("editPropertiesFile", al)
        Dim t As Object = Connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Aktiviert das angegebene Plugin
    ''' </summary>
    ''' <param name="pluginname">Name des Plugins</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function enablePlugin(ByVal pluginname As String, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(pluginname)
        Dim jsonresult As String = connection.CallMethod("enablePlugin", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert die Bukkit Version als String.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getBukkitVersion(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getBukkitVersion", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert den Inhalt einer Datei Base64 kodiert
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getBinaryFileBase64(ByVal filename As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(filename)
        Dim jsonresult As String = connection.CallMethod("getBinaryFileBase64", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function


    ''' <summary>
    ''' Liefert die Anzahl von Spielern die Online sind als Integer.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPlayerCount(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getPlayerCount", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert die Anzahl an erlaubten Spieler auf dem Server als Integer.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPlayerLimit(ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getPlayerLimit", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert die Version vom angegebenen Plugin als String
    ''' </summary>
    ''' <param name="pluginname">Name des Plugins</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPluginVersion(ByVal pluginname As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(pluginname)
        Dim jsonresult As String = connection.CallMethod("getPluginVersion", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert die Server IP des Servers wenn sie angegeben ist. Ansonsten wird ein leerer String zurückgegeben.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getServerIp(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getServerIp", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert den Port auf dem der Server läuft als Integer.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getServerPort(ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getServerPort", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Liefert die Server Version als String
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getServerVersion(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("getServerVersion", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Gibt dem angegebenen Spieler das angegebene Item mit angegebener Anzahl.
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="itemid"></param>
    ''' <param name="anzahl"></param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function givePlayerItem(ByVal username As String, ByVal itemid As Integer, ByVal anzahl As Integer, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(itemid)
        al.Add(anzahl)
        Dim jsonresult As String = connection.CallMethod("givePlayerItem", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Droppt dem angegebenen Spieler das angegebene Item mit angegebener Anzahl.
    ''' </summary>
    ''' <param name="username"></param>
    ''' <param name="itemid"></param>
    ''' <param name="anzahl"></param>
    ''' <param name="connection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function givePlayerItemDrop(ByVal username As String, ByVal itemid As Integer, ByVal anzahl As Integer, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(itemid)
        al.Add(anzahl)
        Dim jsonresult As String = connection.CallMethod("givePlayerItemDrop", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Droppt dem angegebenen Spieler das angegebene Item mit angegebener Anzahl und angegebener Data.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="itemid">Item ID (Liste hier: http://media-mcw.cursecdn.com/3/33/ItemslistV110.png) .</param>
    ''' <param name="anzahl">Anzahl an Items</param>
    ''' <param name="data">Data</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function givePlayerItemDropWithData(ByVal username As String, ByVal itemid As Integer, ByVal anzahl As Integer, ByVal data As Integer, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(itemid)
        al.Add(anzahl)
        al.Add(data)
        Dim jsonresult As String = connection.CallMethod("givePlayerItemDropWithData", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Gibt dem angegebenen Spieler das angegebene Item mit angegebener Anzahl und angegebener Data.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="itemid">Item ID (Liste hier: http://media-mcw.cursecdn.com/3/33/ItemslistV110.png) .</param>
    ''' <param name="anzahl">Anzahl an Items</param>
    ''' <param name="data">Data</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function givePlayerItemWithData(ByVal username As String, ByVal itemid As Integer, ByVal anzahl As Integer, ByVal data As Integer, ByVal connection As Connection) As Boolean
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(itemid)
        al.Add(anzahl)
        al.Add(data)
        Dim jsonresult As String = connection.CallMethod("givePlayerItemWithData", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Kickt den angegebenen Spieler und zeigt ihm eine Kicknachricht.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="kickmessage">Nachricht die dem gekickten erscheint.</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function kickPlayer(ByVal username As String, ByVal kickmessage As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(username)
        al.Add(kickmessage)
        Dim jsonresult As String = connection.CallMethod("kickPlayer", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Gibt dem angegebenen Spieler OP-Rechte.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function opPlayer(ByVal username As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("opPlayer", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Lädt den Server neu.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function reloadServer(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("reloadServer", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Entfernt den angegebenen Spieler von der Whitelist.
    ''' </summary>
    ''' <param name="username">Der Spielername</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function removeFromWhitelist(ByVal username As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(username)
        Dim jsonresult As String = connection.CallMethod("removeFromWhitelist", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Führt den angegebenen Consolen Befehl aus.
    ''' </summary>
    ''' <param name="cmd">Der Consolen Befehl.</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function runConsoleCommand(ByVal cmd As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(cmd)
        Dim jsonresult As String = connection.CallMethod("runConsoleCommand", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Speichert die Map im aktuellen Status ab.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function saveMap(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("saveMap", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Deaktiviert die Funktion: Automatisches Speichern.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function saveOff(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("saveOff", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Aktiviert die Funktion: Automatisches Speichern.
    ''' </summary>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function saveOn(ByVal connection As Connection) As String
        Dim al As New ArrayList()
        Dim jsonresult As String = connection.CallMethod("saveOn", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Sendet eine Nachricht vom angegebenen Spieler zum angegebenen Spieler.
    ''' </summary>
    ''' <param name="usernamefrom">Der Sender</param>
    ''' <param name="usernameto">Der Empfänger</param>
    ''' <param name="message">Die Nachricht</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function sendMessage(ByVal usernamefrom As String, ByVal usernameto As String, ByVal message As String, ByVal connection As Connection) As String
        Dim al As New ArrayList()
        al.Add(usernameto)
        al.Add("<" + usernamefrom + "> " + message)
        Dim jsonresult As String = connection.CallMethod("sendMessage", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

    ''' <summary>
    ''' Ändert den Spielmodus des Spielers
    ''' </summary>
    ''' <param name="user">Der Nutzername</param>
    ''' <param name="gamemode">Spielmode (0 - Survival, 1 - Creative</param>
    ''' <param name="connection">Die Verbindung zum Server</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function setPlayerGameMode(ByVal user As String, ByVal gamemode As Integer, ByVal connection As Connection) As Integer
        Dim al As New ArrayList()
        al.Add(user)
        al.Add(gamemode)
        Dim jsonresult As String = connection.CallMethod("setPlayerGameMode", al)
        Dim t As Object = connection.deser.Deserialize(jsonresult)
        Return DirectCast(t, Dictionary(Of Object, Object)).Item("success")
    End Function

  

End Class
