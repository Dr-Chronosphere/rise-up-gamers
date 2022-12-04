# Insert
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
# Update
```sql
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
# Delete
```sql
public void Delete()
{
    database.Command.CommandText = $"DELETE FROM {Name} WHERE {PrimaryKey} = '{LinkedTab.Inputs[PrimaryKey].Text}'";
    database.Command.ExecuteNonQuery();
}
```