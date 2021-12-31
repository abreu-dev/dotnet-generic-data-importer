�
iC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Contexts\DataContext.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Contexts '
{ 
public 

class 
DataContext 
: 

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
public 
DbSet 
< 
ImportLayout !
>! "
ImportLayout# /
{0 1
get2 5
;5 6
set7 :
;: ;
}< =
public 
DbSet 
< 
Import 
> 
Import #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
DataContext 
( 
DbContextOptions +
<+ ,
DataContext, 7
>7 8
options9 @
)@ A
:B C
baseD H
(H I
optionsI P
)P Q
{R S
}T U
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
modelBuilder 
. 
ApplyConfiguration +
(+ ,
new, /
XptoMapping0 ;
(; <
)< =
)= >
;> ?
modelBuilder 
. 
ApplyConfiguration +
(+ ,
new, /
ImportLayoutMapping0 C
(C D
)D E
)E F
;F G
modelBuilder 
. 
ApplyConfiguration +
(+ ,
new, /

(= >
)> ?
)? @
;@ A
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
} 	
} 
} �
qC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Mappings\ImportLayoutMapping.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Mappings '
{ 
public 

class 
ImportLayoutMapping $
:% &$
IEntityTypeConfiguration' ?
<? @
ImportLayout@ L
>L M
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
/ 0
ImportLayout

0 <
>

< =
builder

> E
)

E F
{ 	
builder 
. 
ToTable 
( 
$str *
)* +
;+ ,
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

( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
	Separator$ -
)- .
. 

( 
$str *
)* +
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Service$ +
)+ ,
. 

( 
$str (
)( )
. 

IsRequired 
( 
) 
; 
builder   
.   
HasMany   
(   
x   
=>    
x  ! "
.  " #
Columns  # *
)  * +
.!! 
WithOne!! 
(!! 
x!! 
=>!! 
x!! 
.!!  
ImportLayout!!  ,
)!!, -
."" 

IsRequired"" 
("" 
)"" 
;"" 
}## 	
}$$ 
}%% �
kC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Mappings\ImportMapping.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Mappings '
{ 
public 

class 

:  $
IEntityTypeConfiguration! 9
<9 :
Import: @
>@ A
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
/ 0
Import

0 6
>

6 7
builder

8 ?
)

? @
{ 	
builder 
. 
ToTable 
( 
$str $
)$ %
;% &
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
. 
HasOne 
( 
x 
=> 
x  !
.! "
ImportLayout" .
). /
. 
WithMany 
( 
x 
=> 
x  
.  !
Imports! (
)( )
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Date$ (
)( )
. 

( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
} 	
} 
} �
iC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Mappings\XptoMapping.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Mappings '
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

( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Date$ (
)( )
. 

( 
$str %
)% &
. 

IsRequired 
( 
) 
; 
builder 
. 
Property 
( 
x 
=> !
x" #
.# $
Version$ +
)+ ,
. 

( 
$str (
)( )
. 

IsRequired 
( 
) 
; 
builder   
.   
Property   
(   
x   
=>   !
x  " #
.  # $
Value  $ )
)  ) *
.!! 

(!! 
$str!! &
)!!& '
."" 

IsRequired"" 
("" 
)"" 
;"" 
}## 	
}$$ 
}%% �
vC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Migrations\20211108232045_Initial.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 

Migrations )
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
{
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
Name 
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
} �j
�C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Migrations\20211228001404_ImportLayoutEImport.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 

