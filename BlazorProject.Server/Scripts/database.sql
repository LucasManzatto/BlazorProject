CREATE TABLE damage_class(
   id              INTEGER  NOT NULL
  ,[name]          VARCHAR(8) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

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

CREATE TABLE [types](
   id              INTEGER  NOT NULL 
  ,[name]          VARCHAR(8) NOT NULL
  ,generation_id   INTEGER  NOT NULL
  ,damage_class_id INTEGER
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Types_Generation FOREIGN KEY (generation_id) REFERENCES Generation(id)
  ,CONSTRAINT FK_Types_Damage_Class FOREIGN KEY (damage_class_id) REFERENCES damage_class(id)
);

CREATE TABLE Species(
   id                      INTEGER  NOT NULL
  ,generation_id           INTEGER  NOT NULL
  ,evolves_from_species_id INTEGER 
  ,evolution_chain         INTEGER  NOT NULL
  ,gender_rate             INTEGER  NOT NULL
  ,capture_rate            INTEGER  NOT NULL
  ,base_happiness          INTEGER  NOT NULL
  ,hatch_counter           INTEGER  NOT NULL
  ,has_gender_differences  BIT  NOT NULL
  ,growth_rate_id          INTEGER  NOT NULL
  ,forms_switchable        BIT  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Species_Generation FOREIGN KEY (generation_id) REFERENCES Generation(id)
  ,CONSTRAINT FK_Species_Evolves_From_Species FOREIGN KEY (evolves_from_species_id) REFERENCES Species(id)
  ,CONSTRAINT FK_Species_Growth_Rate FOREIGN KEY (growth_rate_id) REFERENCES growth_rate(id)
);

CREATE TABLE Pokemons(
   [id]              INTEGER  NOT NULL
  ,[name]		     VARCHAR(23) NOT NULL
  ,[species_id]      INTEGER  NOT NULL
  ,[height]          FLOAT    NOT NULL
  ,[weight]          FLOAT    NOT NULL
  ,[base_experience] INTEGER  NOT NULL
  ,[position]        INTEGER  NOT NULL
  ,[is_default]      BIT  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC) 
  ,CONSTRAINT [FK_Pokemons_Species] FOREIGN KEY ([species_id]) REFERENCES Species(id)
);

DROP TABLE pokemon_types
CREATE TABLE pokemon_types(
   id		  INTEGER  identity(1,1) NOT NULL,
   pokemon_id INTEGER  NOT NULL
  ,[type_id]  INTEGER  NOT NULL
  ,slot       INTEGER  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Pokemon_Types_Pokemon FOREIGN KEY (pokemon_id) REFERENCES Pokemons(id)
  ,CONSTRAINT FK_Pokemon_Types_Types FOREIGN KEY ([type_id]) REFERENCES [types](id)
);

DROP TABLE pokemon_stats
CREATE TABLE pokemon_stats(
   id		  INTEGER  identity(1,1) NOT NULL,
   pokemon_id INTEGER  NOT NULL
  ,hp         INTEGER  NOT NULL
  ,attack     INTEGER  NOT NULL
  ,defense    INTEGER  NOT NULL
  ,sp_attack  INTEGER  NOT NULL
  ,sp_defense INTEGER  NOT NULL
  ,speed      INTEGER  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Pokemon_Stats_Pokemon FOREIGN KEY (pokemon_id) REFERENCES Pokemons(id)
);

DROP TABLE type_efficacy
CREATE TABLE type_efficacy(
	id		      INTEGER  identity(1,1) NOT NULL
  ,damage_type_id INTEGER  NOT NULL
  ,target_type_id INTEGER  NOT NULL
  ,damage_factor  INTEGER  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Damage_Type_Type FOREIGN KEY (damage_type_id) REFERENCES [types](id)
  ,CONSTRAINT FK_Target_Type_Type FOREIGN KEY (target_type_id) REFERENCES [types](id)
);

CREATE TABLE abilities(
   id             INTEGER  NOT NULL
  ,[name]     VARCHAR(16) NOT NULL
  ,generation_id  INTEGER  NOT NULL
  ,[description] VARCHAR(MAX) NOT NULL
  ,is_main_series BIT  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Abilities FOREIGN KEY (generation_id) REFERENCES Generation(id)
);

CREATE TABLE abilities_prose(
   id             INTEGER  NOT NULL,
   ability_id        INTEGER  NOT NULL
  ,local_language_id INTEGER  NOT NULL
  ,short_effect      VARCHAR(320) NOT NULL
  ,effect            VARCHAR(2071) NOT NULL

);

CREATE TABLE locations(
   id         INTEGER  NOT NULL
  ,main_region_id  INTEGER 
  ,[name]       VARCHAR(32) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Locations_Main_Region FOREIGN KEY (main_region_id) REFERENCES main_region(id)
);

