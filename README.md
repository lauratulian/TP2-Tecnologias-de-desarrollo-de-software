# Sistema de Gestión Académica tipo Campus Universitario

Este proyecto tiene como objetivo el desarrollo de un **sistema de gestión académica** para una institución educativa, con funcionalidades orientadas al manejo de personas, usuarios, planes de estudio, materias, cursos e inscripciones.

Está compuesto por dos aplicaciones complementarias:

- Una **aplicación de consola**, orientada a pruebas o administración básica del sistema.
- Una **aplicación de escritorio (Windows Forms)** que brinda una interfaz gráfica completa para el usuario final.

El sistema fue desarrollado en **C#**, siguiendo una **arquitectura en capas** que separa responsabilidades de forma clara (entidades, lógica, acceso a datos, interfaz). Esto permite una mayor escalabilidad, mantenimiento y reutilización del código.

Este proyecto fue realizado en la cátedra de **Tecnologías de Desarrollo de Software** de la **UTN Rosario** por **Ramiro Cordoba, Laura Tulian, Juan Cruz Vazquez,**.

## 🧾 Objetivo

Desarrollar un sistema funcional para la administración de un campus universitario, permitiendo la gestión de:

- Alumnos y sus inscripciones.
- Docentes y asignación a cursos.
- Materias, planes de estudio, comisiones y especialidades.
- Usuarios con distintos permisos y roles.

## 🧩 Estructura del Sistema

Las principales entidades del sistema incluyen:

- `Usuario`: gestiona credenciales y permisos de acceso.
- `Persona`: base común para alumnos, docentes y administrativos.
- `Materia`, `Curso`, `Comision`, `Plan`, `Especialidad`: componentes del plan académico.
- `AlumnoInscripciones`: gestiona las inscripciones de alumnos a cursos.
- `DocenteCurso`: relaciona docentes con cursos y cargos.
- `Modulo` y `ModuloUsuario`: manejan el control de acceso por funcionalidad.
- `Cargos`: define los tipos de asignaciones docentes.

## 🚀 Características Principales

- Aplicación de **consola** para interacción básica y pruebas.
- Aplicación de **escritorio (WinForms)** con interfaz amigable.
- Validación de datos y lógica centralizada.
- Separación clara en capas:
  - `Business.Entities` – Modelo de datos.
  - `Business.Logic` – Lógica del negocio.
  - `Data.Database` – Acceso a base de datos.
  - `UI.Desktop` – Interfaz gráfica.
  - `UI.Consola` – Interfaz por consola.

## 🛠 Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework
- **Base de datos:** SQL Server
- **Diseño:** Arquitectura en Capas / MVC lógico

## 📸 Capturas 

>

