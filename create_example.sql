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

-- Дамп данных таблицы report.calendar: ~42 rows (приблизительно)
/*!40000 ALTER TABLE `calendar` DISABLE KEYS */;
REPLACE INTO `calendar` (`HDay`, `Day_type`) VALUES
	('2022-01-01', 1),
	('2022-01-02', 1),
	('2022-01-03', 1),
	('2022-01-04', 1),
	('2022-01-05', 1),
	('2022-01-06', 1),
	('2022-01-07', 1),
	('2022-01-08', 1),
	('2022-02-22', 2),
	('2022-02-23', 1),
	('2022-03-05', 2),
	('2022-03-07', 1),
	('2022-03-08', 1),
	('2022-05-01', 1),
	('2022-05-02', 1),
	('2022-05-03', 1),
	('2022-05-09', 1),
	('2022-05-10', 1),
	('2022-06-12', 1),
	('2022-06-13', 1),
	('2022-11-03', 2),
	('2022-11-04', 1),
	('2023-01-01', 1),
	('2023-01-02', 1),
	('2023-01-03', 1),
	('2023-01-04', 1),
	('2023-01-05', 1),
	('2023-01-06', 1),
	('2023-01-07', 1),
	('2023-01-08', 1),
	('2023-02-22', 2),
	('2023-02-23', 1),
	('2023-02-24', 1),
	('2023-03-07', 2),
	('2023-03-08', 1),
	('2023-05-01', 1),
	('2023-05-08', 1),
	('2023-05-09', 1),
	('2023-06-12', 1),
	('2023-11-03', 2),
	('2023-11-04', 1),
	('2023-11-06', 1);
/*!40000 ALTER TABLE `calendar` ENABLE KEYS */;

-- Дамп структуры для таблица report.day_code
DROP TABLE IF EXISTS `day_code`;
CREATE TABLE IF NOT EXISTS `day_code` (
  `CodeId` varchar(2) NOT NULL,
  `Name` varchar(300) NOT NULL,
  PRIMARY KEY (`CodeId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп данных таблицы report.day_code: ~11 rows (приблизительно)
/*!40000 ALTER TABLE `day_code` DISABLE KEYS */;
REPLACE INTO `day_code` (`CodeId`, `Name`) VALUES
	('В', 'выходные и праздничные дни'),
	('Б', 'дни временной нетрудоспособности'),
	('ОТ', 'ежегодный основной оплаченный отпуск'),
	('К', 'командировочные дни; а также, выходные (нерабочие) дни при нахождении в командировке, когда сотрудник отдыхает, в соответствии с графиком работы ООО «Наука» в командировке'),
	('До', 'неоплачиваемый отпуск(отпуск за свой счет)'),
	('У', 'отпуск на период обучения'),
	('Ож', 'Отпуск по уходу за ребенком'),
	('Н', 'отсутствие на рабочее место по невыясненным причинам'),
	('Я', 'полный рабочий день'),
	('Рв', 'работа в праздничные и выходные дни, а также работа в праздничные и выходные дни, при нахождении в командировке'),
	('Хд', 'хозяйственный день');
/*!40000 ALTER TABLE `day_code` ENABLE KEYS */;

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
	(1, 'Отдел кадров'),
	(3, 'Отдел разработки ПО'),
	(5, 'Отдел тестирования'),
	(4, 'Транспортный отдел');
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
	(1, 'Гордин', 'Алексей', 'Сергеевич', '1987-03-27', 'Разработчик', 'г. Барнаул, ул. Г.Исакова, д.183', 1, 3),
	(2, 'Иванов', 'Иван', 'Иванович', '1993-02-15', 'Табельщик', 'г. Барнаул, ул. Малахова, д. 74', 0, 1),
	(5, 'Петров', 'Петр', 'Петрович', '1983-09-25', 'Начальник отдела', 'г. Барнаул, ул. Петрова, д. 196', 0, 1),
	(6, 'Павлов', 'Павел', 'Павлович', '1973-05-10', 'Табельщик', 'г. Барнаул, ул. Павловский тракт, д. 100', 0, 1),
	(7, 'Федоров', 'Федор', 'Федорович', '1980-04-30', 'Тестировщик', 'г. Барнаул, ул. Партизанская, д. 90', 0, 3);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;

-- Дамп структуры для таблица report.report
DROP TABLE IF EXISTS `report`;
CREATE TABLE IF NOT EXISTS `report` (
  `EmpID` int(11) NOT NULL,
  `WorkDate` date NOT NULL,
  `CodeId` varchar(2) NOT NULL,
  PRIMARY KEY (`EmpID`,`WorkDate`) USING BTREE,
  KEY `fk_r_dc_idx` (`CodeId`),
  KEY `fk_r_emp_idx` (`EmpID`),
  KEY `fk_r_caleendar_idx` (`WorkDate`) USING BTREE,
  CONSTRAINT `fk_r_dc` FOREIGN KEY (`CodeId`) REFERENCES `day_code` (`CodeId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `fk_r_emp` FOREIGN KEY (`EmpID`) REFERENCES `employees` (`EmpID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=cp1251 COLLATE=cp1251_general_ci;

-- Дамп данных таблицы report.report: ~7 rows (приблизительно)
/*!40000 ALTER TABLE `report` DISABLE KEYS */;
REPLACE INTO `report` (`EmpID`, `WorkDate`, `CodeId`) VALUES
	(1, '2023-02-17', 'Б'),
	(1, '2023-01-08', 'В'),
	(1, '2023-02-01', 'В'),
	(5, '2023-01-11', 'ОТ'),
	(1, '0001-01-01', 'Рв'),
	(5, '2023-01-05', 'Рв'),
	(1, '2023-01-17', 'Я');
/*!40000 ALTER TABLE `report` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
