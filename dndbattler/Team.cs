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

}