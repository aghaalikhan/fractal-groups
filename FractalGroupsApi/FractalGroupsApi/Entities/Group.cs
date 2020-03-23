namespace FractalGroupsApi.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public PersonGroup PersonGroup { get; set; }
    }
}