Migrations )
{ 
public 

partial 
class 
ImportLayoutEImport ,
:- .
	Migration/ 8
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
$str $
,$ %
columns 
: 
table 
=> !
new" %
{
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
Name 
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
,W X
	Separator 
= 
table  %
.% &
Column& ,
<, -
string- 3
>3 4
(4 5
type5 9
:9 :
$str; J
,J K
nullableL T
:T U
falseV [
)[ \
,\ ]
Service 
= 
table #
.# $
Column$ *
<* +
int+ .
>. /
(/ 0
type0 4
:4 5
$str6 ;
,; <
nullable= E
:E F
falseG L
)L M
,M N
Code 
= 
table  
.  !
Column! '
<' (
int( +
>+ ,
(, -
type- 1
:1 2
$str3 8
,8 9
nullable: B
:B C
falseD I
)I J
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 6
,6 7
x8 9
=>: <
x= >
.> ?
Id? A
)A B
;B C
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str 
, 
columns 
: 
table 
=> !
new" %
{ 
Id 
= 
table 
. 
Column %
<% &
Guid& *
>* +
(+ ,
type, 0
:0 1
$str2 D
,D E
nullableF N
:N O
falseP U
)U V
,V W
ImportLayoutId "
=# $
table% *
.* +
Column+ 1
<1 2
Guid2 6
>6 7
(7 8
type8 <
:< =
$str> P
,P Q
nullableR Z
:Z [
false\ a
)a b
,b c
Date   
=   
table    
.    !
Column  ! '
<  ' (
DateTime  ( 0
>  0 1
(  1 2
type  2 6
:  6 7
$str  8 C
,  C D
nullable  E M
:  M N
false  O T
)  T U
,  U V
	Processed!! 
=!! 
table!!  %
.!!% &
Column!!& ,
<!!, -
bool!!- 1
>!!1 2
(!!2 3
type!!3 7
:!!7 8
$str!!9 >
,!!> ?
nullable!!@ H
:!!H I
false!!J O
)!!O P
,!!P Q
ItemsUnprocessed"" $
=""% &
table""' ,
."", -
Column""- 3
<""3 4
int""4 7
>""7 8
(""8 9
type""9 =
:""= >
$str""? D
,""D E
nullable""F N
:""N O
false""P U
)""U V
,""V W 
ItemsFailedProcessed## (
=##) *
table##+ 0
.##0 1
Column##1 7
<##7 8
int##8 ;
>##; <
(##< =
type##= A
:##A B
$str##C H
,##H I
nullable##J R
:##R S
false##T Y
)##Y Z
,##Z [&
ItemsSuccessfullyProcessed$$ .
=$$/ 0
table$$1 6
.$$6 7
Column$$7 =
<$$= >
int$$> A
>$$A B
($$B C
type$$C G
:$$G H
$str$$I N
,$$N O
nullable$$P X
:$$X Y
false$$Z _
)$$_ `
,$$` a
Code%% 
=%% 
table%%  
.%%  !
Column%%! '
<%%' (
int%%( +
>%%+ ,
(%%, -
type%%- 1
:%%1 2
$str%%3 8
,%%8 9
nullable%%: B
:%%B C
false%%D I
)%%I J
.&& 

Annotation&& #
(&&# $
$str&&$ 8
,&&8 9
$str&&: @
)&&@ A
}'' 
,'' 
constraints(( 
:(( 
table(( "
=>((# %
{)) 
table** 
.** 

PrimaryKey** $
(**$ %
$str**% 0
,**0 1
x**2 3
=>**4 6
x**7 8
.**8 9
Id**9 ;
)**; <
;**< =
table++ 
.++ 

ForeignKey++ $
(++$ %
name,, 
:,, 
$str,, E
,,,E F
column-- 
:-- 
x--  !
=>--" $
x--% &
.--& '
ImportLayoutId--' 5
,--5 6
principalTable.. &
:..& '
$str..( 6
,..6 7
principalColumn// '
://' (
$str//) -
,//- .
onDelete00  
:00  !
ReferentialAction00" 3
.003 4
Cascade004 ;
)00; <
;00< =
}11 
)11 
;11 
migrationBuilder33 
.33 
CreateTable33 (
(33( )
name44 
:44 
$str44 *
,44* +
columns55 
:55 
table55 
=>55 !
new55" %
{66 
Id77 
=77 
table77 
.77 
Column77 %
<77% &
Guid77& *
>77* +
(77+ ,
type77, 0
:770 1
$str772 D
,77D E
nullable77F N
:77N O
false77P U
)77U V
,77V W
ImportLayoutId88 "
=88# $
table88% *
.88* +
Column88+ 1
<881 2
Guid882 6
>886 7
(887 8
type888 <
:88< =
$str88> P
,88P Q
nullable88R Z
:88Z [
false88\ a
)88a b
,88b c
Name99 
=99 
table99  
.99  !
Column99! '
<99' (
string99( .
>99. /
(99/ 0
type990 4
:994 5
$str996 E
,99E F
nullable99G O
:99O P
true99Q U
)99U V
,99V W
Position:: 
=:: 
table:: $
.::$ %
Column::% +
<::+ ,
int::, /
>::/ 0
(::0 1
type::1 5
:::5 6
$str::7 <
,::< =
nullable::> F
:::F G
false::H M
)::M N
};; 
,;; 
constraints<< 
:<< 
table<< "
=><<# %
{== 
table>> 
.>> 

PrimaryKey>> $
(>>$ %
$str>>% <
,>>< =
x>>> ?
=>>>@ B
x>>C D
.>>D E
Id>>E G
)>>G H
;>>H I
table?? 
.?? 

ForeignKey?? $
(??$ %
name@@ 
:@@ 
$str@@ Q
,@@Q R
columnAA 
:AA 
xAA  !
=>AA" $
xAA% &
.AA& '
ImportLayoutIdAA' 5
,AA5 6
principalTableBB &
:BB& '
$strBB( 6
,BB6 7
principalColumnCC '
:CC' (
$strCC) -
,CC- .
onDeleteDD  
:DD  !
ReferentialActionDD" 3
.DD3 4
CascadeDD4 ;
)DD; <
;DD< =
}EE 
)EE 
;EE 
migrationBuilderGG 
.GG 
CreateTableGG (
(GG( )
nameHH 
:HH 
$strHH "
,HH" #
columnsII 
:II 
tableII 
=>II !
newII" %
{JJ 
IdKK 
=KK 
tableKK 
.KK 
ColumnKK %
<KK% &
GuidKK& *
>KK* +
(KK+ ,
typeKK, 0
:KK0 1
$strKK2 D
,KKD E
nullableKKF N
:KKN O
falseKKP U
)KKU V
,KKV W
ImportIdLL 
=LL 
tableLL $
.LL$ %
ColumnLL% +
<LL+ ,
GuidLL, 0
>LL0 1
(LL1 2
typeLL2 6
:LL6 7
$strLL8 J
,LLJ K
nullableLLL T
:LLT U
falseLLV [
)LL[ \
,LL\ ]
ImportFileLineMM "
=MM# $
tableMM% *
.MM* +
ColumnMM+ 1
<MM1 2
stringMM2 8
>MM8 9
(MM9 :
typeMM: >
:MM> ?
$strMM@ O
,MMO P
nullableMMQ Y
:MMY Z
trueMM[ _
)MM_ `
,MM` a
	ProcessedNN 
=NN 
tableNN  %
.NN% &
ColumnNN& ,
<NN, -
boolNN- 1
>NN1 2
(NN2 3
typeNN3 7
:NN7 8
$strNN9 >
,NN> ?
nullableNN@ H
:NNH I
falseNNJ O
)NNO P
,NNP Q
ErrorOO 
=OO 
tableOO !
.OO! "
ColumnOO" (
<OO( )
stringOO) /
>OO/ 0
(OO0 1
typeOO1 5
:OO5 6
$strOO7 F
,OOF G
nullableOOH P
:OOP Q
trueOOR V
)OOV W
}PP 
,PP 
constraintsQQ 
:QQ 
tableQQ "
=>QQ# %
{RR 
tableSS 
.SS 

PrimaryKeySS $
(SS$ %
$strSS% 4
,SS4 5
xSS6 7
=>SS8 :
xSS; <
.SS< =
IdSS= ?
)SS? @
;SS@ A
tableTT 
.TT 

ForeignKeyTT $
(TT$ %
nameUU 
:UU 
$strUU =
,UU= >
columnVV 
:VV 
xVV  !
=>VV" $
xVV% &
.VV& '
ImportIdVV' /
,VV/ 0
principalTableWW &
:WW& '
$strWW( 0
,WW0 1
principalColumnXX '
:XX' (
$strXX) -
,XX- .
onDeleteYY  
:YY  !
ReferentialActionYY" 3
.YY3 4
CascadeYY4 ;
)YY; <
;YY< =
}ZZ 
)ZZ 
;ZZ 
migrationBuilder\\ 
.\\ 
CreateIndex\\ (
(\\( )
name]] 
:]] 
$str]] 0
,]]0 1
table^^ 
:^^ 
$str^^ 
,^^  
column__ 
:__ 
$str__ (
)__( )
;__) *
migrationBuilderaa 
.aa 
CreateIndexaa (
(aa( )
namebb 
:bb 
$strbb .
,bb. /
tablecc 
:cc 
$strcc #
,cc# $
columndd 
:dd 
$strdd "
)dd" #
;dd# $
migrationBuilderff 
.ff 
CreateIndexff (
(ff( )
namegg 
:gg 
$strgg <
,gg< =
tablehh 
:hh 
$strhh +
,hh+ ,
columnii 
:ii 
$strii (
)ii( )
;ii) *
}jj 	
	protectedll 
overridell 
voidll 
Downll  $
(ll$ %
MigrationBuilderll% 5
migrationBuilderll6 F
)llF G
{mm 	
migrationBuildernn 
.nn 
	DropTablenn &
(nn& '
nameoo 
:oo 
$stroo "
)oo" #
;oo# $
migrationBuilderqq 
.qq 
	DropTableqq &
(qq& '
namerr 
:rr 
$strrr *
)rr* +
;rr+ ,
migrationBuildertt 
.tt 
	DropTablett &
(tt& '
nameuu 
:uu 
$struu 
)uu 
;uu  
migrationBuilderww 
.ww 
	DropTableww &
(ww& '
namexx 
:xx 
$strxx $
)xx$ %
;xx% &
}yy 	
}zz 
}{{ �
~C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Migrations\20211231174851_NewFieldsToXpto.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 

Migrations )
{ 
public 

partial 
class 
NewFieldsToXpto (
:) *
	Migration+ 4
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
 
	AddColumn

 &
<

& '
DateTime

' /
>

/ 0
(

0 1
name 
: 
$str 
, 
table 
: 
$str 
, 
type
:
$str
,
nullable 
: 
false 
,  
defaultValue 
: 
new !
DateTime" *
(* +
$num+ ,
,, -
$num. /
,/ 0
$num1 2
,2 3
$num4 5
,5 6
$num7 8
,8 9
$num: ;
,; <
$num= >
,> ?
DateTimeKind@ L
.L M
UnspecifiedM X
)X Y
)Y Z
;Z [
migrationBuilder 
. 
	AddColumn &
<& '
double' -
>- .
(. /
name 
: 
$str 
, 
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num !
)! "
;" #
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
,  
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$num 
)  
;  !
} 	
	protected   
override   
void   
Down    $
(  $ %
MigrationBuilder  % 5
migrationBuilder  6 F
)  F G
{!! 	
migrationBuilder"" 
."" 

DropColumn"" '
(""' (
name## 
:## 
$str## 
,## 
table$$ 
:$$ 
$str$$ 
)$$ 
;$$ 
migrationBuilder&& 
.&& 

DropColumn&& '
(&&' (
name'' 
:'' 
$str'' 
,'' 
table(( 
:(( 
$str(( 
)(( 
;(( 
migrationBuilder** 
.** 

DropColumn** '
(**' (
name++ 
:++ 
$str++ 
,++  
table,, 
:,, 
$str,, 
),, 
;,, 
}-- 	
}.. 
}// �
�C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Migrations\20211231180917_ImportLayoutColumnFormat.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 

Migrations )
{ 
public 

partial 
class $
ImportLayoutColumnFormat 1
:2 3
	Migration4 =
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
	AddColumn		 &
<		& '
string		' -
>		- .
(		. /
name

 
:

 
$str

 
,

 
table 
: 
$str +
,+ ,
type 
: 
$str %
,% &
nullable
:
true
)
;
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str 
, 
table 
: 
$str +
)+ ,
;, -
} 	
} 
} �

xC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Repositories\ImportLayoutRepository.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Repositories +
{		 
public

 

class

 "
ImportLayoutRepository

 '
:

( )

Repository

* 4
<

4 5
ImportLayout

5 A
>

A B
,

B C#
IImportLayoutRepository

D [
{ 
public "
ImportLayoutRepository %
(% &
DataContext& 1
dataContext2 =
)= >
:? @
baseA E
(E F
dataContextF Q
)Q R
{S T
}U V
	protected 
override 

IQueryable %
<% &
ImportLayout& 2
>2 3
ImproveQuery4 @
(@ A

IQueryableA K
<K L
ImportLayoutL X
>X Y
queryZ _
)_ `
{ 	
return 
query 
. 
Include  
(  !
i! "
=># %
i& '
.' (
Columns( /
)/ 0
;0 1
} 	
} 
} �
rC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Repositories\ImportRepository.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Repositories +
{		 
public

 

class

 
ImportRepository

 !
:

" #

Repository

$ .
<

. /
Import

/ 5
>

5 6
,

6 7
IImportRepository

8 I
{ 
public 
ImportRepository 
(  
DataContext  +
dataContext, 7
)7 8
:9 :
base; ?
(? @
dataContext@ K
)K L
{M N
}O P
	protected 
override 

IQueryable %
<% &
Import& ,
>, -
ImproveQuery. :
(: ;

IQueryable; E
<E F
ImportF L
>L M
queryN S
)S T
{ 	
return 
query 
. 
Include  
(  !
i! "
=># %
i& '
.' (
ImportLayout( 4
)4 5
. 
ThenInclude 
( 
i 
=> !
i" #
.# $
Columns$ +
)+ ,
. 
Include 
( 
i 
=> 
i 
.  
ImportItems  +
)+ ,
;, -
} 	
} 
} �
pC:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.Data\Repositories\XptoRepository.cs
	namespace 	
	Something
 
. 
Infra 
. 
Data 
. 
Repositories +
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