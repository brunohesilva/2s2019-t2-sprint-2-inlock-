USE M_InLock;

INSERT INTO Usuarios (Email, Senha, Permissao) 
	VALUES	('admin@admin.com', 'admin', 'ADMINISTRADOR')
			,('cliente@cliente.com', 'cliente', 'CLIENTE');

INSERT INTO Estudios (NomeEstudio, PaisOrigem, DataCriacao, UsuarioId)
	VALUES	('Blizzard', 'EUA', '1991-05-24', 1)
			,('Rockstar Studios', 'EUA', '1994-09-17', 1)
			,('Square Enix', 'Jap�o', '2003-04-01', 1);

INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
	VALUES	('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '2012-05-15', 99, 1)
			,('Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '2018-10-26' , 120, 2);