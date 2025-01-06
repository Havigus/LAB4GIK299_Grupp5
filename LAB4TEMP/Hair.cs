namespace LAB4TEMP;

public struct Hair
{
    public string HairColor { get; set; }
    public string HairLenght { get; set; }

    public Hair(string? hairColor = null, string? hairLenght = null) 
    {
        //default variables to "Unknown" if arg is null or empty
        HairColor = string.IsNullOrEmpty(hairColor) ? "Unknown" : hairColor;
        HairLenght = string.IsNullOrEmpty(hairLenght) ? "Unknown" : hairLenght;
    }
}