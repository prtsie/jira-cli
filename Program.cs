using JiraCli;

Console.Write("Input mail >>> ");
var mail = Console.ReadLine();
Console.Write("Input token >>> ");
var token = Console.ReadLine();
Console.Write("Input domain >>> ");
var domain = Console.ReadLine();

var client = new Client(new HttpClient(), mail!, token!, domain!);
var issues = await client.GetIssues();
Console.WriteLine(string.Join('\n', issues.Select(x => x.Key)));
