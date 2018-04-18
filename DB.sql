CREATE DATABASE  IF NOT EXISTS `youtube` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `youtube`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: youtube
-- ------------------------------------------------------
-- Server version	5.6.35

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
-- Table structure for table `comments`
--

DROP TABLE IF EXISTS `comments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `comments` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserID` bigint(20) unsigned NOT NULL,
  `VideoID` bigint(20) unsigned NOT NULL,
  `ActualComment` text NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `CommentToUser_idx` (`UserID`),
  KEY `CommentToVideo_idx` (`VideoID`),
  CONSTRAINT `CommentToUser` FOREIGN KEY (`UserID`) REFERENCES `logins` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `CommentToVideo` FOREIGN KEY (`VideoID`) REFERENCES `videos` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comments`
--

LOCK TABLES `comments` WRITE;
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dislikes`
--

DROP TABLE IF EXISTS `dislikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dislikes` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `videoID` bigint(20) unsigned NOT NULL,
  `userID` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `videoID_UNIQUE` (`videoID`),
  KEY `fk_userID_idx` (`userID`),
  CONSTRAINT `fk_userID` FOREIGN KEY (`userID`) REFERENCES `logins` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_videoID` FOREIGN KEY (`videoID`) REFERENCES `videos` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dislikes`
--

