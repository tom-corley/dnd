public class Cleric : Character
{
    public Cleric(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack) { }

    public override int AttackCharacter(Character target)
    {
        target.TakeDamage(Attack);
        Heal(GameConstants.CLERIC_SELF_HEAL);
        return target.Health;
    }
}