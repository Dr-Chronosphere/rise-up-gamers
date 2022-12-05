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
INSERT INTO Games (GameName, Device, Type, NumberOfPlayers) VALUES (@GameName, @Device, @Type, @NumberOfPlayers);
INSERT INTO Organizations (OrganizationName, OrganizationLocation, YearFounded) VALUES (@OrganizationName, @OrganizationLocation, @YearFounded);
INSERT INTO Teams (OrganizationID, GameID) VALUES (@OrganizationID, @GameID);
INSERT INTO Players (GamerTag, FirstName, LastName, GameID, TeamID) VALUES (@GamerTag, @FirstName, @LastName, @GameID, @TeamID);
INSERT INTO Events (EventName, EventDate, GameID, EventLocation, PrizeMoney, Format) VALUES (@TeamName, @GameID, @TeamLocation);
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
UPDATE Games SET GameName = @GameName, Device = @Deivce, NumberOfPlayers = @NumberOfPlayers WHERE GameID = @GameID;
UPDATE Organizations SET OrganizationName = @OrganizationName, OrganizationLocation = @OrganizationLocation, YearFounded = @YearFounded WHERE OrganizationID = @OrganizationID;
UPDATE Teams SET OrganizationID = @OrganizationID, GameID = @GameID WHERE TeamID = @TeamID;
UPDATE Players SET GamerTag = @GamerTag, FirstName = @FirstName, LastName = @LastName, GameId = @GameID, TeamID = @TeamID WHERE PlayerID = @PlayerID;
UPDATE Events SET EventName = @EventName, EventDate = @EventDate, GameID = @GameID, EventLocation = @EventLocation, PrizeMoney = @PrizeMoney, Format = @Format WHERE EventID = @EventID;
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
DELETE FROM Games WHERE TeamID = @GameID;
DELETE FROM Organizations WHERE OrganizationID = @OrganizationID;
DELETE FROM Teams WHERE TeamID = @TeamID;
DELETE FROM Players WHERE TeamID = @PlayerID;
DELETE FROM Events WHERE TeamID = @EventID;
```
