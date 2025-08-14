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

    public int TakeDamage(int dmg)
    {
        Health = Health - dmg <= 0 ? 0 : Health - dmg;
        return Health;
    }

    public virtual int AttackCharacter(Character target, out string log)
    {
        target.TakeDamage(Attack);
        log = $"{this} attacks {target} dealing {Attack} damage.";
        if (target.Health == 0)
        {
            log += $"\n\t\tThe attack was fatal! {target} has died";
        }
        return target.Health;
    }
}