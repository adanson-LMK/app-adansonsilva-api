# Documentación de API - CRUD de Clientes

Este documento describe los endpoints de la API para gestionar la información de los clientes en el sistema.

## Modelo Cliente

El objeto `Cliente` tiene la siguiente estructura:

```json
{
  "cod": "string",
  "nombre": "string",
  "apellido": "string",
  "dni": "string",
  "estado": "string" 
}
```

- **cod**: Código único del cliente (CHAR(5)).
- **nombre**: Nombre del cliente (VARCHAR(50)).
- **apellido**: Apellido del cliente (VARCHAR(50)).
- **dni**: Documento Nacional de Identidad del cliente (CHAR(8), único).
- **estado**: Estado del cliente. 'A' para Activo, 'I' para Inactivo. (CHAR(1)).

---

## Endpoints de la API

### 1. Listar Clientes Activos

Devuelve una lista de todos los clientes que se encuentran activos en el sistema.

- **URL**: `/api/Cliente`
- **Método**: `GET`
- **Respuesta Exitosa (Código 200 OK)**:

```json
[
  {
    "cod": "CL001",
    "nombre": "Ana",
    "apellido": "Gómez",
    "dni": "11223344",
    "estado": "A"
  },
  {
    "cod": "CL002",
    "nombre": "Luis",
    "apellido": "Sánchez",
    "dni": "22334455",
    "estado": "A"
  }
]
```

### 2. Buscar Cliente por Código

Busca y devuelve un cliente específico utilizando su código.

- **URL**: `/api/Cliente/{codigo}`
- **Método**: `GET`
- **Parámetros de URL**:
  - `codigo` (requerido): El código del cliente a buscar.
- **Respuesta Exitosa (Código 200 OK)**:

```json
{
  "cod": "CL001",
  "nombre": "Ana",
  "apellido": "Gómez",
  "dni": "11223344",
  "estado": "A"
}
```

### 3. Registrar Nuevo Cliente

Crea un nuevo cliente en la base de datos. El estado se asigna automáticamente como 'A' (Activo).

- **URL**: `/api/Cliente`
- **Método**: `POST`
- **Cuerpo de la Solicitud (Body)**:

```json
{
  "cod": "CL004",
  "nombre": "Carlos",
  "apellido": "Pérez",
  "dni": "44556677"
}
```

- **Respuesta Exitosa (Código 201 Created)**: Devuelve un booleano `true` indicando que el registro fue exitoso.

### 4. Editar Cliente

Actualiza la información de un cliente existente.

- **URL**: `/api/Cliente`
- **Método**: `PUT`
- **Cuerpo de la Solicitud (Body)**:

```json
{
  "cod": "CL004",
  "nombre": "Carlos Alberto",
  "apellido": "Pérez",
  "dni": "44556677"
}
```

- **Respuesta Exitosa (Código 201 Created)**: Devuelve un booleano `true` indicando que la edición fue exitosa.

### 5. Eliminar Cliente (Lógicamente)

Realiza una eliminación lógica del cliente, cambiando su estado a 'I' (Inactivo). El registro no se borra físicamente de la base de datos.

- **URL**: `/api/Cliente/{codigo}`
- **Método**: `DELETE`
- **Parámetros de URL**:
  - `codigo` (requerido): El código del cliente a eliminar.
- **Respuesta Exitosa (Código 201 Created)**: Devuelve un booleano `true` indicando que la eliminación lógica fue exitosa.
