namespace apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

public class SortimentDto 
{
    public string? Program { get; set; }
    public string? Type { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj is string value)
        {
            return Code.Equals(value);
        }

        if (obj is SortimentDto sortimentDto)
        {
            return Code.Equals(sortimentDto.Code);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }

    public void Enrich(SortimentDto other)
    {
        if (this.Code != other.Code)
            throw new InvalidOperationException();

        this.Description = other.Description;
        this.Program = other.Program;
        this.Type = other.Type;
    }
}