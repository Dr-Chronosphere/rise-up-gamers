# Overview
The database stores records concerning Esports teams, Esports players, and video games that may be played competitively.
# Tables
## Teams
Attributes | Primary Key? | Foreign Key? | Constraint
- | - | - | -
TeamID | ✅ | ❌ | ⛔
TeamName | ❌ | ❌ | ⛔
GameID | ❌ | ✅ | Games.GameID
TeamLocation | ❌ | ❌ | ⛔
### Functional Dependencies
TeamID -> TeamName, GameID, TeamLocation
## Games
Attributes | Primary Key? | Foreign Key? | Constraint
- | - | - | -
GameID | ✅ | ❌ | ⛔
GameName | ❌ | ❌ | ⛔
Device | ❌ | ❌ | ⛔
Type | ❌ | ❌ | ⛔
NumberOfPlayers | ❌ | ❌ | ⛔
### Functional Dependencies
GameID -> GameName, Device, Type, NumberOfPlayers
## Players
Attributes | Primary Key? | Foreign Key? | Constraint
- | - | - | -
PlayerID | ✅ | ❌ | ⛔
GamerTag | ❌ | ❌ | ⛔
FirstName | ❌ | ❌ | ⛔
LastName | ❌ | ❌ | ⛔
GameID | ❌ | ✅ | Games.GameID
### Functional Dependencies
PlayerID -> GamerTag, FirstName, LastName, GameID
## Rosters
RostersAttributes | Primary Key? | Foreign Key? | Constraint
- | - | - | -
RosterID | ✅ | ❌ | ⛔
TeamID | ❌ | ✅ | Teams.TeamID
GameID | ❌ | ✅ | Games.GameID
ListOfPlayers | ❌ | ❌ | ⛔
### Functional Dependencies
RosterID -> TeamID, GameID, ListOfPlayers
## Events
Attributes | Primary Key? | Foreign Key? | Constraint
- | - | - | -
EventID | ✅ | ❌ | ⛔
EventName | ❌ | ❌ | ⛔
EventDate | ❌ | ❌ | ⛔
GameID | ❌ | ✅ | Games.GameID
EventLocation | ❌ | ❌ | ⛔
PrizeMoney | ❌ | ❌ | ⛔
Format | ❌ | ❌ | ⛔
### Functional Dependencies
EventID -> EventName, EventDate, GameID, EventLocation, PrizeMoney