namespace StudentAffairWeb.Shared;

public class ClassRoomStudent:Base
{
    public Guid ClassRoomId { get; set; }

    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public DateTime? JoinedOn { get; set; }
}