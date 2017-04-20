using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YellowDrawer.Data.Common;

namespace YellowDrawer.Data.Simple
{
    [Table("ExampleTabel")]
    public class ExampleTabel: IIdentifiable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        object IIdentifiable.Id
        {
            get
            {
                return Id;
            }
        }
    }
}
