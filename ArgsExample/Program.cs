// See https://aka.ms/new-console-template for more information


using ArgsExample.Args;

void Main(string[] args)
{
    Args arg = new Args("l,p#,d*", args);
    bool logging = arg.GetBoolean('l');
    int port = arg.GetInt('p');
    string directory = arg.GetString('d');
    ExecuteApplication(logging, port, directory);
}