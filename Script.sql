--Script para criação da tabela
CREATE TABLE USUARIO(
	ID			UNIQUEIDENTIFIER		PRIMARY KEY,
	NOME		VARCHAR(100)			NOT NULL,
	EMAIL		VARCHAR(50)				NOT NULL,
	SENHA		VARCHAR(100)			NOT NULL)
GO

--Script para criação da procedure
CREATE PROCEDURE PROC_INSERIR_USUARIO
	@NOME VARCHAR(100), --Parametro de entrada
	@EMAIL VARCHAR(50), --Parametro de entrada
	@SENHA VARCHAR(100) --Parametro de entrada
AS
BEGIN
	--Verificar se já existe um usuario com o email informado
	IF EXISTS (SELECT 1 FROM USUARIO WHERE EMAIL = @EMAIL)
	BEGIN
		-- Gerando uma mensagem de erro
		RAISERROR('O email informado já está cadastrado', 16, 1); 
		RETURN; --Finalizando a procedure
	END

	--Inserir o usuario no banco de dados
	INSERT INTO USUARIO(ID, NOME, EMAIL, SENHA)
	VALUES(NEWID(),@NOME, @EMAIL, @SENHA);

END
GO
