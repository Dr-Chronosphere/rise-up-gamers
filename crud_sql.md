# Insert
### C#
```c#
public void Insert()
{
    database.Command.CommandText = $"INSERT INTO {Name}({string.Join(", ", Fields)}) VALUES(@{string.Join(", @", Fields)})";
    foreach (KeyValuePair<string, TextBox> input in LinkedTab.Inputs)
    {
        database.Command.Parameters.AddWithValue($"@{input.Key}", input.Value.Text);
    }
    database.Command.ExecuteNonQuery();
}
```
### SQL
@values are filled in upon execution of sql
```sql
INSERT INTO Teams (TeamName, GameID, TeamLocation) VALUES (@TeamName, @GameID, @TeamLocation)
INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES (@GameName, @Device, @Type, @NumberOfPlayers)
INSERT INTO Players (GamerTag, FirstName, LastName, GameID, AssociatedTeam) VALUES (@GamerTag, @FirstName, @LastName, @GameID, @AssociatedTeam)
INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES (@TeamName, @GameID, @TeamLocation)
```
# Update
### C#
```c#
public void Update()
{
    var activeFields = from field in Fields where !string.IsNullOrEmpty(LinkedTab.Inputs[field].Text) select field;
    var setters = activeFields.Select(field => field + " = @" + field.ToLower());
    database.Command.CommandText = $"UPDATE {Name} SET {string.Join(", ", setters)} WHERE {PrimaryKey} = {LinkedTab.Inputs[PrimaryKey].Text}";
    foreach (string field in activeFields)
    {
        database.Command.Parameters.AddWithValue($"@{field.ToLower()}", LinkedTab.Inputs[field].Text);
    }
    database.Command.ExecuteNonQuery();
}
```
### SQL
@values are filled in upon execution of sql
```sql
UPDATE Teams SET TeamName = @TeamName, GameID = @GameID, TeamLocation = @TeamLocation WHERE TeamID = @TeamID
UPDATE Games SET GameName = @GameName, Device = @Deivce, NumberOfPlayers = @NumberOfPlayers WHERE GameID = @GameID
UPDATE Players SET GamerTag = @GamerTag, FirstName = @FirstName, LastName = @LastName, GameId = @GameID, AssociatedTeam = @AssociatedTeam WHERE PlayerID = @PlayerID
UPDATE Events SET EventName = @EventName, EventDate = @EventDate, GameID = @GameID, EventLocation = @EventLocation, PrizeMoney = @PrizeMoney, Format = @Format WHERE EventID = @EventID
```
# Delete
### C#
```c#
public void Delete()
{
    database.Command.CommandText = $"DELETE FROM {Name} WHERE {PrimaryKey} = '{LinkedTab.Inputs[PrimaryKey].Text}'";
    database.Command.ExecuteNonQuery();
}
```
### SQL
@values are filled in upon execution of sql
```sql
DELETE FROM Teams WHERE TeamID = @TeamID
DELETE FROM Games WHERE TeamID = @GameID
DELETE FROM Players WHERE TeamID = @PlayerID
DELETE FROM Events WHERE TeamID = @EventID
```
