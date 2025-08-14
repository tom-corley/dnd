public class Fighter : Character
{
    public Fighter(string name, int baseHealth, int baseAttack) : base(name, baseHealth + GameConstants.FIGHTER_HEALTH_BONUS, baseAttack) { }

    public override string ToString()
    {
        return $"{Name} the Fighter";
    }
}