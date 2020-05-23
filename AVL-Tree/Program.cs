using System;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Add(6);
            tree.Add(8);
            tree.Add(9);
            tree.Add(11);
            tree.Add(12);
            tree.Add(15);
            tree.Add(18);
            tree.Add(Convert.ToInt32(Console.ReadLine()));
            tree.Add(7);
            tree.ShowAllTree();
            tree.Delete(8);
            tree.ShowAllTree();
            //tree.Add(3);
            //tree.ShowAllTree();
            //tree.Find(2);
        }
    }
}
