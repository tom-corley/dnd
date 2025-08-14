public class Wizard : Character
{
    public Wizard(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack * 2) { }

    public override int AttackCharacter(Character target)
    {
        target.TakeDamage(Attack);
        TakeDamage(1);
        return target.Health;
    }
}