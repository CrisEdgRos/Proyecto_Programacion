-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 13, 2023 at 12:42 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `clave3_grupo4db`
--
CREATE DATABASE IF NOT EXISTS `clave3_grupo4dbb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `clave3_grupo4dbb`;


CREATE TABLE `TB_TIPO_CLIENTE` (
  `ID_TP_PERSONA` int(11) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,
  `TIPO_PERSONA` varchar(15) unique NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  INDEX idx_id_tp_persona (ID_TP_PERSONA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;


INSERT INTO `TB_TIPO_CLIENTE` (`TIPO_PERSONA`,`ESTADO`) VALUES
('Fisica','A'),
('Juridica','A');


CREATE TABLE `TB_CLIENTE` (
  `ID_CLIENTE` int(11) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,
  `ID_TP_PERSONA` int(11) NOT NULL,
  `NOM_CLIENTE` varchar(100) NOT NULL,
  `APE_PATE_CLIENTE` varchar(50) NOT NULL,
  `APE_MATE_CLIENTE` varchar(50) NOT NULL,
  `DIRECCION_CLIENTE` varchar(50) NOT NULL,
  `TEL_CEL_CLIENTE` varchar(50) NOT NULL,
  `TEL_FIJO_CLIENTE` varchar(50) NOT NULL,
  `DUI` varchar(15) unique NOT NULL,
  `NOM_CARGO_CLIENTE` varchar(100) NOT NULL,
  `ID_USER` int(11), 
  `SUELDO` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_id_cliente (ID_CLIENTE),
  foreign key (ID_TP_PERSONA) references TB_TIPO_CLIENTE(ID_TP_PERSONA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;


INSERT INTO `TB_CLIENTE` (`ID_TP_PERSONA`, `NOM_CLIENTE`, `APE_PATE_CLIENTE`, `APE_MATE_CLIENTE`, `DIRECCION_CLIENTE`, `TEL_CEL_CLIENTE`, `TEL_FIJO_CLIENTE`, `DUI`, `NOM_CARGO_CLIENTE`, `ID_USER`, `SUELDO`, `ESTADO`) VALUES 
(1, 'DIANA NICOLE', 'MENJIVAR', 'MÉRINO', 'SAN SALVADOR', '7887-3490', '4478-4557', '0910693-9', 'LICENCIADA','6', 5000,'A'),
(2, 'VANESSA MIRANDA', 'PÉREZ', 'ZELAYA', 'SAN SALVADOR', '4532-3124', '9087-7654', '3422123-3', 'DOCTORA', '',   5000,'A'),
(1, 'JEPSI ALEXANDRA', 'MARTÍNEZ', 'SOSA',   'SAN SALVADOR', '9094-3554', '3345-9855', '4821234-2', 'EJECUTIVA', '',  6000,'A'),
(2, 'PAULINA JULISSA', 'RIVERA', 'HERRERA', 'SAN SALVADOR', '6765-2454', '8965-3245',  '45321D2-5', 'DESARROLLADORA WEB', '', 8000,'A'),
(2, 'VALERIA ALEJANDRA', 'VILLALTA', 'SIGUENZA', 'SAN SALVADOR', '9853-6545', '9986-5667', '0842124-1', 'LICENCIADA EN IDIOMAS', '', 9000,'A');

CREATE TABLE `TB_TIPO_CUENTA` (
  `ID_TIPO_CUENTA` int(11) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,
  `NOM_CUENTA` varchar(100) unique NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  INDEX idx_id_tipo_cuenta (ID_TIPO_CUENTA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_TIPO_CUENTA` (`NOM_CUENTA`,`ESTADO`) VALUES
('CORRIENTE','A'),
('AHORRO','A');


