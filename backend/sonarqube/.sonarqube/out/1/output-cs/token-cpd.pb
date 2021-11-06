Æ
C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain\CommandHandlers\XptoCommandHandler.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
CommandHandlers! 0
{ 
public 

class 
XptoCommandHandler #
:$ %
CommandHandler& 4
,4 5
IRequestHandler 
< 
AddXptoCommand &
,& '
Unit( ,
>, -
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly 
IXptoRepository (
_xptoRepository) 8
;8 9
public 
XptoCommandHandler !
(! "
IMediatorHandler" 2
mediatorHandler3 B
,B C 
INotificationHandler" 6
<6 7
DomainNotification7 I
>I J
notificationsK X
,X Y
IXptoRepository" 1
xptoRepository2 @
)@ A
: 
base 
( 
mediatorHandler "
," #
notifications$ 1
)1 2
{ 	
_mediatorHandler 
= 
mediatorHandler .
;. /
_xptoRepository 
= 
xptoRepository ,
;, -
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
AddXptoCommand' 5
request6 =
,= >
CancellationToken? P
cancellationTokenQ b
)b c
{ 	
if 
( 
! 
request 
. 
IsValid  
(  !
)! "
)" #
{   
await!! #
PublishValidationErrors!! -
(!!- .
request!!. 5
)!!5 6
;!!6 7
return"" 
Unit"" 
."" 
Value"" !
;""! "
}## 
if%% 
(%% 
(%% 
await%% 
_xptoRepository%% &
.%%& '
Search%%' -
(%%- .
x%%. /
=>%%0 2
x%%3 4
.%%4 5
Name%%5 9
==%%: <
request%%= D
.%%D E
Entity%%E K
.%%K L
Name%%L P
)%%P Q
)%%Q R
.%%R S
Any%%S V
(%%V W
)%%W X
)%%X Y
{&& 
await'' 
_mediatorHandler'' &
.''& '%
PublishDomainNotification''' @
(''@ A
new''A D
DomainNotification''E W
(''W X
request''X _
.''_ `
MessageType''` k
,''k l
DomainMessages(( "
.((" #
AlreadyInUse((# /
.((/ 0
Format((0 6
(((6 7
$str((7 =
)((= >
.((> ?
Message((? F
)((F G
)((G H
;((H I
return)) 
Unit)) 
.)) 
Value)) !
;))! "
}** 
_xptoRepository,, 
.,, 
Add,, 
(,,  
request,,  '
.,,' (
Entity,,( .
),,. /
;,,/ 0
await.. 
Commit.. 
(.. 
_xptoRepository.. (
...( )

UnitOfWork..) 3
)..3 4
;..4 5
return00 
Unit00 
.00 
Value00 
;00 
}11 	
}22 
}33 î

ÅC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain\Commands\XptoCommands\AddXptoCommand.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Commands! )
.) *
XptoCommands* 6
{ 
public 

class 
AddXptoCommand 
:  !
Command" )
{		 
public

 
Xpto

 
Entity

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
AddXptoCommand 
( 
) 
:  !
base" &
(& '
Guid' +
.+ ,
Empty, 1
)1 2
{3 4
}5 6
public 
override 
bool 
IsValid $
($ %
)% &
{ 	
ValidationResult 
= 
new "#
AddXptoCommandValidator# :
(: ;
); <
.< =
Validate= E
(E F
thisF J
)J K
;K L
return 
ValidationResult #
.# $
IsValid$ +
;+ ,
} 	
} 
} í
jC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain\Entities\Xpto.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Entities! )
{ 
public 

class 
Xpto 
: 
Entity 
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
} 
}		 Õ
wC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain\Interfaces\IXptoRepository.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !

Interfaces! +
{ 
public 

	interface 
IXptoRepository $
:% &
IRepository' 2
<2 3
Xpto3 7
>7 8
{9 :
}; <
} í	
éC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain\Validators\XptoValidators\AddXptoCommandValidator.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !

Validators! +
.+ ,
XptoValidators, :
{ 
public 

class #
AddXptoCommandValidator (
:) *
CommandValidator+ ;
<; <
AddXptoCommand< J
>J K
{		 
public

 #
AddXptoCommandValidator

 &
(

& '
)

' (
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Entity !
.! "
Name" &
)& '
. 
NotEmpty 
( 
) 
. 
WithMessage 
( 
DomainMessages +
.+ ,
RequiredField, 9
.9 :
Format: @
(@ A
$strA G
)G H
.H I
MessageI P
)P Q
;Q R
} 	
} 
} 