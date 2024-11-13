CREATE DATABASE  IF NOT EXISTS `clave3_grupo4db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `clave3_grupo4db`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: clave3_grupo4db
-- ------------------------------------------------------
-- Server version	8.2.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cargos`
--

DROP TABLE IF EXISTS `cargos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cargos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(500) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargos`
--

LOCK TABLES `cargos` WRITE;
/*!40000 ALTER TABLE `cargos` DISABLE KEYS */;
INSERT INTO `cargos` VALUES (1,'VENTAS Y MERCADOTECNIA - VENDEDOR JR\r\n'),(2,'VENTAS Y MERCADOTECNIA - VENDEDOR SR'),(3,'RECURSOS HUMANOS - JEFE DE N√ìMINAS'),(4,'RECURSOS HUMANOS - RECLUTADOR'),(5,'ADMINISTRACI√ìN - CAJERO'),(6,'ADMINISTRACI√ìN - COBRADOR\r\n'),(7,'ADMINISTRACI√ìN - GERENTE GENERAL'),(8,'ADMINISTRACI√ìN - CONTADOR'),(9,'ADMINISTRACI√ìN - RECEPCIONISTA\r\n'),(10,'ADMINISTRACI√ìN - MENSAJERO\r\n');
/*!40000 ALTER TABLE `cargos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `dui` varchar(50) NOT NULL,
  `nombre` varchar(60) NOT NULL,
  `direccion` varchar(50) NOT NULL,
  `telefono` varchar(15) NOT NULL,
  `correo` varchar(60) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'017125896','Luis Carlos Carmona','Calle falsa 123','74586912','luis@hotmail.com'),(2,'017135689','Maria Isabel Romo','Calle 100 # 45-09','75489621','mariaisa@yahoo.es'),(3,'017127845','Juan Ramon Lopez','Bedoya Ramirez','74125369','juanbedoya@gmail.com'),(4,'017685377','Ivan Estrada Latorre','Cuscatancingo ','74784182','alcala_2005_nf@witty.com'),(5,'017678766','Hortensia Ortiz Rosales','Nejapa','79882057','ruano_w5@hotmail.co.uk'),(6,'017220388','Maria Paz Roman Duque','San Salvador','76497496','aguado_2010_tw@lycos.co.uk'),(7,'017661179','Luciano Cuadrado Juan','Ciudad Delgado','71882523','zamora_1996_0@netscape.com'),(8,'017304306','Santos Barbero Garcia','San Antonio','79918864','alfaro_ix@libero.it'),(9,'017865686','Leonardo Mateu Del Valle','Santa Tecla','78228516','murillo_ek@libero.it'),(10,'017628007','Carles Moran Villegas','Usulutan','76909381','esteban_1982_p@email.com');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Direccion` varchar(150) NOT NULL,
  `Telefono` varchar(20) NOT NULL,
  `FechaIngreso` datetime NOT NULL,
  `Cargo` int NOT NULL,
  `correo` varchar(30) NOT NULL,
  `Salario` double NOT NULL,
  `dui` varchar(30) NOT NULL,
  `CuentaBanco` int NOT NULL,
  `CodEmpleado` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (2,'Omar','Salmeron','Final calle','78451292','2023-11-02 00:00:00',1,'prueba2@gmail.com',650,'017123540',12457869,'EV000002'),(7,'Sigfredo Omar','Salmeron Renderos','Colonia Santa Margarita, Cuscatancingo','25288453','2023-11-09 00:00:00',3,'SR01044@ues.edu.sv',450,'013610335',3456,'EMPSig01361'),(8,'Geremy Stanley','Dias Miranda','Final Calle Principal Mejicanos','23456543','2023-11-09 00:00:00',1,'DM02034@ues.edu.sv',450,'10333645',234556,'EMPGer10333'),(9,'John Franklin','Lemus Deras','Pasaje 3 Casa 7, Apopa','43232345','2023-11-09 00:00:00',2,'LD03455@ues.edu.sv',450,'203456104',234523456,'EMPJoh20345'),(10,'Jose Alberto','Martinez Campos','Final Calle principal casa 6, San Marcos','23456543','2023-11-09 00:00:00',4,'MC01055@ues.edu.sv',450,'03045567',23456543,'EMPJos03045'),(11,'Beatriz','Ramirez Arevalo','Pasaje 5, casa 83, San salvador','23452323','2023-11-09 00:00:00',1,'RA0234@ues.edu.sv',450,'034523454',34564567,'EMPBea03452'),(12,'Gabriel Omar','Ramirez','Calle Principal, casa 67, Apopa','23243434','2023-11-09 00:00:00',5,'RG03045',450,'014520335',34566543,'EMPGab01452'),(13,'Jose Alejandro','Martinez','Pasaje 10, Casa 10, San Salvador','23255664','2023-11-09 00:00:00',10,'MJ02345@ues.edu.sv',450,'022334556',45904567,'EMPJos02233'),(14,'Juan','Hernandez','Colonia Santa Clara, San Salvador','23235443','2023-11-09 00:00:00',1,'HA01056@ues.edu.sv',450,'012332445',23455432,'EMPJua01233'),(15,'Daniela','Arevalo Ramirez','Calle San Jose, Pasaje 4, Cuscatancingo','23245432','2023-11-09 00:00:00',1,'AR22034@ues.edu.sv',450,'098756455',678976543,'EMPDan09875'),(16,'Oscar Armando','Ramirez','Pasaje Carlos, casa 67, Ciudad Delgado','23267654','2023-11-09 00:00:00',2,'RO23034@ues.edu.sv',450,'012334564',34566543,'EMPOsc01233');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_detalle`
--

DROP TABLE IF EXISTS `factura_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_detalle` (
  `id` int NOT NULL AUTO_INCREMENT,
  `factura_id` int NOT NULL,
  `producto_id` int NOT NULL,
  `cantidad` int NOT NULL,
  `valor_unitario` double DEFAULT NULL,
  `total_producto` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `numero` (`factura_id`),
  KEY `producto_id` (`producto_id`),
  CONSTRAINT `factura_detalle_ibfk_1` FOREIGN KEY (`producto_id`) REFERENCES `productos` (`id`),
  CONSTRAINT `factura_detalle_ibfk_2` FOREIGN KEY (`factura_id`) REFERENCES `facturas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_detalle`
--

LOCK TABLES `factura_detalle` WRITE;
/*!40000 ALTER TABLE `factura_detalle` DISABLE KEYS */;
INSERT INTO `factura_detalle` VALUES (1,1,3,200,21,4294),(2,1,6,50,13,664),(3,2,3,234,21,5024),(4,3,1,20,21,429),(5,3,2,20,18,354),(6,3,4,20,11,226),(7,3,5,20,17,339),(8,4,4,29,11,328),(9,4,5,29,17,492),(10,4,8,29,2,61),(11,4,9,29,79,2283),(12,5,7,25,6,141),(13,5,9,25,79,1968),(14,5,2,25,18,442),(15,5,6,25,13,332),(16,6,5,35,17,593),(17,6,8,35,2,74),(18,6,11,35,35,1225),(19,6,2,35,18,620),(20,6,1,35,21,751),(21,7,1,25,21,537),(22,7,2,25,18,442),(23,7,3,25,21,537),(24,7,4,25,11,282),(25,7,5,25,17,424),(26,7,8,25,2,53),(27,7,9,25,79,1968),(28,8,2,35,18,620),(29,8,3,35,21,751),(30,8,5,35,17,593),(31,8,8,35,2,74),(32,8,10,35,45,1575),(33,8,11,35,35,1225),(34,9,7,50,6,282),(35,9,9,50,79,3936),(36,10,1,35,21,751),(37,10,6,35,13,465),(38,10,9,35,79,2755),(39,11,1,10,21,215),(40,11,2,10,18,177),(41,11,7,10,6,56),(42,11,9,10,79,787),(43,12,1,34,21,730),(44,12,5,34,17,576),(45,12,7,34,6,192),(46,12,5,34,17,576),(47,12,9,34,79,2676),(48,13,1,34,21,730),(49,13,6,34,13,452),(50,13,9,34,79,2676),(51,14,1,40,21,859),(52,14,4,40,11,452),(53,14,8,40,2,84),(54,14,10,40,45,1800),(55,15,1,25,21,537),(56,15,3,25,21,537),(57,15,7,25,6,141),(58,15,10,25,45,1125),(59,16,3,54,21,1159),(60,16,7,54,6,305),(61,16,10,54,45,2430),(62,16,11,54,35,1890);
/*!40000 ALTER TABLE `factura_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facturas`
--

DROP TABLE IF EXISTS `facturas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facturas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `cliente_id` int NOT NULL,
  `valor_total` double NOT NULL,
  `codempleado` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `facturas_ibfk_3` FOREIGN KEY (`cliente_id`) REFERENCES `clientes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facturas`
--

LOCK TABLES `facturas` WRITE;
/*!40000 ALTER TABLE `facturas` DISABLE KEYS */;
INSERT INTO `facturas` VALUES (1,'2023-11-05',8,4958,'EV000001'),(2,'2023-10-10',1,5023.98,'EMPSig01361'),(3,'2023-10-10',2,1348.4,'EMPGer10333'),(4,'2023-10-05',3,3163.32,'EMPJoh20345'),(5,'2023-10-05',5,2883.75,'EMPJos03045'),(6,'2023-10-05',6,3263.05,'EMPBea03452'),(7,'2023-10-05',6,4243,'EMPJos02233'),(8,'2023-10-05',8,4838.05,'EMPJos02233'),(9,'2023-10-05',9,4218.5,'EMPDan09875'),(10,'2023-10-05',9,3971.45,'EMPDan09875'),(11,'2023-10-05',4,1235.4,'EMPSig01361'),(12,'2023-11-09',3,4751.16,'EMPSig01361'),(13,'2023-11-09',5,3857.98,'EMPBea03452'),(14,'2023-11-09',7,3195.2,'EMPJos02233'),(15,'2023-11-09',10,2339.75,'EMPGab01452'),(16,'2023-11-09',6,5784.48,'EMPJos02233');
/*!40000 ALTER TABLE `facturas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mes`
--

DROP TABLE IF EXISTS `mes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `mes` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mes`
--

LOCK TABLES `mes` WRITE;
/*!40000 ALTER TABLE `mes` DISABLE KEYS */;
INSERT INTO `mes` VALUES (1,'ENERO'),(2,'FEBRERO'),(3,'MARZO'),(4,'ABRIL'),(5,'MAYO'),(6,'JUNIO'),(7,'JULIO'),(8,'AGOSTO'),(9,'SEPTIEMBRE'),(10,'OCTUBRE'),(11,'NOVIEMBRE'),(12,'DICIEMBRE');
/*!40000 ALTER TABLE `mes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nominas`
--

DROP TABLE IF EXISTS `nominas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nominas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) COLLATE utf8mb3_unicode_ci NOT NULL,
  `apellido` varchar(100) COLLATE utf8mb3_unicode_ci NOT NULL,
  `cargo` varchar(100) COLLATE utf8mb3_unicode_ci NOT NULL,
  `sueldobase` double NOT NULL,
  `horasext` int NOT NULL,
  `PrecioHoraExt` double NOT NULL,
  `PagoHorasExt` double NOT NULL,
  `BonoVentas` double NOT NULL,
  `renta` double NOT NULL,
  `isss` double NOT NULL,
  `afp` double NOT NULL,
  `sueldoneto` double NOT NULL,
  `mes` int NOT NULL,
  `periodo` int NOT NULL,
  `codempleado` varchar(50) COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=141 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nominas`
--

LOCK TABLES `nominas` WRITE;
/*!40000 ALTER TABLE `nominas` DISABLE KEYS */;
INSERT INTO `nominas` VALUES (22,'Londiz','Ramirez','1',450,0,5,0,0,45,13.5,32.625,0,1,2023,'EV000001'),(23,'Omar','Salmeron','1',650,0,5,0,0,65,19.5,47.125,0,1,2023,'EV000002'),(24,'Gabriel','Arevalo','1',450,0,5,0,0,45,13.5,32.625,0,1,2023,'EV000003'),(25,'Beatriz','Ramos','1',700,0,5,0,0,70,21,50.75,0,1,2023,'EV000004'),(26,'Oscar','Perez','1',750,0,5,0,0,75,22.5,54.37499999999999,0,1,2023,'EV000005'),(27,'PEDRO A.','CRUZ','4',500,0,5,0,0,50,15,36.25,0,1,2023,'EMPPED17458'),(115,'Omar','Salmeron','1',650,0,5,0,0,65,19.5,47.125,518.375,10,2023,'EV000002'),(116,'Sigfredo Omar','Salmeron Renderos','3',450,0,5,0,90,45,13.5,32.625,448.875,10,2023,'EMPSig01361'),(117,'Geremy Stanley','Dias Miranda','1',450,0,5,0,0,45,13.5,32.625,358.875,10,2023,'EMPGer10333'),(118,'John Franklin','Lemus Deras','2',450,0,5,0,67.5,45,13.5,32.625,426.375,10,2023,'EMPJoh20345'),(119,'Jose Alberto','Martinez Campos','4',450,0,5,0,45,45,13.5,32.625,403.875,10,2023,'EMPJos03045'),(120,'Beatriz','Ramirez Arevalo','1',450,0,5,0,67.5,45,13.5,32.625,426.375,10,2023,'EMPBea03452'),(121,'Gabriel Omar','Ramirez','5',450,0,5,0,0,45,13.5,32.625,358.875,10,2023,'EMPGab01452'),(122,'Jose Alejandro','Martinez','10',450,0,5,0,90,45,13.5,32.625,448.875,10,2023,'EMPJos02233'),(123,'Juan','Hernandez','1',450,0,5,0,0,45,13.5,32.625,358.875,10,2023,'EMPJua01233'),(124,'Daniela','Arevalo Ramirez','1',450,0,5,0,90,45,13.5,32.625,448.875,10,2023,'EMPDan09875'),(125,'Oscar Armando','Ramirez','2',450,0,5,0,0,45,13.5,32.625,358.875,10,2023,'EMPOsc01233'),(130,'Omar','Salmeron','1',650,0,5,0,0,65,19.5,47.125,518.375,11,2023,'EV000002'),(131,'Sigfredo Omar','Salmeron Renderos','3',450,0,5,0,90,45,13.5,32.625,448.875,11,2023,'EMPSig01361'),(132,'Geremy Stanley','Dias Miranda','1',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPGer10333'),(133,'John Franklin','Lemus Deras','2',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPJoh20345'),(134,'Jose Alberto','Martinez Campos','4',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPJos03045'),(135,'Beatriz','Ramirez Arevalo','1',450,0,5,0,67.5,45,13.5,32.625,426.375,11,2023,'EMPBea03452'),(136,'Gabriel Omar','Ramirez','5',450,0,5,0,45,45,13.5,32.625,403.875,11,2023,'EMPGab01452'),(137,'Jose Alejandro','Martinez','10',450,0,5,0,90,45,13.5,32.625,448.875,11,2023,'EMPJos02233'),(138,'Juan','Hernandez','1',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPJua01233'),(139,'Daniela','Arevalo Ramirez','1',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPDan09875'),(140,'Oscar Armando','Ramirez','2',450,0,5,0,0,45,13.5,32.625,358.875,11,2023,'EMPOsc01233');
/*!40000 ALTER TABLE `nominas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `codigo` varchar(100) NOT NULL,
  `descripcion` varchar(60) NOT NULL,
  `valor` double NOT NULL,
  `cantidad_inicial` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `codigo` (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'PD00001','Caja para empaque de reposter√≠a con acabado KRAFT 10x10x5\" -',21.47,10000),(2,'PD00002','Mantelitos a cuadros Antigrasa - Paquete de 500 Unidades',17.7,50000),(3,'PD00003','Caja para empaque de reposter√≠a BLANCA 10x10x5\" - 50 Unidade',21.47,40000),(4,'PD00004','Portavaso de cart√≥n con asa para 2 unidades - 50 unidades',11.3,10000),(5,'PD00005','Bolsa Trilaminada Blanca - Fuelle y Sello lateral (3 capas) ',16.95,50000),(6,'PD00006','Bolsa trilaminada con acabado KRAFT, fuelle y sello lateral ',13.28,40000),(7,'PD00007','Bolsa TRANSPARENTE con fuelle y sello centrado (1 libra o 45',5.65,20000),(8,'PD00008','Bolsa TRANSPARENTE Con fuelle y sello centrado - Capacidad (',2.11,50000),(9,'PD00009','Manga o Fajilla para Vaso \"Dise√±o Caf√©\", Bebidas Calientes (',78.72,50000),(10,'PD00010','Vaso de Papel Personalizado Marca SOLO¬Æ para Bebidas Calient',45,80000),(11,'PD00011','Vaso Transparente Personalizado Marca SOLO¬Æ para Bebidas Fr√≠',35,10000);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Usuario` varchar(20) NOT NULL,
  `Clave` blob NOT NULL,
  `estado` enum('Activo','Inactivo','','') NOT NULL,
  `fecha_creacion` date NOT NULL,
  `codempleado` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Omar','Salmeron','osalmeron',_binary 'R-C\«húR@¿ÄBJâßÖ','Activo','2023-11-01','EV000002'),(6,'Sigfredo Omar','Salmeron Renderos','ssalmeron',_binary ')√≠·ÉÅDvn«∫7¶\‚','Activo','2023-11-09','EMPSig01361'),(7,'Geremy Stanley','Diaz Miranda','gdiaz',_binary 'ôÛg~ú+¨H*¢fG\n','Activo','2023-11-09','EMPGer10333'),(8,'John Franklin','Lemus Deras','jlemus',_binary 'ùú8y\r|<5\◊1‚ªß¢¨','Activo','2023-11-09','EMPJoh20345'),(9,'Jose','Martinez','jmartinez',_binary 'V¯∑ëä\◊7\Ôú\„\–\«*m','Activo','2023-11-09','EMPJos03045'),(10,'Beatriz','Ramirez Arevalo','bramirez',_binary '/\‡¯\Ãm˜\ŒQ\–\0\≈\Ê','Activo','2023-11-09','EMPBea03452'),(11,'Gabriel Omar','Ramirez','gramirez',_binary 'ƒÜ\“4¶¯?\—Cø†E¢™t','Activo','2023-11-09','EMPGab01452'),(13,'Juan','Hernandez','jhernandez',_binary 'éπÑõ\ZîNÄ	áÆ¡\„Û\r','Activo','2023-11-09','EMPJua01233'),(14,'Daniela','Arevalo Ramirez','darevalo',_binary 'Wy\Ê(}\Èá\–\0\Á\‡ç{1','Activo','2023-11-09','EMPDan09875'),(15,'Oscar Armando','Ramirez','oramirez',_binary 'pK\‚€Åˆcn\0=ÆK\0','Activo','2023-11-09','EMPOsc01233'),(16,'Jose Alejandro','Martinez','jamartinez',_binary 'ãXJIg6	úIv∫@:Ú','Activo','2023-11-09','EV000002');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-10 18:31:28
