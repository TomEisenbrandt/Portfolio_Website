
;	Programmer - Tom E.

;	PURPOSE : When the user presses 'CTRL' + 'x'
;	the script runs a macro which rapidly presses a + d

;	This is meant for quickly escaping from an
;	grapple quicktime event, very useful for facing giants on hard difficulty.

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

;	Avoids checking empty variables to see if they are environment variables 
#NoEnv ;
;	Enable warnings
; #Warn ;
;	SendEvent = Send, SendRaw, etc.
SendMode Input ;
;	Starting directory
SetWorkingDir %A_ScriptDir% ;

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

COUNTER := 0 ;
HUNNA := 100 ;
KeySendDelay := 25 ; 25ms between each key
KeyPressDuration := 5 ; 5ms key is held

;	Set the delay between key press and how long they last
setkeydelay, KeySendDelay, KeyPressDuration ;


;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
;	Press CTRL + x to send A + D 100 times or until P pressed
;	Use this to quickly escape from an enemy grapple
^x:: ;
while( COUNTER < HUNNA ) {
; state DOWN = 1,true,D		/		UP = 0,false,U
GetKeyState, state, p ; This part is broken but w/e
if( state == D ) {
break ;
}	;	END of if P depressed
Send {d}{a} ;
COUNTER++ ;
}	;	END of while loop
COUNTER = 0 ;	Reset counter 
Return ;

;~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
;	Press CTRL + K to terminate script
^k:: ;
ExitApp ;

;	END OF FILE
