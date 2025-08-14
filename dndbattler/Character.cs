public abstract class Character
{
    private int Health { get; set; }
    private int Attack { get; set; }
    private string Name { get; set; }

    public Character(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public int takeDamage(int dmg)
    {
        Health -= dmg;
        return Health;
    }

    public int Attack(Character target)
    {
        target.takeDamage(Attack);
        return target.Health;
    }
}