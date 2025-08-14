public abstract class Character
{
    public const int MIN_STAT = 1;
    public const int MAX_STAT = 10;
    public int Health { get; protected set; }
    public int MaxHealth { get; }
    public int Attack { get; protected set; }
    public string Name { get; protected set; }
    public bool Alive => Health > 0;

    public Character(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        MaxHealth = Health;
        Attack = attack;
    }

    public int Heal(int amount)
    {
        Health += amount;
        return Health;
    }

    public int TakeDamage(int dmg)
    {
        Health -= dmg;
        return Health;
    }

    public virtual int AttackCharacter(Character target)
    {
        target.TakeDamage(Attack);
        return target.Health;
    }
}