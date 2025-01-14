-- @ 2023 César Martínez. All Copyright.
-- CREADOR DEL CÓDIGO SQL -> CÉSAR OVIDIO MARTÍNEZ CHICAS.

CREATE DATABASE SISTEMA_BANCARIO
ON PRIMARY
(NAME='SISTEMA_BANCARIO', FILENAME='D:\Sistema de Banca en C# y SQL Server\SCRIPT DATABASE\SISTEMA_BANCARIO.mdf',
SIZE =8Mb, FILEGROWTH=20%
),
FILEGROUP DATA DEFAULT
(NAME='SISTEMA_BANCARIO_Data', FILENAME='D:\Sistema de Banca en C# y SQL Server\SCRIPT DATABASE\SISTEMA_BANCARIO_Data.ndf',
SIZE =8Mb, FILEGROWTH=20%
)
LOG ON
(NAME='SISTEMA_BANCARIO_Log', FILENAME='D:\Sistema de Banca en C# y SQL Server\SCRIPT DATABASE\SISTEMA_BANCARIO_Log.ldf',
SIZE =8Mb, FILEGROWTH=20%
)
GO --SCRIPT DE CÉSAR MARTÍNEZ | CREACIÓN DE UNA BASE DE DATOS CON BUENAS PRÁCTICAS HACIENDO USO DE FILEGROUPS

USE SISTEMA_BANCARIO
GO

--------------------------------------------------------------------------------------------------------------------
-- TABLAS 
--------------------------------------------------------------------------------------------------------------------




CREATE TABLE TB_USUARIO_EM(
   ID_USER              INT IDENTITY(1,1),
   FECHA_REGISTRO       DATETIME2 DEFAULT GETDATE(),
   USUARIO              VARCHAR(15) NOT NULL,
   CONTRASEÑA           VARCHAR(10) NOT NULL,
   ADMIN                BIT NOT NULL,
   PRESTAMOS            BIT NOT NULL,
   CUENTAS              BIT NOT NULL,
   TARJETAS             BIT NOT NULL,
   ESTADO               BIT DEFAULT 1,

   CONSTRAINT PK_USER PRIMARY KEY (ID_USER),
   CONSTRAINT UQ_USUARIO UNIQUE (USUARIO)
)
GO
CREATE NONCLUSTERED INDEX IX_USUARIO_EM
ON USUARIO_EM (ID_USER)
WHERE ID_USER >= 1;
GO

CREATE TABLE TB_EMPLEADO(
   ID_EM            INT IDENTITY(1,1),
   FECHA_REGISTRO   DATETIME2 DEFAULT GETDATE(),

   ID_SUCURSAL      INT NOT NULL,
   ID_CARGO_EM      INT NOT NULL,
   ID_USER          INT NOT NULL,

   NOM_EMPLEADO     VARCHAR(20)   NOT NULL,
   APE_PATE         VARCHAR(12)   NOT NULL,
   APE_MATE         VARCHAR(12)   NOT NULL,
   DIRECCION        VARCHAR(25)   NOT NULL,
   DNI_EM           VARCHAR(10)   NOT NULL,
   SUELDO           DECIMAL(18,2) NOT NULL,
   ESTADO           BIT DEFAULT 1,

   CONSTRAINT PK_EM PRIMARY KEY (ID_EM),
   CONSTRAINT FK_EM_CARGO FOREIGN KEY (ID_CARGO_EM) REFERENCES CARGO_EMPLEADO (ID_CARGO_EM),
   CONSTRAINT FK_EM_USER FOREIGN KEY (ID_USER)      REFERENCES USUARIO_EM (ID_USER),
   CONSTRAINT FK_EM_SUCURSAL FOREIGN KEY (ID_SUCURSAL) REFERENCES SUCURSAL (ID_SUCURSAL),
   CONSTRAINT UQ_EMLEADO UNIQUE (NOM_EMPLEADO, APE_PATE, APE_MATE, DNI_EM)
)
GO
CREATE NONCLUSTERED INDEX IX_EMPELADO
ON EMPLEADO (ID_EM)
WHERE ID_EM >= 1;
GO


