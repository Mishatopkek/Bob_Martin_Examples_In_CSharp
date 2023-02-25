namespace ArgsExample.Args;

public class Args
{
    private Dictionary<char, object> marshalers;
    private List<char> argsFound;
    private List<string> currentArgument;

    public Args(string schema, string[] args)
    {
        marshalers = new Dictionary<char, object>();
        argsFound = new List<char>();
        ParseSchema(schema);
        ParseArgumentStrings(args.ToList());
    }

    private void ParseSchema(string schema)
    {
        for (int element = 0; element < sch; element++)
        {
            
        }
    }
}