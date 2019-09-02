USE M_InLock;

SELECT * FROM Usuarios;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT J.*, E.*	
FROM Estudios E
INNER JOIN Jogos AS J
ON E.EstudioId = J.EstudioId;

CREATE PROCEDURE 
BuscarPorEmailESenha @Email nvarchar(30), @Senha varchar(30)
AS
SELECT * FROM Usuarios WHERE Email = @Email;

EXEC BuscarPorEmailESenha @Email = 'admin@admin.com', @Senha = 'admin';


CREATE PROCEDURE 
BuscarPorJogoId @JogoId varchar(255)
AS
SELECT * FROM Jogos WHERE JogoId = @JogoId

EXEC BuscarPorJogoId @JogoId = 2;


CREATE PROCEDURE 
BuscarPorEstudioId @EstudioId varchar(255)
AS
SELECT * FROM Estudios WHERE EstudioId = @EstudioId

EXEC BuscarPorEstudioId @EstudioId =  2;

