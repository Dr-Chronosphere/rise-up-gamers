# Games
```sql
INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('League of Legends', 'PC', 'MOBA', 5);

INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('CS:GO', 'PC', 'Tactical Shooter', 5);

INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Rocket League', 'Cross-Platform', 'Sports', 3);

INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Fortnite', 'Cross-Platform', 'Battle Royale', 4);

INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES ('Hearthstone', 'PC', 'Card', 1);
```
# Teams
```sql
INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES ('Cloud 9', 1, 'California, USA');

INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES ('Cloud 9', 2, 'California, USA');

INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES ('Tempo Storm', 5, 'Los Angeles, California, USA');

INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES ('Wichita State', 3, 'Wichita, Kansas, USA');

INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES ('Team Liquid', 1, 'California, USA');
```
# Players
```sql
INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('Sneaky', 'Zachary', 'Scuderi', 1);

INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('MrGopher', 'Tobin', 'Hushower', 3);

INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('S1mple', 'Natus', 'Vincere', 2);

INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('Mero', 'Matthew', 'Faitel', 4);

INSERT INTO Players (GamerTag, FirstName, LastName, GameID) VALUES ('Reynad', 'Andrey', 'Yanyuk', 5);
```
# Rosters
```sql
INSERT INTO Rosters (TeamID, GameID, ListOfPlayers) VALUES (1, 1, 'Fudge, Blaber, Jensen, Berserker, Zven');

INSERT INTO Rosters (TeamID, GameID, ListOfPlayers) VALUES (3, 3, 'Actual Quarter, Pibro3, GiffyA');

INSERT INTO Rosters (TeamID, GameID, ListOfPlayers) VALUES (5, 1, 'Bwipo, Santorin, Bjergsen, Hans sama, CoreJJ');

INSERT INTO Rosters (TeamID, GameID, ListOfPlayers) VALUES (3, 5, 'Eloise');

INSERT INTO Rosters (TeamID, GameID, ListOfPlayers) VALUES (2, 2, 'nafany, HObbitt, interz, Ax1Le, sh1ro');
```
# Events
```sql
INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('LOL Worlds Championship', 'September 29, 2022', 1, 'New York City, New York, USA', 2230000, 'Single Elimination');

INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('LOL MSI', 'May 10, 2022', 1, 'Busan, South Korea', 250000, 'Single Elimination');

INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('RLCS Worlds Championship', 'August 4, 2022', 3, 'Fort Worth, Texas, USA', 2085000, 'Double Elimination into Single Elimination');

INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('Fortnite World Cup', 'November 12, 2022', 4, 'Raleigh, North Carolina, USA', 1000000, 'Points System into Single Elimination');

INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES ('BLAST Premier: Fall Finals 2022', 'November 23, 2022', 2, 'Copenhagen, Denmark', 425000, 'Single Elimination');
```