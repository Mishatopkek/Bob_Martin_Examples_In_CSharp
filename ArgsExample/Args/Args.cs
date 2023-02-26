namespace ArgsExample.Args;

public class Args
{
    private Dictionary<char, object> marshalers; //Finish this
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
        foreach (string element in schema.Split(","))
        {
            if (element.Length > 0)
            {
                ParseSchemaElement(element.Trim());
            }
        }
    }

    private void ParseSchemaElement(string element)
    {
        char elementId = element[0];
        string elementTail = element[1..];
        ValidateSchemaElementId(elementId);
        if (elementTail.Length == 0)
            marshalers[elementId] = new BooleanArgumentMarshaler();
        else if (elementTail == "*")
            marshalers[elementId] = new StringArgumentMarshaler();
        else if (elementTail == "#")
            marshalers[elementId] = new IntegerArgumentMarshaler();
        else if (elementTail == "##")
            marshalers[elementId] = new DoubleArgumentMarshaler();
        else if (elementTail == "[*]")
            marshalers[elementId] = new StringArrayArgumentMarshaler();
        else
            throw new Exception();
    }

    private void ValidateSchemaElementId(char elementId)
    {
        if (!char.IsLetter(elementId))
        {
            throw new Exception();
        }
    }

    private void ParseArgumentStrings(List<string> argsList)
    {
        for (;;) //TODO finish it
        {
            string argString = currentArgument.Next();
            if (argString.StartsWith("-")
            {
                ParseArgumentCharacters(argString[1..]);
            }
            currentArgument.Previous();
            break;
        }
    }

    private void ParseArgumentCharacters(string argChars)
    {
        foreach (char charArgChar in argChars)
        {
            ParseArgumentCharacter(charArgChar);
        }
    }

    private void ParseArgumentCharacter(char argChar)
    {
        ArgumentMarshaler m = marshalers[argChar];
        if (m == null)
        {
            throw new Exception();
        }
        else
        {
            argsFound.Add(argChar);
            try
            {
                m.Add(argChar);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public bool Has(char arg)
    {
        return argsFound.Contains(arg);
    }

    public int NextArgument()
    {
        return currentArgument.NextIndex();
    }

    public bool GetBoolean(char arg)
    {
        return BooleanArgumentMarshaler.GetValue(marshalers[arg]);
    }

    public string GetString(char arg)
    {
        return StringArgumentMarshaler.GetValue(marshalers[arg]);
    }

    public int GetInt(char arg)
    {
        return IntegerArgumentMarshaler.GetValue(marshalers[arg]);
    }

    public double GetDouble(char arg)
    {
        return DoubleArgumentMarshaler.GetValue(marshalers[arg]);
    }

    public string[] GetStringArray(char arg)
    {
        return StringArrayArgumentMarshaler.GetValue(marshalers[arg]);
    }

}