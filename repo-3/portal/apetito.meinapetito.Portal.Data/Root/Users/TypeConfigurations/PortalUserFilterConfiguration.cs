using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apetito.meinapetito.Portal.Data.Root.Users.TypeConfigurations;

public class PortalUserFilterConfiguration : IEntityTypeConfiguration<PortalUserFilter>
{
    public void Configure(EntityTypeBuilder<PortalUserFilter> builder)
    {
        builder.HasKey(e => e.Id);
    }
}