CREATE TABLE `TB_CUENTA` (
  `ID_CUENTA` int(11) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,
  `ID_TIPO_CUENTA` int(11) NOT NULL,
  `ID_CLIENTE` int(11) NOT NULL,  
  `CODIGO_CUENTA` varchar(20) unique NOT NULL,
  `SALDO_ACTUAL` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  INDEX idx_cuenta (ID_CUENTA),
  foreign key (ID_TIPO_CUENTA) references TB_TIPO_CUENTA(ID_TIPO_CUENTA),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

DELIMITER //

CREATE TRIGGER GenerarNumeroCuenta
BEFORE INSERT ON TB_CUENTA
FOR EACH ROW
BEGIN
    DECLARE v_NumeroCuenta VARCHAR(12);
    
    -- Generar un número de cuenta aleatorio
    SET v_NumeroCuenta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 10, '0'),'.',''),1,0,'1');
    
    -- Asegurarse de que el número de cuenta sea único
    WHILE EXISTS (SELECT 1 FROM TB_CUENTA WHERE CODIGO_CUENTA = v_NumeroCuenta) DO
        SET v_NumeroCuenta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 10, '0'),'.',''),1,0,'1');
    END WHILE;

    -- Asignar el número de cuenta generado a la nueva fila
    SET NEW.CODIGO_CUENTA = v_NumeroCuenta;
END //

DELIMITER ;

INSERT INTO `TB_CUENTA` (`ID_TIPO_CUENTA`, `ID_CLIENTE`, `SALDO_ACTUAL`,`ESTADO`) VALUES
(1, 1, 8000, 'A'),
(2, 2, 4000, 'A'),
(1, 3, 5000, 'A'),
(2, 4, 6000, 'A'),
(2, 5, 9000, 'A');

