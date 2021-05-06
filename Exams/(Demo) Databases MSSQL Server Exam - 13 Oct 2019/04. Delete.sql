--04. Delete

DELETE
FROM	Issues
WHERE	Issues.RepositoryId IN (SELECT r.Id
                                  FROM Repositories AS r
								 WHERE [Name] = 'Softuni-Teamwork');
										  
DELETE
FROM	RepositoriesContributors
WHERE	RepositoriesContributors.RepositoryId IN (SELECT r.Id
													FROM Repositories AS r
												   WHERE [Name] = 'Softuni-Teamwork');