CREATE TABLE evolution_triggers(
	id         INTEGER  NOT NULL
	,[name]       VARCHAR(32) NOT NULL
	,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE item_pockets(
   id         INTEGER  NOT NULL 
  ,name       VARCHAR(9) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE item_categories(
   id         INTEGER  NOT NULL
  ,item_pocket_id  INTEGER  NOT NULL
  ,name       VARCHAR(16) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Item_Categories_Item_Pocket FOREIGN KEY (item_pocket_id) REFERENCES item_pockets(id)
);

CREATE TABLE item_fling_effects(
   id         INTEGER  NOT NULL
  ,name       VARCHAR(12) NOT NULL
    ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE items(
   id              INTEGER  NOT NULL
  ,name            VARCHAR(31) NOT NULL
  ,item_category_id INTEGER  NOT NULL
  ,cost            INTEGER  NOT NULL
  ,fling_power     INTEGER 
  ,item_fling_effect_id INTEGER 
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Items_Item_Category FOREIGN KEY (item_category_id) REFERENCES item_categories(id)
  ,CONSTRAINT FK_Items_Item_Fling_Effect FOREIGN KEY (item_fling_effect_id) REFERENCES item_fling_effects(id)
);

CREATE TABLE move_effects(
   id                INTEGER  NOT NULL 
  ,short_effect      VARCHAR(148) NOT NULL
  ,effect            VARCHAR(4103) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE move_targets(
   id         INTEGER  NOT NULL
  ,name       VARCHAR(25) NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE moves(
   id                      INTEGER  NOT NULL
  ,[name]                  VARCHAR(32) NOT NULL
  ,generation_id           INTEGER  NOT NULL
  ,[type_id]               INTEGER  NOT NULL
  ,[power]                 INTEGER 
  ,pp                      INTEGER 
  ,accuracy                INTEGER 
  ,[priority]              INTEGER  NOT NULL
  ,move_target_id               INTEGER  NOT NULL
  ,damage_class_id         INTEGER  NOT NULL
  ,move_effect_id               INTEGER  NOT NULL
  ,move_effect_chance           INTEGER
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Moves_Generation FOREIGN KEY (generation_id) REFERENCES generation(id)
  ,CONSTRAINT FK_Moves_Type FOREIGN KEY ([type_id]) REFERENCES [types](id)
  ,CONSTRAINT FK_Moves_Move_Target FOREIGN KEY (move_target_id) REFERENCES move_targets(id)
  ,CONSTRAINT FK_Moves_Damage_Class FOREIGN KEY (damage_class_id) REFERENCES damage_class(id)
  ,CONSTRAINT FK_Moves_Move_Effect FOREIGN KEY (move_effect_id) REFERENCES move_effects(id)
);

CREATE TABLE pokemon_evolution(
   id                      INTEGER  NOT NULL
  ,evolved_species_id      INTEGER  NOT NULL
  ,evolution_trigger_id    INTEGER  NOT NULL
  ,trigger_item_id         INTEGER 
  ,minimum_level           INTEGER 
  ,gender                  INTEGER 
  ,location_id             INTEGER 
  ,held_item_id            INTEGER 
  ,time_of_day             VARCHAR(5)
  ,known_move_id           INTEGER 
  ,known_move_type_id      INTEGER 
  ,minimum_happiness       INTEGER 
  ,minimum_beauty          INTEGER 
  ,minimum_affection       INTEGER 
  ,relative_physical_stats INTEGER 
  ,party_species_id        INTEGER 
  ,party_type_id           INTEGER 
  ,trade_species_id        INTEGER 
  ,needs_overworld_rain    BIT  NOT NULL
  ,turn_upside_down        BIT  NOT NULL
  ,PRIMARY KEY CLUSTERED ([id] ASC)
  ,CONSTRAINT FK_Pokemon_Evolution_Evolved_Species FOREIGN KEY (evolved_species_id) REFERENCES species(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Evolved_Trigger FOREIGN KEY (evolution_trigger_id) REFERENCES evolution_triggers(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Trigger_Item FOREIGN KEY (trigger_item_id) REFERENCES items(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Location FOREIGN KEY (location_id) REFERENCES locations(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Held_Item FOREIGN KEY (held_item_id) REFERENCES items(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Know_Move FOREIGN KEY (known_move_id) REFERENCES moves(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Know_Move_Type FOREIGN KEY (known_move_type_id) REFERENCES [types](id)
  ,CONSTRAINT FK_Pokemon_Evolution_Party_Species FOREIGN KEY (party_species_id) REFERENCES species(id)
  ,CONSTRAINT FK_Pokemon_Evolution_Party_Type FOREIGN KEY (party_type_id) REFERENCES [types](id)
  ,CONSTRAINT FK_Pokemon_Evolution_Trade_Species FOREIGN KEY (trade_species_id) REFERENCES species(id)
);