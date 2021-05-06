--08. Non-Directory Files

  SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS Size
	FROM Files AS f
   WHERE f.Id NOT IN (
						SELECT f2.ParentId 
						  FROM Files AS f2
						 WHERE f2.ParentId IS NOT NULL
					 )
ORDER BY f.Id,
	     f.[Name],
		 f.Size DESC