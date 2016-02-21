-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: horario
-- ------------------------------------------------------
-- Server version	5.7.10-log

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

Drop database if exists Horario;
Create database Horario;
Use Horario;


--
-- Table structure for table `asignatura`
--

DROP TABLE IF EXISTS `asignatura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asignatura` (
  `CodAsignatura` varchar(5) NOT NULL,
  `Nombre` varchar(80) NOT NULL,
  `HorasSemanales` smallint(5) unsigned NOT NULL,
  `HorasTotales` smallint(5) unsigned DEFAULT NULL,
  PRIMARY KEY (`CodAsignatura`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignatura`
--

LOCK TABLES `asignatura` WRITE;
/*!40000 ALTER TABLE `asignatura` DISABLE KEYS */;
INSERT INTO `asignatura` VALUES ('@APLI','Desdoble de Aplicaciones ofimáticas',4,256),('@BDD','Desdoble de Bases de Datos',3,192),('@MONT','Desdoble de Montaje y mantenimiento de equipos',3,224),('@PROG','Desdoble de Programación',6,256),('@RED','Desdoble de Redes Locales',3,224),('@SIST','Desdoble de Sistemas informáticos',3,192),('AD','Acceso a datos',5,105),('APLI','Aplicaciones ofimáticas',8,256),('APLIW','Aplicaciones web',4,84),('BDD','Bases de Datos',6,192),('DI','Desarrollo de interfaces',7,147),('EIE','Empresa e iniciativa emprendedora',4,84),('EIEM','Empresa e iniciativa empresarial',4,84),('ENT','Entornos de desarrollo',3,96),('FOL','Formación y orientación laboral',3,96),('HLC','Horas de Libre Configuración',3,63),('MARC','Lenguajes de marcas y sistemas de gestión de información',4,128),('MONT','Montaje y mantenimiento de equipos',7,224),('PMDMO','Programación multimedia y dispositivos móviles',4,84),('PROG','Programación',8,256),('PSPRO','Programación de servicios y procesos',3,63),('RED','Redes Locales',7,224),('SEG','Seguridad informática',5,105),('SERV','Servicios en red',7,147),('SGE','Sistemas de gestión empresarial',4,84),('SISM','Sistemas operativos monopuestos',5,160),('SISR','Sistemas operativos en red',7,147),('SIST','Sistemas informáticos',6,192);
/*!40000 ALTER TABLE `asignatura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curso`
--

DROP TABLE IF EXISTS `curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `curso` (
  `CodOe` char(4) NOT NULL,
  `CodCurso` char(2) NOT NULL,
  `Tutor` char(3) NOT NULL,
  PRIMARY KEY (`CodOe`,`CodCurso`),
  UNIQUE KEY `Tutor` (`Tutor`),
  CONSTRAINT `curso_ibfk_1` FOREIGN KEY (`CodOe`) REFERENCES `ofertaeducativa` (`CodOe`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `curso_ibfk_2` FOREIGN KEY (`Tutor`) REFERENCES `profesor` (`CodProf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curso`
--

LOCK TABLES `curso` WRITE;
/*!40000 ALTER TABLE `curso` DISABLE KEYS */;
INSERT INTO `curso` VALUES ('DAM','1A','AGL'),('SMR','1A','JGG'),('SMR','2A','MAF'),('DAM','2A','SAA');
/*!40000 ALTER TABLE `curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `horario`
--

DROP TABLE IF EXISTS `horario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `horario` (
  `CodTramo` char(2) NOT NULL,
  `CodOe` char(4) NOT NULL,
  `CodCurso` char(2) NOT NULL,
  `CodAsignatura` varchar(5) NOT NULL,
  PRIMARY KEY (`CodOe`,`CodCurso`,`CodAsignatura`,`CodTramo`),
  KEY `CodAsignatura` (`CodAsignatura`),
  KEY `CodTramo` (`CodTramo`),
  CONSTRAINT `horario_ibfk_1` FOREIGN KEY (`CodOe`, `CodCurso`) REFERENCES `curso` (`CodOe`, `CodCurso`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `horario_ibfk_2` FOREIGN KEY (`CodAsignatura`) REFERENCES `asignatura` (`CodAsignatura`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `horario_ibfk_3` FOREIGN KEY (`CodTramo`) REFERENCES `tramohorario` (`CodTramo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `horario`
--

LOCK TABLES `horario` WRITE;
/*!40000 ALTER TABLE `horario` DISABLE KEYS */;
INSERT INTO `horario` VALUES ('J1','DAM','1A','@PROG'),('J1','DAM','1A','PROG'),('J1','DAM','2A','SGE'),('J1','SMR','1A','@APLI'),('J1','SMR','1A','APLI'),('J1','SMR','2A','APLIW'),('J2','DAM','1A','@PROG'),('J2','DAM','1A','PROG'),('J2','DAM','2A','PMDMO'),('J2','SMR','1A','SISM'),('J2','SMR','2A','SISR'),('J3','DAM','1A','ENT'),('J3','DAM','2A','PMDMO'),('J3','SMR','1A','MONT'),('J3','SMR','2A','SERV'),('J4','DAM','1A','@SIST'),('J4','DAM','1A','SIST'),('J4','DAM','2A','DI'),('J4','SMR','1A','@RED'),('J4','SMR','1A','RED'),('J4','SMR','2A','EIEM'),('J5','DAM','1A','FOL'),('J5','DAM','2A','DI'),('J5','SMR','1A','@MONT'),('J5','SMR','1A','MONT'),('J5','SMR','2A','SEG'),('J6','DAM','1A','MARC'),('J6','DAM','2A','EIE'),('J6','SMR','1A','APLI'),('J6','SMR','2A','HLC'),('L1','DAM','1A','@PROG'),('L1','DAM','1A','PROG'),('L1','DAM','2A','PSPRO'),('L1','SMR','1A','APLI'),('L1','SMR','2A','EIEM'),('L2','DAM','1A','@PROG'),('L2','DAM','1A','PROG'),('L2','DAM','2A','EIE'),('L2','SMR','1A','@APLI'),('L2','SMR','1A','APLI'),('L2','SMR','2A','HLC'),('L3','DAM','1A','FOL'),('L3','DAM','2A','PSPRO'),('L3','SMR','1A','RED'),('L3','SMR','2A','SISR'),('L4','DAM','1A','@BDD'),('L4','DAM','1A','BDD'),('L4','DAM','2A','AD'),('L4','SMR','1A','RED'),('L4','SMR','2A','SISR'),('L5','DAM','1A','@BDD'),('L5','DAM','1A','BDD'),('L5','DAM','2A','SEG'),('L5','SMR','1A','MONT'),('L5','SMR','2A','SERV'),('L6','DAM','1A','MARC'),('L6','DAM','2A','DI'),('L6','SMR','1A','FOL'),('L6','SMR','2A','SEG'),('M1','DAM','1A','PROG'),('M1','DAM','2A','HLC'),('M1','SMR','1A','RED'),('M1','SMR','2A','SERV'),('M2','DAM','1A','BDD'),('M2','DAM','2A','DI'),('M2','SMR','1A','RED'),('M2','SMR','2A','SERV'),('M3','DAM','1A','ENT'),('M3','DAM','2A','DI'),('M3','SMR','1A','@MONT'),('M3','SMR','1A','MONT'),('M3','SMR','2A','SEG'),('M4','DAM','1A','@SIST'),('M4','DAM','1A','SIST'),('M4','DAM','2A','AD'),('M4','SMR','1A','@RED'),('M4','SMR','1A','RED'),('M4','SMR','2A','APLIW'),('M5','DAM','1A','SIST'),('M5','DAM','2A','AD'),('M5','SMR','1A','@APLI'),('M5','SMR','1A','APLI'),('M5','SMR','2A','EIEM'),('M6','DAM','1A','MARC'),('M6','DAM','2A','EIE'),('M6','SMR','1A','SISM'),('M6','SMR','2A','SISR'),('V1','DAM','1A','@PROG'),('V1','DAM','1A','PROG'),('V1','DAM','2A','PMDMO'),('V1','SMR','1A','APLI'),('V1','SMR','2A','HLC'),('V2','DAM','1A','@PROG'),('V2','DAM','1A','PROG'),('V2','DAM','2A','PMDMO'),('V2','SMR','1A','FOL'),('V2','SMR','2A','SISR'),('V3','DAM','1A','@BDD'),('V3','DAM','1A','BDD'),('V3','DAM','2A','SGE'),('V3','SMR','1A','@APLI'),('V3','SMR','1A','APLI'),('V3','SMR','2A','SERV'),('V4','DAM','1A','SIST'),('V4','DAM','2A','HLC'),('V4','SMR','1A','@RED'),('V4','SMR','1A','RED'),('V4','SMR','2A','SEG'),('V5','DAM','1A','ENT'),('V5','DAM','2A','HLC'),('V5','SMR','1A','SISM'),('V5','SMR','2A','EIEM'),('V6','DAM','1A','PROG'),('V6','DAM','2A','DI'),('V6','SMR','1A','MONT'),('V6','SMR','2A','APLIW'),('X1','DAM','1A','@SIST'),('X1','DAM','1A','SIST'),('X1','DAM','2A','SGE'),('X1','SMR','1A','SISM'),('X1','SMR','2A','SERV'),('X2','DAM','1A','BDD'),('X2','DAM','2A','PSPRO'),('X2','SMR','1A','SISM'),('X2','SMR','2A','SERV'),('X3','DAM','1A','BDD'),('X3','DAM','2A','DI'),('X3','SMR','1A','@MONT'),('X3','SMR','1A','MONT'),('X3','SMR','2A','APLIW'),('X4','DAM','1A','FOL'),('X4','DAM','2A','AD'),('X4','SMR','1A','MONT'),('X4','SMR','2A','SISR'),('X5','DAM','1A','MARC'),('X5','DAM','2A','AD'),('X5','SMR','1A','FOL'),('X5','SMR','2A','SISR'),('X6','DAM','1A','SIST'),('X6','DAM','2A','EIE'),('X6','SMR','1A','APLI'),('X6','SMR','2A','SEG');
/*!40000 ALTER TABLE `horario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login` (
  `usuario` varchar(10) NOT NULL,
  `password` varchar(12) NOT NULL,
  `tipousuario` tinyint(2) NOT NULL,
  PRIMARY KEY (`usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES ('AGL','AGL',1),('corpex','corpex',0),('CSG','CSG',1),('EPM','EPM',1),('JER','JER',1),('JGG','JGG',1),('MAF','MAF',1),('papa','papa',0),('PBG','PBG',1),('pepe','pepe',0),('PJM','PJM',1),('RAR','RAR',1),('SAA','SAA',1);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ofertaeducativa`
--

DROP TABLE IF EXISTS `ofertaeducativa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ofertaeducativa` (
  `CodOe` char(4) NOT NULL,
  `Nombre` varchar(60) DEFAULT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Tipo` char(4) DEFAULT NULL,
  PRIMARY KEY (`CodOe`),
  UNIQUE KEY `Nombre` (`Nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ofertaeducativa`
--

LOCK TABLES `ofertaeducativa` WRITE;
/*!40000 ALTER TABLE `ofertaeducativa` DISABLE KEYS */;
INSERT INTO `ofertaeducativa` VALUES ('DAM','Grado Superior de Desarollo de Aplicaciones Multiplataforma','El CFGs DAM tiene una duración de 2000 horas\n repartidas entre dos cursos académicos incluyendo 400 horas de Formacion en centros de trabajo (FCT) en empresas del Sector','CFGS'),('SMR','Grado Medio de Sistemas Microinformáticos y Redes','El CFGM SMR tiene una duración de 2000 horas \n repartidas entre dos cursos académicos incluyendo un trimestre de Formacion en centros de trabajo (FCT) en empresas del Sector','CFGM');
/*!40000 ALTER TABLE `ofertaeducativa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesor`
--

DROP TABLE IF EXISTS `profesor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profesor` (
  `CodProf` char(3) NOT NULL,
  `Nombre` varchar(60) NOT NULL,
  `Alta` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `FechaDeNacimiento` date DEFAULT NULL,
  PRIMARY KEY (`CodProf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesor`
--

LOCK TABLES `profesor` WRITE;
/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES ('AGL','Ana Gutiérrez Lozano','2016-01-25 18:58:41','1979-12-20'),('AMN','Alejandro Madrid Nuñez','2015-01-25 18:56:54','1945-01-02'),('CSG','Cristóbal Sánchez García','2016-01-25 18:58:41','1977-07-12'),('EPM','Eva Peralta Macías','2016-01-25 18:58:41','1982-08-15'),('JER','José Manuel Escribano Romero','2016-01-25 18:58:41','1986-09-13'),('JGG','Javier Graña González','2016-01-25 18:58:41','1977-04-01'),('MAF','María José Ávila Fernández','2016-01-25 18:58:41','1979-03-24'),('PBG','Pilar Baena García','2016-01-25 18:58:41','1982-11-16'),('PJM','Pedro Joya Máñez','2016-01-25 18:58:41','1980-05-15'),('RAR','Rosa Alcázar Rosal','2016-01-25 18:58:41','1979-05-14'),('SAA','Santiago Acha Aller','2016-01-25 18:58:41','1978-10-04');
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reparto`
--

DROP TABLE IF EXISTS `reparto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reparto` (
  `CodOe` char(4) NOT NULL,
  `CodCurso` char(2) NOT NULL,
  `CodAsignatura` varchar(5) NOT NULL,
  `CodProf` char(3) DEFAULT NULL,
  PRIMARY KEY (`CodOe`,`CodCurso`,`CodAsignatura`),
  KEY `CodAsignatura` (`CodAsignatura`),
  KEY `CodProf` (`CodProf`),
  CONSTRAINT `reparto_ibfk_1` FOREIGN KEY (`CodOe`, `CodCurso`) REFERENCES `curso` (`CodOe`, `CodCurso`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reparto_ibfk_2` FOREIGN KEY (`CodAsignatura`) REFERENCES `asignatura` (`CodAsignatura`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reparto_ibfk_3` FOREIGN KEY (`CodProf`) REFERENCES `profesor` (`CodProf`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reparto`
--

LOCK TABLES `reparto` WRITE;
/*!40000 ALTER TABLE `reparto` DISABLE KEYS */;
INSERT INTO `reparto` VALUES ('DAM','1A','@PROG','AGL'),('DAM','1A','BDD','AGL'),('SMR','2A','SEG','AGL'),('SMR','1A','SISM','CSG'),('DAM','1A','PROG','EPM'),('DAM','2A','AD','EPM'),('DAM','1A','SIST','JER'),('SMR','1A','MONT','JER'),('DAM','1A','ENT','JGG'),('DAM','2A','SGE','JGG'),('SMR','1A','RED','JGG'),('SMR','2A','HLC','JGG'),('DAM','1A','MARC','MAF'),('SMR','1A','@RED','MAF'),('SMR','2A','SERV','MAF'),('DAM','1A','@SIST','PBG'),('SMR','1A','@MONT','PBG'),('SMR','1A','APLI','PBG'),('SMR','2A','SISR','PBG'),('DAM','1A','@BDD','PJM'),('DAM','2A','HLC','PJM'),('DAM','2A','PMDMO','PJM'),('DAM','2A','PSPRO','PJM'),('SMR','2A','APLIW','PJM'),('DAM','1A','FOL','RAR'),('DAM','2A','EIE','RAR'),('SMR','1A','FOL','RAR'),('SMR','2A','EIEM','RAR'),('DAM','2A','DI','SAA'),('SMR','1A','@APLI','SAA');
/*!40000 ALTER TABLE `reparto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tramohorario`
--

DROP TABLE IF EXISTS `tramohorario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tramohorario` (
  `CodTramo` char(2) NOT NULL,
  `HoraInicio` time DEFAULT NULL,
  `HoraFin` time DEFAULT NULL,
  `Dia` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`CodTramo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tramohorario`
--

LOCK TABLES `tramohorario` WRITE;
/*!40000 ALTER TABLE `tramohorario` DISABLE KEYS */;
INSERT INTO `tramohorario` VALUES ('J1','08:15:00','09:15:00','Jueves'),('J2','09:15:00','10:15:00','Jueves'),('J3','10:15:00','11:15:00','Jueves'),('J4','11:45:00','12:45:00','Jueves'),('J5','12:45:00','13:45:00','Jueves'),('J6','13:45:00','14:45:00','Jueves'),('L1','08:15:00','09:15:00','Lunes'),('L2','09:15:00','10:15:00','Lunes'),('L3','10:15:00','11:15:00','Lunes'),('L4','11:45:00','12:45:00','Lunes'),('L5','12:45:00','13:45:00','Lunes'),('L6','13:45:00','14:45:00','Lunes'),('M1','08:15:00','09:15:00','Martes'),('M2','09:15:00','10:15:00','Martes'),('M3','10:15:00','11:15:00','Martes'),('M4','11:45:00','12:45:00','Martes'),('M5','12:45:00','13:45:00','Martes'),('M6','13:45:00','14:45:00','Martes'),('V1','08:15:00','09:15:00','Viernes'),('V2','09:15:00','10:15:00','Viernes'),('V3','10:15:00','11:15:00','Viernes'),('V4','11:45:00','12:45:00','Viernes'),('V5','12:45:00','13:45:00','Viernes'),('V6','13:45:00','14:45:00','Viernes'),('X1','08:15:00','09:15:00','Miércoles'),('X2','09:15:00','10:15:00','Miércoles'),('X3','10:15:00','11:15:00','Miércoles'),('X4','11:45:00','12:45:00','Miércoles'),('X5','12:45:00','13:45:00','Miércoles'),('X6','13:45:00','14:45:00','Miércoles');
/*!40000 ALTER TABLE `tramohorario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-02-21 12:47:54
