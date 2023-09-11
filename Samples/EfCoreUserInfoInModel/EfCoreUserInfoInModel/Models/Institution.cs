using EfCoreUserInfoInModel.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreUserInfoInModel.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ValidatedByUser]
        [NotMapped]
        public string LongInUserId { get; set; }
    }
}
