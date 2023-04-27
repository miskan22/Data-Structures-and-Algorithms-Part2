/*
//1. O(2 power of n)
for (int k = n; k > 0; k--) // loops n times
{
    for (int i = 30; i > 0; i--) //loops 30 times
    {
        for (int j = n; j > 0; j--) //loops n times
        {
            WriteLine("*"); // these two executed n^2 times
        }
    }
}
=> T(n) = cn * c30 * cn = O(n^2)

//2. O(logn)
int count = n;
while (count > 1)
{
    count = count / 2;
}
=> count = 2*2*2*... = 2^k, 2k = n
    log base2 (2^k) = log(n), k = log(n)
O(n) = log(n)

//3. O(2 of power n)
for (int i = 10; i > 0; i--) loops 10 times
{
    WriteLine("*");
}
for (int i = n; i > 0; i--) loops n times
{
    for(int j = n; j > 0; j--) loops n times
    {
        WriteLine("*"); //these two for loop is infinite loop
    }
}
=> T(n) = c10 + cn^2 = O(n^2)
*/