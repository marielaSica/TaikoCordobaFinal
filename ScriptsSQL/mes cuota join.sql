SELECT * FROM MesCuota 

SELECT * FROM Integrante i inner join MesCuota_Integrante mci ON i.Id = mci.IntegranteId inner join MesCuota mc ON mci.MesCuotaId = mc.Id

SELECT mc.*, i.Nombre AS Integrante FROM Integrante i inner join MesCuota_Integrante mci ON i.Id = mci.IntegranteId inner join MesCuota mc ON mci.MesCuotaId = mc.Id

SELECT mc.*, i.Nombre AS Integrante FROM MesCuota mc inner join MesCuota_Integrante mci ON mc.Id = mci.MesCuotaId inner join Integrante i ON i.Id = mci.IntegranteId

INSERT INTO MesCuota ( Monto , Fecha , Mes, TalonPago,Comentarios) VALUES (120 , '12/03/2017', '12/03/2017', 3, '' )

SELECT * FROM MesCuota_Pago mcp inner join MesCuota mc ON mcp.MesCuotaId = mc.Id  where mcp.PagoId = 1

SELECT mc.*, mc.Año AS AñoPago, mc.Mes AS MesPago FROM MesCuota_Pago mcp inner join MesCuota mc ON mcp.MesCuotaId = mc.Id  where mcp.PagoId = 1

SELECT Año, Mes , Total FROM MesCuota_Pago mcp inner join MesCuota mc ON mcp.MesCuotaId = mc.Id  where mcp.PagoId = 1