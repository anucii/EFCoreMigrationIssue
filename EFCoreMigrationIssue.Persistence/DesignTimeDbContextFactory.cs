using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreMigrationIssue.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFCoreMigrationIssueDbContext>
    {
        public EFCoreMigrationIssueDbContext CreateDbContext(string[] args)
        {
            Debug.WriteLine(Directory.GetCurrentDirectory() + @"\Config.db");

            return new EFCoreMigrationIssueDbContext(Directory.GetCurrentDirectory() + @"\Config.db");
        }
    }
}
