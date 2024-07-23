# Aplicación del SENA 2024

## Historias de usuario adaptadas para la gestión de Hogwarts:

### Historia de Usuario 1: Gestión de Estudiantes
**Como** administrador de Hogwarts, **quiero** poder gestionar los estudiantes, **para** mantener un registro actualizado de los mismos.

**Criterios de Aceptación:**
- Puedo añadir nuevos estudiantes con información como nombre, apellido, fecha de nacimiento, casa y Asignaturas inscritos.
- Puedo editar la información de los estudiantes.
- Puedo eliminar estudiantes del registro.
- Puedo ver una lista de todos los estudiantes.

### Historia de Usuario 2: Asignación de Casas
**Como** administrador de Hogwarts, **quiero** asignar estudiantes a diferentes casas, **para** organizar mejor el colegio.

**Criterios de Aceptación:**
- Puedo asignar una casa a un estudiante al momento de su registro.
- Puedo cambiar la casa de un estudiante existente.
- Puedo ver una lista de estudiantes filtrada por casa.

### Historia de Usuario 3: Gestión de Profesores
**Como** administrador de Hogwarts, **quiero** poder gestionar los profesores, **para** mantener un registro actualizado de los mismos y sus asignaturas.

**Criterios de Aceptación:**
- Puedo añadir nuevos profesores con información como nombre, apellido y asignatura.
- Puedo editar la información de los profesores.
- Puedo eliminar profesores del registro.
- Puedo ver una lista de todos los profesores.

### Historia de Usuario 4: Inscripción a Asignaturas
**Como** estudiante, **quiero** poder inscribirme en diferentes asignaturas, **para** asistir a las clases que me interesan.

**Criterios de Aceptación:**
- Puedo ver una lista de asignaturas disponibles.
- Puedo inscribirme en un curso.
- Puedo ver una lista de asignaturas en los que estoy inscrito.
- Puedo darme de baja de un curso.

### Diagrama de Clases
Basado en las historias de usuario, el diagrama de clases incluirá las siguientes entidades y relaciones:

![diagrama de clases](./assets/diagram-class-relations.svg "diagrama de clases")


<!-- ```plantuml
@startuml
abstract class Base {
  + id: UUID
}

abstract class Person extends Base {
  + firstName: string
  + lastName: string
  + description: string
  + age: int
  + dateOfBirth: Date
  + bloodStatus: BloodStatus
  + picture: Picture
}

class Subject {
  + name: string
  + description: string
}

class Teacher extends Person {
}

class House {
  + name: string
  + founder: string
}

class Student extends Person {
}

class StudentSubject {
  + studentId: UUID
  + subjectId: UUID
  + enrollmentDate: Date
}

class Photograph {
  + url: string
}

Base <|-- Subject
Base <|-- House
Base <|-- StudentSubject
Base <|-- Photograph

Subject "1" -- "1" Teacher: "teaches"
House "1" -- "0..*" Student: "belongs to"
Student "0..*" -- "0..*" Subject: "takes"
Student "0..*" -- "0..*" StudentSubject: "is"
Subject "0..*" -- "0..*" StudentSubject: "is"
Student "0..*" -- "1" Photograph: "may have"
Teacher "0..*" -- "1" Photograph: "may have"
@enduml


``` -->

En este diagrama:

- `Estudiante` tiene una relación de uno a muchos con `Casa` (un estudiante pertenece a una casa, una casa puede tener muchos estudiantes).
- `Estudiante` tiene una relación de muchos a muchos con `Asignatura` (un estudiante puede inscribirse en muchas Asignaturas, una Asignatura puede tener muchos estudiantes inscritos) a través de la tabla intermedia `EstudianteAsignatura`.
- `Profesor` tiene una relación de uno a uno con `Asignatura` (un profesor enseña una asignatura, una asignatura es enseñada por un profesor).

<!-- Elementos casa harry potter
Las Casas de Hogwarts, fundadas por Godric Gryffindor, Helga Hufflepuff, Rowena Ravenclaw y Salazar Slytherin, tienen elementos característicos que definen a sus estudiantes y les otorgan una identidad única.

Gryffindor

Fundador: Godric Gryffindor
Colores: Oro y escarlata
Animal: León
Reliquia más preciada: La espada de Godric Gryffindor
Elemento: Fuego
Características: Valentía, disposición, coraje y caballerosidad
Hufflepuff

Fundadora: Helga Hufflepuff
Colores: Amarillo y negro carbón
Animal: Tejón
Reliquia más preciada: La copa de Helga Hufflepuff
Elemento: Tierra
Características: Lealtad, honestidad y trabajo duro
Ravenclaw

Fundadora: Rowena Ravenclaw
Colores: Azul y bronce
Animal: Águila (o cuervo en algunas versiones)
Reliquia más preciada: La diadema de Rowena Ravenclaw
Elemento: Aire
Características: Creatividad, curiosidad y búsqueda de conocimiento
Slytherin

Fundador: Salazar Slytherin
Colores: Verde y plateado
Animal: Serpiente
Reliquia más preciada: El guardapelo de Salazar Slytherin
Elemento: Agua
Características: Ambición, astucia y determinación
Cada Casa tiene su propio espíritu y cultura, lo que refleja la personalidad y los valores de sus estudiantes. -->