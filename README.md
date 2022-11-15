
# BGlobal Challenge

En este repositorio podras encontrar un proyecto sencillo con un CRUD para 
el almacenamiento de carros. Ademas cuenta con un consumo sencillo de a 
un api rest.




## Instalacion

Este proyecto cuenta con tres archivos para poder realizar ejecucion:
- .env
- docker-compose.yml
- Init.sql

**.env:** Contiene las 
variables de entorno basicas de la base de datos (Nombre, usuario y password).

**docker-compose.yml:** Contiene la imagen, red basica, puertos, entre otros 
aspectes basicos para levantar el ambiente de base de datos.

**Init.sql:** Contiene el query de creacion de la tabla el cual se ejecuta automaticamente 
al ejecutar el **docker-compose**

```bash
  cd BGlobalChallenge/Services/BGlobalChallenge.Services.CarAPI
  docker-compose up
```

Una vez que docker haya descargado la imagen y haya desplegado el contenedor, 
el proyecto debe compilarse y ejecutarse desde el IDE de desarrollo 
**(Preferiblemente Rider)**

Cuando el proyecto haya compilado e iniciado se desplegara el navegador 
con swagger en donde se podran observar y probar los endpoint.
## Autor

- [@elyjcolmenarez](https://github.com/ElyJColmenarez)

