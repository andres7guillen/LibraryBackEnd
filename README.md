# LibraryBackEnd


Api REST para la administracion de una biblioteca, hecha en .net Core 2.2 El contexto de datos fue hecho con Entity framework 2.2,
 para crear la base de datos se debe modificar el connection string de nombre "LibraryDb",que esta en el archivo 
 "appsettings.json"  del proyecto del LibraryApi, con la cadena de conexion que uds tengan,
,una vez modificado el connection string se debe abrir la consola de administrador de paquetes apuntando al proyecto de LibraryData
 y una vez ahi ejecutar el comando "update-database -migration initDb". Proyecto hecho con visual studio 2019 community y .net Core 2.2

Front End hecho con angular 8, para ejecutar este proyecto primero se abre el CMD, o la terminal de visual studio Code, se deja 
apuntando a la carpeta del front(LibraryFrontEnd) y se ejecuta el comando "npm Install", este comando instalara todas las dependencias 
del proyecto alojadas en el Package.json, ya una vez ejecutado, se corren los proyectos y ya se pueden usar.

SOLUCION POSIBLE ERROR EN LA CONEXION CON LA DB:
Si se presenta algun error al correr el api, lo que se tiene que hacer es ir a visual studio, despues HERRAMIENTAS, se crea una nueva conexion con base 
de datos se ponen las credenciales correspondientes, una vez creada la nueva conexion, en la parte superior izquierda del visaul studio en la pestaña 
de EXPLORADOR DE SERVIDORES, ahi esta la nueva conexion, se selecciona y se oprime la tecla F4, se abren las propiedades y se copia el valor del campo  
“Cadena de conexion”: Esa cadena de conexión es la que se debe pegar en el value del key de "LibraryDb" del app.setttings.json, haciendo eso se corrige el error. 
 




