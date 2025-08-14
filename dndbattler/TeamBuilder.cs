public class TeamBuilder
{
    private readonly CharacterFactory _factory;
    private List<Character> _members = new List<Character>();
    private string _teamName = "Unnamed";

    public TeamBuilder(CharacterFactory factory)
    {
        _factory = factory;
    }

    public TeamBuilder Name(string name)
    {
        _teamName = name;
        return this;
    }

    public TeamBuilder AddMember(CharacterType type, string name)
    {
        if (_members.Count >= GameConstants.TEAM_SIZE)
        {
            throw new Exception($"Team already has {GameConstants.TEAM_SIZE} members");
        }
        _members.Add(_factory.Create(type, name));
        return this;
    }

    public Team Build()
    {
        if (_members.Count != GameConstants.TEAM_SIZE)
        {
            throw new Exception($"Team must have {GameConstants.TEAM_SIZE} members");
        }
        return new Team(_teamName, _members);
    }
}