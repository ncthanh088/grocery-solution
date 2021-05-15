using Grocery.Domain.Common;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class Media : IEntity<long>
    {
        public long Id { get; set; }
        public string Caption { get; set; }
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public MediaType MediaType { get; set; }
    }
}