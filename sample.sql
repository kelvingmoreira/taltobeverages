/*********Dados para demonstração da API. Executar apenas uma vez.*********/

SET IDENTITY_INSERT [Beverages] ON 

INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (1, 'Skol', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (2, 'Brahma', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (3, 'Stella', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (4, 'Bohemia', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())

SET IDENTITY_INSERT [Beverages] OFF

GO

--Cashbacks SKOL
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 0, 0.25, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 1, 0.07, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 2, 0.06, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 3, 0.02, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 4, 0.10, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 5, 0.15, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (1, 6, 0.20, GETDATE(), GETDATE())

--Cashbacks BRAHMA
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 0, 0.30, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 1, 0.05, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 2, 0.10, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 3, 0.15, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 4, 0.20, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 5, 0.25, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (2, 6, 0.30, GETDATE(), GETDATE())

--Cashbacks STELLA
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 0, 0.35, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 1, 0.03, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 2, 0.05, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 3, 0.08, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 4, 0.13, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 5, 0.18, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (3, 6, 0.25, GETDATE(), GETDATE())

--Cashbacks BOHEMIA
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 0, 0.40, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 1, 0.10, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 2, 0.15, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 3, 0.15, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 4, 0.15, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 5, 0.20, GETDATE(), GETDATE())
INSERT INTO Cashbacks ([BeverageId], [DayOfWeek], [Value], [CreationDate], [LastWriteDate]) VALUES (4, 6, 0.40, GETDATE(), GETDATE())

GO



--Samples de ordens
SET IDENTITY_INSERT [Orders] ON 

INSERT INTO Orders ([Id], [DatePlaced], [TotalCashbackRefunded], [CreationDate], [LastWriteDate]) VALUES (1, '2021-01-07T00:00:00.00', 0, GETDATE(), GETDATE())
INSERT INTO Orders ([Id], [DatePlaced], [TotalCashbackRefunded], [CreationDate], [LastWriteDate]) VALUES (2, '2021-02-09T00:00:00.00', 0, GETDATE(), GETDATE())
INSERT INTO Orders ([Id], [DatePlaced], [TotalCashbackRefunded], [CreationDate], [LastWriteDate]) VALUES (3, '2021-03-02T00:00:00.00', 0, GETDATE(), GETDATE())
INSERT INTO Orders ([Id], [DatePlaced], [TotalCashbackRefunded], [CreationDate], [LastWriteDate]) VALUES (4, '2021-04-21T00:00:00.00', 0, GETDATE(), GETDATE())
INSERT INTO Orders ([Id], [DatePlaced], [TotalCashbackRefunded], [CreationDate], [LastWriteDate]) VALUES (5, '2021-05-29T00:00:00.00', 0, GETDATE(), GETDATE())

SET IDENTITY_INSERT [Orders] OFF

GO

--Samples de lançamentos

INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (1, 1, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (1, 2, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (1, 4, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())

INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (2, 2, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (2, 3, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())

INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (3, 1, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (3, 2, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (3, 3, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (3, 4, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())

INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (4, 4, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())

INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (5, 1, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())
INSERT INTO OrderEntries ([OrderId], [BeverageId], [CashbackRefunded], [Quantity], [CreationDate], [LastWriteDate]) VALUES (5, 4, 0, FLOOR(RAND() * 100) + 1, GETDATE(), GETDATE())

GO

MERGE INTO OrderEntries [oe]
   USING (SELECT 
	oe.Id,
	oe.Quantity,
	ROUND((SELECT [Value] FROM Cashbacks WHERE [DayOfWeek] =  DATEPART(weekday, o.DatePlaced) - 1 AND BeverageId = oe.[BeverageId] )  * oe.Quantity * b.Price, 2) [CashbackRefunded]
	FROM OrderEntries [oe]
	LEFT JOIN Orders [o] on [oe].OrderId = o.Id
	LEFT JOIN Beverages [b] on [oe].BeverageId = b.Id
	) [nv] 
ON [oe].Id = [nv].Id
WHEN MATCHED THEN
UPDATE SET [oe].[CashbackRefunded] = nv.CashbackRefunded;

MERGE INTO Orders [o]
   USING (SELECT OrderId, SUM([CashbackRefunded]) [TotalCashbackRefunded] From OrderEntries GROUP BY OrderId) [nv] 
ON [o].Id = [nv].OrderId
WHEN MATCHED THEN
UPDATE SET [o].[TotalCashbackRefunded] = nv.[TotalCashbackRefunded];
