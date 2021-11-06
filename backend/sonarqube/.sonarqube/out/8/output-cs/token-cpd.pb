¸

áC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\AutoMapper\DtoToCommandMappingProfile.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &

AutoMapper& 0
{ 
public 

class &
DtoToCommandMappingProfile +
:, -
Profile. 5
{		 
public

 &
DtoToCommandMappingProfile

 )
(

) *
)

* +
{ 	
CreateXptoMap 
( 
) 
; 
} 	
private 
void 
CreateXptoMap "
(" #
)# $
{ 	
	CreateMap 
< 

AddXptoDto  
,  !
AddXptoCommand" 0
>0 1
(1 2
)2 3
. 
	ForMember 
( 
d 
=> 
d  !
.! "
Entity" (
,( )
o* +
=>, .
o/ 0
.0 1
MapFrom1 8
(8 9
s9 :
=>; =
new> A
XptoB F
(F G
)G H
{I J
NameK O
=P Q
sR S
.S T
NameT X
}Y Z
)Z [
)[ \
;\ ]
} 	
} 
} √
ÜC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\AutoMapper\EntityToDtoMappingProfile.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &

AutoMapper& 0
{ 
public 

class %
EntityToDtoMappingProfile *
:+ ,
Profile- 4
{ 
public		 %
EntityToDtoMappingProfile		 (
(		( )
)		) *
{

 	
	CreateMap 
< 
Xpto 
, 
XptoDto #
># $
($ %
)% &
;& '
} 	
} 
} ˘
âC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\DataTransferObjects\XptoDTOs\AddXptoDto.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &
DataTransferObjects& 9
.9 :
XptoDtos: B
{ 
public 

class 

AddXptoDto 
: 
DataTransferObject 0
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
}		 ì
åC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\DataTransferObjects\XptoDTOs\UpdateXptoDto.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &
DataTransferObjects& 9
.9 :
XptoDtos: B
{ 
public 

class 
UpdateXptoDto 
:  
DataTransferObject! 3
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
}

 
} ú
ÜC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\DataTransferObjects\XptoDTOs\XptoDto.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &
DataTransferObjects& 9
.9 :
XptoDtos: B
{ 
public 

class 
XptoDto 
: 
DataTransferObject -
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public		 
int		 
Code		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 
string

 
Name

 
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
' (
} 
} Å
|C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\Interfaces\IXptoAppService.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &

Interfaces& 0
{ 
public 

	interface 
IXptoAppService $
:% &
IAppService' 2
<2 3
XptoDto3 :
,: ;

AddXptoDto< F
>F G
{H I
}J K
} ∂
yC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Application\Services\XptoAppService.cs
	namespace 	
GenericImporter
 
. 
Application %
.% &
Services& .
{ 
public 

class 
XptoAppService 
:  !

AppService" ,
<, -
XptoDto- 4
,4 5

AddXptoDto6 @
,@ A
XptoB F
>F G
,G H
IXptoAppService 
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IMediatorHandler )
	_mediator* 3
;3 4
public 
XptoAppService 
( 
IMapper %
mapper& ,
,, -
IMediatorHandler .
mediator/ 7
,7 8
IXptoRepository -
xptoRepository. <
)< =
: 
base 
( 
mapper 
, 
xptoRepository )
)) *
{ 	
_mapper 
= 
mapper 
; 
	_mediator 
= 
mediator  
;  !
} 	
public 
override 
async 
Task "
Add# &
(& '

AddXptoDto' 1

addXptoDto2 <
)< =
{ 	
await 
	_mediator 
. 
SendCommand '
(' (
_mapper( /
./ 0
Map0 3
<3 4
AddXptoCommand4 B
>B C
(C D

addXptoDtoD N
)N O
)O P
;P Q
} 	
}   
}!! 