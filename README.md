Descripción del Proyecto
Funcionalidad de la Aplicación
Esta aplicación web permite gestionar series, productoras y géneros mediante una interfaz intuitiva y fácil de usar. Las funcionalidades principales incluyen:

Home:

Un menú con opciones para navegar al home, series, productoras y géneros.
Listado de todas las series con detalles como nombre, imagen de portada, géneros y productora.
Botón para ver el detalle de cada serie, que muestra un reproductor de video con el enlace guardado.
Filtros y Búsqueda:

Búsqueda por nombre de la serie.
Filtros por productora y género, mostrando solo las series correspondientes.
Mantenimiento de Series:

Listado de series con opciones para editar y eliminar.
Formulario para crear nuevas series con campos requeridos (nombre, imagen, enlace de video, productora, género primario y secundario).
Formulario para editar series existentes.
Confirmación antes de eliminar una serie.
Mantenimiento de Productoras:

Listado de productoras con opciones para editar y eliminar.
Formulario para crear y editar productoras con validación del nombre.
Mantenimiento de Géneros:

Listado de géneros con opciones para editar y eliminar.
Formulario para crear y editar géneros con validación del nombre.
Tecnologías Utilizadas
ASP.NET Core MVC: Utilizado para la creación de controladores y vistas.
.NET 6, 7 o 8: Versión de .NET para el desarrollo del proyecto.
Entity Framework con Code First: Para la persistencia de datos.
ViewModels: Para gestionar los datos entre las vistas y el modelo.
Bootstrap: Para el diseño y la responsividad de la interfaz de usuario.
Descripción del Proyecto para el README en GitHub
Este proyecto es una aplicación web desarrollada con ASP.NET Core MVC que permite gestionar series de televisión, productoras y géneros.
La aplicación cuenta con un sistema de mantenimiento que facilita la creación, edición y eliminación de estos elementos.

Funcionalidades
Home: Pantalla principal con un menú de navegación y un listado de series.
Series: Mantenimiento de series con opciones para agregar, editar y eliminar.
Productoras: Mantenimiento de productoras con opciones para agregar, editar y eliminar.
Géneros: Mantenimiento de géneros con opciones para agregar, editar y eliminar.
Filtros y Búsqueda: Búsqueda por nombre, filtro por productora y género.
Tecnologías
ASP.NET Core MVC: Framework principal para el desarrollo.
.NET 6, 7 o 8: Versiones compatibles del framework.
Entity Framework con Code First: Para la gestión de la base de datos.
ViewModels: Para la organización y validación de los datos.
Bootstrap: Para una interfaz de usuario atractiva y responsiva.
Ejecución


Para ejecutar este proyecto:

Clona el repositorio.
Configura la base de datos utilizando Entity Framework con Code First. (SOLO PON LA DIRECCION A TU BASE DE DATOS en el APPSETINGS.JSON de la capa de AppStreaming, luego abres herramientas en Visual Studio 
vas a la opcion Nuget Package Manager, luego a la opcion Package Manage Console y ahí asegurate que la consola tenga como proyecto predeterminado la capa AppStreaming, luego escribes Update-Database, y listo.)
Ejecuta la aplicación desde Visual Studio o utilizando el CLI de .NET.
Este proyecto es ideal para aprender sobre la gestión de datos en una aplicación web utilizando ASP.NET Core MVC y Entity Framework,
con una capa clara de separación de la lógica de negocio, la persistencia de datos y la interfaz de usuario.
