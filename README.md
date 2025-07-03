# Sistema de Gestión Académica 

Este proyecto corresponde al **Trabajo Práctico Nº2 (TP2)** de la asignatura **Tecnologías de Desarrollo de Software** de la **UTN Rosario**. Tiene como finalidad aplicar los conceptos abordados durante el cursado mediante el desarrollo de un sistema real, estructurado en capas y compuesto por múltiples proyectos conectados entre sí.

## 📘 Presentación

El objetivo del trabajo es implementar una versión simplificada de un **Sistema de Gestión Académica **, el cual permite registrar y administrar las actividades académicas de una universidad, contemplando entidades clave como alumnos, profesores, materias, planes de estudio e inscripciones.

La solución está compuesta por varios **proyectos conectados (referenciados)** entre ellos, cumpliendo con una **arquitectura multicapa**:

- Capa de Presentación (Web y Desktop)
- Capa de Negocios
- Capa de Datos
- Componentes Transversales (Entidades y Utilidades)

## 🏫 Modelo de Aplicación

El sistema permite gestionar:

- **Personas**: Alumnos y Profesores, con datos comunes (legajo, nombre, apellido, dirección).
- **Materias**: Vinculadas a un Plan, con carga horaria.
- **Planes**: Asociados a una Especialidad.
- **Cursos**: Creados anualmente, vinculados a una Comisión, con cupo limitado.
- **Docentes en Cursos**: Asignación con distintos cargos.
- **Inscripciones**: Permite a los alumnos inscribirse en cursos con cupo disponible.

### 📌 Diagrama del Modelo de Dominio


## ✅ Funcionalidades Implementadas

- ABMC (Alta, Baja, Modificación, Consulta) de:
  - Usuarios
  - Alumnos
  - Profesores
  - Especialidades
  - Planes y Materias
  - Comisiones
  - Cursos
- Inscripción de alumnos a cursos con control de cupo
- Registro de notas
- Reportes de cursos y planes (exportables a PDF)
- Autenticación de acceso por usuario y contraseña

---

## 🧱 Arquitectura y Requerimientos Técnicos

### 🖥️ Capa de Presentación

#### Web (ASP.NET MVC)
- Aplicación desarrollada en **ASP.NET MVC**
- Implementación de **Layouts**, **Partial Views**, y hojas de estilo (CSS)
- Validaciones del lado del **cliente (JavaScript)** y del **servidor**
- Generación de reportes **exportables a PDF**
- Control de acceso mediante **login (autenticación)**
- Menú de navegación general

#### Escritorio (Windows Forms)
- Aplicación de escritorio desarrollada en **Windows Forms**
- Implementación de **login** para autenticación
- Menú principal con acceso a todas las funcionalidades

---

### 🧠 Capa de Negocios
- Implementación de reglas de negocio específicas (por ejemplo, validación de cupo antes de inscripción)
- Generación de **excepciones personalizadas** ante errores de validación

---

### 🗄️ Capa de Datos
- Persistencia mediante **SQL Server**
- Acceso a datos centralizado
- Uso de **ADO.NET** o **Entity Framework**
- Posibilidad de uso de **Stored Procedures**
- Implementación de **transacciones** para operaciones compuestas (Planes y Materias, Usuarios y Permisos)

---

### 🔄 Componentes Transversales

#### Entidades
- Implementadas como **clases orientadas a objetos**, con uso de **colecciones tipadas**

#### Proyecto Utilidades
- Clases reutilizables comunes al sistema (por ejemplo: validaciones, conversores, manejo de errores)
- Implementación opcional de **log de errores**

---

### 🛡️ Requerimientos Técnicos Adicionales 

- ✅ Log de errores en archivo o base de datos (Utilidades)
- ✅ Uso de transacciones para ABMC compuestos
- ✅ Control de acceso por módulo (autorización)
- ✅ Uso de Stored Procedures o frameworks ORM (Entity Framework / NHibernate)

---

## 🧼 Buenas Prácticas Aplicadas

- Uso consistente de **nomenclatura estandarizada**
- Separación lógica de responsabilidades por capas y proyectos
- **Comentarios explicativos** en zonas clave del código
- Reutilización de código a través de clases utilitarias
- Aplicación de principios de **POO** y diseño limpio

---


## 📸 Capturas 

>

## 🛠 Herramientas Utilizadas

Para la realización de este Trabajo Práctico se emplearon diversas herramientas y tecnologías, que se detallan a continuación:

- **Entorno de Desarrollo:**  
  Microsoft Visual Studio Community 2019 (Versión 16.11.3)  
- **Framework:**  
  Microsoft .NET Framework (Versión 4.7.2)  
- **Sistema de Gestión de Base de Datos:**  
  Microsoft SQL Server Management Studio (SSMS) (Versión 18.9.2)  
- **Motor de Base de Datos:**  
  Microsoft SQL Server 2019 (Versión 15.0.2000.5)  
