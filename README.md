<h1 align="center">Zestora</h1>

<p align="center">
  <strong>Plataforma integral de comercio electrónico para la gestión avanzada de ventas, inventario y clientes.</strong>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Frontend-Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white" alt="Frontend Angular">
  <img src="https://img.shields.io/badge/Backend-.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Backend .NET Core">
  <img src="https://img.shields.io/badge/Database-PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white" alt="Database PostgreSQL">
</p>

---

## Resumen Ejecutivo

**Zestora** es una aplicación transaccional de comercio electrónico de arquitectura Full-Stack. Diseñada bajo altos estándares de ingeniería de software, utiliza **Angular** para la interfaz de cliente y **.NET** para los servicios backend, garantizando una plataforma escalable, segura y de alto rendimiento orientada a la conversión y la gestión operativa.

## Arquitectura del Sistema

El proyecto implementa **Clean Architecture**, asegurando una separación estricta de responsabilidades a través de múltiples capas lógicas independientes. Esta estructura facilita la mantenibilidad y la escalabilidad del código a largo plazo:

```text
Zestora.slnx
├── ClientApp/                  # Aplicación cliente (Frontend Angular)
├── src/
│   ├── Zestora.API/            # Capa de presentación y controladores REST
│   ├── Zestora.Application/    # Lógica de negocio, servicios y transferencia de datos
│   ├── Zestora.Domain/         # Entidades core e interfaces de dominio puro
│   └── Zestora.Infrastructure/ # Acceso a datos, persistencia y repositorios
└── SQL/                        # Scripts de migración y estructuración de base de datos
```

## Estándares y Patrones de Diseño

La plataforma aplica patrones de diseño reconocidos en la industria para resolver problemas arquitectónicos comunes de manera eficiente.

### Servicios Backend (.NET)

| Patrón Implementado | Descripción Técnica | Ubicación Principal |
|---------------------|---------------------|---------------------|
| **Clean Architecture** | Organización jerárquica con dependencias apuntando hacia el dominio. | Estructura global |
| **Repository Pattern** | Abstracción de la capa de acceso a datos. | `Zestora.Infrastructure/Repositories/` |
| **Unit of Work** | Coordinación transaccional para operaciones atómicas. | `UnitOfWork.cs` |
| **Dependency Injection** | Inversión de control para reducir el acoplamiento. | `Program.cs` |
| **Generic Repository** | Operaciones CRUD base asíncronas y reutilizables. | `BaseRepositoryAsync.cs` |
| **Specification Pattern** | Encapsulamiento de criterios de consulta complejos. | `SpecificationEvaluator.cs` |
| **Service Layer** | Aislamiento de las reglas y procesos de negocio. | `Zestora.Application/Services/` |

### Interfaz Frontend (Angular)

| Patrón Implementado | Descripción Técnica | Ubicación Principal |
|---------------------|---------------------|---------------------|
| **Feature Modules** | Organización modular orientada a dominios funcionales. | `ClientApp/src/app/features/` |
| **Lazy Loading** | Carga diferida de recursos para optimización de rendimiento. | `app.routes.ts` |
| **Core Module** | Contenedor de servicios singleton y utilidades globales. | `ClientApp/src/app/core/` |
| **Component-Based UI** | Interfaz construida mediante componentes aislados y reutilizables. | Directorios de componentes |
| **Reactive Forms** | Control de estado y validación síncrona/asíncrona de formularios. | Módulo de Autenticación |
| **Service Integration** | Abstracción de la comunicación con APIs REST. | `ClientApp/src/app/core/services/` |

---

## Interfaz de Programación de Aplicaciones (API) y Enrutamiento

### Rutas de la Aplicación Cliente

| Ruta Web | Componente Asociado | Propósito Operativo |
|----------|---------------------|---------------------|
| `/` | Redirección | Redirige al módulo de autenticación de forma predeterminada. |
| `/auth` | `AuthModule` | Módulo principal de gestión de identidad. |
| `/auth/login` | `LoginComponent` | Portal de acceso y validación de credenciales. |
| `/auth/register` | `RegisterComponent` | Flujo de registro para nuevos clientes. |

