∞
uC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Infra.Data\Contexts\DataContext.cs
	namespace 	
GenericImporter
 
. 
Infra 
.  
Data  $
.$ %
Contexts% -
{ 
public 

class 
DataContext 
: 
BaseDbContext ,
{		 
public

 
DbSet

 
<

 
Xpto

 
>

 
Xpto

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
DataContext 
( 
DbContextOptions +
<+ ,
DataContext, 7
>7 8
options9 @
)@ A
:B C
baseD H
(H I
optionsI P
)P Q
{R S
}T U
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
modelBuilder 
. 
ApplyConfiguration +
(+ ,
new, /
XptoMapping0 ;
(; <
)< =
)= >
;> ?
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
} 	
} 
} á
uC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Infra.Data\Mappings\XptoMapping.cs
	namespace 	
GenericImporter
 
. 
Infra 
.  
Data  $
.$ %
Mappings% -
{ 
public 

class 
XptoMapping 
: $
IEntityTypeConfiguration 7
<7 8
Xpto8 <
>< =
{		 
public

 
void

 
	Configure

 
(

 
EntityTypeBuilder

 /
<

/ 0
Xpto

0 4
>

4 5
builder

6 =
)

= >
{ 	
builder 
. 
ToTable 
( 
$str "
)" #
;# $
builder 
. 
HasKey 
( 
x 
=> 
x  !
.! "
Id" $
)$ %
;% &
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Code$ (
)( )
. 
ValueGeneratedOnAdd $
($ %
)% &
. 
Metadata 
.  
SetAfterSaveBehavior .
(. / 
PropertySaveBehavior/ C
.C D
IgnoreD J
)J K
;K L
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Name$ (
)( )
. 
HasColumnName 
( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
} 	
} 
} Ó
ÇC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Infra.Data\Migrations\20211105020653_Initial.cs
	namespace 	
GenericImporter
 
. 
Infra 
.  
Data  $
.$ %

Migrations% /
{ 
public 

partial 
class 
Initial  
:! "
	Migration# ,
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{		 	
migrationBuilder

 
.

 
CreateTable

 (
(

( )
name 
: 
$str 
, 
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
Nome 
= 
table  
.  !
Column! '
<' (
string( .
>. /
(/ 0
type0 4
:4 5
$str6 E
,E F
nullableG O
:O P
falseQ V
)V W
,W X
Code 
= 
table  
.  !
Column! '
<' (
int( +
>+ ,
(, -
type- 1
:1 2
$str3 8
,8 9
nullable: B
:B C
falseD I
)I J
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% .
,. /
x0 1
=>2 4
x5 6
.6 7
Id7 9
)9 :
;: ;
} 
) 
; 
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	DropTable &
(& '
name 
: 
$str 
) 
; 
} 	
} 
} ê
|C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Infra.Data\Repositories\XptoRepository.cs
	namespace 	
GenericImporter
 
. 
Infra 
.  
Data  $
.$ %
Repositories% 1
{ 
public 

class 
XptoRepository 
:  !

Repository" ,
<, -
Xpto- 1
>1 2
,2 3
IXptoRepository4 C
{		 
public

 
XptoRepository

 
(

 
DataContext

 )
dataContext

* 5
)

5 6
:

7 8
base

9 =
(

= >
dataContext

> I
)

I J
{

K L
}

M N
} 
} 