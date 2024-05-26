namespace Fiorello_PB101.Models
{
    public class FooterLink:BaseEntity
    {
        public string Section { get; set; }
        public List<LinkItem> Links { get; set; }
    }
}
