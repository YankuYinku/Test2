namespace apetito.meinapetito.Portal.Contracts.IntegrationFields
{
    public class SortimentIntegrationFieldEntry
    {

        public string Id { get; set; } = string.Empty;
        public string Title { get; set; }  = string.Empty;
        public string Description { get; set; }  = string.Empty;
        public Sortiment Blob { get; set; } = new Sortiment();

        public override bool Equals(object? obj)
        {
            return obj is SortimentIntegrationFieldEntry entry &&
                   Id == entry.Id &&
                   Title == entry.Title &&
                   Description == entry.Description &&
                   EqualityComparer<Sortiment>.Default.Equals(Blob, entry.Blob);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Description, Blob);
        }
    }

}