LOCK TABLES `dislikes` WRITE;
/*!40000 ALTER TABLE `dislikes` DISABLE KEYS */;
INSERT INTO `dislikes` VALUES (11,1,1),(14,13,1);
/*!40000 ALTER TABLE `dislikes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `historyvideo`
--

DROP TABLE IF EXISTS `historyvideo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `historyvideo` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserID` bigint(20) unsigned NOT NULL,
  `VideoID` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `HistoryVideoToUsers_idx` (`UserID`),
  KEY `HistoryVideoToVideo_idx` (`VideoID`),
  CONSTRAINT `HistoryVideoToUsers` FOREIGN KEY (`UserID`) REFERENCES `logins` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `HistoryVideoToVideo` FOREIGN KEY (`VideoID`) REFERENCES `videos` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historyvideo`
--

LOCK TABLES `historyvideo` WRITE;
/*!40000 ALTER TABLE `historyvideo` DISABLE KEYS */;
/*!40000 ALTER TABLE `historyvideo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `likes` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `VideoID` bigint(20) unsigned NOT NULL,
  `UserID` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `LikesToVideos_idx` (`VideoID`),
  KEY `LikesToUsers_idx` (`UserID`),
  CONSTRAINT `LikesToUsers` FOREIGN KEY (`UserID`) REFERENCES `logins` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `LikesToVideos` FOREIGN KEY (`VideoID`) REFERENCES `videos` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `likes`
--

LOCK TABLES `likes` WRITE;
/*!40000 ALTER TABLE `likes` DISABLE KEYS */;
INSERT INTO `likes` VALUES (4,7,1),(7,2,1),(24,3,1),(25,4,5),(26,13,5),(29,13,1),(34,4,1),(35,8,1);
/*!40000 ALTER TABLE `likes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logins`
--

DROP TABLE IF EXISTS `logins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logins` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` varchar(64) NOT NULL,
  `Password` varchar(64) NOT NULL,
  `Email` varchar(64) NOT NULL,
  `ChannelColour` varchar(45) NOT NULL,
  `Subscribers` bigint(20) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`),
  UNIQUE KEY `Email_UNIQUE` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logins`
--

LOCK TABLES `logins` WRITE;
/*!40000 ALTER TABLE `logins` DISABLE KEYS */;
INSERT INTO `logins` VALUES (1,'martis900','20c053ef9cf99a1fdd28aee28ff193a7','martynas.alekna0@gmail.com','red',5000),(2,'antanas','52f4a2f058431d8e5c5cf87fb03cd1a2','antanas@gmail.com','green',40010),(3,'mar','5fa9db2e335ef69a4eeb9fe7974d61f4','martynas.alekna10@gmail.com','blue',0),(4,'ale','f7a3803365a55b197a3b43bc64aacc13','ale@gmail.com','grey',0),(5,'kasparas','74b45c30a2cf051afb3947cd493cfceb','kasparas.miciunas@gmail.com','red',0),(6,'a','0cc175b9c0f1b6a831c399e269772661','a@gmail.com','red',0),(7,'b','92eb5ffee6ae2fec3ad71c777531578f','b@gmail.com','red',0),(8,'mantas','202cb962ac59075b964b07152d234b70','mantas.skyrius@gmail.com','red',0);
/*!40000 ALTER TABLE `logins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptions`
--

DROP TABLE IF EXISTS `subscriptions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subscriptions` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `SubscriberID` bigint(20) unsigned NOT NULL,
  `ChannelID` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `SubscriberToChannel_idx` (`SubscriberID`),
  KEY `ChannelToLogins_idx` (`ChannelID`),
  CONSTRAINT `ChannelToLogins` FOREIGN KEY (`ChannelID`) REFERENCES `logins` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `SubscriberToLogins` FOREIGN KEY (`SubscriberID`) REFERENCES `logins` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptions`
--

LOCK TABLES `subscriptions` WRITE;
/*!40000 ALTER TABLE `subscriptions` DISABLE KEYS */;
/*!40000 ALTER TABLE `subscriptions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videos`
--

DROP TABLE IF EXISTS `videos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `videos` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ChannelID` bigint(20) unsigned NOT NULL,
  `Name` varchar(64) NOT NULL,
  `VideoLink` varchar(200) NOT NULL,
  `Views` bigint(20) unsigned NOT NULL,
  `LikeCount` bigint(20) unsigned NOT NULL,
  `DislikeCount` bigint(20) unsigned NOT NULL,
  `Description` text NOT NULL,
  `UploadDate` datetime NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  UNIQUE KEY `SongLink_UNIQUE` (`VideoLink`),
  KEY `VideosToLogins_idx` (`ChannelID`),
  CONSTRAINT `VideosToLogins` FOREIGN KEY (`ChannelID`) REFERENCES `logins` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videos`
--

LOCK TABLES `videos` WRITE;
/*!40000 ALTER TABLE `videos` DISABLE KEYS */;
INSERT INTO `videos` VALUES (1,3,'dainuska','https://www.youtube.com/v/YnwsMEabmSo',128,5,15,'yrthtjtyjtyjtyjtyjtyj','2016-01-09 00:00:00'),(2,2,'lolas','https://www.youtube.com/v/mfLydx7DmDg',22,5,4,'eiryu54ty854 yt584793 yt 945uh3bhu3bvr','2016-01-11 00:00:00'),(3,2,'PUDIPAI','https://www.youtube.com/v/YEtxp_XZesw',3,7529,30,'e wjigiufehguwe oigheroui ghefuiog hefguioewhfgui','2016-01-10 00:00:00'),(4,1,'MINECRAFT IN REAL LIFE2','https://www.youtube.com/v/WjJjo4gXGCQ',42,11,3,'lol patasytas\r\n\r\nHAHAHHAHA','2016-01-12 00:00:00'),(5,1,'What Happens If You put Slime in','https://www.youtube.com/v/sQSXscWiZ04',8,1,1,'Glow in the Dark Slime - http://amzn.to/2jc6glJ\r\n\r\nVacuum Experiments - https://www.youtube.com/watch?v=qgjg4...\r\n\r\nFAN MAIL: \r\nCRAZY RUSSIAN HACKER\r\nP.O. Box 49\r\nWaynesville, NC 28786\r\n\r\nSubscribe to my 2nd channel https://www.youtube.com/user/origami768\r\n\r\nfollow me on:\r\ninstagram https://instagram.com/crazyrussianhac...\r\nfacebook - https://www.facebook.com/CrazyRussian...\r\n\r\n\r\nCrazyRussianHacker Playlists:\r\nScience Experiments - http://bit.ly/1Rnyw2m\r\nLife Hacks - http://bit.ly/22HUYIM\r\nSurvival Ideas - http://bit.ly/1Z2nnEV','2016-01-08 00:00:00'),(6,1,'President Trump Waves Goodbye','https://www.youtube.com/v/mWrzY78eZdo',5,1,1,'wf','2016-01-07 00:00:00'),(7,1,'My Year 2016 (MB)','https://www.youtube.com/v/1coC9foZ2e8',10,5,1,'Im getting on the normal year video loop and uploading in january instead of May so there is some old footage in here but still the same year! So enjoy this video a little earlier than usual!','2016-01-06 00:00:00'),(8,1,'GameOn 2016 | Ką ir kodėl žaidžią ','https://www.youtube.com/v/FQKvtE-WQLo',8,1,2,'Vaidas Baumila, Donalda Meiželytė, Dominykas Klajumas ir Jonas Nainys yra žaidėjai! Diskusijos metu, dalyviai ne tik atskleidė kokius žaidimus jie mėgsta labiausiai, tačiau ir pasidalino nuotaikingomis istorijomis iš virtualių pasaulių.\r\n\r\nhttp://www.gameon.lt/','2016-01-05 00:00:00'),(9,1,'SECRET SERVICE ARREST MY BROO','https://www.youtube.com/v/TnmEX6mpSHE',2,1,1,'I’m a 21 year old kid living in Hollywood. I make comedy vids, travel a lot, and I have a pretty colorful parrot named Maverick. This is my life.','2016-01-04 00:00:00'),(10,2,'Donald Trumps conflicts of interest','https://www.youtube.com/v/TSDC7CCyeGY',2,1,1,'When Americans talk about corruption in politics, they usually mean the outsize influence corporations and the wealthy can exert in politics through campaign donations. But President-elect Donald Trumps administration risks a much more direct type of corruption.','2016-01-03 00:00:00'),(11,1,'Fake news wasnt the biggest media','https://www.youtube.com/v/vdsj-PIqR0g',3,1,1,'Vox.com is a news website that helps you cut through the noise and understand what\'s really driving the events in the headlines.','2016-01-02 00:00:00'),(12,1,'Would you use time travel to kill bab','https://www.youtube.com//v/hJn8iUe6rwY',0,1,1,'Well? Would you? Voxs Phil Edwards asked author James Gleick about the history of this unusual philosophical question.','2016-01-01 00:00:00'),(13,5,'LOS ANGELES SUNSET DRONE MISSION!','https://www.youtube.com/v/fELR2Z39DGY',4,2,1,'Check out the Freeletics app here: http://frltcs.com/jonolsson\r\nhttp://instagram.com/jonolsson1\r\nhttp://instagram.com/marcusvaleur','2016-01-15 00:00:00'),(14,8,'Gandalf sax','https://www.youtube.com/v/BBGEG21CGo0',3,0,0,'ENJOY MY FIRST VID!!','2017-01-28 09:32:05');
/*!40000 ALTER TABLE `videos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'youtube'
--

--
-- Dumping routines for database 'youtube'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-28  9:38:35