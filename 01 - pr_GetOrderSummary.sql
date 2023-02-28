  CREATE PROCEDURE  pr_GetOrderSummary
  @StartDate DATETIME,
  @EndDate DATETIME,
  @EmployeeID INT =  NULL,
  @CustomerID nchar(5) =  NULL
  /*
  Author: Jephren Naicker
  Date : 2023/02/23
  Description: return a summary of orders with filters optional

  exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL
  
  exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL
  
  exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'
  
  exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'



  */
  AS
  BEGIN

    SELECT 
           CONCAT(emp.TitleOfCourtesy,emp.FirstName,emp.LastName)[EmployeeFullName],
    	   shp.CompanyName[Shipper CompanyName],
    	   cus.CompanyName[Customer CompanyName],
    	   COUNT(Distinct ord.OrderID)[NumberOfOders],--maybe bug here
    	   CAST((dateadd(DAY,0, datediff(day,0, Ord.OrderDate))) as date),
    	   SUM(ord.Freight)[TotalFreightCost],
    	   Count(prd.ProductID)[NumberOfDifferentProducts],
    	   SUM(ROUND(CONVERT(money, Od.Quantity * (1 - OD.Discount) * Od.UnitPrice), 2))+ SUM(ord.Freight)[TotalOrderValue]
    FROM Orders [ord]
    JOIN Employees [emp]
      ON (ord.EmployeeID = emp.EmployeeID)
    JOIN Shippers [shp]
      ON (shp.ShipperID = ord.ShipVia)
    JOIN Customers [cus]
      ON (cus.CustomerID = ord.CustomerID)
    JOIN [Order Details] [OD]
      ON (OD.OrderID = ord.OrderID)
    JOIN Products [prd]
      ON (OD.ProductID = prd.ProductID)
   WHERE 
      CAST(ord.OrderDate as date) Between CAST(@StartDate as date) AND CAST(@EndDate as date)
      AND (@EmployeeID IS NULL  OR ord.EmployeeID = @EmployeeID)  
      AND (@CustomerID IS NULL  OR ord.CustomerID = @CustomerID)  
    GROUP BY CONCAT(emp.TitleOfCourtesy,emp.FirstName,emp.LastName),shp.CompanyName,cus.CompanyName, dateadd(DAY,0, datediff(day,0, Ord.OrderDate))
    ORDER BY [EmployeeFullName],[Customer CompanyName]

  END
 
