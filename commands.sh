#Verificar Estado Solucion
dotnet build
dotnet test

#Limpiar solucion
dotnet clean

#Migracion
dotnet ef migrations add InitialCreate -v -s .\src\Hogwarts.Api\Hogwarts.Api.csproj -p .\src\Hogwarts.Infrastructure\Hogwarts.Infrastructure.csproj

dotnet ef database update -v -s .\src\Hogwarts.Api\Hogwarts.Api.csproj -p .\src\Hogwarts.Infrastructure\Hogwarts.Infrastructure.csproj
