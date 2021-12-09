var inputArray = File.ReadAllLines("input.txt").Select(x => Convert.ToInt32(x)).ToArray();

//CountIncreases(inputArray);
//CountInreasesSliding(new int[] { 1, 2, 3, 4, 5, 6 });
CountInreasesSliding(inputArray);

static void CountIncreases(int[] inputArray)
{
    int previous = inputArray[0];
    int count = 0;
    for (int i = 1; i < inputArray.Length; i++)
    {
        if (inputArray[i] > previous) count++;
        previous = inputArray[i];
    }

    Console.WriteLine(count);
}

static void CountInreasesSliding(int[] inputArray)
{
    int windowStart = 0;
    int windowSum = 0;
    int previousSum = 0;
    int count = 0;

    for(int windowEnd = 0; windowEnd < inputArray.Length; windowEnd++)
    {
        windowSum += inputArray[windowEnd];
        if (windowEnd - windowStart == 2)
        {
            if(previousSum != 0 && windowSum > previousSum)
            {
                count++;
            }

            previousSum = windowSum;
            windowSum -= inputArray[windowStart++];            
        }
    }

    Console.WriteLine(count);
}