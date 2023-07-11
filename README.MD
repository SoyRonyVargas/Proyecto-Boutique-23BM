
# Boutique

Instrucciones para arrancar el proyecto

# Tareas
- [ ] Diseño (Beto y Martin)
- [ ] Eventos con la interfaz (Angel y Edison)
- [ ] Servicios Yo

## Necesitas
- Visual Studio
- Xampp

En el archivo Context.cs verificar que el puerto y el usuario root sean iguales a los
de tu Xampp. 
 
```sh                                                      // aqui cambiar el puerto y si tiene contraseña tambien.
static readonly string connectionString = "Server=localhost;port=3306;User ID=root; Password=; Database=Boutique23BM";
```
## Arrancar el proyecto

Restaura los paquetes desde la consola con
```sh
dotnet restore
```

Ejecuta las migraciones en la terminal con
```sh
dotnet ef database update
```

O con la terminal de paquetes
```sh
Update-Database
```

Dale al boton de play en visual studio.
