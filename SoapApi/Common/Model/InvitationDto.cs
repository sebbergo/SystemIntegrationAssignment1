namespace Common.Model
{
    public class InvitationDto
    {
        public string Title { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {
            return $"Dear {this.Title} {this.Name}";
        }
    }
}
