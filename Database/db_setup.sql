CREATE DATABASE  IF NOT EXISTS `InsuranceBrokerageDB`;
USE `InsuranceBrokerageDB`;


DROP TABLE IF EXISTS `Customer`;

CREATE TABLE `Customer` (
  `Id` int(15) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `PolicyType` ENUM("Public Liability", "Motor Fleet") DEFAULT NULL,
  `InsurerName` varchar(50) DEFAULT NULL,
  `Premium` double DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

LOCK TABLES `Customer` WRITE;

INSERT INTO `Customer` (Name, Address, PolicyType, InsurerName, Premium) VALUES ('XYZ Plumbing','24 Fleet Street, Glasgow','Public Liability','Allianz',2321.45);

UNLOCK TABLES;
