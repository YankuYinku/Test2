using apetito.CQS;
using apetito.meinapetito.Portal.Application.Root.Intrastructure.Queries;
using apetito.meinapetito.Portal.Contracts.Root.Users.Sortiments;

namespace apetito.meinapetito.Portal.Application.Root.Users.Current.Sortiments.Queries;

public class RetrieveSortimentsOfUserEmailQuery : UserQueryBase, IQuery<IEnumerable<SortimentDto>>
{

    public IEnumerable<string> SortimentCodes { get; set; } = Enumerable.Empty<string>();

}