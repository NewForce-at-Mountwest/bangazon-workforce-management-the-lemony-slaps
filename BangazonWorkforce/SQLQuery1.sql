SELECT e.Id,
                       e.FirstName,
                       e.LastName,
                       e.DepartmentId,
                       e.isSuperVisor,
                    d.Name 
                    FROM Employee e
                    JOIN Department d ON e.DepartmentId = d.Id
