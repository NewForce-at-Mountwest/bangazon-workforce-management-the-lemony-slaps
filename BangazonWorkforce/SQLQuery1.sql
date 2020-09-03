<<<<<<< HEAD
﻿SELECT ce.Id, ce.EmployeeId, ce.ComputerId, ce.AssignDate, ce.UnassignDate, c.Make, c.Manufacturer FROM ComputerEmployee ce 
                      RIGHT JOIN Computer c ON ce.ComputerId = c.id
                      RIGHT JOIN Employee e ON ce.EmployeeId = e.id 
                      WHERE ce.UnassignDate IS NOT NULL AND e.Id =2

 SELECT e.Id, e.FirstName, e.LastName, e.isSupervisor, e.DepartmentId, c.Make, c.Manufacturer
       FROM Employee e JOIN ComputerEmployee ce ON ce.EmployeeId = e.id JOIN Computer c ON c.id = ce.ComputerId
       WHERE e.Id = 2 AND ce.UnassignDate IS NULL

SELECT 
  mt.my_row,
 (SELECT COUNT(mt2.my_row) FROM my_table mt2 WHERE mt2.foo = mt.foo) as cnt
FROM my_table mt
WHERE mt.foo = 'bar'

Select d.[Name] AS 'Department Name', d.Budget, (SELECT COUNT(e.DepartmentId) FROM Employee e WHERE e.DepartmentId=d.id) AS 'Num of Employees'
FROM Department d 

SELECT ce.Id, ce.EmployeeId, ce.ComputerId, ce.AssignDate, ce.UnassignDate, c.Make, c.Manufacturer FROM ComputerEmployee ce JOIN Computer c ON ce.ComputerId = c.id
                        WHERE ce.UnassignDate IS NOT NULL
=======
﻿SELECT e.Id,
                       e.FirstName,
                       e.LastName,
                       e.DepartmentId,
                       e.isSuperVisor,
                    d.Name 
                    FROM Employee e
                    JOIN Department d ON e.DepartmentId = d.Id
>>>>>>> master
