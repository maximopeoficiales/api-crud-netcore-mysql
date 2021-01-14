#Instrucciones 

1.- dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.1 (varia segun tu version de dotnet)

2.- añadir al \*\* .csproj
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="5.0.0-alpha.2" />
3.- verificar si puedes ejecutar dotnet ef ( si no ejecutar ) dotnet tool install --global dotnet-ef

4.- dotnet restore (para añadir el pomelo.entity\*\*\*\*)

5.- dotnet ef dbcontext scaffold "Server=localhost;Database=ef;User=root;Password=123456;TreatTinyAsBoolean=true;" "Pomelo.EntityFrameworkCore.MySql" -o models

6.- Modificar el startup con el siguiente codigo: modificando el context y tu cadena conexion
`
    services.AddDbContextPool<DB_PAMYSContext>(
dbContextOptions => dbContextOptions
.UseMySql(
// Replace with your connection string.
"Server=localhost;port=3307;Database=DB_PAMYS;User=root;Password=root;TreatTinyAsBoolean=true;",
// Replace with your server version and type.
// For common usages, see pull request #1233.
new MySqlServerVersion(new Version(8, 0, 21)), // use MariaDbServerVersion for MariaDB
mySqlOptions => mySqlOptions
.CharSetBehavior(CharSetBehavior.NeverAppend))
// Everything from this point on is optional but helps with debugging.
.EnableSensitiveDataLogging()
.EnableDetailedErrors()
);
`


<!-- dotnet ef dbcontext scaffold "Server=localhost;port=3307;Database=DB_PAMYS;User=root;Password=root;TreatTinyAsBoolean=true;" "Pomelo.EntityFrameworkCore.MySql" -o models
 -->
