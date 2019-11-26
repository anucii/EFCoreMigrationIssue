using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;

namespace EFCoreMigrationIssue.Persistence
{
    public class FooRepository
    {
        public FooRepository()
        {
        }

        public void Add(Foo item)
        {
            using var context = GetDbContext();

            context.Foos.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<Foo> GetAll()
        {
            using var context = GetDbContext();

            return context.Foos.ToList();
        }

        private EFCoreMigrationIssueDbContext GetDbContext()
        {
            return new EFCoreMigrationIssueDbContext(GetDbFilePath());
        }

        private string GetDbFilePath()
        {
            var filename = "database.db3";
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
