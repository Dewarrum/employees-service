namespace Domain;

public sealed class User
{
    public User(string name, byte[] password)
    {
        Name = name;
        Password = password;
        LastActiveAt = DateTime.UtcNow;
    }

    internal User()
    {
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = default!;
    public byte[] Password { get; private set; } = default!;
    public DateTime LastActiveAt { get; set; }
}