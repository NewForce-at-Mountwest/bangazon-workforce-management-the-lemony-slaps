Select d.[Name] AS 'Department Name', d.Budget, (SELECT COUNT(e.DepartmentId) FROM Employee e WHERE e.DepartmentId=d.id) AS 'Num of Employees'
FROM Department d