ì
ÄC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\CommandHandlers\CommandHandler.cs
	namespace		 	
GenericImporter		
 
.		 
Domain		  
.		  !
Core		! %
.		% &
CommandHandlers		& 5
{

 
public 

abstract 
class 
CommandHandler (
{ 
private 
readonly 
IMediatorHandler )
_mediatorHandler* :
;: ;
private 
readonly %
DomainNotificationHandler 2
_notifications3 A
;A B
	protected 
CommandHandler  
(  !
IMediatorHandler! 1
mediatorHandler2 A
,A B 
INotificationHandler! 5
<5 6
DomainNotification6 H
>H I
notificationsJ W
)W X
{ 	
_mediatorHandler 
= 
mediatorHandler .
;. /
_notifications 
= 
( %
DomainNotificationHandler 7
)7 8
notifications8 E
;E F
} 	
	protected 
async 
Task 
< 
bool !
>! "
Commit# )
() *
IUnitOfWork* 5
uow6 9
)9 :
{ 	
if 
( 
_notifications 
. 
HasNotifications /
(/ 0
)0 1
)1 2
{ 
await 
_mediatorHandler &
.& '%
PublishDomainNotification' @
(@ A
newA D
DomainNotificationE W
(W X
$strX `
,` a
DomainMessages "
." #
CommitFailed# /
./ 0
Message0 7
)7 8
)8 9
;9 :
return 
false 
; 
} 
if   
(   
await   
uow   
.   
Commit    
(    !
)  ! "
)  " #
return  $ *
true  + /
;  / 0
await"" 
_mediatorHandler"" "
.""" #%
PublishDomainNotification""# <
(""< =
new""= @
DomainNotification""A S
(""S T
$str""T \
,""\ ]
DomainMessages## 
.## 
CommitFailed## +
.##+ ,
Message##, 3
)##3 4
)##4 5
;##5 6
return$$ 
false$$ 
;$$ 
}%% 	
	protected'' 
async'' 
Task'' #
PublishValidationErrors'' 4
(''4 5
Command''5 <
command''= D
)''D E
{(( 	
foreach)) 
()) 
var)) 
error)) 
in)) !
command))" )
.))) *
ValidationResult))* :
.)): ;
Errors)); A
)))A B
{** 
await++ 
_mediatorHandler++ &
.++& '%
PublishDomainNotification++' @
(++@ A
new++A D
DomainNotification++E W
(++W X
command++X _
.++_ `
MessageType++` k
,++k l
error,, 
.,, 
ErrorMessage,, &
),,& '
),,' (
;,,( )
}-- 
}.. 	
}// 
}00 ’
rC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Commands\Command.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Commands& .
{ 
public 

abstract 
class 
Command !
:" #
Message$ +
,+ ,
IRequest- 5
<5 6
Unit6 :
>: ;
{		 
public

 
virtual

 
ValidationResult

 '
ValidationResult

( 8
{

9 :
get

; >
;

> ?
	protected

@ I
set

J M
;

M N
}

O P
	protected 
Command 
( 
Guid 
aggregateId *
)* +
:, -
base. 2
(2 3
aggregateId3 >
)> ?
{@ A
}B C
public 
abstract 
bool 
IsValid $
($ %
)% &
;& '
} 
} ±	
vC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Common\DomainMessage.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Common& ,
{ 
public 

class 
DomainMessage 
{ 
public 
string 
Message 
{ 
get  #
;# $
}% &
public 
DomainMessage 
( 
string #
message$ +
)+ ,
{ 	
Message		 
=		 
message		 
;		 
}

 	
public 
DomainMessage 
Format #
(# $
params$ *
object+ 1
[1 2
]2 3
args4 8
)8 9
{ 	
return 
new 
DomainMessage $
($ %
string% +
.+ ,
Format, 2
(2 3
Message3 :
,: ;
args< @
)@ A
)A B
;B C
} 	
} 
} ï
wC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Common\DomainMessages.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Common& ,
{ 
public 

static 
class 
DomainMessages &
{ 
public 
static 
DomainMessage #
CommitFailed$ 0
=>1 3
new4 7
(7 8
$str8 Y
)Y Z
;Z [
public 
static 
DomainMessage #
RequiredField$ 1
=>2 4
new5 8
(8 9
$str9 X
)X Y
;Y Z
public 
static 
DomainMessage #
AlreadyInUse$ 0
=>1 3
new4 7
(7 8
$str8 ]
)] ^
;^ _
public 
static 
DomainMessage #
InvalidFormat$ 1
=>2 4
new5 8
(8 9
$str9 W
)W X
;X Y
public		 
static		 
DomainMessage		 #
NotFound		$ ,
=>		- /
new		0 3
(		3 4
$str		4 U
)		U V
;		V W
public

 
static

 
DomainMessage

 # 
InUseByAnotherEntity

$ 8
=>

9 ;
new

< ?
(

? @
$str

@ d
)

d e
;

e f
} 
} ¿
qC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Entities\Entity.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Entities& .
{ 
public 

abstract 
class 
Entity  
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
int 
Code 
{ 
get 
; 
set "
;" #
}$ %
}		 
}

 »
nC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Events\Event.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Events& ,
{ 
public 

abstract 
class 
Event 
:  !
Message" )
,) *
INotification+ 8
{ 
	protected 
Event 
( 
Guid 
aggregateId (
)( )
:* +
base, 0
(0 1
aggregateId1 <
)< =
{> ?
}@ A
}		 
}

 è
pC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Events\Message.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Events& ,
{ 
public 

abstract 
class 
Message !
{ 
public 
string 
MessageType !
{" #
get$ '
;' (
	protected) 2
set3 6
;6 7
}8 9
public 
Guid 
AggregateId 
{  !
get" %
;% &
	protected' 0
set1 4
;4 5
}6 7
public		 
DateTime		 
	Timestamp		 !
{		" #
get		$ '
;		' (
private		) 0
set		1 4
;		4 5
}		6 7
	protected 
Message 
( 
Guid 
aggregateId *
)* +
{ 	
AggregateId 
= 
aggregateId %
;% &
MessageType 
= 
GetType !
(! "
)" #
.# $
Name$ (
;( )
	Timestamp 
= 
DateTime  
.  !
UtcNow! '
;' (
} 	
} 
} “
xC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Interfaces\IRepository.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &

Interfaces& 0
{		 
public

 

	interface

 
IRepository

  
<

  !
TEntity

! (
>

( )
where

* /
TEntity

0 7
:

8 9
Entity

: @
{ 
IUnitOfWork 

UnitOfWork 
{  
get! $
;$ %
}& '
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
Search# )
() *

Expression* 4
<4 5
Func5 9
<9 :
TEntity: A
,A B
boolC G
>G H
>H I
	predicateJ S
)S T
;T U
Task 
< 
IEnumerable 
< 
TEntity  
>  !
>! "
GetAll# )
() *
)* +
;+ ,
Task 
< 
TEntity 
> 
GetById 
( 
Guid "
id# %
)% &
;& '

IQueryable 
< 
TEntity 
> 
Query !
(! "
)" #
;# $
void 
Add 
( 
TEntity 
entity 
)  
;  !
void 
Update 
( 
TEntity 
entity "
)" #
;# $
void 
Remove 
( 
TEntity 
entity "
)" #
;# $
} 
} ñ
xC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Interfaces\IUnitOfWork.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &

Interfaces& 0
{ 
public 

	interface 
IUnitOfWork  
{ 
Task 
< 
bool 
> 
Commit 
( 
) 
; 
} 
}		 ≤	
{C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Mediator\IMediatorHandler.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Mediator& .
{ 
public		 

	interface		 
IMediatorHandler		 %
{

 
Task 
PublishEvent 
< 
T 
> 
( 
T 
@event %
)% &
where' ,
T- .
:/ 0
Event1 6
;6 7
Task 
< 
Unit 
> 
SendCommand 
< 
T  
>  !
(! "
T" #
command$ +
)+ ,
where- 2
T3 4
:5 6
Command7 >
;> ?
Task %
PublishDomainNotification &
<& '
T' (
>( )
() *
T* +
notification, 8
)8 9
where: ?
T@ A
:B C
DomainNotificationD V
;V W
} 
} ç
zC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Mediator\MediatorHandler.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Mediator& .
{ 
public		 

class		 
MediatorHandler		  
:		! "
IMediatorHandler		# 3
{

 
private 
readonly 
	IMediator "
	_mediator# ,
;, -
public 
MediatorHandler 
( 
	IMediator (
mediator) 1
)1 2
{ 	
	_mediator 
= 
mediator  
;  !
} 	
public 
async 
Task 
< 
Unit 
> 
SendCommand  +
<+ ,
T, -
>- .
(. /
T/ 0
command1 8
)8 9
where: ?
T@ A
:B C
CommandD K
{ 	
return 
await 
	_mediator "
." #
Send# '
(' (
command( /
)/ 0
;0 1
} 	
public 
async 
Task 
PublishEvent &
<& '
T' (
>( )
() *
T* +
@event, 2
)2 3
where4 9
T: ;
:< =
Event> C
{ 	
await 
	_mediator 
. 
Publish #
(# $
@event$ *
)* +
;+ ,
} 	
public 
async 
Task %
PublishDomainNotification 3
<3 4
T4 5
>5 6
(6 7
T7 8
notification9 E
)E F
whereG L
TM N
:O P
DomainNotificationQ c
{ 	
await 
	_mediator 
. 
Publish #
(# $
notification$ 0
)0 1
;1 2
} 	
}   
}!! ƒ	
ÇC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Notifications\DomainNotification.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Notifications& 3
{ 
public 

class 
DomainNotification #
:$ %
Message& -
,- .
INotification/ <
{ 
public		 
string		 
Key		 
{		 
get		 
;		  
}		! "
public

 
string

 
Value

 
{

 
get

 !
;

! "
}

# $
public 
DomainNotification !
(! "
string" (
key) ,
,, -
string. 4
value5 :
): ;
:< =
base> B
(B C
GuidC G
.G H
NewGuidH O
(O P
)P Q
)Q R
{ 	
Key 
= 
key 
; 
Value 
= 
value 
; 
} 	
} 
} ï
âC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Notifications\DomainNotificationHandler.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &
Notifications& 3
{ 
public 

class %
DomainNotificationHandler *
:+ , 
INotificationHandler- A
<A B
DomainNotificationB T
>T U
{		 
private

 
readonly

 
List

 
<

 
DomainNotification

 0
>

0 1
_notifications

2 @
;

@ A
public %
DomainNotificationHandler (
(( )
)) *
{ 	
_notifications 
= 
new  
List! %
<% &
DomainNotification& 8
>8 9
(9 :
): ;
;; <
} 	
public 
Task 
Handle 
( 
DomainNotification -
message. 5
,5 6
CancellationToken7 H
cancellationTokenI Z
)Z [
{ 	
_notifications 
. 
Add 
( 
message &
)& '
;' (
return 
Task 
. 
CompletedTask %
;% &
} 	
public 
virtual 
List 
< 
DomainNotification .
>. /
GetNotifications0 @
(@ A
)A B
{ 	
return 
_notifications !
;! "
} 	
public 
virtual 
bool 
HasNotifications ,
(, -
)- .
{ 	
return 
GetNotifications #
(# $
)$ %
.% &
Count& +
>, -
$num. /
;/ 0
} 	
}   
}!! Ó
}C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Domain.Core\Validators\CommandValidator.cs
	namespace 	
GenericImporter
 
. 
Domain  
.  !
Core! %
.% &

Validators& 0
{ 
public 

abstract 
class 
CommandValidator *
<* +
T+ ,
>, -
:. /
AbstractValidator0 A
<A B
TB C
>C D
whereE J
TK L
:M N
CommandO V
{ 
	protected 
CommandValidator "
(" #
)# $
{% &
}' (
}		 
}

 