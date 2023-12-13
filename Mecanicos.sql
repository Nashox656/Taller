-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 11-12-2023 a las 01:21:17
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.1.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `TallerMec`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Mecanicos`
--

CREATE TABLE `Mecanicos` (
  `IdMecanico` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Edad` int(2) NOT NULL,
  `Domicilio` varchar(100) NOT NULL,
  `Titulo` varchar(100) NOT NULL,
  `Especialidad` varchar(100) NOT NULL,
  `SueldoBase` int(5) NOT NULL,
  `GratTitulo` int(5) NOT NULL,
  `SueldoTotal` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `Mecanicos`
--
ALTER TABLE `Mecanicos`
  ADD PRIMARY KEY (`IdMecanico`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `Mecanicos`
--
ALTER TABLE `Mecanicos`
  MODIFY `IdMecanico` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
