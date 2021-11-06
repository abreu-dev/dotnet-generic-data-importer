dotnet test ../GenericImporter.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet sonarscanner begin /k:"GenericImporter" /d:sonar.host.url="http://localhost:8082" /d:sonar.login="7df82298d6592d1787b33ccde74c925643af92cf" /d:sonar.cs.opencover.reportsPaths="../tests/*/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Tests*.cs
dotnet build ../GenericImporter.sln
dotnet sonarscanner end /d:sonar.login="7df82298d6592d1787b33ccde74c925643af92cf"