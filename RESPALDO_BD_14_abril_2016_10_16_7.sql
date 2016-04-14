-- MySQL dump 10.13  Distrib 5.6.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: test
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bautismos`
--

DROP TABLE IF EXISTS `bautismos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bautismos` (
  `id_bautismo` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) DEFAULT NULL,
  `num_hoja` int(11) DEFAULT NULL,
  `num_partida` varchar(10) DEFAULT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `padre` varchar(100) DEFAULT NULL,
  `madre` varchar(100) DEFAULT NULL,
  `fecha_nac` date DEFAULT NULL,
  `lugar_nac` varchar(100) DEFAULT NULL,
  `fecha_bautismo` date DEFAULT NULL,
  `padrino` varchar(100) DEFAULT NULL,
  `madrina` varchar(100) DEFAULT NULL,
  `presbitero` varchar(100) DEFAULT NULL,
  `anotacion` text,
  `anio` varchar(100) DEFAULT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_bautismo`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`),
  CONSTRAINT `bautismos_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bautismos`
--

LOCK TABLES `bautismos` WRITE;
/*!40000 ALTER TABLE `bautismos` DISABLE KEYS */;
/*!40000 ALTER TABLE `bautismos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'BAUTISMO'),(2,'CONFIRMACIÓN'),(3,'PRIMERA COMUNION'),(4,'MATRIMONIO');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comuniones`
--

DROP TABLE IF EXISTS `comuniones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comuniones` (
  `id_comunion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `padre` varchar(100) NOT NULL,
  `madre` varchar(100) NOT NULL,
  `fecha_comunion` date NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `padrino` varchar(100) NOT NULL,
  `madrina` varchar(100) NOT NULL,
  `presbitero` varchar(100) DEFAULT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_comunion`),
  KEY `id_libro` (`id_libro`),
  CONSTRAINT `comuniones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comuniones`
--

LOCK TABLES `comuniones` WRITE;
/*!40000 ALTER TABLE `comuniones` DISABLE KEYS */;
/*!40000 ALTER TABLE `comuniones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `confirmaciones`
--

DROP TABLE IF EXISTS `confirmaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `confirmaciones` (
  `id_confirmacion` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `padre` varchar(100) NOT NULL,
  `madre` varchar(100) NOT NULL,
  `fecha_confirmacion` date NOT NULL,
  `fecha_bautismo` date NOT NULL,
  `lugar_bautismo` varchar(100) NOT NULL,
  `padrino` varchar(100) NOT NULL,
  `madrina` varchar(100) NOT NULL,
  `presbitero` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_confirmacion`),
  KEY `id_libro` (`id_libro`),
  KEY `id_libro_2` (`id_libro`),
  CONSTRAINT `confirmaciones_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `confirmaciones`
--

LOCK TABLES `confirmaciones` WRITE;
/*!40000 ALTER TABLE `confirmaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `confirmaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coordenadas`
--

DROP TABLE IF EXISTS `coordenadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `coordenadas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoria` int(11) NOT NULL,
  `formato` int(11) NOT NULL,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `categoria` (`categoria`),
  CONSTRAINT `coordenadas_ibfk_1` FOREIGN KEY (`categoria`) REFERENCES `categorias` (`id_categoria`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coordenadas`
--

LOCK TABLES `coordenadas` WRITE;
/*!40000 ALTER TABLE `coordenadas` DISABLE KEYS */;
INSERT INTO `coordenadas` VALUES (1,1,1,0,0),(2,2,1,0,0),(3,3,1,0,0),(4,4,1,0,0),(5,1,2,0,0);
/*!40000 ALTER TABLE `coordenadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `egresos`
--

DROP TABLE IF EXISTS `egresos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `egresos` (
  `fecha` date NOT NULL,
  `concepto` int(11) NOT NULL,
  `cantidad` double NOT NULL,
  PRIMARY KEY (`fecha`,`concepto`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `egresos`
--

LOCK TABLES `egresos` WRITE;
/*!40000 ALTER TABLE `egresos` DISABLE KEYS */;
/*!40000 ALTER TABLE `egresos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `informacion`
--

DROP TABLE IF EXISTS `informacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `informacion` (
  `nombre_parroquia` varchar(100) NOT NULL,
  `nombre_parroco` varchar(100) NOT NULL,
  `calles` varchar(150) DEFAULT NULL,
  `colonia` varchar(50) DEFAULT NULL,
  `ciudad` varchar(50) DEFAULT NULL,
  `estado` varchar(50) DEFAULT NULL,
  `cp` varchar(8) DEFAULT NULL,
  `telefono` varchar(100) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `ubicacion_carpeta` varchar(100) NOT NULL,
  `contrasena` varchar(100) NOT NULL,
  `nombre_obispo` varchar(100) DEFAULT NULL,
  `nombre_diocesis` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `informacion`
--

LOCK TABLES `informacion` WRITE;
/*!40000 ALTER TABLE `informacion` DISABLE KEYS */;
INSERT INTO `informacion` VALUES ('Parroquia Ntra. Sra. de la Anunciación','Jose María Mendoza Guillén','Juan de la Barrera, Juan Escutia','','Villa Victoria','Michoacán','61770','4255742093','alfonso.calderon.chavez@gmail.com','c:/DOCsParroquia','4255925238','José Velazco Martínez','Diócesis de Apatzingán A. R.');
/*!40000 ALTER TABLE `informacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingresos`
--

DROP TABLE IF EXISTS `ingresos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingresos` (
  `fecha` date DEFAULT NULL,
  `concepto` int(11) DEFAULT NULL,
  `cantidad` double DEFAULT NULL,
  `fila` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresos`
--

LOCK TABLES `ingresos` WRITE;
/*!40000 ALTER TABLE `ingresos` DISABLE KEYS */;
/*!40000 ALTER TABLE `ingresos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `libros`
--

DROP TABLE IF EXISTS `libros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `libros` (
  `id_libro` int(11) NOT NULL AUTO_INCREMENT,
  `id_categoria` int(11) DEFAULT NULL,
  `nombre_libro` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_libro`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `libros`
--

LOCK TABLES `libros` WRITE;
/*!40000 ALTER TABLE `libros` DISABLE KEYS */;
/*!40000 ALTER TABLE `libros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matrimonios`
--

DROP TABLE IF EXISTS `matrimonios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `matrimonios` (
  `id_matrimonio` int(11) NOT NULL AUTO_INCREMENT,
  `id_libro` int(11) NOT NULL,
  `num_hoja` int(11) NOT NULL,
  `num_partida` varchar(10) NOT NULL,
  `novio` varchar(100) NOT NULL,
  `novia` varchar(100) NOT NULL,
  `fecha_matrimonio` date NOT NULL,
  `lugar_celebracion` varchar(100) NOT NULL,
  `testigo1` varchar(100) NOT NULL,
  `testigo2` varchar(100) NOT NULL,
  `asistente` varchar(100) NOT NULL,
  `nota_marginal` varchar(100) NOT NULL,
  `anio` varchar(10) NOT NULL,
  `bis` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_matrimonio`),
  KEY `id_libro` (`id_libro`),
  CONSTRAINT `matrimonios_ibfk_1` FOREIGN KEY (`id_libro`) REFERENCES `libros` (`id_libro`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matrimonios`
--

LOCK TABLES `matrimonios` WRITE;
/*!40000 ALTER TABLE `matrimonios` DISABLE KEYS */;
/*!40000 ALTER TABLE `matrimonios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-14 10:16:10