### Endpoints del Backend

#### Gestión de Productos (`/api/Product`)

| Método | Endpoint | Funcionalidad |
|--------|----------|---------------|
| `POST` | `/api/Product` | Alta de un nuevo producto en el catálogo. |
| `POST` | `/api/Product/bulk` | Inserción masiva de productos (lotes). |
| `GET` | `/api/Product/{id}` | Recuperación de detalles específicos de un producto. |
| `GET` | `/api/Product` | Listado general del catálogo de productos. |

#### Gestión de Clientes (`/api/Customer`)

| Método | Endpoint | Funcionalidad |
|--------|----------|---------------|
| `POST` | `/api/Customer/CreateUser` | Registro y provisión de una nueva cuenta de cliente. |
| `POST` | `/api/Customer/ValidateUser` | Autenticación y verificación de credenciales de acceso. |
| `GET` | `/api/Customer/GetAllActiveUsers` | Listado administrativo de clientes con estado activo. |

---

## Pila Tecnológica

La selección de tecnologías responde a criterios de rendimiento, seguridad y soporte a nivel empresarial.

### Frontend
- **Framework:** Angular v21.1
- **Lenguaje:** TypeScript v5.9
- **Programación Reactiva:** RxJS v7.8
- **Estilos:** PostCSS
- **Pruebas Unitarias:** Vitest

### Backend
- **Framework:** ASP.NET Core (.NET)
- **ORM:** Entity Framework Core (Implementación `PostgresContext`)
- **Base de Datos:** PostgreSQL
- **Documentación de API:** Swagger/OpenAPI

---

## Modelo de Dominio Core

La plataforma modela su lógica de negocio basándose en las siguientes entidades principales, distribuidas por áreas de gestión:

- **Gestión de Usuarios:** `Customer` (Clientes), `StaffAccount` (Administradores).
- **Catálogo de Ventas:** `Product` (Artículos), `Category` (Clasificación).
- **Proceso de Compra:** `Cart`, `CartItem` (Carrito temporal), `Order`, `OrderItem` (Transacciones formalizadas).
- **Logística y Almacén:** `Inventory` (Control de existencias), `Shipping` (Tarifas y zonas de envío).
- **Marketing y Fidelización:** `Coupon`, `ProductCoupon` (Promociones), `Notification` (Avisos del sistema).

---

## Guía de Despliegue Local

### Requisitos Previos
- Instalación de .NET SDK.
- Entorno de ejecución Node.js y gestor de paquetes npm.
- Instancia activa de PostgreSQL.

### Inicialización de Servicios Backend
1. Navegar al directorio de la API:
   ```bash
   cd src/Zestora.API
   ```
2. Ejecutar el proyecto:
   ```bash
   dotnet run
   ```
   *Nota: La API se desplegará por defecto en `https://localhost:5001`. La interfaz de documentación de Swagger estará disponible automáticamente en este puerto.*

### Inicialización de la Aplicación Cliente
1. Navegar al directorio del frontend:
   ```bash
   cd ClientApp
   ```
2. Instalar dependencias y ejecutar:
   ```bash
   npm install
   npm start
   ```
   *Nota: La aplicación cliente estará disponible en `http://localhost:4200`.*

---

## Consideraciones Técnicas Adicionales

- **Seguridad CORS:** Las políticas de intercambio de recursos de origen cruzado están estrictamente configuradas para permitir tráfico proveniente de `http://localhost:4200`.
- **Entornos de Desarrollo:** La interfaz gráfica de Swagger está habilitada exclusivamente bajo configuraciones de desarrollo para prevenir exposición de contratos en producción.
- **Persistencia de Datos:** El sistema está optimizado y configurado de forma nativa para operar con el motor relacional PostgreSQL.