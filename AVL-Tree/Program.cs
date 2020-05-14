using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            ///tree.Add(Convert.ToInt32(Console.ReadLine()));
            //tree.Add(7);
            tree.ShowAllTree();
            tree.Delete(7);
            tree.ShowAllTree();
            tree.Add(3);
            tree.ShowAllTree();           
        }
    }
}
