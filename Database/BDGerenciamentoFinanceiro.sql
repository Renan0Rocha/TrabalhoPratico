CREATE DATABASE GestaoFinanceira;
USE GestaoFinanceira;

-- Criação das tabelas

CREATE TABLE Funcionario (
    idFuncionario INT PRIMARY KEY NOT NULL KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    CPF VARCHAR(11),
    dataNascimento DATE,
    cargo VARCHAR(50)
);

CREATE TABLE Cliente (
    idCliente INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    cpf VARCHAR(11),
    email VARCHAR(100),
    telefone VARCHAR(50),
    dataNascimento DATE
);

CREATE TABLE Venda (
    idVenda INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    idCliente INT,
    idFuncionario INT,
    dataVenda DATE,
    hora TIME,
    valor DECIMAL(10, 2),
    desconto DECIMAL(10, 2),
    valorFinal DECIMAL(10, 2),
    tipo VARCHAR(50),
    FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
    FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario)
);

CREATE TABLE Servico (
    idServico INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    descricao VARCHAR(255),
    preco DECIMAL(10, 2),
    tempo TIME
);

CREATE TABLE VendaServico (
    idVenda INT NOT NULL AUTO_INCREMENT,
    idServico INT NOT NULL,
    quantidade INT,
    valorUnitario double,
    PRIMARY KEY (idVenda, idServico),
    FOREIGN KEY (idVenda) REFERENCES Venda(idVenda) ON DELETE CASCADE,
    FOREIGN KEY (idServico) REFERENCES Servico(idServico)
);

CREATE TABLE Caixa(
    idCaixa INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    idFuncionario INT NOT NULL,
    saldoInicial DECIMAL(10, 2),
    totalEntradas DECIMAL(10, 2),
    totalSaidas DECIMAL(10, 2),
    status BOOLEAN,
    FOREIGN KEY (idFuncionario) REFERENCES Funcionario (idFuncionario)
);

CREATE TABLE Dispositivo(
    idDispositivo INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    aliquota DOUBLE,
    descricao VARCHAR(300),
    status BOOLEAN
);

CREATE TABLE Recebimento (
    idRecebimento INT PRIMARY KEY AUTO_INCREMENT,
    idCaixa INT,
    idVenda INT,
    valor DECIMAL(10, 2),
    dataVencimento DATE,
    dataPagamento DATE,
    status BOOLEAN,
    FOREIGN KEY (idVenda) REFERENCES Venda(idVenda),
    FOREIGN KEY (idCaixa) REFERENCES Caixa(idCaixa)
);

CREATE TABLE Encargo (
    idEncargo INT PRIMARY KEY AUTO_INCREMENT,
    idRecebimento INT,
    idDispositivo INT NOT NULL,
    valor DECIMAL(10, 2),
    descricao VARCHAR(300),
    FOREIGN KEY (idRecebimento) REFERENCES Recebimento(idRecebimento) ON DELETE CASCADE,
    FOREIGN KEY (idDispositivo) REFERENCES Dispositivo(idDispositivo)
);


CREATE TABLE Despesa(
    idDespesa INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    idCaixa INT ,
    valor DECIMAL(10, 2),
    descricao VARCHAR(300),
	dataVencimento DATE,
    dataPagamento DATE,
    status BOOLEAN,
    FOREIGN KEY (idCaixa) REFERENCES Caixa(idCaixa)
);


INSERT INTO Cliente (nome, CPF, email, telefone, dataNascimento) VALUES
('Ana Costa', '34567890123', 'ana.costa@example.com', '555-1234', '1980-04-15'),
('Carlos Dias', '45678901234', 'carlos.dias@example.com', '555-5678', '1985-06-20'),
('Bruno Ribeiro', '04566547891', 'bruno.dias@example.com', '555-999', '1990-07-20'),
('Lucia Fernandes', '56789012345', 'lucia.fernandes@example.com', '555-9012', '1990-08-25');