CREATE TABLE `TB_TIPO_TARJETA_CREDITO` (
  `ID_TP_TARJETA` int(11) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,
  `NOM_TARJETA` varchar(50) unique NOT NULL,
  `LIMITE` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  INDEX idx_id_tp_tarjeta(ID_TP_TARJETA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_TIPO_TARJETA_CREDITO` (`NOM_TARJETA`, `LIMITE`,`ESTADO`) VALUES
('CLASICA', 2000, 'A'),
('DORADA', 4000, 'A'),
('PLATINUM', 7000, 'A');

CREATE TABLE `TB_TARJETA_CREDITO` (
  `ID_TARJETA_CREDITO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_CLIENTE` int(11) NOT NULL,  
  `ID_TP_TARJETA` int(11) NOT NULL,
  `CODIGO_TARJETA` varchar(20) unique NOT NULL,
  `FECHA_VENCIMIENTO` date NOT NULL,
  `CVV` int(3) NOT NULL, 
  `SALDO_DISPONIBLE` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_id_tarjeta_credito (ID_TARJETA_CREDITO),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_TP_TARJETA) references TB_TIPO_TARJETA_CREDITO(ID_TP_TARJETA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

DELIMITER //

CREATE TRIGGER GenerarNumeroTarjetaCredito
BEFORE INSERT ON TB_TARJETA_CREDITO
FOR EACH ROW
BEGIN
    DECLARE v_NumeroTarjeta CHAR(16);
    
    -- Generar un número aleatorio de 16 dígitos
    SET v_NumeroTarjeta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 15, '0'),'.',''),1,0,'4');

    -- Asegurarse de que el número de tarjeta sea único
    WHILE EXISTS (SELECT 1 FROM TB_TARJETA_CREDITO WHERE CODIGO_TARJETA = v_NumeroTarjeta) DO
        SET v_NumeroTarjeta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 15, '0'),'.',''),1,0,'4');
    END WHILE;

    -- Asignar el número de tarjeta generado a la nueva fila
    SET NEW.CODIGO_TARJETA = v_NumeroTarjeta;
END //

DELIMITER ;

INSERT INTO `TB_TARJETA_CREDITO` (`ID_CLIENTE`, `ID_TP_TARJETA`, `FECHA_VENCIMIENTO`, `CVV`, `SALDO_DISPONIBLE`, `ESTADO`) VALUES
(1, 1, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 2000, 'A'),
(2, 1, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 2000, 'A'),
(3, 2, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 4000, 'A'),
(4, 2, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 4000, 'A'),
(5, 3, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 7000, 'A');

CREATE TABLE `TB_TARJETA_DEBITO` (
  `ID_TARJETA_DEBITO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_CLIENTE` int(11) NOT NULL, 
  `ID_CUENTA` int(11) NOT NULL, 
  `CODIGO_TARJETA` varchar(20) unique NOT NULL,
  `FECHA_VENCIMIENTO` date NOT NULL,
  `CVV` int(3) NOT NULL, 
  `ESTADO` varchar(1) NOT NULL,
  index idx_id_tarjeta_debito (ID_TARJETA_DEBITO),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_CUENTA) references TB_CUENTA(ID_CUENTA)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

DELIMITER //

CREATE TRIGGER GenerarNumeroTarjetaDebito
BEFORE INSERT ON TB_TARJETA_DEBITO
FOR EACH ROW
BEGIN
    DECLARE v_NumeroTarjeta CHAR(16);
    
    -- Generar un número aleatorio de 16 dígitos
    SET v_NumeroTarjeta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 15, '0'),'.',''),1,0,'5');

    -- Asegurarse de que el número de tarjeta sea único
    WHILE EXISTS (SELECT 1 FROM TB_TARJETA_DEBITO WHERE CODIGO_TARJETA = v_NumeroTarjeta) DO
        SET v_NumeroTarjeta = INSERT(REPLACE(LPAD(FLOOR(RAND() * 10000000000000000), 15, '0'),'.',''),1,0,'5');
    END WHILE;

    -- Asignar el número de tarjeta generado a la nueva fila
    SET NEW.CODIGO_TARJETA = v_NumeroTarjeta;
END //

DELIMITER ;
INSERT INTO `TB_TARJETA_DEBITO` (`ID_CLIENTE`, `ID_CUENTA`, `FECHA_VENCIMIENTO`, `CVV`, `ESTADO`) VALUES
(1, 1, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 'A'),
(2, 2, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 'A'),
(3, 3, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 'A'),
(4, 4, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 'A'),
(5, 5, DATE_ADD(CURDATE(), INTERVAL 3 YEAR), FLOOR(RAND() * 1000), 'A');

CREATE TABLE `TB_TIPO_PRESTAMO` (
  `ID_TP_PRESTAMO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `NOM_PRESTAMO` varchar(100) unique NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_tp_prestamo (ID_TP_PRESTAMO)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_TIPO_PRESTAMO` (`NOM_PRESTAMO`, `ESTADO`) VALUES
('PERSONAL','A'),
('AGROPECUARIO','A'),
('HIPOTECARIO','A');

CREATE TABLE `TB_TIPO_PAGO` (
  `ID_TP_PAGO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `TIPO_COBRO` varchar(100) unique NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TP_PAGO (ID_TP_PAGO)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_TIPO_PAGO` (`TIPO_COBRO`, `ESTADO`) VALUES
('CONTADO','A'),
('CREDITO','A');

CREATE TABLE `TB_PRESTAMO` (
  `ID_PRESTAMO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_CLIENTE` int(11) NOT NULL, 
  `ID_CUENTA` int(11) NOT NULL, 
  `ID_TARJETA_CREDITO` int(11) NOT NULL, 
  `ID_TP_PRESTAMO` int(11) NOT NULL,   
  `ID_TP_PAGO` int(11) NOT NULL, 
  `MONTO_PRESTADO` double NOT NULL,
  `MTCN_PRESTAMO` int(25) NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_PRESTAMO (ID_PRESTAMO),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_CUENTA) references TB_CUENTA(ID_CUENTA),
  foreign key (ID_TP_PRESTAMO) references TB_TIPO_PRESTAMO(ID_TP_PRESTAMO),
  foreign key (ID_TP_PAGO) references TB_TIPO_PAGO(ID_TP_PAGO)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_PRESTAMO` (`ID_CLIENTE`, `ID_CUENTA`, `ID_TARJETA_CREDITO`, `ID_TP_PRESTAMO`, `ID_TP_PAGO`, `MONTO_PRESTADO`,`ESTADO`) VALUES
(1, 1, 1, 1, 1, 240.00,'A'),
(2, 2, 2, 1, 1, 720.00,'A'),
(3, 3, 3, 2, 1, 430.00,'A'),
(4, 4, 4, 1, 1, 150.00,'A'),
(5, 5, 5, 2, 1, 380.00,'A');

CREATE TABLE `TB_SUCURSAL` (
  `ID_SUCURSAL` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `NOMBRE_SUCURSAL` varchar(50) unique NOT NULL,
  `DIRECCION` varchar(100) NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_SUCURSAL (ID_SUCURSAL)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_SUCURSAL` (`NOMBRE_SUCURSAL`, `DIRECCION`, `ESTADO`) VALUES
('AGENCIA SAN BENITO','San Salvador, San Bénito','A'),
('AGENCIA SANTA ELENA','San Salvador, Santa Elena','A'),
('AGENCIA CUSCATLAN','San Salvador, Antiguo Cuscatlan','A'),
('AGENCIA MERLIOT','San Salvador, Ciudad Merliot','A'),
('AGENCIA ZONA ROSA','San Salvador, Zona Rosa','A');

CREATE TABLE `TB_CARGO_EMPLEADO` (
  `ID_CARGO_EM` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `NOM_CARGO` varchar(100) unique NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_CARGO_EMPLEADO (ID_CARGO_EM)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_CARGO_EMPLEADO` (`NOM_CARGO`, `ESTADO`) VALUES
('Ingeniero de Datos','A'),
('Desarrollador Jatb_usuariova Full Stack','A'),
('Ingeniero en Sistemas','A'),
('Ingeniero de Redes','A'),
('Desarrollador Trainee','A');

CREATE TABLE `TB_USUARIO` (
  `ID_USER` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `USUARIO` varchar(15) unique NOT NULL,
  `CONTRASEÑA` blob NOT NULL,
  `ADMIN` varchar(1) NOT NULL,
  `PRESTAMOS` varchar(1) NOT NULL,
  `CUENTAS` varchar(1) NOT NULL,
  `TARJETAS` varchar(1) NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_USUARIO_EM (ID_USER)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_USUARIO` (`USUARIO`, `CONTRASEÑA`, `ADMIN`, `PRESTAMOS`, `CUENTAS`, `TARJETAS`, `ESTADO`) VALUES
('cmartinez' , aes_encrypt('cmartinez','123'),  1, 0, 0, 0,'A'),
('hmerino'  , aes_encrypt('hmerino','123'), 0, 0, 1, 0,'A'),
('vmartinez', aes_encrypt('vmartinez','123'), 0, 1, 0, 0,'A'),
('mayala'   , aes_encrypt('mayala','123'), 0, 0, 0, 1,'A'),
('mestrada' , aes_encrypt('mestrada','123'), 0, 0, 0, 0,'A');

CREATE TABLE `TB_EMPLEADO` (
  `ID_EM` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_SUCURSAL` int(11) NOT NULL, 
  `ID_CARGO_EM` int(11) NOT NULL, 
  `ID_USER` int(11) NOT NULL, 
  `NOM_EMPLEADO` varchar(50) NOT NULL,
  `APE_PATE` varchar(25) NOT NULL,
  `APE_MATE` varchar(25) NOT NULL,
  `FECHA_NAC` date NOT NULL, 
  `DIRECCION` varchar(100) NOT NULL,
  `DUI_EMP` varchar(12) unique NOT NULL,
  `SUELDO` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_EMPLEADO (ID_EM),
  foreign key (ID_SUCURSAL) references TB_SUCURSAL(ID_SUCURSAL),
  foreign key (ID_CARGO_EM) references TB_CARGO_EMPLEADO(ID_CARGO_EM),
  foreign key (ID_USER) references TB_USUARIO(ID_USER)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;


INSERT INTO `TB_EMPLEADO` (`ID_SUCURSAL`, `ID_CARGO_EM`, `ID_USER`, `NOM_EMPLEADO`, `APE_PATE`, `APE_MATE`, `FECHA_NAC`, `DIRECCION`, `DUI_EMP`, `SUELDO`, `ESTADO`) VALUES
(1, 1, 1, 'César Ovidio',  'Martínez', 'Chicas', '10-11-2003', 'San Salvador', '06072354-9', 5000, 'A'),
(2, 2, 2, 'Héctor Manuel', 'Menjivar', 'Mérino', '31-10-2002', 'San Salvador', '03452212-8', 4000, 'A'),
(3, 3, 3, 'Víctor Manuel', 'Martínez', 'Garcia', '31-12-1999', 'San Salvador', '02063245-7', 3000, 'A'),
(4, 4, 4, 'Miguel Ángel',  'Ayala',    'Leiva',  '01-01-2002', 'San Salvador', '03013209-6', 2000, 'A'),
(5, 5, 5, 'Melvin Steven', 'Estrada',  'Rivas',  '08-08-2003', 'San Salvador', '04521034-5', 1000, 'A');

CREATE TABLE `TB_MOVIMIENTO_ABONO` (
  `ID_MV_ABONO` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_CUENTA` int(11) NOT NULL, 
  `ID_PRESTAMO` int(11) NOT NULL, 
  `ID_CLIENTE` int(11) NOT NULL, 
  `ID_EM` int(11) NOT NULL,
  `ID_SUCURSAL` int(11) NOT NULL,
  `MTCN_MV_ABONO` int(11) NOT NULL,
  `MONTO_SALIDA` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_MOVIMIENTO_ABONO (ID_MV_ABONO),
  foreign key (ID_PRESTAMO) references TB_PRESTAMO(ID_PRESTAMO),
  foreign key (ID_SUCURSAL) references TB_SUCURSAL(ID_SUCURSAL),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_CUENTA) references TB_CUENTA(ID_CUENTA),
  foreign key (ID_EM) references TB_EMPLEADO(ID_EM)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_MOVIMIENTO_ABONO`(`ID_CUENTA`, `ID_PRESTAMO`, `ID_CLIENTE`, `ID_EM`, `ID_SUCURSAL`, `MONTO_SALIDA`, `ESTADO`) VALUES
(1, 1, 1, 1, 1, 40, 'A');


CREATE TABLE `TB_MOVIMIENTO_TARJETA` (
  `ID_MV_TARJETA` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,  
  `ID_TARJETA_CREDITO` int(11) NOT NULL, 
  `ID_SUCURSAL` int(11) NOT NULL, 
  `ID_CLIENTE` int(11) NOT NULL, 
  `ID_EM` int(11) NOT NULL,
  `MTCN_MV_TARJETA` int(11) NOT NULL,
  `MONTO_SALIDA` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_MOVIMIENTO_TARJETA (ID_MV_TARJETA),
  foreign key (ID_TARJETA_CREDITO) references TB_TARJETA_CREDITO(ID_TARJETA_CREDITO),
  foreign key (ID_SUCURSAL) references TB_SUCURSAL(ID_SUCURSAL),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_EM) references TB_EMPLEADO(ID_EM)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_MOVIMIENTO_TARJETA`(`ID_TARJETA_CREDITO`, `ID_SUCURSAL`, `ID_CLIENTE`, `ID_EM`, `MONTO_SALIDA`, `ESTADO`) VALUES
(1, 1, 1, 1, 40, 'A');

CREATE TABLE `TB_MOVIMIENTO_CUENTA` (
  `ID_MV_CUENTA` int(25) auto_increment primary key,
  `FECHA_REGISTRO` datetime default now() NOT NULL,    
  `ID_CUENTA` int(11) NOT NULL, 
  `ID_CLIENTE` int(11) NOT NULL, 
  `ID_EM` int(11) NOT NULL,
  `ID_SUCURSAL` int(11) NOT NULL,   
  `MTCN_MV_CUENTA` int(11) NOT NULL,
  `MONTO_ENTRADA` double NOT NULL,
  `MONTO_SALIDA` double NOT NULL,
  `ESTADO` varchar(1) NOT NULL,
  index idx_TB_MOVIMIENTO_CUENTA (ID_MV_CUENTA),
  foreign key (ID_CUENTA) references TB_CUENTA(ID_CUENTA),
  foreign key (ID_SUCURSAL) references TB_SUCURSAL(ID_SUCURSAL),
  foreign key (ID_CLIENTE) references TB_CLIENTE(ID_CLIENTE),
  foreign key (ID_EM) references TB_EMPLEADO(ID_EM)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

INSERT INTO `TB_MOVIMIENTO_CUENTA`(`ID_CUENTA`, `ID_SUCURSAL`, `ID_CLIENTE`, `ID_EM`, `MONTO_ENTRADA`, `MONTO_SALIDA`, `ESTADO`) VALUES
(1, 1, 1, 1, 300, 0,'A');

-- --------------------------------------------------------
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
