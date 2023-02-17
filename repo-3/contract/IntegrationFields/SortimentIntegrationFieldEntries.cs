namespace apetito.meinapetito.Portal.Contracts.IntegrationFields
{
    public class SortimentIntegrationFieldEntries
    {

        public int Results_size { get; set; }
        public List<SortimentIntegrationFieldEntry> Results { get; set; } = new List<SortimentIntegrationFieldEntry>();

    }

}