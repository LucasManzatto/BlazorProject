
CREATE TABLE growth_rate(
   id         INTEGER  NOT NULL
  ,[name]     VARCHAR(6) NOT NULL
  ,[formula]  VARCHAR(388) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE main_region(
   id         INTEGER  NOT NULL
  ,[name]       VARCHAR(6) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE Generation(
   [id]             INTEGER  NOT NULL
  ,[main_region_id] INTEGER  NOT NULL
  ,[name]     VARCHAR(14) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Generation_Main_Region FOREIGN KEY (main_region_id) REFERENCES main_region(id)
);

CREATE TABLE Species(
   id                      INTEGER  NOT NULL
  ,[name]				   VARCHAR(12) NOT NULL
  ,generation_id           INTEGER  NOT NULL
  ,evolves_from_species_id INTEGER 
  ,evolution_chain         INTEGER  NOT NULL
  ,gender_rate             INTEGER  NOT NULL
  ,capture_rate            INTEGER  NOT NULL
  ,base_happiness          INTEGER  NOT NULL
  ,is_baby                 BIT  NOT NULL
  ,hatch_counter           INTEGER  NOT NULL
  ,has_gender_differences  BIT  NOT NULL
  ,growth_rate_id          INTEGER  NOT NULL
  ,forms_switchable        BIT  NOT NULL
  ,position                INTEGER  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Species_Generation FOREIGN KEY (generation_id) REFERENCES Generation(id)
  ,CONSTRAINT FK_Species_Evolves_From_Species FOREIGN KEY (evolves_from_species_id) REFERENCES Species(id)
  ,CONSTRAINT FK_Species_Growth_Rate FOREIGN KEY (growth_rate_id) REFERENCES growth_rate(id)
);

CREATE TABLE Pokemons(
   [id]              INTEGER  NOT NULL
  ,[name]		     VARCHAR(23) NOT NULL
  ,[species_id]      INTEGER  NOT NULL
  ,[height]          INTEGER  NOT NULL
  ,[weight]          INTEGER  NOT NULL
  ,[base_experience] INTEGER  NOT NULL
  ,[position]        INTEGER  NOT NULL
  ,[is_default]      BIT  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC) 
  ,CONSTRAINT [FK_Pokemons_Species] FOREIGN KEY ([species_id]) REFERENCES Species(id)
);
