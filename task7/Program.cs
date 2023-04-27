using static System.Console;

class Program
{
    static void Main()
    {
        Task7();
    }
    static void Task7()
    {
        BST bst = new BST();
        new int[] {3, 2, 5, 1, 7, 9, 6}.ToList().ForEach(i => bst.Insert(i));
        //int count = DisplayPrime(bst.Root);
        if (bst.Root != null)
        {
            WriteLine("BST in ascending order: ");
            PrintAscending(bst.Root);
            WriteLine("\nBST in descending order: ");
            PrintDescending(bst.Root);
            WriteLine($"\nPrime numbers in BST: ");
            DisplayPrime(bst.Root);
            WriteLine($"\nBST size: {GetBSTSize(bst.Root)}");
        }
    }
    static void PrintDescending(BSTNode? root)
    {
        if(root == null) return;
        if(root.Right != null) PrintDescending(root.Right);
        Write($"{root.Key, -4}");
        if(root.Left != null) PrintDescending(root.Left);
        //return 0;
    }
    static void PrintAscending(BSTNode? root)
    {
        if(root == null) return;
        if(root.Left != null) PrintAscending(root.Left);
        Write($"{root.Key, -4}");
        if(root.Right != null) PrintAscending(root.Right);
        //return 0;
    }
    static void DisplayPrime(BSTNode? root)
    {
        if(root == null) return;
        if(root.Left != null) DisplayPrime(root.Left);
        if(IsPrime(root.Key)) //call the function.
        Write($"{root.Key, -4}");
        if(root.Right != null) DisplayPrime(root.Right);
    }
    static int GetBSTSize(BSTNode? root)
    {
        if(root == null) return 0;
        return 1 + (GetBSTSize(root.Left) + GetBSTSize(root.Right));
    }
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if(n % i == 0) return false;
        }
        return true;
    }
}
class BST
{
    public BSTNode? Root {get; set;}
    public bool Contains(int e)
    {
        BSTNode? t = Root;
        while (t != null)
        {
            if(e == t.Key) return true;
            else if (e < t.Key)
                t = t.Left;//keep searching in left subtree
            else
                t = t.Right;//keep searching in right subtree
        }
        return false;//because the previous loop didn't return true
    }
    public bool Insert(int e)
    {
        BSTNode node = new BSTNode(e);
        if(Root == null)
        {
            Root = node;
            return true;
        }
        BSTNode t = Root;
        while(true)
        {
            if(e < t.Key)
            { 
                if(t.Left == null)
                {
                    t.Left = node;
                    return true;
                }
                //otherwise
                t = t.Left; //go to left-subtree
            } 
            else if(e > t.Key)
            { 
                if(t.Right == null)
                {
                    t.Right = node;
                    return true;
                }
                t = t.Right; //goto right-subtree
            } 
            else
            {
                //t.Key == e. duplicate
                return false;
            }
        }//end of while(true)
    }//end of Insert
}
class BSTNode
{
    public int Key {get; set;}
    public BSTNode? Left {get; set;}
    public BSTNode? Right {get; set;}
    public BSTNode(int elem)
    {
        this.Key = elem;
    }
}