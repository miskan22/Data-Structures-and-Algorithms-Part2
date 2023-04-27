using static System.Console;
class Program
{
    static void Main()
    {
        Task5();
        WriteLine();
        WriteLine("Push: Insert an item into a stack");
        WriteLine("Pop: Remove an item from a stack");
        WriteLine("Enqueue: Insert an item into a queue");
        WriteLine("Dequeue: Remove an item from a queue");
    }
    static void Task5()
    {
        var stack = new MyStack();
        int size = 3, count = 1;//to display the number of numbers that we are reading.
        //size is length.
        WriteLine("Enter 3 numbers: ");
        while (count <= size)//(stack.Count > 0)
        {
            Write($"Enter a number: ");//1,2, ...so on
            if (int.TryParse(ReadLine(), out int num))//ReadLine: read a line from the console
            {
                //rather than display a number, needs to push the stack
                count++;//to stop the loop
                stack.Push(num);
            }
        }
        WriteLine("The entered numbers in reverse order:");
        for(int i = 0; i < size; i++)
        //run this loop for 3 times. int is minimum 0 to maximum 3
        {
            Write(stack.Peek() + " ");
            stack.Pop();
        }
    }
}


//either use the MyStack class or create an instance
class MyStack
{
    private LinkedList<int> _stack;
    public int Count {get => _stack.Count;}
    public MyStack() {_stack = new LinkedList<int>();}
    public void Push(int e)
    {
        _stack.AddFirst(e);
    }
    public int Peek()
    {//count the list and if the stack is an empty, goes to the first one.
        if (Count == 0)
        {
            throw new InvalidOperationException("Empty stack");
        }
        return _stack.First();
    }
    public int Pop()
    {
        int e = Peek();
        _stack.RemoveFirst();
        return e;
    }
}