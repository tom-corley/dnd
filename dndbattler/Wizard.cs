public class Wizard : Character
{
    public Wizard(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack * 2) { }

    public override int AttackCharacter(Character target, out string log)
    {
        int res = base.AttackCharacter(target, out log);
        TakeDamage(GameConstants.WIZARD_SELF_DAMAGE);
        log += $"\n\t\t{this} deals {GameConstants.WIZARD_SELF_DAMAGE} to themself while attacking";
        if (Health == 0)
        {
            log += ", killing themselves!";
        }
        return res;
    }

    public override string ToString()
    {
        return $"{Name} the Wizard";
    }
}