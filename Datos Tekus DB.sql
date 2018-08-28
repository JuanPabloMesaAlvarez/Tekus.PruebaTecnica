
INSERT INTO Countries (CountryId, Name) VALUES (1,'Colombia'),(2,'Brasil'),(3,'Ecuador')
,(4,'Venezuela'),(5,'Bolivia'),(6,'Uruaguay'),(7,'Paraguay'),(8,'Peru'),(9,'Argentina'),(10,'Chile')

INSERT INTO Customers (Nit, Name, Email) 
VALUES (890010999, 'ESPACIAL', 'espacial@espacial.com'),(890010998, 'QUANTICA', 'quantica@quantica.com'),(890010997, 'HIDRAULICA', 'hidraulica@hidraulica.com'),
(890010996, 'ALGORITMICO', 'algoritmico@algoritmico.com'),(890010995, 'EXPONENCIAL', 'exponencial@exponencial.com'),(890010994, 'INTERPLANETARIO', 'interplanetario@interplanetario.com'),
(890010993, 'MAGNETICO', 'magnetico@magnetico.com'),(890010992, 'BINARIO', 'binario@binario.com'),(890010991, 'NEUTRON', 'neutron@neutron.com'),
(890010990, 'PROTON', 'proton@proton.com')


INSERT INTO Services (Name, Cost, CustomerId) VALUES ('LANZAMIENTO ESPACIAL', 1500, 1),('SISTEMAS QUANTICOS', 130, 2),('CREACION DE AGUJEROS NEGROS', 23500, 3),
('VIAJE INTERESPACIAL', 200, 4),('DESTRUCCION DE MASA', 2000, 5),('CARGA DE MOTOR DE PROTONES', 340, 6),('ATERRIZAJE ESPACIAL', 500, 7),('VIAJE INTERPLANETARIO', 120, 8),
('CARGA MAGNETICA DE ESTRELLAS', 12000, 9),('BUSQUEDA BINARIA ESPACIAL', 8000, 10),('LIMPIEZA HIDRAULICA DE NAVE', 50, 8),('CARGA EXPONENCIAL DE MOTOR 7', 6400, 5),
('ALINEAMIENTO ALGORITMICO DE COHETES', 2100, 3),('RECARGA DE NEUTRON 543', 320, 1),('DESCOMPOSICION DE VORTICES', 9500, 4)


INSERT INTO ServicesCountries (ServiceId, CountryId) VALUES 
(4, 1), (1, 2),(12, 3),(13, 4),(6, 5),(8, 6),(9, 7),(4, 8),(2, 9),(3,10),
(1, 7),(5, 8),(9, 9),(1,10)