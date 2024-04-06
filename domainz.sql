-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: domainz
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.27-MariaDB

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
-- Table structure for table `airport`
--

DROP TABLE IF EXISTS `airport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `airport` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `city_id` int(11) NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_airport_city1_idx` (`city_id`),
  CONSTRAINT `fk_airport_city1` FOREIGN KEY (`city_id`) REFERENCES `city` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `airport`
--

LOCK TABLES `airport` WRITE;
/*!40000 ALTER TABLE `airport` DISABLE KEYS */;
/*!40000 ALTER TABLE `airport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `boarding_pass`
--

DROP TABLE IF EXISTS `boarding_pass`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `boarding_pass` (
  `id` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `class_id` int(11) NOT NULL,
  `gate` varchar(45) NOT NULL,
  `time` time NOT NULL,
  `passenger_full_name` varchar(40) NOT NULL,
  `passenger_plane_flight_number` varchar(6) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_boarding_pass_class1_idx` (`class_id`),
  KEY `fk_boarding_pass_passenger1_idx` (`passenger_full_name`,`passenger_plane_flight_number`),
  CONSTRAINT `fk_boarding_pass_class1` FOREIGN KEY (`class_id`) REFERENCES `class` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_boarding_pass_passenger1` FOREIGN KEY (`passenger_full_name`, `passenger_plane_flight_number`) REFERENCES `passenger` (`full_name`, `plane_flight_number`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `boarding_pass`
--

LOCK TABLES `boarding_pass` WRITE;
/*!40000 ALTER TABLE `boarding_pass` DISABLE KEYS */;
/*!40000 ALTER TABLE `boarding_pass` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `city`
--

DROP TABLE IF EXISTS `city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `city` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `country_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_city_country_idx` (`country_id`),
  CONSTRAINT `fk_city_country` FOREIGN KEY (`country_id`) REFERENCES `country` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `city`
--

LOCK TABLES `city` WRITE;
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` VALUES (1,'Surabaya',1);
/*!40000 ALTER TABLE `city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `country`
--

DROP TABLE IF EXISTS `country`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `country` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `country`
--

LOCK TABLES `country` WRITE;
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` VALUES (1,'Indonesia');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passenger`
--

DROP TABLE IF EXISTS `passenger`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `passenger` (
  `full_name` varchar(40) NOT NULL,
  `plane_flight_number` varchar(6) NOT NULL,
  `seat_number` varchar(3) NOT NULL,
  `user_id` int(11) NOT NULL,
  `age_type` enum('Adult','Child','Baby') NOT NULL,
  PRIMARY KEY (`full_name`,`plane_flight_number`),
  KEY `fk_passenger_user1_idx` (`user_id`),
  KEY `fk_passenger_plane_flight1_idx` (`plane_flight_number`),
  CONSTRAINT `fk_passenger_plane_flight1` FOREIGN KEY (`plane_flight_number`) REFERENCES `plane_flight` (`flight_number`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_passenger_user1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passenger`
--

LOCK TABLES `passenger` WRITE;
/*!40000 ALTER TABLE `passenger` DISABLE KEYS */;
/*!40000 ALTER TABLE `passenger` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plane`
--

DROP TABLE IF EXISTS `plane`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plane` (
  `id` varchar(10) NOT NULL,
  `name` varchar(45) NOT NULL,
  `type` enum('Jumbo','Midsize','Light','Turboprop') NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plane`
--

LOCK TABLES `plane` WRITE;
/*!40000 ALTER TABLE `plane` DISABLE KEYS */;
/*!40000 ALTER TABLE `plane` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plane_flight`
--

DROP TABLE IF EXISTS `plane_flight`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `plane_flight` (
  `flight_number` varchar(6) NOT NULL,
  `plane_id` varchar(10) NOT NULL,
  `total_passenger` int(11) NOT NULL,
  `status` enum('idle','flight','departing','landing') NOT NULL,
  `from_airport_id` int(11) NOT NULL,
  `to_airport_id` int(11) NOT NULL,
  PRIMARY KEY (`flight_number`),
  KEY `fk_plane_flight_airport1_idx` (`from_airport_id`),
  KEY `fk_plane_flight_airport2_idx` (`to_airport_id`),
  KEY `fk_plane_flight_plane1_idx` (`plane_id`),
  CONSTRAINT `fk_plane_flight_airport1` FOREIGN KEY (`from_airport_id`) REFERENCES `airport` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_plane_flight_airport2` FOREIGN KEY (`to_airport_id`) REFERENCES `airport` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_plane_flight_plane1` FOREIGN KEY (`plane_id`) REFERENCES `plane` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plane_flight`
--

LOCK TABLES `plane_flight` WRITE;
/*!40000 ALTER TABLE `plane_flight` DISABLE KEYS */;
/*!40000 ALTER TABLE `plane_flight` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport_rate`
--

DROP TABLE IF EXISTS `transport_rate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transport_rate` (
  `from_airport_id` int(11) NOT NULL,
  `to_airport_id` int(11) NOT NULL,
  `class_id` int(11) NOT NULL,
  `age_type` enum('Adult','Child','Baby') NOT NULL,
  `fee` int(11) NOT NULL,
  PRIMARY KEY (`from_airport_id`,`to_airport_id`,`class_id`,`age_type`),
  KEY `fk_transport_rate_airport1_idx` (`from_airport_id`),
  KEY `fk_transport_rate_airport2_idx` (`to_airport_id`),
  KEY `fk_transport_rate_class1_idx` (`class_id`),
  CONSTRAINT `fk_transport_rate_airport1` FOREIGN KEY (`from_airport_id`) REFERENCES `airport` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transport_rate_airport2` FOREIGN KEY (`to_airport_id`) REFERENCES `airport` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transport_rate_class1` FOREIGN KEY (`class_id`) REFERENCES `class` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport_rate`
--

LOCK TABLES `transport_rate` WRITE;
/*!40000 ALTER TABLE `transport_rate` DISABLE KEYS */;
/*!40000 ALTER TABLE `transport_rate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(45) NOT NULL,
  `full_name` varchar(40) NOT NULL,
  `password` varchar(30) NOT NULL,
  `address` varchar(45) NOT NULL,
  `date_of_birth` date NOT NULL,
  `mobile_number` varchar(15) NOT NULL,
  `from_city_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`email`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_user_city1_idx` (`from_city_id`),
  CONSTRAINT `fk_user_city1` FOREIGN KEY (`from_city_id`) REFERENCES `city` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'cella@gmail.com','Marcella Tanjung','89a9b502987e6354174019153b436d','Jl Tenggilis No 1','2004-12-03','087855324215',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-06 13:42:26
