-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 05, 2023 at 08:48 PM
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
  `CuentaBanco` int(30) NOT NULL,
  `CodEmpleado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `empleados`
--

INSERT INTO `empleados` (`Id`, `Nombre`, `Apellido`, `Direccion`, `Telefono`, `FechaIngreso`, `Cargo`, `correo`, `Salario`, `dui`, `CuentaBanco`, `CodEmpleado`) VALUES
(1, 'Londiz', 'Ramirez', 'Final calle ', '78451298', '2023-11-02 00:00:00', 1, 'prueba1@gmail.com', 450, '017123569', 12457896, 'EV000001'),
(2, 'Omar', 'Salmeron', 'Final calle', '78451292', '2023-11-02 00:00:00', 1, 'prueba2@gmail.com', 650, '017123540', 12457869, 'EV000002'),
(3, 'Gabriel', 'Arevalo', 'Final calle', '78451296', '2023-11-02 00:00:00', 1, 'prueba3@gmail.com', 450, '017123525', 12457880, 'EV000003'),
(4, 'Beatriz', 'Ramos', 'Final calle', '78451221', '2023-11-02 00:00:00', 1, 'prueba4@gmail.com', 700, '017123521', 12457821, 'EV000004'),
(5, 'Oscar', 'Perez', 'Final calle', '78451256', '2023-11-02 00:00:00', 1, 'prueba5@gmail.com', 750, '017123585', 12457896, 'EV000005'),
(6, 'PEDRO A.', 'CRUZ', 'MEJICANOS SAN SALVADOR', '74589632', '2023-11-03 00:00:00', 4, 'peddro.cruz@gmail.com', 500, '1745893625', 123654789, 'EMPPED17458');

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
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `cargo` varchar(100) NOT NULL,
  `sueldobase` double NOT NULL,
  `horasext` int(11) NOT NULL,
  `PrecioHoraExt` double NOT NULL,
  `PagoHorasExt` double NOT NULL,
  `BonoVentas` double NOT NULL,
  `renta` double NOT NULL,
  `isss` double NOT NULL,
  `afp` double NOT NULL,
  `sueldoneto` double NOT NULL,
  `mes` int(11) NOT NULL,
  `periodo` int(11) NOT NULL,
  `codempleado` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

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
(1, 'Omar', 'Salmeron', 'osalmeron', 0x522d43c7689c5240c00b80424a89a785, 'Activo', '2023-11-01', 'EV000002'),
(2, 'Londiz', 'Ramirez', 'lramirez', 0xad3943b68967b03fb31d04c4f8372963, 'Activo', '2023-11-01', 'EV000001'),
(3, 'Gabriel Omar', 'Arevalo', 'garevalo', 0x3435363839, 'Activo', '2023-11-04', 'EV000003'),
(4, 'PEDRO', 'CRUZ', 'pcruz', 0xe6752ed19d43faea49429400a04fffcc, 'Activo', '2023-11-05', 'EMPPED17458');

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `facturas`
--
ALTER TABLE `facturas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

--
-- AUTO_INCREMENT for table `factura_detalle`
--
ALTER TABLE `factura_detalle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
