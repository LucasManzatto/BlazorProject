CREATE TABLE Generations(
   id             INTEGER  NOT NULL PRIMARY KEY 
  ,main_region_id INTEGER  NOT NULL
  ,identifier     VARCHAR(14) NOT NULL
);
INSERT INTO Generations(id,main_region_id,identifier) VALUES (1,1,'generation-i');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (2,2,'generation-ii');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (3,3,'generation-iii');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (4,4,'generation-iv');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (5,5,'generation-v');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (6,6,'generation-vi');
INSERT INTO Generations(id,main_region_id,identifier) VALUES (7,7,'generation-vii');