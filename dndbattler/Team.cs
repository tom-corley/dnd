using System.Text;
public class Team
{
    public string Name;
    public List<Character> Members;

    public Team(string name, List<Character> members)
    {
        if (members.Count != GameConstants.TEAM_SIZE)
        {
            throw new Exception($"Team must contain {GameConstants.TEAM_SIZE} members");
        }
        Name = name;
        Members = members;
    }

    public bool IsAlive => Members.Any(m => m.Alive); 

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{Name} Status:");
        foreach (Character member in Members)
        {
            sb.Append($"\t{member}:  {member.Health}/{member.MaxHealth}");
        }
        return sb.ToString();
    }

}