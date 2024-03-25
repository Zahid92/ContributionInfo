namespace ContributionInfo.Models
{
    public class Project
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Image { get; set; }
        public Project(string name, string description, string? link, string image) {
            Name = name;
            Description = description;
            Link = link;
            Image = image;
        }
        public Project() { }
        
    }
}
