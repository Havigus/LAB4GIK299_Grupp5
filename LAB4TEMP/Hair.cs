namespace Lab4_GIK299;

public struct Hair
{
    public string HairColor { get; set; }
    public string HairLenght { get; set; }

    public Hair(string? hairColor = null, string? hairLenght = null) 
    {
        HairColor = string.IsNullOrWhiteSpace(hairColor) ? "Unknown" : hairColor;
        HairLenght = string.IsNullOrWhiteSpace(hairLenght) ? "Unknown" : hairLenght;
    }
}