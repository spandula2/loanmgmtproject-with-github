-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 02, 2023 at 06:07 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_loan_mgmt_system`
--
CREATE DATABASE IF NOT EXISTS `db_loan_mgmt_system` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_loan_mgmt_system`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_customer_details`
--

DROP TABLE IF EXISTS `tbl_customer_details`;
CREATE TABLE IF NOT EXISTS `tbl_customer_details` (
  `CustId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `CompanyName` varchar(200) DEFAULT NULL,
  `Designation` varchar(100) DEFAULT NULL,
  `Salary` decimal(10,2) DEFAULT 0.00,
  `Email` varchar(100) DEFAULT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `Roles` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`CustId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_customer_details`
--

INSERT INTO `tbl_customer_details` (`CustId`, `Name`, `FirstName`, `LastName`, `CompanyName`, `Designation`, `Salary`, `Email`, `Phone`, `Password`, `Roles`) VALUES
(1, 'Azar', 'Azaruddin', 'Bhadgavkar', 'Nityo Infotech', 'Software Developer', '62700.00', 'azaruddinbhadgavkar1111@gmail.com', '08408098804', '8408098804', 'Management'),
(2, 'Azaruddin', 'Azaruddin', 'Bhadgavkar', 'Nityo Infotech', 'Software Developer', '62700.00', 'azaruddinbhadgavkar1111@gmail.com', '08408098804', '8408098804', 'Customer');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_offer_details`
--

DROP TABLE IF EXISTS `tbl_offer_details`;
CREATE TABLE IF NOT EXISTS `tbl_offer_details` (
  `OfferId` int(11) NOT NULL AUTO_INCREMENT,
  `OfferName` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`OfferId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_offer_details`
--

INSERT INTO `tbl_offer_details` (`OfferId`, `OfferName`) VALUES
(1, 'Home Loan '),
(2, 'Personal Loan '),
(3, 'Car Loan');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
