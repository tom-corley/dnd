public class Fighter : Character
{
    public Fighter(string name, int baseHealth, int baseAttack) : base(name, baseHealth + 5, baseAttack) { }

    public override string ToString()
    {
        return $"{Name} the Fighter";
    }
}