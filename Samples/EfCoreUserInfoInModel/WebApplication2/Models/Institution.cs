using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Attributes;

namespace WebApplication2.Models
{
    public class Institution
    {
        public int Id { get; set; }
        [ValidatedByUser]
        public string Name { get; set; }
    }
}
