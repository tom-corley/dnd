public class Wizard : Character
{
    public Wizard(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack * 2) { }

    public override int AttackCharacter(Character target)
    {
        target.takeDamage(Attack);
        takeDamage(1);
        return target.Health;
    }
}