public class Wizard : Character
{
    public Wizard(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack * 2) { }

    public override int AttackCharacter(Character target)
    {
        target.TakeDamage(Attack);
        TakeDamage(GameConstants.WIZARD_SELF_DAMAGE);
        return target.Health;
    }
}