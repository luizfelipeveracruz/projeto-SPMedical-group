USE MedicalGroup_LF
GO

--Selects simples para mostrar as tabelas
SELECT * FROM clinica;
SELECT * FROM tipoUsuario;
SELECT * FROM especializacao ORDER BY idEspecializacao asc;
SELECT * FROM usuario ORDER BY IdUsuario asc;
SELECT * FROM paciente;
SELECT * FROM medico;
SELECT * FROM situacao;
SELECT * FROM consulta;
GO

--Mostrar Consulta com todas as informa��es necess�rias:
SELECT nomePaciente 'Paciente', nomeMedico 'M�dico', FORMAT(dataConsulta, 'dd/MM/yyyy hh.mm') 'Data da Consulta', situacao, nomeFantasia 'Clinica'
FROM consulta
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
InNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao
ORDER BY consulta.idConsulta asc;
GO

--Mostrar a quantidade de usu�rios:
SELECT COUNT(idUsuario) 'Quantidade de usu�rios' FROM usuario;
GO
