public class CharacterFactory
{
    private Random Rng;
    public CharacterFactory(Random rng)
    {
        Rng = rng;
    }

    public Character Create(CharacterType type, string name)
    {
        int baseHealth = Rng.Next(GameConstants.MIN_STAT, GameConstants.MAX_STAT + 1);
        int baseDmg = Rng.Next(GameConstants.MIN_STAT, GameConstants.MAX_STAT + 1);

        switch (type)
        {
            case CharacterType.Fighter:
                return new Fighter(name, baseHealth, baseDmg);
            case CharacterType.Wizard:
                return new Wizard(name, baseHealth, baseDmg);
            case CharacterType.Cleric:
                return new Cleric(name, baseHealth, baseDmg);
            default:
                throw new Exception("Not a valid character type");
        }
    }
}