CREATE TABLE TB_MOVIMIENTO_ABONO(
   ID_MV_ABONO         INT IDENTITY(1,1),
   FECHA_REGISTRO      DATETIME2 DEFAULT GETDATE(),
   ID_CUENTA           INT NOT NULL,
   ID_PRESTAMO         INT NOT NULL,
   ID_CLIENTE          INT NOT NULL,
   ID_EM               INT NOT NULL,
   ID_SUCURSAL         INT NOT NULL,
   MTCN_MV_ABONO       UNIQUEIDENTIFIER DEFAULT NEWID(),
   MONTO_SALIDA        DECIMAL(18,2) DEFAULT 0.00,
   ESTADO              BIT DEFAULT 1,

   CONSTRAINT PK_MV_ABONO PRIMARY KEY (ID_MV_ABONO),
   CONSTRAINT FK_MV_ABONO_PRESTAMO FOREIGN KEY (ID_PRESTAMO) REFERENCES PRESTAMO (ID_PRESTAMO),
   CONSTRAINT FK_MV_ABONO_SUCURSAL FOREIGN KEY (ID_SUCURSAL) REFERENCES SUCURSAL (ID_SUCURSAL),
   CONSTRAINT FK_MV_ABONO_CLIEN FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTE (ID_CLIENTE),
   CONSTRAINT FK_MV_ABONO_CUENTA FOREIGN KEY (ID_CUENTA) REFERENCES CUENTA (ID_CUENTA),
   CONSTRAINT FK_MV_ABONO_EM FOREIGN KEY (ID_EM) REFERENCES EMPLEADO (ID_EM)
)
GO 
CREATE NONCLUSTERED INDEX IX_MV_ABONO
ON MOVIMIENTO_ABONO (ID_MV_ABONO)
WHERE ID_MV_ABONO >= 1
GO

CREATE TABLE TB_MOVIMIENTO_TARJETA(
   ID_MV_TARJETA       INT IDENTITY(1,1),
   FECHA_REGISTRO      DATETIME2 DEFAULT GETDATE(),
   ID_TARJETA_CREDITO  INT NOT NULL,
   ID_SUCURSAL         INT NOT NULL,
   ID_CLIENTE          INT NOT NULL,
   ID_EM               INT NOT NULL,
   MTCN_MV_TARJETA     UNIQUEIDENTIFIER DEFAULT NEWID(),
   MONTO_SALIDA        DECIMAL(18,2) DEFAULT 0.00,
   ESTADO              BIT DEFAULT 1,

   CONSTRAINT PK_MV_TARJETA PRIMARY KEY (ID_MV_TARJETA),
   CONSTRAINT FK_MvTarjeta_TARJETA FOREIGN KEY (ID_TARJETA_CREDITO) REFERENCES TARJETA_CREDITO (ID_TARJETA_CREDITO),
   CONSTRAINT FK_MvTarjeta_SUCURSAL FOREIGN KEY (ID_SUCURSAL) REFERENCES SUCURSAL (ID_SUCURSAL),
   CONSTRAINT FK_MvTarjeta_CLIEN FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTE (ID_CLIENTE),
   CONSTRAINT FK_MvTarjeta_EM FOREIGN KEY (ID_EM) REFERENCES EMPLEADO (ID_EM)
)
GO 
CREATE NONCLUSTERED INDEX IX_MV_TARJETA
ON MOVIMIENTO_TARJETA (ID_MV_TARJETA)
WHERE ID_MV_TARJETA >= 1
GO

CREATE TABLE TB_MOVIMIENTO_CUENTA(
   ID_MV_CUENTA        INT IDENTITY(1,1),
   FECHA_REGISTRO      DATETIME2 DEFAULT GETDATE(),
   ID_CUENTA           INT NOT NULL,
   ID_CLIENTE          INT NOT NULL,
   ID_EM               INT NOT NULL,
   ID_SUCURSAL         INT NOT NULL,
   MTCN_MV_CUENTA      UNIQUEIDENTIFIER DEFAULT NEWID(),
   MONTO_ENTRADA       DECIMAL(18,2) DEFAULT 0.00,
   MONTO_SALIDA        DECIMAL(18,2) DEFAULT 0.00,
   ESTADO              BIT DEFAULT 1,

   CONSTRAINT PK_MV_CUENTA PRIMARY KEY (ID_MV_CUENTA),
   CONSTRAINT FK_MvCuenta_CUENTA FOREIGN KEY (ID_CUENTA)     REFERENCES CUENTA   (ID_CUENTA),
   CONSTRAINT FK_MvCuenta_SUCURSAL FOREIGN KEY (ID_SUCURSAL) REFERENCES SUCURSAL (ID_SUCURSAL),
   CONSTRAINT FK_MvCuenta_CLIEN FOREIGN KEY (ID_CLIENTE)     REFERENCES CLIENTE  (ID_CLIENTE),
   CONSTRAINT FK_MvCuenta_EM FOREIGN KEY (ID_EM) REFERENCES EMPLEADO (ID_EM)
)
GO 
CREATE NONCLUSTERED INDEX IX_MV_CUENTA
ON MOVIMIENTO_CUENTA (ID_MV_CUENTA)
WHERE ID_MV_CUENTA >= 1
GO
