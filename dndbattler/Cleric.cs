public class Cleric : Character
{
    public Cleric(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack) { }

    public override int AttackCharacter(Character target)
    {
        target.TakeDamage(Attack);
        Heal(1);
        return target.Health;
    }
}