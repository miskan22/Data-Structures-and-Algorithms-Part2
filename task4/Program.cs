using static System.Console;
class Program
{
    static void Main()
    {
        Task4();
    }
    static void Task4()
    {
        DLL dll = new DLL();
        int[] a = GenerateUniqueNumbers(10);
        foreach (int i in a)
        {
            dll.AddLast(i);
        }
        //a.ToList().ForEach(n=>Write(n + " "));
        WriteLine("DLL nodes in reverse order");
        PrintBackwards(dll);
        FindMiddle(dll);
    }
    static int [] GenerateUniqueNumbers(int size)
    {
        Random random = new Random();
        HashSet<int> values = new HashSet<int>();
        while (true){
            values.Add(random.Next(1, 100));
            if(values.Count == size) break;
        }
        return values.ToArray();
    }
    static int GetDLLSize(DLL dll)//find length
    {
        DLLNode? t = dll.Head;
        int i = 0;
        while (t != null){
            t = t.Next;
            i++;
        }
        return i;
    }
    static void PrintBackwards(DLL dll)
    {
        if(dll.Tail == null || dll.Head == null) return;
        DLLNode? t = dll.Tail;
        while (t != null){
            Write(t.Num + " ");
            t = t.Prev;
        }
    }
    static void FindMiddle(DLL dll)//from tail to head
    {
        DLLNode? t = dll.Head;
        if (t != null) {
            int i = GetDLLSize(dll);
            int mid = i / 2;
            while (mid != 0) {
                t = t.Next;
                mid--;
            }
            WriteLine();
            Console.WriteLine($"Middle node: {t.Num}");
        }
    }
    class DLL
    {
        public DLLNode? Head {get; set;}
        public DLLNode? Tail {get; set;}
        public void AddLast(int e)
        {
            DLLNode node = new DLLNode(e);
            if (Head == null || Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
        }
    }
    class DLLNode
    {
        public int Num {get; set;}
        public DLLNode? Prev {get; set;}
        public DLLNode? Next {get; set;}
        public DLLNode(int elem)
        {
            this.Num = elem;
        }
    }
}