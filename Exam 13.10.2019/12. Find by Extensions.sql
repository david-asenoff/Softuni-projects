--12. Find by Extensions
CREATE PROC usp_FindByExtension @extension VARCHAR(30)
AS
	SELECT f.Id,f.[Name], CONCAT(f.Size, 'KB') AS Size FROM Files AS f
	 WHERE f.Name LIKE '%.'+@extension

--EXEC dbo.usp_FindByExtension 'txt'