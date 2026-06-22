for (int i = 1; i <= 100; i++)
{
    string output;
    if (i % 15 == 0)
    {
        output = "FizzBuzz";
    }
    else if (i % 3 == 0)
    {
        output = "Fizz";
    }
    else if (i % 5 == 0)
    {
        output = "Buzz";
    }
    else
    {
        output = i.ToString();
    }

    Console.WriteLine(output);
}