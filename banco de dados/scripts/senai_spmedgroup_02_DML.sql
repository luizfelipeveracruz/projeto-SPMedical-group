USE MedicalGroup_LF
GO

INSERT INTO tipoUsuario (tituloTipoUsuario)
VALUES ('Administrador'), ('Medico'), ('Paciente')
GO

INSERT INTO usuario (idTipoUsuario, email, senha, nome)
VALUES (2, 'ligia@gmail.com', 'ligia123', 'Ligia'),
(3, 'alexandre@gmail.com', 'alexandre223', 'Alexandre'),
(1, 'fernando@gmail.com', 'fernando323', 'Fernando'),
(2, 'henrique@gmail.com', 'henrique423', 'Henrique'), 
(1, 'joao@gmail.com', 'joao523', 'João'),
(3, 'bruno@gmail.com', 'bruno623', 'Bruno'),
(3, 'mariana@outlook', 'mariana723', 'Mariana'),
(1, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123', 'Ricardo'),
(1, 'roberto.possarle@spmedicalgroup.com.br', 'roberto123', 'Roberto'),
(1, 'helena.souza@spmedicalgroup.com.br', 'helena123', 'Helena'),
(1, 'adm@adm.com', 'adm123', 'Administrador');
GO

SELECT * FROM usuario
GO

SELECT * FROM clinica
GO

INSERT INTO clinica (nomeFantasia, CNPJ, razaoSocial, endereco)
VALUES ('Clinica Possarle', '86.400.902/0001', 'Sp Medical Group', 'Av.Barão de Limeira, 535, São Paulo, SP'
);
GO

INSERT INTO especializacao (tipoEspecialidade)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'), ('Cirurgia da Mão'),
('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediátrica'), ('Cirurgia Plástica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), 
('Dermatologia'), ('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria');
GO

SELECT * FROM usuario
GO
SELECT * FROM medico
GO


INSERT INTO medico(idClinica, idUsuario, idEspecializacao, nomeMedico, CRM)
VALUES (1, 1, 2, 'Ricardo Lemos', '54356SP'),
(1, 1, 17,	'Roberto Possarle',	'53452SP'),
(1, 1, 16,	'Helena Strada', '65463SP');
GO


INSERT INTO paciente(IdUsuario, nomePaciente, dataNascimento, telefone, rg, cpf, endereco)
VALUES (1, 'Ligia', '1992-6-13', '1197263923', '952637804','94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
(2, 'Alexandre', '2001-07-23', '11987972043','326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
(3, 'Fernando', '1988-10-10', '11971223453',	'546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
(4, 'Henrique', '1975-10-13', '11934566298', '543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(5, 'João', '1964-08-27', '1176566377', '532544441', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
(6, 'Bruno', '1982-03-21', '11954368769', '545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
(7, 'Mariana',	'2000-03-05', '11926783129', '545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

SELECT * FROM consulta
GO

INSERT INTO situacao(situacao)
VALUES ('Agendada'),('Realizada'),('Cancelada');
GO

INSERT INTO consulta(idPaciente, idMedico, idSituacao, dataConsulta, descricao)
VALUES (7, 3, 2, '20201020 03:00:00 PM', null),
(2, 2, 3, '20200601 10:30:00 AM', 'Consulta Cancelada'),
(3, 2, 2, '20200702 11:00:00 AM', null),
(5, 2, 2, '20180602 08:40:00 AM', null),
(4, 1, 3, '20190702 12:00:00 AM', 'Consulta Cancelada'),
(7, 3, 1,'20200803 03:00:00 PM', 'Consulta Agendada'),
(4, 1, 1, '20200903 11:00:00 PM', 'Consulta Agendada');
GO