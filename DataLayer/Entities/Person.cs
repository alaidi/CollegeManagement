namespace DataLayer.Entities;
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public string PhotoUrl { get; set; }
}

public class PersonEntity: IEntity
{
    public int PersonId { get; set; }
    public Person Person { get; set; }
}

public class IEntity
{
    public int Id { get; set; }
}