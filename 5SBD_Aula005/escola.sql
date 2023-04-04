-- phpMyAdmin SQL Dump
-- version 4.8.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 04-Abr-2023 às 14:13
-- Versão do servidor: 10.1.31-MariaDB
-- PHP Version: 7.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `escola`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno`
--

CREATE TABLE `aluno` (
  `id` int(11) NOT NULL,
  `nome` varchar(150) NOT NULL,
  `matricula` varchar(150) NOT NULL,
  `email` varchar(150) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `aluno`
--

INSERT INTO `aluno` (`id`, `nome`, `matricula`, `email`) VALUES
(1, 'Ana', '1', 'ana@email.com'),
(2, 'lucas', '2', 'lucas@email.com'),
(3, 'joana', '3', 'joana@email.com'),
(4, 'felipe', '4', 'felipe@email.com'),
(5, 'maria', '5', 'maria@email.com');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluno_turma`
--

CREATE TABLE `aluno_turma` (
  `idAluno` int(11) NOT NULL,
  `idTurma` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `aluno_turma`
--

INSERT INTO `aluno_turma` (`idAluno`, `idTurma`) VALUES
(1, 1),
(5, 1),
(4, 2),
(1, 3),
(3, 3),
(1, 2),
(5, 3),
(4, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `matricula`
--

CREATE TABLE `matricula` (
  `id` int(11) NOT NULL,
  `idAluno` int(11) NOT NULL,
  `idTurma` int(11) NOT NULL,
  `av1` float NOT NULL,
  `av2` float NOT NULL,
  `media` float NOT NULL,
  `faltas` int(11) NOT NULL,
  `status` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `matricula`
--

INSERT INTO `matricula` (`id`, `idAluno`, `idTurma`, `av1`, `av2`, `media`, `faltas`, `status`) VALUES
(1, 1, 1, 6, 7, 6.5, 4, 1),
(2, 5, 1, 9, 9, 9, 0, 1),
(3, 4, 2, 5, 6, 5.5, 12, 0),
(4, 1, 3, 7, 8, 7.5, 0, 1),
(5, 3, 3, 8, 8, 8, 4, 0),
(6, 1, 2, 4, 5, 4.5, 16, 0),
(7, 5, 3, 10, 9, 9.5, 0, 0),
(8, 4, 1, 6, 6, 6, 0, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `turma`
--

CREATE TABLE `turma` (
  `id` int(11) NOT NULL,
  `codigo` varchar(50) NOT NULL,
  `sigla` varchar(50) NOT NULL,
  `nome` varchar(250) NOT NULL,
  `turno` varchar(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `turma`
--

INSERT INTO `turma` (`id`, `codigo`, `sigla`, `nome`, `turno`) VALUES
(1, 'TM001', '5SBD', 'Script de Banco de Dados', 'noite'),
(2, 'TM002', '5TAV', 'Topicos Avancados', 'noite'),
(3, 'TM003', '5ADS', 'Analise e Desenvolvimento de sistema', 'noite');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aluno`
--
ALTER TABLE `aluno`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `matricula`
--
ALTER TABLE `matricula`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `turma`
--
ALTER TABLE `turma`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aluno`
--
ALTER TABLE `aluno`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `matricula`
--
ALTER TABLE `matricula`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `turma`
--
ALTER TABLE `turma`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
