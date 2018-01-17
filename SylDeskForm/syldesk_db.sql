-- MySQL dump 10.16  Distrib 10.1.21-MariaDB, for Win32 (AMD64)
--
-- Host: localhost    Database: localhost
-- ------------------------------------------------------
-- Server version	10.1.21-MariaDB

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
-- Table structure for table `especies`
--

DROP TABLE IF EXISTS `especies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `especies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `especie` varchar(40) NOT NULL,
  `nombrecientifico` varchar(40) NOT NULL,
  `nombrecomun` varchar(40) NOT NULL,
  `familia` varchar(40) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `especie` (`especie`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especies`
--

LOCK TABLES `especies` WRITE;
/*!40000 ALTER TABLE `especies` DISABLE KEYS */;
INSERT INTO `especies` VALUES (1,'bananas','en','pijama','yes'),(2,'chango','rechiflado','chino','quenochinguesalachanga');
/*!40000 ALTER TABLE `especies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `individuos`
--

DROP TABLE IF EXISTS `individuos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `individuos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proyecto_id` int(11) NOT NULL,
  `sitio` int(11) NOT NULL,
  `area` int(11) NOT NULL,
  `cuadrante` int(11) DEFAULT NULL,
  `numero` int(11) NOT NULL,
  `arbolnumeroensitio` int(11) NOT NULL,
  `bifurcados` tinyint(1) DEFAULT NULL,
  `especie` varchar(40) DEFAULT NULL,
  `nombrecientifico` varchar(40) DEFAULT NULL,
  `nombrecomun` varchar(40) DEFAULT NULL,
  `familia` varchar(40) DEFAULT NULL,
  `perimetro` decimal(10,4) DEFAULT NULL,
  `diametro` decimal(10,4) DEFAULT NULL,
  `alturafl` decimal(10,4) DEFAULT NULL,
  `alturatotal` decimal(10,4) DEFAULT NULL,
  `coberturalargo` decimal(10,4) DEFAULT NULL,
  `coberturaancho` decimal(10,4) DEFAULT NULL,
  `formadefuste` varchar(20) DEFAULT NULL,
  `estadocondicion` varchar(20) DEFAULT NULL,
  `rad` decimal(10,4) DEFAULT NULL,
  `atcategorias` decimal(10,4) DEFAULT NULL,
  `dncategorias` int(11) DEFAULT NULL,
  `ab` decimal(10,4) DEFAULT NULL,
  `grupo` int(11) DEFAULT NULL,
  `volumenvv` decimal(10,4) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `proyecto_id_fk` (`proyecto_id`),
  CONSTRAINT `proyecto_id_fk` FOREIGN KEY (`proyecto_id`) REFERENCES `proyectos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=96 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `individuos`
--

LOCK TABLES `individuos` WRITE;
/*!40000 ALTER TABLE `individuos` DISABLE KEYS */;
INSERT INTO `individuos` VALUES (93,11,1,500,NULL,1,1,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(94,11,1,500,NULL,2,2,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(95,11,1,500,NULL,2,3,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `individuos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proyectos`
--

DROP TABLE IF EXISTS `proyectos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proyectos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) NOT NULL,
  `superficie` decimal(11,4) NOT NULL,
  `sector` varchar(20) NOT NULL,
  `descripcion` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proyectos`
--

LOCK TABLES `proyectos` WRITE;
/*!40000 ALTER TABLE `proyectos` DISABLE KEYS */;
INSERT INTO `proyectos` VALUES (11,'Ejemplo',120.0000,'ejemplo','ejemploejemploejemploejemploejemplo');
/*!40000 ALTER TABLE `proyectos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sitios`
--

DROP TABLE IF EXISTS `sitios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sitios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `proyecto_id` int(11) NOT NULL,
  `numero_sitio` int(11) NOT NULL,
  `coordenada_x` decimal(11,4) DEFAULT NULL,
  `coordenada_y` decimal(11,4) DEFAULT NULL,
  `municipio` varchar(20) DEFAULT NULL,
  `estado_sucesional` varchar(20) DEFAULT NULL,
  `numero_consecutivo1` int(11) NOT NULL DEFAULT '1',
  `numero_consecutivo2` int(11) NOT NULL DEFAULT '1',
  `numero_consecutivo3` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `proyecto_id_fk2` (`proyecto_id`),
  CONSTRAINT `proyecto_id_fk2` FOREIGN KEY (`proyecto_id`) REFERENCES `proyectos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sitios`
--

LOCK TABLES `sitios` WRITE;
/*!40000 ALTER TABLE `sitios` DISABLE KEYS */;
INSERT INTO `sitios` VALUES (14,11,1,NULL,NULL,NULL,NULL,3,1,1);
/*!40000 ALTER TABLE `sitios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-17  5:28:45
