SELECT TOP 5 * FROM Evento ORDER BY FechaHora ASC;

SELECT * FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  ORDER BY FechaHora ASC;


SELECT * FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  inner join Tema t ON t.Id = et.Tema_Id ORDER BY FechaHora ASC;


SELECT *
FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  
inner join Tema t ON t.Id = et.Tema_Id ORDER BY e.FechaHora ASC; 

SELECT *
FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  
inner join Tema t ON t.Id = et.Tema_Id 
inner join Evento_Integrante ei ON e.Id = ei.Evento_Id 
inner join Integrante i ON i.Id = ei.Integrante_Id
ORDER BY e.FechaHora ASC

SELECT e.*, t.Id AS TemaId, i.Id AS IntegranteId
FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  
inner join Tema t ON t.Id = et.Tema_Id 
inner join Evento_Integrante ei ON e.Id = ei.Evento_Id 
inner join Integrante i ON i.Id = ei.Integrante_Id
ORDER BY e.FechaHora ASC

SELECT e.*, t.Id AS TemaId, t.Nombre AS Tema, i.Id AS IntegranteId, i.Nombre AS Integrantes
FROM Evento e inner join Evento_Tema et ON e.Id = et.Evento_Id  
inner join Tema t ON t.Id = et.Tema_Id 
inner join Evento_Integrante ei ON e.Id = ei.Evento_Id 
inner join Integrante i ON i.Id = ei.Integrante_Id
ORDER BY e.FechaHora ASC