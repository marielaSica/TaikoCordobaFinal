SELECT * FROM MesCuota 

SELECT * FROM MesCuota mc inner join MesCuota_Pago mcp ON mcp.MesCuotaId = mc.Id inner join Pago p ON mcp.PagoId = p.Id

SELECT A�o, Mes, p.Monto, p.Fecha AS FechaPago, p.TalonPago, p.Comentarios, p.IntegranteId AS Integrante 
FROM MesCuota mc inner join MesCuota_Pago mcp ON mcp.MesCuotaId = mc.Id 
inner join Pago p ON mcp.PagoId = p.Id

SELECT A�o, Mes, p.Monto, p.Fecha AS FechaPago, p.TalonPago, p.Comentarios, p.IntegranteId AS Integrante, Total
                                            FROM MesCuota mc inner join MesCuota_Pago mcp ON mcp.MesCuotaId = mc.Id 
                                            inner join Pago p ON mcp.PagoId = p.Id 