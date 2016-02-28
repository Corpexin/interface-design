-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: alumno_examen
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

--
-- Table structure for table `propuesta`
--

DROP TABLE IF EXISTS `propuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `propuesta` (
  `Id` int(11) NOT NULL,
  `Titulo` varchar(45) NOT NULL,
  `Descripcion` varchar(125) NOT NULL,
  `NIFu` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`,`NIFu`),
  KEY `NIFu_idx` (`NIFu`),
  CONSTRAINT `NIFu` FOREIGN KEY (`NIFu`) REFERENCES `usuario` (`NIF`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propuesta`
--

LOCK TABLES `propuesta` WRITE;
/*!40000 ALTER TABLE `propuesta` DISABLE KEYS */;
INSERT INTO `propuesta` VALUES (1,'Propuesta1','Propuesta de algo interesante','1234568789E'),(2,'Propuesta2','Segunda propuesta de yo que se que poner','pepe'),(3,'Propuesta3','Asfaltar la calle que esta muy mal conservada','pepe'),(4,'Propuesta4','Poner una piscina en la plaza del pueblo','pepe'),(5,'Propuesta5','Nueva propuesta creada','pepe'),(6,'Propuesta6','hacer algo','pepo'),(7,'Propuesta7','propuesta descripcion algo','pipi'),(8,'Propuesta 8','mas texto con mas cosas que añadir','pepe');
/*!40000 ALTER TABLE `propuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `NIF` varchar(45) NOT NULL,
  `Contrasenha` varchar(45) NOT NULL,
  `VotosDisponibles` int(11) DEFAULT NULL,
  PRIMARY KEY (`NIF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES ('1234568789E','1234',2),('papa','papa',0),('pepe','pepe',0),('pepo','pepo',0),('pipi','pipi',0),('popo','popo',3),('pupu','pupu',2);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vota`
--

DROP TABLE IF EXISTS `vota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vota` (
  `NIF` varchar(45) NOT NULL,
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`NIF`,`Id`),
  KEY `Id_idx` (`Id`),
  CONSTRAINT `Id` FOREIGN KEY (`Id`) REFERENCES `propuesta` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `NIF` FOREIGN KEY (`NIF`) REFERENCES `usuario` (`NIF`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vota`
--

LOCK TABLES `vota` WRITE;
/*!40000 ALTER TABLE `vota` DISABLE KEYS */;
INSERT INTO `vota` VALUES ('1234568789E',1),('papa',1),('pepe',1),('pepe',2),('pepe',3),('pipi',3),('pepo',4),('pipi',4),('pepo',5),('papa',6),('pepo',6),('pipi',6),('pupu',6);
/*!40000 ALTER TABLE `vota` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-02-25 14:06:12
