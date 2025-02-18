# 🔥 User Management System - Clean Architecture & .NET 8 🔥

## 📌 Descripción del Proyecto

Bienvenido a **User Management System**, un proyecto diseñado para demostrar el uso de **Clean Architecture**, **.NET 8**, **Entity Framework Core**, **JWT Authentication**, y otras tecnologías clave en el desarrollo de aplicaciones empresariales modernas.

Este proyecto sirve como una plataforma de gestión de usuarios, con autenticación segura basada en **JWT (JSON Web Tokens)**, un robusto manejo de errores mediante **Middleware personalizado**, e implementación del **Patrón Repositorio y Dependency Injection** para garantizar una arquitectura escalable y mantenible.

## 🚀 Tecnologías Utilizadas

- **.NET 8** - Última versión del framework para aplicaciones modernas.
- **ASP.NET Core Web API** - Backend RESTful.
- **Entity Framework Core** - ORM para la interacción con bases de datos.
- **SQL Server** - Base de datos relacional.
- **JWT Authentication** - Seguridad basada en tokens.
- **ASP.NET Identity** - Gestión de usuarios y roles.
- **Clean Architecture** - Separación de responsabilidades para un código más escalable.
- **Repository Pattern** - Abstracción del acceso a datos.
- **Dependency Injection** - Inyección de dependencias para mejorar la modularidad.
- **Middleware personalizado** - Manejo centralizado de errores.
- **Swagger (OpenAPI)** - Documentación interactiva de la API.
- **Blazor WebAssembly** *(Próximamente)* - Interfaz web dinámica.

---

## 🏗️ Arquitectura del Proyecto

El proyecto sigue la estructura **Clean Architecture**, con una clara separación en capas:

📂 **UserManagementSystem**  
 ├── 📂 **API** *(Capa de Presentación - ASP.NET Core Web API)*  
 │   ├── 📂 Controllers *(Endpoints para la API)*  
 │   ├── 📂 Middleware *(Manejo centralizado de errores)*  
 │   ├── 📂 Program.cs *(Configuración del Proyecto)*  
 │  
 ├── 📂 **Application** *(Capa de Aplicación - Casos de Uso y Servicios)*  
 │   ├── 📂 Interfaces *(Definición de contratos de los servicios)*  
 │   ├── 📂 DTOs *(Modelos de datos para transferir información)*  
 │  
 ├── 📂 **Domain** *(Capa de Dominio - Entidades y Lógica de Negocio)*  
 │   ├── 📂 Entities *(Definición de modelos de la base de datos)*  
 │  
 ├── 📂 **Infrastructure** *(Capa de Infraestructura - Persistencia y Seguridad)*  
 │   ├── 📂 Persistence *(DbContext y configuración de la base de datos)*  
 │   ├── 📂 Repositories *(Implementaciones del Patrón Repositorio)*  
 │   ├── 📂 Security *(Configuración de Identity y JWT)*  

---

## 🛠️ Características Principales

✅ **Gestión de Usuarios**  
- Creación, edición y eliminación de usuarios.  
- Manejo de estados (usuarios activos/inactivos).  

✅ **Autenticación y Autorización**  
- Registro de usuarios con **Identity y JWT**.  
- Inicios de sesión seguros con JWT Tokens.  
- Roles y permisos con **ASP.NET Identity**.  

✅ **Manejo de Errores Global**  
- Middleware personalizado para capturar excepciones y devolver respuestas JSON estructuradas.  

✅ **Pruebas y Seguridad** *(en desarrollo 🚀)*  
- Unit Testing con **xUnit y Moq**.  
- Seguridad en endpoints con **Policies y Claims**.  
- Logging avanzado con **Serilog**.  

✅ **Próximamente**  
- Interfaz gráfica con **Blazor WebAssembly**.  
- Integración con servicios externos (Ej. API de terceros).  
- Despliegue en **Azure App Service** con **CI/CD**.  

---

## 🎯 Objetivo del Proyecto

El objetivo principal de este proyecto es servir como una demostración profesional de un sistema completo de gestión de usuarios, aplicando buenas prácticas de desarrollo con **.NET 8**, Clean Architecture y seguridad avanzada. 

Ideal para:

✔️ **Demostrar habilidades Full Stack con .NET**.    
✔️ **Aprender y aplicar arquitectura escalable con .NET**.  
