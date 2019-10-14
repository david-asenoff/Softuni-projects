--09. Most Contributed Repositories
SELECT TOP (5) rc.RepositoryId AS Id,
			   r.Name, 
			   COUNT(rc.RepositoryId) AS Commits 
	  FROM Commits AS c
 LEFT JOIN Repositories AS r ON r.Id=c.RepositoryId
 LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId=r.Id
  GROUP BY rc.RepositoryId,r.[Name]
  ORDER BY Commits DESC, rc.RepositoryId ASC, r.[Name] ASC