```sql
-- Crear la base de datos y seleccionarla
CREATE DATABASE IF NOT EXISTS bd_teksan_ventas;
USE bd_teksan_ventas;

-- Eliminar tablas si existen (en orden para evitar errores por claves foráneas)
DROP TABLE IF EXISTS tb_detalle_venta;
DROP TABLE IF EXISTS tb_venta;
DROP TABLE IF EXISTS tb_cliente;
DROP TABLE IF EXISTS tb_detalle_compra;
DROP TABLE IF EXISTS tb_compra;
DROP TABLE IF EXISTS tb_usuario;
DROP TABLE IF EXISTS tb_proveedor;
DROP TABLE IF EXISTS tb_producto;
DROP TABLE IF EXISTS tb_categoria;
DROP TABLE IF EXISTS tb_marca;

-- ============================
-- 🏷️ Tabla de Marcas
-- ============================
CREATE TABLE tb_marca (
    codigo_marca CHAR(5) NOT NULL PRIMARY KEY,
    marca VARCHAR(35) NOT NULL
);

-- ============================
-- 🗂️ Tabla de Categorías
-- ============================
CREATE TABLE tb_categoria (
    codigo_categoria CHAR(5) NOT NULL PRIMARY KEY,
    categoria VARCHAR(40) NOT NULL
);

-- ============================
-- 📦 Tabla de Productos
-- ============================
CREATE TABLE tb_producto (
    codigo_producto CHAR(5) NOT NULL PRIMARY KEY,
    producto VARCHAR(40) NOT NULL,
    costo DECIMAL(10,2),
    ganancia DECIMAL(10,2),
    stock INT,
    producto_codigo_marca CHAR(5) NOT NULL,
    producto_codigo_categoria CHAR(5) NOT NULL,
    FOREIGN KEY (producto_codigo_marca) REFERENCES tb_marca(codigo_marca),
    FOREIGN KEY (producto_codigo_categoria) REFERENCES tb_categoria(codigo_categoria)
);

-- ============================
-- 🏢 Tabla de Proveedores
-- ============================
CREATE TABLE tb_proveedor (
    cod CHAR(5) NOT NULL PRIMARY KEY,
    razon_social VARCHAR(50) NOT NULL,
    ruc CHAR(11) NOT NULL,
    direccion VARCHAR(80)
);

-- ============================
-- 👤 Tabla de Usuarios
-- ============================
CREATE TABLE tb_usuario (
    cod CHAR(5) NOT NULL PRIMARY KEY,
    nombre_usuario VARCHAR(40) NOT NULL,
    clave VARCHAR(100) NOT NULL,
    correo VARCHAR(80)
);

-- ============================
-- 👥 Tabla de Clientes (con eliminación lógica)
-- ============================
CREATE TABLE tb_cliente (
    cod CHAR(5) NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50),
    dni CHAR(8) UNIQUE,
    estado CHAR(1) NOT NULL DEFAULT 'A' -- A: Activo, I: Inactivo
);

-- ============================
-- 📥 Tabla de Compras (Cabecera)
-- ============================
CREATE TABLE tb_compra (
    cod CHAR(5) NOT NULL PRIMARY KEY,
    fecha DATE NOT NULL,
    cod_proveedor CHAR(5) NOT NULL,
    cod_usuario CHAR(5),
    FOREIGN KEY (cod_proveedor) REFERENCES tb_proveedor(cod),
    FOREIGN KEY (cod_usuario) REFERENCES tb_usuario(cod)
);

-- ============================
-- 🧾 Tabla Detalle de Compras
-- ============================
CREATE TABLE tb_detalle_compra (
    cod_compra CHAR(5) NOT NULL,
    cod_prod CHAR(5) NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (cod_compra, cod_prod),
    FOREIGN KEY (cod_compra) REFERENCES tb_compra(cod),
    FOREIGN KEY (cod_prod) REFERENCES tb_producto(codigo_producto)
);

-- ============================
-- 💵 Tabla de Ventas (Cabecera)
-- ============================
CREATE TABLE tb_venta (
    cod CHAR(5) NOT NULL PRIMARY KEY,
    fecha DATE NOT NULL,
    cod_cliente CHAR(5),
    cod_usuario CHAR(5),
    total DECIMAL(10,2),
    FOREIGN KEY (cod_cliente) REFERENCES tb_cliente(cod),
    FOREIGN KEY (cod_usuario) REFERENCES tb_usuario(cod)
);

-- ============================
-- 📋 Tabla Detalle de Ventas
-- ============================
CREATE TABLE tb_detalle_venta (
    cod_venta CHAR(5) NOT NULL,
    cod_prod CHAR(5) NOT NULL,
    cantidad INT NOT NULL,
    precio_venta DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (cod_venta, cod_prod),
    FOREIGN KEY (cod_venta) REFERENCES tb_venta(cod),
    FOREIGN KEY (cod_prod) REFERENCES tb_producto(codigo_producto)
);

-- ============================
-- 📥 Insertar Marcas
-- ============================
INSERT INTO tb_marca (codigo_marca, marca) VALUES
    ('M0006', 'Intel'),
    ('M0007', 'AMD'),
    ('M0008', 'NVIDIA'),
    ('M0009', 'ASUS'),
    ('M0010', 'Corsair');

-- ============================
-- 🗂️ Insertar Categorías
-- ============================
INSERT INTO tb_categoria (codigo_categoria, categoria) VALUES
    ('C0006', 'Procesadores'),
    ('C0007', 'Tarjetas Gráficas'),
    ('C0008', 'Placas Base'),
    ('C0009', 'Memorias RAM'),
    ('C0010', 'Almacenamiento SSD');

-- ============================
-- 📦 Insertar Productos
-- ============================
INSERT INTO tb_producto (
    codigo_producto, producto, costo, ganancia, stock, producto_codigo_marca, producto_codigo_categoria
) VALUES
    ('P0001', 'Core i5-13600K', 250.00, 50.00, 15, 'M0006', 'C0006'),
    ('P0002', 'Ryzen 7 7700X', 300.00, 60.00, 10, 'M0007', 'C0006'),
    ('P0003', 'RTX 4070 Ti', 750.00, 150.00, 8, 'M0008', 'C0007'),
    ('P0004', 'Motherboard B650', 180.00, 40.00, 12, 'M0009', 'C0008'),
    ('P0005', 'RAM Vengeance 16GB', 60.00, 15.00, 20, 'M0010', 'C0009');

-- ============================
-- 🏢 Insertar Proveedores
-- ============================
INSERT INTO tb_proveedor (cod, razon_social, ruc, direccion) VALUES
    ('PR001', 'Distribuidora Lima Tech', '20123456789', 'Av. Primavera 101'),
    ('PR002', 'Global Hardware SAC', '20234567890', 'Av. Brasil 200'),
    ('PR003', 'ElectroPerú Components', '20345678901', 'Jr. Ayacucho 150');

-- ============================
-- 👤 Insertar Usuarios
-- ============================
INSERT INTO tb_usuario (cod, nombre_usuario, clave, correo) VALUES
    ('U001', 'joseperez', 'clave123', 'joseperez@mail.com'),
    ('U002', 'mariarodriguez', 'abc456', 'maria@mail.com'),
    ('U003', 'adansonsilva', 'adanson502', 'adansonsilva@mail.com');

-- ============================
-- 👥 Insertar Clientes
-- ============================
INSERT INTO tb_cliente (cod, nombre, apellido, dni) VALUES
    ('CL001', 'Ana', 'Gómez', '11223344'),
    ('CL002', 'Luis', 'Sánchez', '22334455'),
    ('CL003', 'Marta', 'Díaz', '33445566');

-- ============================
-- 📥 Insertar Compras
-- ============================
INSERT INTO tb_compra (cod, fecha, cod_proveedor, cod_usuario) VALUES
    ('CO001', '2025-10-01', 'PR001', 'U001'),
    ('CO002', '2025-10-02', 'PR002', 'U001');

-- ============================
-- 🧾 Insertar Detalle de Compras
-- ============================
INSERT INTO tb_detalle_compra (cod_compra, cod_prod, cantidad, precio) VALUES
    ('CO001', 'P0001', 5, 250.00),
    ('CO001', 'P0005', 10, 60.00),
    ('CO002', 'P0003', 4, 750.00),
    ('CO002', 'P0002', 2, 300.00);

-- ============================
-- 💵 Insertar Ventas
-- ============================
INSERT INTO tb_venta (cod, fecha, cod_cliente, cod_usuario, total) VALUES
    ('VE001', '2025-10-05', 'CL001', 'U002', 375.00),
    ('VE002', '2025-10-05', 'CL002', 'U003', 900.00);

-- ============================
-- 📋 Insertar Detalle de Ventas
-- ============================
INSERT INTO tb_detalle_venta (cod_venta, cod_prod, cantidad, precio_venta) VALUES
    ('VE001', 'P0001', 1, 300.00),
    ('VE001', 'P0005', 1, 75.00),
    ('VE002', 'P0003', 1, 900.00);
