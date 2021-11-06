æ
‡C:\Users\Gabriel\Desktop\Repos\dotnet-generic-importer\backend\src\GenericImporter.Infra.CrossCutting.IoC\NativeInjectorBootStrapper.cs
	namespace 	
GenericImporter
 
. 
Infra 
.  
CrossCutting  ,
., -
IoC- 0
{ 
public 

static 
class &
NativeInjectorBootStrapper 2
{ 
public 
static 
void 
RegisterServices +
(+ ,
IServiceCollection, >
services? G
)G H
{ 	
services 
. 
	AddScoped 
< 
IMediatorHandler /
,/ 0
MediatorHandler1 @
>@ A
(A B
)B C
;C D
services 
. 
	AddScoped 
<  
INotificationHandler 3
<3 4
DomainNotification4 F
>F G
,G H%
DomainNotificationHandlerI b
>b c
(c d
)d e
;e f
services 
. 
	AddScoped 
< 
IRequestHandler .
<. /
AddXptoCommand/ =
,= >
Unit? C
>C D
,D E
XptoCommandHandlerF X
>X Y
(Y Z
)Z [
;[ \
services 
. 
	AddScoped 
< 
DataContext *
>* +
(+ ,
), -
;- .
services!! 
.!! 
	AddScoped!! 
<!! 
IXptoRepository!! .
,!!. /
XptoRepository!!0 >
>!!> ?
(!!? @
)!!@ A
;!!A B
services$$ 
.$$ 
	AddScoped$$ 
<$$ 
IXptoAppService$$ .
,$$. /
XptoAppService$$0 >
>$$> ?
($$? @
)$$@ A
;$$A B
}&& 	
}'' 
}(( 