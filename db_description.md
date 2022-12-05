# Overview
The database stores records concerning Esports teams, Esports players, and video games that may be played competitively.
# Tables
## Games
This table contains records for esports games
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- GameID | ✅ | ❌ | ⛔
- GameName | ❌ | ❌ | ⛔
- Device | ❌ | ❌ | ⛔
- Type | ❌ | ❌ | ⛔
- NumberOfPlayers | ❌ | ❌ | ⛔
### Functional Dependencies
GameID -> GameName, Device, Type, NumberOfPlayers
### In 3NF?
Yes
### Sample Data
- 1 | League of Legends | PC | MOBA | 5
- 2 | CS:GO | PC | Tactical Shooter | 5
## Organizations
This table contains records for esports organizations
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- OrganizationID | ✅ | ❌ | ⛔
- OrganizationName | ❌ | ❌ | ⛔
- OrganizationLocation | ❌ | ❌ | ⛔
- YearFounded | ❌ | ❌ | ⛔
### Functional Dependencies
OrganizationID -> OrganizationName, OrganizationLocation, YearFounded
### In 3NF?
Yes
### Sample Data
- 1 | Cloud 9 | California, USA | 2013
- 2 | Fnatic | London, UK | 2004
## Teams
This table contains records for esports teams and serves as a linking table between OrganizationID and GameID
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- TeamID | ✅ | ❌ | ⛔
- OrganizationID | ❌ | ✅ | Organizations.OrganizationID
- GameID | ❌ | ✅ | Games.GamesID
### Functional Dependencies
TeamID -> OrganizationID, GameID
### In 3NF?
Yes
### Sample Data
- 1 | 1 | 1
- 2 | 1 | 2
## Players
This table contains records for players for registered games (NOTE: Players can be unassociated with a team (No TeamID))
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- PlayerID | ✅ | ❌ | ⛔
- GamerTag | ❌ | ❌ | ⛔
- FirstName | ❌ | ❌ | ⛔
- LastName | ❌ | ❌ | ⛔
- GameID | ❌ | ✅ | Games.GameID
- TeamID | ❌ | ✅ | Teams.TeamID
### Functional Dependencies
PlayerID -> GamerTag, FirstName, LastName, GameID, TeamID
### In 3NF?
Yes
### Sample Data
- 1 | Sneaky | Zachary | Scuderi | 1 | 1
- 2 | MrGopher | Tobin | Hushower | 3 | 4
## Events
This table contains records for esports events for registered games
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- EventID | ✅ | ❌ | ⛔
- EventName | ❌ | ❌ | ⛔
- EventDate | ❌ | ❌ | ⛔
- GameID | ❌ | ✅ | Games.GameID
- EventLocation | ❌ | ❌ | ⛔
- PrizeMoney | ❌ | ❌ | ⛔
- Format | ❌ | ❌ | ⛔
### Functional Dependencies
EventID -> EventName, EventDate, GameID, EventLocation, PrizeMoney
### In 3NF?
Yes
### Sample Data
- 1 | LOL Words Championship | September 29, 2022 | 1 | New York City, New York, USA | 2230000 | Single Elimination
- 4 | Fornite World Cup | November 12, 2022 | 4 | Raleigh, North Carolina, USA | 1000000 | Points System into Single Elimination
