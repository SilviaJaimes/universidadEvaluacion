# Universidad

Este proyecto proporciona una API que permite implementar una base de datos para gestionar la información de sus estudiantes, profesores, cursos y asignaturas.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

## 1. Generación del token 🔑:

**Endpoint**: `http://localhost:5033/api/usuario/token`

**Método**: `POST`

**Payload**:

`{
    "Nombre": "Admini",
    "Contraseña": "pass1234"
}`

## 2. Registro de Usuarios 📝:

**Endpoint**: `http://localhost:5033/api/usuario/register`

**Método**: `POST`

**Payload**:

json
`{
    "Usuario": "<nombre_de_usuario>",
    "Contraseña": "<contraseña>",
    "CorreoElectronico": "<correo_electronico>"
}`

Este endpoint permite a los usuarios registrarse en el sistema.

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token.

## 3. Refresh Token 🔄:

**Endpoint**: `http://localhost:5033/api/usuario/refresh-token`

**Método**: `POST`

**Payload**:

`{
    "Nombre": "<nombre_de_usuario>",
    "Contraseña": "<contraseña>"
}`

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

**Otros Endpoints**

Obtener Todos los Usuarios: GET `http://localhost:5033/api/usuario`

Obtener Usuario por ID: GET `http://localhost:5033/api/usuario/{id}`

Actualizar Usuario: PUT `http://localhost:5033/api/usuario/{id}`

Eliminar Usuario: DELETE `http://localhost:5033/api/usuario/{id}`


## Desarrollo de los Endpoints requeridos⌨️

Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 del GET se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)


**1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-1`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/3a70fd98-0132-4e50-b916-18b328f7a4a1)  


**2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-2`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/5e82f690-5846-4189-9b32-154f5cfd34d5)  


**3. Devuelve el listado de los alumnos que nacieron en `1999`:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-3`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/4b4f00fd-d69b-41d7-960c-aacca46b786b)  


**4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-4`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/719e8fa7-7469-489e-870b-b4af124b3dbf)  


**5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`:**

**Endpoint**: `http://localhost:5033/api/Asignatura/consulta-5`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/4489f76a-3585-4fbb-9303-0a0c0eb66998)  


**6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-6`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/417b835f-4510-40c4-97e2-c65e8ce5f76e)  


**7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`:**

**Endpoint**: `http://localhost:5033/api/Asignatura/consulta-7`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/5c6e3ab1-c1ce-4ae8-8771-54589d7fdf66)  


**8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre`:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-8`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/489f4715-c230-4d54-9794-29931ffcf460)  


**9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`:**

**Endpoint**: `http://localhost:5033/api/Asignatura/consulta-9`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/3113f268-b799-41eb-aed8-20a9dd020199)  


**10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-10`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/90eb6cf0-c89a-4d8f-895e-3c13dfc058e1)  


**11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-11`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/bdb86d81-7cfa-46df-82cd-9df13b39fa31)  


**12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-12`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/755d98f8-6c0d-47c0-a25a-bf913fc58979)  


**13. Devuelve un listado con los profesores que no están asociados a un departamento.Devuelve un listado con los departamentos que no tienen profesores asociados:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-13`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/af4cce24-1324-4acb-afd6-53a494b7f637)  


**14. Devuelve un listado con los profesores que no imparten ninguna asignatura:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-14`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/ef1872c1-1715-4210-8303-a892c7d98d81)  


**15. Devuelve un listado con las asignaturas que no tienen un profesor asignado:**

**Endpoint**: `http://localhost:5033/api/Asignatura/consulta-15`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/517b8d8a-a010-44bc-995d-f1f936c65e33)  


**16. Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar. El resultado debe mostrar el nombre del departamento y el nombre de la asignatura que no se haya impartido nunca:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-16`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/f18cf7f8-2f21-44ed-ab6b-d3a1662bfedf)  


**17. Devuelve el número total de **alumnas** que hay:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-17`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/04012235-f5ab-4adc-82bc-bbd4895790e1)  


**18. Calcula cuántos alumnos nacieron en `1999`:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-18`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/eae9b8a8-c600-4009-a152-f04e41de2036)  


**19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-19`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/796c862b-1500-4fd9-ab56-bc91c364ac68)  


**20. Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-20`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/3ac76bbe-37d8-453b-b61a-afdbe9bb224e)  


**21. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas:**

**Endpoint**: `http://localhost:5033/api/Grado/consulta-21`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/08f7fe39-7706-40d6-858e-38018f0a41a4)  


**22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas:**

**Endpoint**: `http://localhost:5033/api/Grado/consulta-22`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/1fddfb04-b709-4586-be48-9fdd48fbaa03)  


**23. Devuelve un listado que muestre el nombre de los grados y la suma del número total de créditos que hay para cada tipo de asignatura. El resultado debe tener tres columnas: nombre del grado, tipo de asignatura y la suma de los créditos de todas las asignaturas que hay de ese tipo. Ordene el resultado de mayor a menor por el número total de crédidos:**

**Endpoint**: `http://localhost:5033/api/Grado/consulta-23`

**Método**: `GET`  



**24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-24`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/02d9b837-5c9d-4990-b8ea-bd2f6cbf1aaa)  


**25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-25`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/74942151-18d5-4503-af0f-b53e7fe05342)  


**26. Devuelve todos los datos del alumno más joven:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-26`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/c7e92c2a-3e15-483f-bc22-875314b1a820)  


**27. Devuelve un listado con los profesores que no están asociados a un departamento:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-27`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/4a9bf5c6-5e75-4af3-b491-1479966ea012)  


**28. Devuelve un listado con los departamentos que no tienen profesores asociados:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-28`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/480c7fe3-b354-48ce-9133-a5778128a7f6)  


**29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura:**

**Endpoint**: `http://localhost:5033/api/Persona/consulta-29`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/c0fcf9f2-5cf9-47cc-ac00-97be3012d5c6)  


**30. Devuelve un listado con las asignaturas que no tienen un profesor asignado:**

**Endpoint**: `http://localhost:5033/api/Asignatura/consulta-30`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/1b458643-9f50-4d3d-8b9f-901786645c26)  


**31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar:**

**Endpoint**: `http://localhost:5033/api/Departamento/consulta-31`

**Método**: `GET`  
![image](https://github.com/SilviaJaimes/universidadEvaluacion/assets/132016483/e54fe7c3-926f-4788-a612-777045fb9e68)  


## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Patrón Repository y Unit of Work para la gestión de datos.

AutoMapper para el mapeo entre entidades y DTOs.

## Agradecimientos 🎁

A todas las librerías y herramientas utilizadas en este proyecto.

A ti, por considerar el uso de este sistema.

⌨️ con ❤️ por Silvia.
