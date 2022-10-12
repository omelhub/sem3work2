namespace Model2;

public class Student : IDomainObject
{
    public string Name { get; set; } = string.Empty;
    public string Speciality { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public int Id { get; set; }
}