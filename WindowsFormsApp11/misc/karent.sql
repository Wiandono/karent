-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.21-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win32
-- HeidiSQL Version:             9.4.0.5174
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for karent
CREATE DATABASE IF NOT EXISTS `karent` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `karent`;

-- Dumping structure for table karent.booking
CREATE TABLE IF NOT EXISTS `booking` (
  `booking_id` int(5) NOT NULL AUTO_INCREMENT,
  `id_cars` int(5) NOT NULL,
  `id_user` int(5) NOT NULL,
  `pick_date` varchar(10) NOT NULL,
  `drop_date` varchar(10) NOT NULL,
  `location` varchar(50) NOT NULL,
  `return` int(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`booking_id`),
  KEY `id_cars` (`id_cars`),
  KEY `id_user` (`id_user`),
  CONSTRAINT `cars` FOREIGN KEY (`id_cars`) REFERENCES `cars` (`cars_id`),
  CONSTRAINT `user` FOREIGN KEY (`id_user`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- Dumping data for table karent.booking: ~15 rows (approximately)
/*!40000 ALTER TABLE `booking` DISABLE KEYS */;
INSERT INTO `booking` (`booking_id`, `id_cars`, `id_user`, `pick_date`, `drop_date`, `location`, `return`) VALUES
	(1, 1, 1, '10/22/2017', '10/23/2017', 'Bandara Abdul Rachman Saleh', 1),
	(2, 1, 1, '10/22/2017', '10/23/2017', 'Universitas Brawijaya', 1),
	(3, 2, 1, '10/22/2017', '10/23/2017', 'Alun-Alun Malang', 1),
	(4, 3, 1, '10/23/2017', '10/24/2017', 'Stasiun Malang Kota', 1),
	(5, 3, 1, '10/24/2017', '10/25/2017', 'Stasiun Malang Kota', 1),
	(6, 1, 1, '10/24/2017', '10/25/2017', 'Taman Krida Budaya', 1),
	(7, 1, 1, '10/24/2017', '10/25/2017', 'Taman Krida Budaya', 0),
	(8, 1, 1, '10/24/2017', '10/25/2017', 'Universitas Brawijaya', 0),
	(9, 1, 1, '10/24/2017', '10/25/2017', 'Universitas Brawijaya', 0),
	(10, 1, 1, '10/24/2017', '10/25/2017', 'Taman Krida Budaya', 0),
	(11, 14, 1, '10/24/2017', '10/27/2017', 'Alun-Alun Malang', 0),
	(12, 14, 1, '10/24/2017', '10/25/2017', 'Stasiun Malang Kota', 1),
	(13, 7, 1, '10/25/2017', '11/29/2017', 'Alun-Alun Malang', 1),
	(16, 1, 5, '10/24/2017', '10/25/2017', 'Stasiun Malang Kota', 1),
	(17, 3, 5, '10/24/2017', '10/26/2017', 'Bandara Abdul Rachman Saleh', 1);
/*!40000 ALTER TABLE `booking` ENABLE KEYS */;

-- Dumping structure for table karent.cars
CREATE TABLE IF NOT EXISTS `cars` (
  `cars_id` int(5) NOT NULL AUTO_INCREMENT,
  `image` varchar(35) NOT NULL DEFAULT '0',
  `name` varchar(20) NOT NULL,
  `category` varchar(10) NOT NULL,
  `capacity` int(5) NOT NULL,
  `transmission` varchar(10) NOT NULL,
  `price` int(10) NOT NULL,
  `stock` int(5) NOT NULL,
  PRIMARY KEY (`cars_id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- Dumping data for table karent.cars: ~15 rows (approximately)
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` (`cars_id`, `image`, `name`, `category`, `capacity`, `transmission`, `price`, `stock`) VALUES
	(1, 'Agya.png', 'Toyota Agya', 'Kecil', 5, 'Automatic', 350000, 3),
	(2, 'Ayla.png', 'Daihatsu Ayla', 'Kecil', 5, 'Automatic', 350000, 7),
	(3, 'Brio.jpg', 'Honda Brio', 'Kecil', 5, 'Manual', 325000, 1),
	(4, 'March.jpg', 'Nissan March', 'Kecil', 5, 'Automatic', 350000, 10),
	(5, 'Vios_color.jpg', 'Toyota Vios', 'Kecil', 5, 'Automatic', 400000, 4),
	(6, 'Lancer.jpg', 'Mitsubishi Lancer', 'Kecil', 5, 'Manual', 400000, 9),
	(7, 'Avanza.jpg', 'Toyota Avanza', 'Sedang', 8, 'Automatic', 600000, 9),
	(8, 'Xenia.jpeg', 'Daihatsu Xenia', 'Sedang', 8, 'Automatic', 600000, 6),
	(9, 'Mobilio.jpg', 'Honda Mobilio', 'Sedang', 8, 'Manual', 550000, 1),
	(10, 'Livina.png', 'Nissan Livina', 'Sedang', 8, 'Manual', 550000, 4),
	(11, 'Gran Max.jpg', 'Daihatsu Gran Max', 'Sedang', 8, 'Manual', 600000, 4),
	(12, 'Innova.jpg', 'Toyota Innova', 'Sedang', 8, 'Automatic', 700000, 3),
	(13, 'Fortuner.jpg', 'Toyota Fortuner', 'Sedang', 8, 'Manual', 750000, 1),
	(14, 'Elf Short.jpg', 'Isuzu Elf Short', 'Besar', 10, 'Manual', 850000, 8),
	(15, 'Hiace.png', 'Toyota Hiace', 'Besar', 14, 'Manual', 900000, 1);
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;

-- Dumping structure for table karent.user
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(4) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Dumping data for table karent.user: ~4 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`user_id`, `username`, `password`) VALUES
	(1, 'wian', 'Mozilla'),
	(2, 'dicang', 'Firefox'),
	(3, 'Andy', 'Mozill'),
	(4, 'matata', 'hakuna'),
	(5, 'kahlma', 'kanggul');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
