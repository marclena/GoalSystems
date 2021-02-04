# GoalSystems
La aplicación se ha desarrollada utilizando conceptos de repositorio, inyección de dependencia e interfaces.
Esto permite que la aplicación no este acoplada a ningun repositorio.
En el ejemplo del codigo el repositorio implementa una lista para mantener los inventarios
## Arquitectura
La arquitedtura de la solución se ha desarrollad en basea repositorios y se ha dividio en carpetas
### Models
Aqui tenemos la definición del modelo del inventario, aqui tenemos todos los campos del inventario
#### DTO
Aqui he creado 2 versiones del modelo, para poner como ejemplo que desde la api puedes devolver una versión del modelo sin exponer el modelo real
La logica de negocio lo que hace es rellenar el objeto de modelo pero con automapper lo transformo a DTO para mostrar al cliente.
Para configurar el mapper se utiliza la inyección de dependencia inherenete del .Net Core
## Swagger
COmo vereys, he configurado la aplicación para que ejecute el swagger y asi lo podais probar.
Tambien he añadido atributos de comentarios para loss metodos y parametros y tambien para saber los status code
## Repositorios
Aqui es donde tenemos los repositorios y los interfaces para no acoplar el codigo con el repositorio
Mediante inyección de dependencia defino que clase implementara el interface. De esta manera si tenemos un nuevo repositorio que implemeneta el interface es muy facil cambiarlo. 
Es decir un desacoplamiento total y una mayor facilidad para pruebas
