-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.10.3-MariaDB - mariadb.org binary distribution
-- Операционная система:         Win64
-- HeidiSQL Версия:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных report
DROP DATABASE IF EXISTS `report`;
CREATE DATABASE IF NOT EXISTS `report` /*!40100 DEFAULT CHARACTER SET cp1251 COLLATE cp1251_general_ci */;
USE `report`;

-- Дамп структуры для таблица report.calendar
DROP TABLE IF EXISTS `calendar`;
CREATE TABLE IF NOT EXISTS `calendar` (
  `HDay` date NOT NULL,
  `Day_type` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`HDay`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп структуры для таблица report.day_code
DROP TABLE IF EXISTS `day_code`;
CREATE TABLE IF NOT EXISTS `day_code` (
  `CodeId` varchar(2) NOT NULL,
  `Name` varchar(300) NOT NULL,
  PRIMARY KEY (`CodeId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп структуры для таблица report.departments
DROP TABLE IF EXISTS `departments`;
CREATE TABLE IF NOT EXISTS `departments` (
  `DepId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`DepId`),
  UNIQUE KEY `name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп данных таблицы report.departments: ~4 rows (приблизительно)
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
REPLACE INTO `departments` (`DepId`, `Name`) VALUES
	(1, 'Отдел кадров');
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;

-- Дамп структуры для таблица report.employees
DROP TABLE IF EXISTS `employees`;
CREATE TABLE IF NOT EXISTS `employees` (
  `EmpID` int(11) NOT NULL AUTO_INCREMENT,
  `LastName` varchar(45) NOT NULL,
  `FirstName` varchar(45) NOT NULL,
  `MiddleName` varchar(45) DEFAULT NULL,
  `BirthDay` date NOT NULL,
  `Post` varchar(100) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `RemoteWork` tinyint(4) NOT NULL DEFAULT 0,
  `DepId` int(11) DEFAULT NULL,
  PRIMARY KEY (`EmpID`),
  KEY `fk_emp_dep_idx` (`DepId`),
  CONSTRAINT `fk_emp_dep` FOREIGN KEY (`DepId`) REFERENCES `departments` (`DepId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп данных таблицы report.employees: ~5 rows (приблизительно)
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
REPLACE INTO `employees` (`EmpID`, `LastName`, `FirstName`, `MiddleName`, `BirthDay`, `Post`, `Address`, `RemoteWork`, `DepId`) VALUES
	(1, 'Админов', 'Админ', 'Админович', '1987-03-27', 'Табельщик', 'Интернет', 1, 1);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;

-- Дамп структуры для таблица report.report
DROP TABLE IF EXISTS `report`;
CREATE TABLE IF NOT EXISTS `report` (
  `EmpID` int(11) NOT NULL,
  `WorkDate` date NOT NULL,
  `CodeId` varchar(2) NOT NULL,
  PRIMARY KEY (`EmpID`,`WorkDate`,`CodeId`) USING BTREE,
  KEY `fk_r_dc_idx` (`CodeId`),
  KEY `fk_r_emp_idx` (`EmpID`),
  CONSTRAINT `fk_r_dc` FOREIGN KEY (`CodeId`) REFERENCES `day_code` (`CodeId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fk_r_emp` FOREIGN KEY (`EmpID`) REFERENCES `employees` (`EmpID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
