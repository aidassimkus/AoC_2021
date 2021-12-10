var commands = File.ReadAllLines("input.txt")
                   .Select(x =>
                   {
                       var line = x.Split(" ");
                       return new Command() { Name = line[0], Value = Convert.ToInt32(line[1]) };
                   })
                   .ToList();

//CalculatePosition(commands);
//CalculatePositionWithAim(new List<Command>()
//{
//    new Command() { Name = "down", Value = 5 }, //x = 0, aim = 5, depth = 0
//    new Command() { Name = "forward", Value = 2 }, //x = 2, aim = 5, depth = 10
//    new Command() { Name = "up", Value = 3 }, //x = 2, aim = 2, depth = 10
//    new Command() { Name = "forward", Value = 3 }, //x = 5, aim = 2, depth = 16
//});
CalculatePositionWithAim(commands);

static void CalculatePosition(List<Command> commands)
{
    int x = 0;
    int depth = 0;

    foreach (var cmd in commands)
    {
        switch (cmd.Name)
        {
            case "forward":
                x += cmd.Value;
                break;
            case "up":
                depth -= cmd.Value;
                break;
            case "down":
                depth += cmd.Value;
                break;
        }
    }
    Console.WriteLine(depth * x);
}

static void CalculatePositionWithAim(List<Command> commands)
{
    int x = 0;
    int depth = 0;
    int aim = 0;

    foreach (var cmd in commands)
    {
        switch (cmd.Name)
        {
            case "forward":
                x += cmd.Value;
                depth += aim * cmd.Value;
                break;
            case "up":
                aim -= cmd.Value;
                break;
            case "down":
                aim += cmd.Value;
                break;
        }
    }
    Console.WriteLine(depth * x);
}

public record Command
{
    public string Name { get; init; }
    public int Value { get; init; }
}