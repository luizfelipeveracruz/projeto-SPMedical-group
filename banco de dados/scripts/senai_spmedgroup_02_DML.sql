USE MedicalGroup
GO

INSERT INTO tipoUsuario (tituloTipoUsuario)
VALUES ('Administrador'), ('Medico'), ('Paciente')
GO

INSERT INTO usuario (idTipoUsuario, email, senha)
VALUES (2,'ligia@gmail.com','ligia123', 3, 'alexandre@gmail.com', 'alexandre223', 1, 'fernando@gmail.com', 'fernando323',
2, 'henrique@gmail.com', 'henrique423', 1, 'joao@gmail.com', 'joao523', 3, 'bruno@gmail.com', 'bruno623')
GO