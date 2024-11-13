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
CREATE DATABASE IF NOT EXISTS `clave3_grupo4db` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `clave3_grupo4db`;

-- --------------------------------------------------------

--
-- Table structure for table `cargos`
--

CREATE TABLE `cargos` (
  `Id` int(11) NOT NULL,
  `nombre` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `cargos`
--

INSERT INTO `cargos` (`Id`, `nombre`) VALUES
(1, 'VENTAS Y MERCADOTECNIA - VENDEDOR JR\r\n'),
(2, 'VENTAS Y MERCADOTECNIA - VENDEDOR SR'),
(3, 'RECURSOS HUMANOS - JEFE DE NÓMINAS'),
(4, 'RECURSOS HUMANOS - RECLUTADOR'),
(5, 'ADMINISTRACIÓN - CAJERO'),
(6, 'ADMINISTRACIÓN - COBRADOR\r\n'),
(7, 'ADMINISTRACIÓN - GERENTE GENERAL'),
(8, 'ADMINISTRACIÓN - CONTADOR'),
(9, 'ADMINISTRACIÓN - RECEPCIONISTA\r\n'),
(10, 'ADMINISTRACIÓN - MENSAJERO\r\n');

-- --------------------------------------------------------

--
-- Table structure for table `clientes`
--

CREATE TABLE `clientes` (
  `id` int(11) NOT NULL,
  `dui` varchar(50) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `correo` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `clientes`
--

INSERT INTO `clientes` (`id`, `dui`, `nombre`, `direccion`, `telefono`, `correo`) VALUES
(1, '017125896', 'Luis Carlos Carmona', 'Calle falsa 123', '74586912', 'luis@hotmail.com'),
(2, '017135689', 'Maria Isabel Romo', 'Calle 100 # 45-09', '75489621', 'mariaisa@yahoo.es'),
(3, '017127845', 'Juan Ramon Lopez', 'Bedoya Ramirez', '74125369', 'juanbedoya@gmail.com'),
(4, '017685377', 'Ivan Estrada Latorre', 'Cuscatancingo ', '74784182', 'alcala_2005_nf@witty.com'),
(5, '017678766', 'Hortensia Ortiz Rosales', 'Nejapa', '79882057', 'ruano_w5@hotmail.co.uk'),
(6, '017220388', 'Maria Paz Roman Duque', 'San Salvador', '76497496', 'aguado_2010_tw@lycos.co.uk'),
(7, '017661179', 'Luciano Cuadrado Juan', 'Ciudad Delgado', '71882523', 'zamora_1996_0@netscape.com'),
(8, '017304306', 'Santos Barbero Garcia', 'San Antonio', '79918864', 'alfaro_ix@libero.it'),
(9, '017865686', 'Leonardo Mateu Del Valle', 'Santa Tecla', '78228516', 'murillo_ek@libero.it'),
(10, '017628007', 'Carles Moran Villegas', 'Usulutan', '76909381', 'esteban_1982_p@email.com');

-- --------------------------------------------------------

--
-- Table structure for table `empleados`
--

CREATE TABLE `empleados` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Direccion` varchar(150) NOT NULL,
  `Telefono` varchar(20) NOT NULL,
  `FechaIngreso` datetime NOT NULL,
  `Cargo` int(11) NOT NULL,
  `correo` varchar(30) NOT NULL,
  `Salario` double NOT NULL,
  `dui` varchar(30) NOT NULL,
  `CuentaBanco` int(11) NOT NULL,
  `CodEmpleado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `empleados`
--

INSERT INTO `empleados` (`Id`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `FechaIngreso`, `Cargo`, `correo`, `Salario`, `dui`, `CuentaBanco`, `CodEmpleado`) VALUES
(1, 'Omar', 'Salmeron', 'Final calle', '78451292', '2023-11-02 00:00:00', 1, 'prueba2@gmail.com', 650, '017123540', 12457869, 'EV000002'),
(2, 'Sigfredo Omar', 'Salmeron Renderos', 'Colonia Santa Margarita, Cuscatancingo', '25288453', '2023-11-09 00:00:00', 3, 'SR01044@ues.edu.sv', 450, '013610335', 3456, 'EMPSig01361'),
(3, 'Geremy Stanley', 'Dias Miranda', 'Final Calle Principal Mejicanos', '23456543', '2023-11-09 00:00:00', 1, 'DM02034@ues.edu.sv', 450, '10333645', 234556, 'EMPGer10333'),
(4, 'John Franklin', 'Lemus Deras', 'Pasaje 3 Casa 7, Apopa', '43232345', '2023-11-09 00:00:00', 2, 'LD03455@ues.edu.sv', 450, '203456104', 234523456, 'EMPJoh20345'),
(5, 'Jose Alberto', 'Martinez Campos', 'Final Calle principal casa 6, San Marcos', '23456543', '2023-11-09 00:00:00', 4, 'MC01055@ues.edu.sv', 450, '03045567', 23456543, 'EMPJos03045'),
(6, 'Beatriz', 'Ramirez Arevalo', 'Pasaje 5, casa 83, San salvador', '23452323', '2023-11-09 00:00:00', 1, 'RA0234@ues.edu.sv', 450, '034523454', 34564567, 'EMPBea03452'),
(7, 'Gabriel Omar', 'Ramirez', 'Calle Principal, casa 67, Apopa', '23243434', '2023-11-09 00:00:00', 5, 'RG03045', 450, '014520335', 34566543, 'EMPGab01452'),
(8, 'Jose Alejandro', 'Martinez', 'Pasaje 10, Casa 10, San Salvador', '23255664', '2023-11-09 00:00:00', 10, 'MJ02345@ues.edu.sv', 450, '022334556', 45904567, 'EMPJos02233'),
(9, 'Juan', 'Hernandez', 'Colonia Santa Clara, San Salvador', '23235443', '2023-11-09 00:00:00', 1, 'HA01056@ues.edu.sv', 450, '012332445', 23455432, 'EMPJua01233'),
(10, 'Daniela', 'Arevalo Ramirez', 'Calle San Jose, Pasaje 4, Cuscatancingo', '23245432', '2023-11-09 00:00:00', 1, 'AR22034@ues.edu.sv', 450, '098756455', 678976543, 'EMPDan09875'),
(11, 'Oscar Armando', 'Ramirez', 'Pasaje Carlos, casa 67, Ciudad Delgado', '23267654', '2023-11-09 00:00:00', 2, 'RO23034@ues.edu.sv', 450, '012334564', 34566543, 'EMPOsc01233');

-- --------------------------------------------------------

--
-- Table structure for table `facturas`
--

CREATE TABLE `facturas` (
  `id` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `cliente_id` int(11) NOT NULL,
  `valor_total` double NOT NULL,
  `codempleado` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `facturas`
--

INSERT INTO `facturas` (`id`, `fecha`, `cliente_id`, `valor_total`, `codempleado`) VALUES
(1, '2023-11-05', 8, 4958, 'EV000001'),
(2, '2023-10-10', 1, 5023.98, 'EMPSig01361'),
(3, '2023-10-10', 2, 1348.4, 'EMPGer10333'),
(4, '2023-10-05', 3, 3163.32, 'EMPJoh20345'),
(5, '2023-10-05', 5, 2883.75, 'EMPJos03045'),
(6, '2023-10-05', 6, 3263.05, 'EMPBea03452'),
(7, '2023-10-05', 6, 4243, 'EMPJos02233'),
(8, '2023-10-05', 8, 4838.05, 'EMPJos02233'),
(9, '2023-10-05', 9, 4218.5, 'EMPDan09875'),
(10, '2023-10-05', 9, 3971.45, 'EMPDan09875'),
(11, '2023-10-05', 4, 1235.4, 'EMPSig01361'),
(12, '2023-11-09', 3, 4751.16, 'EMPSig01361'),
(13, '2023-11-09', 5, 3857.98, 'EMPBea03452'),
(14, '2023-11-09', 7, 3195.2, 'EMPJos02233'),
(15, '2023-11-09', 10, 2339.75, 'EMPGab01452'),
(16, '2023-11-09', 6, 5784.48, 'EMPJos02233');

-- --------------------------------------------------------

--
-- Table structure for table `factura_detalle`
--

CREATE TABLE `factura_detalle` (
  `id` int(11) NOT NULL,
  `factura_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `valor_unitario` double DEFAULT NULL,
  `total_producto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `factura_detalle`
--

INSERT INTO `factura_detalle` (`id`, `factura_id`, `producto_id`, `cantidad`, `valor_unitario`, `total_producto`) VALUES
(1, 1, 3, 200, 21, 4294),
(2, 1, 6, 50, 13, 664),
(3, 2, 3, 234, 21, 5024),
(4, 3, 1, 20, 21, 429),
(5, 3, 2, 20, 18, 354),
(6, 3, 4, 20, 11, 226),
(7, 3, 5, 20, 17, 339),
(8, 4, 4, 29, 11, 328),
(9, 4, 5, 29, 17, 492),
(10, 4, 8, 29, 2, 61),
(11, 4, 9, 29, 79, 2283),
(12, 5, 7, 25, 6, 141),
(13, 5, 9, 25, 79, 1968),
(14, 5, 2, 25, 18, 442),
(15, 5, 6, 25, 13, 332),
(16, 6, 5, 35, 17, 593),
(17, 6, 8, 35, 2, 74),
(18, 6, 11, 35, 35, 1225),
(19, 6, 2, 35, 18, 620),
(20, 6, 1, 35, 21, 751),
(21, 7, 1, 25, 21, 537),
(22, 7, 2, 25, 18, 442),
(23, 7, 3, 25, 21, 537),
(24, 7, 4, 25, 11, 282),
(25, 7, 5, 25, 17, 424),
(26, 7, 8, 25, 2, 53),
(27, 7, 9, 25, 79, 1968),
(28, 8, 2, 35, 18, 620),
(29, 8, 3, 35, 21, 751),
(30, 8, 5, 35, 17, 593),
(31, 8, 8, 35, 2, 74),
(32, 8, 10, 35, 45, 1575),
(33, 8, 11, 35, 35, 1225),
(34, 9, 7, 50, 6, 282),
(35, 9, 9, 50, 79, 3936),
(36, 10, 1, 35, 21, 751),
(37, 10, 6, 35, 13, 465),
(38, 10, 9, 35, 79, 2755),
(39, 11, 1, 10, 21, 215),
(40, 11, 2, 10, 18, 177),
(41, 11, 7, 10, 6, 56),
(42, 11, 9, 10, 79, 787),
(43, 12, 1, 34, 21, 730),
(44, 12, 5, 34, 17, 576),
(45, 12, 7, 34, 6, 192),
(46, 12, 5, 34, 17, 576),
(47, 12, 9, 34, 79, 2676),
(48, 13, 1, 34, 21, 730),
(49, 13, 6, 34, 13, 452),
(50, 13, 9, 34, 79, 2676),
(51, 14, 1, 40, 21, 859),
(52, 14, 4, 40, 11, 452),
(53, 14, 8, 40, 2, 84),
(54, 14, 10, 40, 45, 1800),
(55, 15, 1, 25, 21, 537),
(56, 15, 3, 25, 21, 537),
(57, 15, 7, 25, 6, 141),
(58, 15, 10, 25, 45, 1125),
(59, 16, 3, 54, 21, 1159),
(60, 16, 7, 54, 6, 305),
(61, 16, 10, 54, 45, 2430),
(62, 16, 11, 54, 35, 1890);

-- --------------------------------------------------------

--
-- Table structure for table `mes`
--

CREATE TABLE `mes` (
  `id` int(11) NOT NULL,
  `mes` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `mes`
--

INSERT INTO `mes` (`id`, `mes`) VALUES
(1, 'ENERO'),
(2, 'FEBRERO'),
(3, 'MARZO'),
(4, 'ABRIL'),
(5, 'MAYO'),
(6, 'JUNIO'),
(7, 'JULIO'),
(8, 'AGOSTO'),
(9, 'SEPTIEMBRE'),
(10, 'OCTUBRE'),
(11, 'NOVIEMBRE'),
(12, 'DICIEMBRE');

-- --------------------------------------------------------

--
-- Table structure for table `nominas`
--

CREATE TABLE `nominas` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `apellido` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `cargo` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `sueldobase` double NOT NULL,
  `horasext` int(11) NOT NULL,
  `VentaMes` double NOT NULL,
  `PagoHorasExt` double NOT NULL,
  `BonoVentas` double NOT NULL,
  `renta` double NOT NULL,
  `isss` double NOT NULL,
  `afp` double NOT NULL,
  `sueldoneto` double NOT NULL,
  `mes` int(11) NOT NULL,
  `periodo` int(11) NOT NULL,
  `codempleado` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `productos`
--

CREATE TABLE `productos` (
  `id` int(11) NOT NULL,
  `codigo` varchar(100) NOT NULL,
  `descripcion` varchar(60) NOT NULL,
  `valor` double NOT NULL,
  `cantidad_inicial` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `productos`
--

INSERT INTO `productos` (`id`, `codigo`, `descripcion`, `valor`, `cantidad_inicial`) VALUES
(1, 'PD00001', 'Caja para empaque de repostería con acabado KRAFT 10x10x5\" -', 21.47, 10000),
(2, 'PD00002', 'Mantelitos a cuadros Antigrasa - Paquete de 500 Unidades', 17.7, 50000),
(3, 'PD00003', 'Caja para empaque de repostería BLANCA 10x10x5\" - 50 Unidade', 21.47, 40000),
(4, 'PD00004', 'Portavaso de cartón con asa para 2 unidades - 50 unidades', 11.3, 10000),
(5, 'PD00005', 'Bolsa Trilaminada Blanca - Fuelle y Sello lateral (3 capas) ', 16.95, 50000),
(6, 'PD00006', 'Bolsa trilaminada con acabado KRAFT, fuelle y sello lateral ', 13.28, 40000),
(7, 'PD00007', 'Bolsa TRANSPARENTE con fuelle y sello centrado (1 libra o 45', 5.65, 20000),
(8, 'PD00008', 'Bolsa TRANSPARENTE Con fuelle y sello centrado - Capacidad (', 2.11, 50000),
(9, 'PD00009', 'Manga o Fajilla para Vaso \"Diseño Café\", Bebidas Calientes (', 78.72, 50000),
(10, 'PD00010', 'Vaso de Papel Personalizado Marca SOLO® para Bebidas Calient', 45, 80000),
(11, 'PD00011', 'Vaso Transparente Personalizado Marca SOLO® para Bebidas Frí', 35, 10000);

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Usuario` varchar(20) NOT NULL,
  `Clave` blob NOT NULL,
  `estado` enum('Activo','Inactivo','','') NOT NULL,
  `fecha_creacion` date NOT NULL,
  `codempleado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Nombre`, `Apellido`, `Usuario`, `Clave`, `estado`, `fecha_creacion`, `codempleado`) VALUES
(1, 'Omar', 'Salmeron', 'osalmeron', 0xe4fd1ba7d14022960beb2bfd1fce03e2, 'Activo', '2023-11-01', 'EV000002'),
(2, 'Sigfredo Omar', 'Salmeron Renderos', 'ssalmeron', 0x2912c3ade1838144766ec7ba37a6e27f, 'Activo', '2023-11-09', 'EMPSig01361'),
(3, 'Geremy Stanley', 'Diaz Miranda', 'gdiaz', 0x99f3677e9c2b05ac482aa27f66471f0a, 'Activo', '2023-11-09', 'EMPGer10333'),
(4, 'John Franklin', 'Lemus Deras', 'jlemus', 0x9d9c38790d7c3c35d731e2bba7a210ac, 'Activo', '2023-11-09', 'EMPJoh20345'),
(5, 'Jose', 'Martinez', 'jmartinez', 0x56f8b7918a0117d737ef9ce3d0c72a6d, 'Activo', '2023-11-09', 'EMPJos03045'),
(6, 'Beatriz', 'Ramirez Arevalo', 'bramirez', 0x2f0be0f80fcc6df7ce51d000c5e60714, 'Activo', '2023-11-09', 'EMPBea03452'),
(7, 'Gabriel Omar', 'Ramirez', 'gramirez', 0xc486d234a6f83fd143bfa00e45a2aa74, 'Activo', '2023-11-09', 'EMPGab01452'),
(8, 'Juan', 'Hernandez', 'jhernandez', 0x8eb9849b1a944e8009f087aec1e3f30d, 'Activo', '2023-11-09', 'EMPJua01233'),
(9, 'Daniela', 'Arevalo Ramirez', 'darevalo', 0x571b7901e6287de987d000e7e08d7b31, 'Activo', '2023-11-09', 'EMPDan09875'),
(10, 'Oscar Armando', 'Ramirez', 'oramirez', 0x0f19704be2db81f6636e7f003dae4b00, 'Activo', '2023-11-09', 'EMPOsc01233'),
(11, 'Jose Alejandro', 'Martinez', 'jamartinez', 0x8b584a49670c36099c497615ba403af2, 'Activo', '2023-11-09', 'EMPJos02233');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cargos`
--
ALTER TABLE `cargos`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `empleados`
--
ALTER TABLE `empleados`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `facturas`
--
ALTER TABLE `facturas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cliente_id` (`cliente_id`);

--
-- Indexes for table `factura_detalle`
--
ALTER TABLE `factura_detalle`
  ADD PRIMARY KEY (`id`),
  ADD KEY `numero` (`factura_id`),
  ADD KEY `producto_id` (`producto_id`);

--
-- Indexes for table `mes`
--
ALTER TABLE `mes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `nominas`
--
ALTER TABLE `nominas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `codigo` (`codigo`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cargos`
--
ALTER TABLE `cargos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `empleados`
--
ALTER TABLE `empleados`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `facturas`
--
ALTER TABLE `facturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `factura_detalle`
--
ALTER TABLE `factura_detalle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT for table `mes`
--
ALTER TABLE `mes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `nominas`
--
ALTER TABLE `nominas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- AUTO_INCREMENT for table `productos`
--
ALTER TABLE `productos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `facturas`
--
ALTER TABLE `facturas`
  ADD CONSTRAINT `facturas_ibfk_3` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`id`);

--
-- Constraints for table `factura_detalle`
--
ALTER TABLE `factura_detalle`
  ADD CONSTRAINT `factura_detalle_ibfk_1` FOREIGN KEY (`producto_id`) REFERENCES `productos` (`id`),
  ADD CONSTRAINT `factura_detalle_ibfk_2` FOREIGN KEY (`factura_id`) REFERENCES `facturas` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
