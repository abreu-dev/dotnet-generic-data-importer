À	
yC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Configurations\AutoMapperConfig.cs
	namespace 	
GenericImporter
 
. 
API 
. 
Configurations ,
{ 
public 

static 
class 
AutoMapperConfig (
{ 
public		 
static		 
void		 &
AddAutoMapperConfiguration		 5
(		5 6
this		6 :
IServiceCollection		; M
services		N V
)		V W
{

 	
if 
( 
services 
== 
null  
)  !
throw" '
new( +!
ArgumentNullException, A
(A B
nameofB H
(H I
servicesI Q
)Q R
)R S
;S T
services 
. 
AddAutoMapper "
(" #
typeof# )
() *&
DtoToCommandMappingProfile* D
)D E
,E F
typeof# )
() *%
EntityToDtoMappingProfile* C
)C D
)D E
;E F
} 	
} 
} ð

wC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Configurations\DatabaseConfig.cs
	namespace 	
GenericImporter
 
. 
API 
. 
Configurations ,
{ 
public		 

static		 
class		 
DatabaseConfig		 &
{

 
public 
static 
void $
AddDatabaseConfiguration 3
(3 4
this4 8
IServiceCollection9 K
servicesL T
,T U
IConfigurationV d
configuratione r
)r s
{ 	
if 
( 
services 
== 
null  
)  !
throw" '
new( +!
ArgumentNullException, A
(A B
nameofB H
(H I
servicesI Q
)Q R
)R S
;S T
services 
. 
AddDbContext !
<! "
DataContext" -
>- .
(. /
options/ 6
=>7 9
options 
. 
UseSqlServer (
(( )
configuration) 6
.6 7
GetConnectionString7 J
(J K
$strK ^
)^ _
)_ `
)` a
;a b
} 	
} 
} Å
‚C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Configurations\DependencyInjectionConfig.cs
	namespace 	
GenericImporter
 
. 
API 
. 
Configurations ,
{ 
public 

static 
class %
DependencyInjectionConfig 1
{ 
public		 
static		 
void		 /
#AddDependencyInjectionConfiguration		 >
(		> ?
this		? C
IServiceCollection		D V
services		W _
)		_ `
{

 	
if 
( 
services 
== 
null  
)  !
throw" '
new( +!
ArgumentNullException, A
(A B
nameofB H
(H I
servicesI Q
)Q R
)R S
;S T&
NativeInjectorBootStrapper &
.& '
RegisterServices' 7
(7 8
services8 @
)@ A
;A B
} 	
} 
} ¾
{C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Controllers\HealthCheckController.cs
	namespace 	
GenericImporter
 
. 
API 
. 
Controllers )
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class !
HealthCheckController &
:' (
ControllerBase) 7
{ 
[		 	
HttpGet			 
]		 
public

 
IActionResult

 
Get

  
(

  !
)

! "
{ 	
return 
Ok 
( 
) 
; 
} 	
} 
} Ç
tC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Controllers\XptoController.cs
	namespace 	
GenericImporter
 
. 
API 
. 
Controllers )
{ 
public 

class 
XptoController 
:  !
BaseController" 0
{ 
private 
readonly 
IXptoAppService (
_xptoAppService) 8
;8 9
public 
XptoController 
(  
INotificationHandler 2
<2 3
DomainNotification3 E
>E F
notificationsG T
,T U
IXptoAppService -
xptoAppService. <
)< =
: 
base 
( 
notifications  
)  !
{ 	
_xptoAppService 
= 
xptoAppService ,
;, -
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
IEnumerable %
<% &
XptoDto& -
>- .
>. /
Get0 3
(3 4
)4 5
{ 	
return 
await 
_xptoAppService (
.( )
GetAll) /
(/ 0
)0 1
;1 2
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
XptoDto !
>! "
Get# &
(& '
Guid' +
id, .
). /
{   	
return!! 
await!! 
_xptoAppService!! (
.!!( )
GetById!!) 0
(!!0 1
id!!1 3
)!!3 4
;!!4 5
}"" 	
[$$ 	
HttpPost$$	 
]$$ 
public%% 
async%% 
Task%% 
<%% 
IActionResult%% '
>%%' (
Add%%) ,
(%%, -
[%%- .
FromBody%%. 6
]%%6 7

AddXptoDto%%8 B

addXptoDto%%C M
)%%M N
{&& 	
await'' 
_xptoAppService'' !
.''! "
Add''" %
(''% &

addXptoDto''& 0
)''0 1
;''1 2
return(( 
Response(( 
((( 
)(( 
;(( 
})) 	
}** 
}++ ò

aC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Program.cs
	namespace 	
GenericImporter
 
. 
API 
{ 
public 

static 
class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
CreateHostBuilder

 
(

 
args

 "
)

" #
.

# $
Build

$ )
(

) *
)

* +
.

+ ,
Run

, /
(

/ 0
)

0 1
;

1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} Ì
aC:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.API\Startup.cs
	namespace

 	
GenericImporter


 
.

 
API

 
{ 
public 

class 
Startup 
{ 
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. $
AddDatabaseConfiguration -
(- .
Configuration. ;
); <
;< =
services 
. &
AddAutoMapperConfiguration /
(/ 0
)0 1
;1 2
services"" 
."" 

AddMediatR"" 
(""  
typeof""  &
(""& '
Startup""' .
)"". /
)""/ 0
;""0 1
services%% 
.%% /
#AddDependencyInjectionConfiguration%% 8
(%%8 9
)%%9 :
;%%: ;
services'' 
.'' 
AddSwaggerGen'' "
(''" #
c''# $
=>''% '
{(( 
c)) 
.)) 

SwaggerDoc)) 
()) 
$str)) !
,))! "
new))# &
OpenApiInfo))' 2
{))3 4
Title))5 :
=)); <
$str))= R
,))R S
Version))T [
=))\ ]
$str))^ b
}))c d
)))d e
;))e f
}** 
)** 
;** 
}++ 	
public.. 
void.. 
	Configure.. 
(.. 
IApplicationBuilder.. 1
app..2 5
,..5 6
IWebHostEnvironment..7 J
env..K N
)..N O
{// 	
if00 
(00 
env00 
.00 
IsDevelopment00 !
(00! "
)00" #
)00# $
{11 
app22 
.22 %
UseDeveloperExceptionPage22 -
(22- .
)22. /
;22/ 0
app33 
.33 

UseSwagger33 
(33 
)33  
;33  !
app44 
.44 
UseSwaggerUI44  
(44  !
c44! "
=>44# %
c44& '
.44' (
SwaggerEndpoint44( 7
(447 8
$str448 R
,44R S
$str44T l
)44l m
)44m n
;44n o
}55 
app77 
.77 
UseHttpsRedirection77 #
(77# $
)77$ %
;77% &
app99 
.99 

UseRouting99 
(99 
)99 
;99 
app;; 
.;; 
UseAuthorization;;  
(;;  !
);;! "
;;;" #
app== 
.== 
UseEndpoints== 
(== 
	endpoints== &
=>==' )
{>> 
	endpoints?? 
.?? 
MapControllers?? (
(??( )
)??) *
;??* +
}@@ 
)@@ 
;@@ 
}AA 	
}BB 
}CC 