using System.Text;
public class Team
{
    public string Name;
    public List<Character> Members;

    public Team(string name, List<Character> members)
    {
        if (members.Count != 3)
        {
            throw new Exception("Team must contain three members");
        }
        Name = name;
        Members = members;
    }

    public bool IsAlive()
    {
        bool ans = false;
        foreach (Character character in Members)
        {
            ans = ans || character.Alive;
        }
        return ans;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{Name} Status:");
        foreach (Character member in Members)
        {
            sb.Append($"\n\t{member.Name}:  {member.Health}/{member.MaxHealth}");
        }
        return sb.ToString();
    }

}