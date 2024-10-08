using System.Text.Json.Serialization;

namespace CarJournal.Services.Client;

public class SelectedCarData
{
    public int Id { get; private set; } = -1;
    public string Name { get; private set; }
    public bool HasData { get; private set; }
    public string ResultMessage { get; private set; }

    public SelectedCarData(string resultMessage)
    {
        HasData = false;
        Name = "";
        ResultMessage = resultMessage;
    }

    [JsonConstructor]
    public SelectedCarData(int id, string name, bool hasData, string resultMessage = "Success!")
    {
        Id = id;
        Name = name;
        ResultMessage = resultMessage;
        HasData = hasData;
    }
}