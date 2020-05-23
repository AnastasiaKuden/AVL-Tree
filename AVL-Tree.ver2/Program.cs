using System;

namespace AVL_Tree.ver2
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tryTree = new AVLTree<int>();

            tryTree.Add(5);
            tryTree.Add(3);
            tryTree.Add(7);
            tryTree.Add(2);
            tryTree.Add(12);
            tryTree.Add(15);
            tryTree.Add(21);

            foreach (var item in tryTree)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(tryTree.Contains(5));

            tryTree.Remove(3);

            foreach (var item in tryTree)
            {
                Console.WriteLine(item);
            }

            tryTree.Clear(); 

            foreach (var item in tryTree)
            {
                Console.WriteLine(item);
            }
        }
    }
}
