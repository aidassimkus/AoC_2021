var numbers = File.ReadAllLines("input.txt").ToList();

//Calculate(numbers);
CalculatePart2(new List<string>()
{
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010"
}, 0, false);

//Console.WriteLine(Convert.ToInt32(CalculatePart2(numbers, 0, true), 2) * Convert.ToInt32(CalculatePart2(numbers, 0, false), 2));

static void Calculate(List<string> numbers)
{
    //TODO: transpose list to binary numbers by each column value?

    var noOfDigits = numbers[0].Length;

    string gamma = "";
    string epsilon = "";

    for (int i = 0; i < noOfDigits; i++)
    {
        var ithDigitOfFirstItem = CharToInt(numbers[0][i]);
        int numberOfOnes = (ithDigitOfFirstItem & 1);

        foreach (var number in numbers.Skip(1))
        {
            var ithDigit = CharToInt(number[i]);
            numberOfOnes += (ithDigit & 1);
        }

        int numberOfZeros = numbers.Count - numberOfOnes;

        gamma += numberOfOnes > numberOfZeros ? 1 : 0;
        epsilon += numberOfOnes > numberOfZeros ? 0 : 1;

    }

    Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));

    int CharToInt(char ch)
    {
        return ch - '0';
    }
}

static string CalculatePart2(List<string> numbers, int position, bool oxygen)
{
    //TODO: can we avoid going through the list of numbers for different measurements (oxygen vs. CO2)?

    var noOfDigits = numbers[0].Length;

    var numbersWithOnes = new List<string>();
    var numbersWithZeros = new List<string>();

    if (numbers.Count == 1)
    {
        Console.WriteLine(numbers[0]);
        return numbers[0];
    }

    for (int i = position; i < noOfDigits; i++)
    {
        var ithDigitOfFirstItem = CharToInt(numbers[0][i]);
        int numberOfOnes = (ithDigitOfFirstItem & 1);

        CollectNumbersWithOnesOrZeros(numbers[0], i);

        foreach (var number in numbers.Skip(1))
        {
            CollectNumbersWithOnesOrZeros(number, i);

            var ithDigit = CharToInt(number[i]);
            numberOfOnes += (ithDigit & 1);
        }

        void CollectNumbersWithOnesOrZeros(string number, int i)
        {
            if (number[i] == '1')
            {
                numbersWithOnes.Add(number);
            }
            else
            {
                numbersWithZeros.Add(number);
            }
        }

        int numberOfZeros = numbers.Count - numberOfOnes;

        if (numberOfOnes >= numberOfZeros)
        {
            return CalculatePart2(oxygen ? numbersWithOnes : numbersWithZeros, position + 1, oxygen);
        }

        return CalculatePart2(oxygen ? numbersWithZeros : numbersWithOnes, position + 1, oxygen);
    }

    int CharToInt(char ch)
    {
        return ch - '0';
    }

    return "";
}