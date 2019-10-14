--Section 4. Programmability
--11. User Total Commits
CREATE FUNCTION udf_UserTotalCommits (@username VARCHAR (50))
RETURNS INT
AS
	BEGIN
  DECLARE @count INT = (SELECT COUNT(*) FROM Users AS u
						  JOIN Commits AS c ON u.Id = c.ContributorId
						 WHERE u.Username=@username)
   RETURN @count
END

--SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')