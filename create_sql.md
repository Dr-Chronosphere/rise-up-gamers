```sql
CREATE TABLE Games(
    GameID INTEGER PRIMARY KEY NOT NULL,
    GameName TEXT,
    Device TEXT,
    Type TEXT,
    NumberOfPlayers INTEGER
);
CREATE TABLE Organizations(
    OrganizationID INTEGER PRIMARY KEY NOT NULL,
    OrganizationName TEXT, 
    OrganizationLocation TEXT,
    YearFounded INTEGER            
);
CREATE TABLE Teams(
    TeamID INTEGER PRIMARY KEY NOT NULL,
    OrganizationID INTEGER,
    GameID INTEGER,
    FOREIGN KEY (OrganizationID) REFERENCES Organizations(OrganizationID) ON DELETE CASCADE,
    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
);
CREATE TABLE Players(
    PlayerID INTEGER PRIMARY KEY NOT NULL,
    GamerTag TEXT,
    FirstName TEXT,
    LastName TEXT,
    GameID INTEGER,
    TeamID INTEGER,
    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE,
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID) ON DELETE CASCADE
);
CREATE TABLE Events(
    EventID INTEGER PRIMARY KEY NOT NULL,
    EventName TEXT,
    EventDate TEXT,
    GameID INTEGER,
    EventLocation TEXT,
    PrizeMoney INTEGER,
    Format TEXT,
    FOREIGN KEY (GameID) REFERENCES Games(GameID) ON DELETE CASCADE
);
```
