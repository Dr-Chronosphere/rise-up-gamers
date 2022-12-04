# Overview
The database stores records concerning Esports teams, Esports players, and video games that may be played competitively.
# Tables
## Teams
This table contains records for esports teams for registered games
### Attributes
Attribute | Primary Key? | Foreign Key? | Constraint?
- TeamID | ✅ | ❌ | ⛔
- TeamName | ❌ | ❌ | ⛔
- GameID | ❌ | ✅ | Games.GameID
- TeamLocation | ❌ | ❌ | ⛔
### Functional Dependencies
TeamID -> TeamName, GameID, TeamLocation
### In 3NF?
Yes
### Sample Data
- 1 | Cloud 9 | 1 | California, USA
- 4 | Wichita State | 3 | Wichita, Kansas, USA
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
