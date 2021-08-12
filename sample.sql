SET IDENTITY_INSERT [Beverages] ON 

INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (1, 'Skol', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (2, 'Brahma', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (3, 'Stella', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())
INSERT INTO Beverages ([Id], [Name], [Price], [CreationDate], [LastWriteDate]) VALUES (4, 'Bohemia', ROUND(3 + RAND(), 2), GETDATE(), GETDATE())

SET IDENTITY_INSERT [Beverages] OFF

GO

