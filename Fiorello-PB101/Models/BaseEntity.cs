namespace Fiorello_PB101.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool SofDeleted { get; set; } = false;
        public DateTime CreatedDate{ get; set; }=DateTime.Now;
    }
}
