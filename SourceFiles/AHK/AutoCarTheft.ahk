;	Coder : Tom E.

;	IMPORTANT - READ ME
; Execute program with Admin priviledges or else [it won't work]!
; You may need to edit the code to suite your own account( phone contacts may differ for example )	
; MUST HAVE CEO/VIP mode ENABLED
; Keys must be bound to Numpad, F keys or mouse keys. 
; > Normal button will not work for GTA 5 because it uses a script hook
; The ammo buyer may not work properly depending on your loadout.
; Key delays are measured in milliseconds, here is a conversion key.
;
; Millisecond	-	Second
; 1000ms		= 	1s
; 1ms			= 	0.001s
;
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	GENERAL
;	~	~	~	~	~
;	>	>	>	>	>	>	>	>	>	>	>	>
#SingleInstance, Force ; Forces only one instance of program to run at a time
SetWorkingDir %A_ScriptDir% ; Starting directory
;#NoEnv ; Avoids checking empty variables to see if they are environment variables 
;SendMode Input ; SendEvent = Send, SendRaw, etc.
;#Warn ; Enable warnings
;#IfWinActive ahk_class ------- ; Disable script if user Alt-Tabs out of game
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	VARIABLE LIST / KEY DELAYS
;	~	~	~	~	~
;	>	>	>	>	>	>	>	>	>	>	>	>
Global PhoneDelay := 600 ; Delay when opening phone
Global MenuDelay := 1000 ; Delay for int menu to load , try to keep between 90 - 150
Global SendDelay := 300 ; Keystroke interval
Global KeyPressDuration := 200 ; Time key is held for
;	>	>	>	>	>	>	>	>	>	>	>	>
setkeydelay, KeySendDelay, KeyPressDuration ;	Set the delay between key press and how long they last
;	>	>	>	>	>	>	>	>	>	>	>	>
UserConfigs = SpeedTheif.ini ; File containing user configs.
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	GUI & .ini FILE I/O
;	~	~	~	~	~
;	>	>	>	>	>	>	>	>	>	>	>	>
;	GUI TEXT
; GUI , ADD , CONTROL_TYPE [, Options , TEXT ]
Gui, Add, Text,, Call_Mechanic: ;
Gui, Add, Text,, Call_Insurance: ;
Gui, Add, Text,, Call_Lamar: ;
Gui, Add, Text,, Call_Lester: ;
Gui, Add, Text,, Suicide: ;
Gui, Add, Text,, CEO_Bullshark: ;
Gui, Add, Text,, CEO_BuyArmor: ;
Gui, Add, Text,, Inventory_Armor: ;
Gui, Add, Text,, Inventory_Food: ;
Gui, Add, Text,, Inventory_Ammo: ;
Gui, Add, Text,, Exit_Script: ;
;	>	>	>	>	>	>	>	>	>	>	>	>
;	GUI BINDINGS
; GUI , ADD , HOTKEY , vChosenHotKey
Gui, Add, Hotkey, vCallMechanic ;
Gui, Add, Hotkey, vCallInsurance ;
Gui, Add, Hotkey, vCallLamar ;
Gui, Add, Hotkey, vCallLester ;
Gui, Add, Hotkey, vBuySuicide ;
Gui, Add, Hotkey, vCEOBullshark ;
Gui, Add, Hotkey, vCEOArmor ;
Gui, Add, Hotkey, vInvenArmor ;
Gui, Add, Hotkey, vInvenFood ;
Gui, Add, Hotkey, vInvenAmmo ;
Gui, Add, Hotkey, vExitKey ;
;	>	>	>	>	>	>	>	>	>	>	>	>
;	READ INI FILE
;	If the file exists .ini file will be read for data to load in
IfExist,%UserConfigs%
{
; READ , OUTPUT(Read in value) , FILE_NAME , SECTION_NAME , KEY 
IniRead, Read_CallMechanic, %UserConfigs%, Bindings, JohnnyOnTheSpot ;
IniRead, Read_CallInsurance, %UserConfigs%, Bindings, VehicleRebuy ;
IniRead, Read_CallLamar, %UserConfigs%, Bindings, HireMugger ;
IniRead, Read_CallLester, %UserConfigs%, Bindings, HackerMan ;
IniRead, Read_BuySuicide, %UserConfigs%, Bindings, KYS ;
IniRead, Read_CEOBullshark, %UserConfigs%, Bindings, Juice ;
IniRead, Read_CEOArmor, %UserConfigs%, Bindings, Sponge ;
IniRead, Read_InvenArmor, %UserConfigs%, Bindings, IArmor ;
IniRead, Read_InvenFood, %UserConfigs%, Bindings, IFood ;
IniRead, Read_InvenAmmo, %UserConfigs%, Bindings, IAmmo ;
IniRead, Read_ExitKey, %UserConfigs%, Bindings, Exit ;
}
;	>	>	>	>	>	>	>	>	>	>	>	>
;	GUI CONTROL
; GUICONTROL , SUB-COMMAND , CONTROL_ID [, PARAM3 ]
GuiControl,, CallMechanic, %Read_CallMechanic% ;
GuiControl,, CallInsurance, %Read_CallInsurance% ;
GuiControl,, CallLamar, %Read_CallLamar% ;
GuiControl,, CallLester, %Read_CallLester% ;
GuiControl,, BuySuicide, %Read_BuySuicide% ;
GuiControl,, CEOBullshark, %Read_CEOBullshark% ;
GuiControl,, CEOArmor, %Read_CEOArmor% ;
GuiControl,, InvenArmor, %Read_InvenArmor% ;
GuiControl,, InvenFood, %Read_InvenFood% ;
GuiControl,, InvenAmmo, %Read_InvenAmmo% ;
GuiControl,, ExitKey, %Read_ExitKey% ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Gui, Add, Button, gsave, save
Gui, Show,, GTA Macro Menu ; Shows window, sizes it and gives it a title
Return ;
save:
Gui, Submit
;	>	>	>	>	>	>	>	>	>	>	>	>
;	WRITE INI FILE
IfNotExist,%UserConfigs%
{
; WRITE , VALUE , FILE_NAME , SECTION_NAME , KEY
IniWrite, %CallMechanic%, %UserConfigs%, Bindings, JohnnyOnTheSpot ; 
IniWrite, %CallInsurance%, %UserConfigs%, Bindings, VehicleRebuy ;
IniWrite, %CallLamar%, %UserConfigs%, Bindings, HireMugger ;
IniWrite, %CallLester%, %UserConfigs%, Bindings, HackerMan ;
IniWrite, %BuySuicide%, %UserConfigs%, Bindings, KYS ;
IniWrite, %CEOBullshark%, %UserConfigs%, Bindings, Juice ;
IniWrite, %CEOArmor%, %UserConfigs%, Bindings, Sponge ;
IniWrite, %InvenArmor%, %UserConfigs%, Bindings, IArmor ;
IniWrite, %InvenFood%, %UserConfigs%, Bindings, IFood ;
IniWrite, %InvenAmmo%, %UserConfigs%, Bindings, IAmmo ;
IniWrite, %ExitKey% , %UserConfigs% , Bindings , Exit ;
}
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	HOTKEY LIST
;	~	~	~	~	~
; HOTKEY , KEY_NAME [, LABEL, OPTIONS ]
Hotkey, %CallMechanic%, Mechanic ;
Hotkey, %CallInsurance%, Mors_Mutual ;
Hotkey, %CallLamar%, Lamar ;
Hotkey, %CallLester%, Lester ;
Hotkey, %BuySuicide%, Suicide ;
Hotkey, %CEOBullshark%, Bullshark ;
Hotkey, %CEOArmor%, BuyArmor ;
Hotkey, %InvenArmor%, InventoryArmor ;
Hotkey, %InvenFood%, InventoryFood ;
Hotkey, %InvenAmmo%, InventoryAmmo ;
Hotkey, %ExitKey%, Exitlabel ;
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
;
;#IfWinActive ahk_class grcWindow
;
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	MACRO LIST
;	~	~	~	~	~
;In the contacts menu LEFT = PAGE / RIGHT = PAGE DOWN - This can save a few keystrokes
;	>	>	>	>	>	>	>	>	>	>	>	>
Mechanic: ; Call Mechanic
PhoneContacts( ) ;
Send {left}{left}{down}{enter} ; Go to mechanic contact
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Mors_Mutual: ; Call insurance
PhoneContacts( ) ;
Send {left}{up}{up}{enter} ; Go to mechanic contact
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Lamar: ; Call Lamar - hire mugger
PhoneContacts( ) ;
Send {left}{left}{left}{down}{enter} ; Go to Lester contact
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Lester: ; Call Lester
PhoneContacts( ) ;
Send {left}{left}{left}{down}{down}{enter} ; Go to Lester contact
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Suicide: ; kill self
IntMenu( )
Send {up}{up}{enter}
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Bullshark: ; Buy Bullshark pills via CEO
IntMenu( )
Send {enter} ; Enter SS menu
Send {up}{up}{up}{enter} ; Enter CEO Abilities
Send {down}{enter} ; Request buff ( 60 seconds , recieve 1/2 damage , give x2 damage )
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
BuyArmor: ; Buy Armor via CEO
IntMenu( )
Send {enter} ; Enter SS menu
Send {up}{up}{up}{enter} ; Enter CEO Abilities
Send {down}{down}{down}{enter} ; Request wearable bullet sponge
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
InventoryArmor: ; Go to armor inventory
IntMenu( )
Send {down}{down}{enter} ; Enter inventory
Send {down}{enter} ; Enter armor selection
;Send {up}{up}{up}{enter} ; Equip 'Super Heavy Armor'
;Send {m} ; Exit menu
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
InventoryFood: ; go to healing items inventory
IntMenu( )
Send {down}{down}{enter} ; Enter inventory
Send {down}{down}{enter} ; Enter food selection
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
InventoryAmmo: ; go to weapon ammo inventory and fill ammo 
IntMenu( )
Send {down}{down}{enter} ; Enter inventory
Sleep, 2000 ; Allow Ammo option to load
Send {down}{down}{down}{enter} ; Enter mobile ammo shop
Send {up}{enter}{down}{right} ; Buy full 'Rifle Ammo' then move to next gun type
Sleep, 800 ; Allow time for transaction delay
Send {up}{enter}{down}{right} ; Buy full 'Shotgun Ammo' then next gun
Sleep, 800 ; Allow time for transaction delay
Send {up}{enter}{down}{right} ; Buy full 'Sniper Ammo' then next gun
Sleep, 800 ; Allow time for transaction delay
Send {down}{left}{down}{down}{enter} ; Buy full 'Proximity Mine'
Sleep, 800 ; Allow time for transaction delay
Send {up}{up}{left}{down}{down}{enter} ; Buy full 'Sticky Bomb'	
Sleep, 800 ; Allow time for transaction delay
Send {down}{right}{up}{enter} ; Buy full 'RPG'
Sleep, 800 ; Allow time for transaction delay
Send {up}{up}{right}{down}{down}{enter} ; Buy full 'Minigun'
Send {m} ; Exit menu
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
;--------------------------------------------------------------------------------------------------
;	~	~	~	~	~
;	FUNCTIONS
;	~	~	~	~	~
;	>	>	>	>	>	>	>	>	>	>	>	>
PhoneContacts( ){
Send {up} ; Bring up phone
sleep, %PhoneDelay% ; Allow phone to load
Send {up}{right}{enter} ; Enter contacts panel
}
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
IntMenu( ){
Send {m} ; Open interaction menu
sleep, %MenuDelay% ; Allow menu time to load
}
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
Exitlabel:
ExitApp
Return ;
;	>	>	>	>	>	>	>	>	>	>	>	>
;	~	~	~	~	~
;
;	END OF FILE
;
;	~	~	~	~	~
