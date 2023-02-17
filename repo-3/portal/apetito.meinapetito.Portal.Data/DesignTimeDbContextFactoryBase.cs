using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace apetito.meinapetito.Portal.Data;

public abstract class DesignTimeDbContextFactoryBase<T> : IDesignTimeDbContextFactory<T> where T : DbContext
{
    private const string ParameterConnectionString = "--connectionString=";

    public T CreateDbContext(string[] args)
    {
        var connectionString = DetermineConnectionStringFromArguments(args);
        var options = new DbContextOptionsBuilder<T>().UseSqlServer(connectionString).Options;

        return (T)Activator.CreateInstance(typeof(T), new object[] { options })!;
    }

    private static string DetermineConnectionStringFromArguments(IReadOnlyList<string> args)
    {
        if (args.Count != 1 && !args[0].StartsWith(ParameterConnectionString))
        {
            throw new ArgumentException(
                "Invalid arguments (type --connectionString=MYCONNECTIONSTRING)");
        }

        return args[0].Replace(ParameterConnectionString, string.Empty);
    }

}