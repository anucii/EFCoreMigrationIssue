using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreMigrationIssue.Persistence
{
    [Table(nameof(Foo))]
    public class Foo 
    {
        public Foo(string uri)
        {
            Uri = uri;
        }

        [Key]
        public int Id { get; set; }
        public string Uri { get; set; }
    }
}
