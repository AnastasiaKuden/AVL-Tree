using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Tree
{
    public class Tree
    {
        Node head;

        public Tree()
        {
        }

        private Node DoBalance(Node currentHead)
        {
            int dif = FindFactorBalance(currentHead);
            if (dif > 1)
            {
                if (FindFactorBalance(currentHead.left) > 0)
                {
                    currentHead = RotateLeft(currentHead);
                }
                else
                {
                    currentHead = RotateLeftRight(currentHead);
                }
            }
            else if (dif < -1)
            {
                if (FindFactorBalance(currentHead.right) > 0)
                {
                    currentHead = RotateRightLeft(currentHead);
                }
                else
                {
                    currentHead = RotateRight(currentHead);
                }
            }
            return currentHead;
        }

        private int FindFactorBalance(Node currentHead)
        {
            int leftHeight = getHeight(currentHead.left);
            int rightHeight = getHeight(currentHead.right);
            return leftHeight - rightHeight;
        }

        private int getHeight(Node currentHead)
        {
            int height = 0;
            if (currentHead != null)
            {
                int leftHeight = getHeight(currentHead.left);
                int rightHeight = getHeight(currentHead.right);
                int max = Math.Max(leftHeight, rightHeight);
                height = max + 1;
            }
            return height;
        }

        private Node RotateRight(Node mainHead)
        {
            Node center = mainHead.right;
            mainHead.right = center.left;
            center.left = mainHead;
            return center;
        }

        private Node RotateLeft(Node mainHead)
        {
            Node center = mainHead.left;
            mainHead.left = center.right;
            center.right = mainHead;
            return center;
        }

        private Node RotateLeftRight(Node mainHead)
        {
            Node center = mainHead.left;
            mainHead.left = RotateRight(center);
            return RotateLeft(mainHead);
        }

        private Node RotateRightLeft(Node mainHead)
        {
            Node center = mainHead.right;
            mainHead.right = RotateLeft(center);
            return RotateRight(mainHead);
        }

        //create
        public void Add(int value)
        {
            Node newValue = new Node(value);
            if (head == null)
            {
                head = newValue;
            }
            else
            {
                head = Add(head, newValue);
            }
        }

        private Node Add(Node currentHead, Node newValue)
        {
            if (currentHead == null)
            {
                currentHead = newValue;
                return currentHead;
            }
            if (newValue.value < currentHead.value)
            {
                currentHead.left = Add(currentHead.left, newValue);
                currentHead = DoBalance(currentHead);
            }
            else if (newValue.value >= currentHead.value)
            {
                currentHead.right = Add(currentHead.right, newValue);
                currentHead = DoBalance(head);
            }
            return currentHead;
        }       

        //delete
        public void Delete(int valueToDelete)
        {
            head = Delete(head, valueToDelete);
        }

        private Node Delete(Node currentHead, int valueToDelete)
        {
            Node mainHead;

            if (currentHead == null)
            { 
                return null; 
            }
            else
            {                
                if (valueToDelete < currentHead.value)
                {
                    currentHead.left = Delete(currentHead.left, valueToDelete);
                    if (FindFactorBalance(currentHead) == -2)
                    {
                        if (FindFactorBalance(currentHead.right) <= 0)
                        {
                            currentHead = RotateRight(currentHead);
                        }
                        else
                        {
                            currentHead = RotateRightLeft(currentHead);
                        }
                    }
                }                
                else if (valueToDelete > currentHead.value)
                {
                    currentHead.right = Delete(currentHead.right, valueToDelete);
                    if (FindFactorBalance(currentHead) == 2)
                    {
                        if (FindFactorBalance(currentHead.left) >= 0)
                        {
                            currentHead = RotateLeft(currentHead);
                        }
                        else
                        {
                            currentHead = RotateLeftRight(currentHead);
                        }
                    }
                }                
                else
                {
                    if (currentHead.right != null)
                    {                        
                        mainHead = currentHead.right;
                        while (mainHead.left != null)
                        {
                            mainHead = mainHead.left;
                        }
                        currentHead.value = mainHead.value;
                        currentHead.right = Delete(currentHead.right, mainHead.value);
                        if (FindFactorBalance(currentHead) == 2)
                        {
                            if (FindFactorBalance(currentHead.left) >= 0)
                            {
                                currentHead = RotateLeft(currentHead);
                            }
                            else 
                            { 
                                currentHead = RotateLeftRight(currentHead); 
                            }
                        }
                    }
                    else
                    {   
                        return currentHead.left;
                    }
                }
            }
            return currentHead;
        }

        //read
        public void ShowAllTree()
        {
            if (head == null)
            {
                Console.WriteLine("Пусто");
                return;
            }
            ShowAllTree(head);
            Console.WriteLine();
        }
        private void ShowAllTree(Node currentHead)
        {
            if (currentHead != null)
            {
                ShowAllTree(currentHead.left);
                Console.Write($"({currentHead.value})");
                ShowAllTree(currentHead.right);
            }
        }       
    }
}
