public class Cleric : Character
{
    public Cleric(string name, int baseHealth, int baseAttack) : base(name, baseHealth, baseAttack) { }

    public int Heal(int amount)
    {
        Health = Health + amount <= MaxHealth ? Health + amount : MaxHealth;
        return Health;
    }

    public override int AttackCharacter(Character target, out string log)
    {
        int res = base.AttackCharacter(target, out log);
        Heal(GameConstants.CLERIC_SELF_HEAL);
        log += $"\n\t\t{this} heals {GameConstants.CLERIC_SELF_HEAL} health points";
        return res;
    }

    public override string ToString()
    {
        return $"{Name} the Cleric";
    }
}