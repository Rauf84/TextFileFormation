using System;

namespace TextFileFormation
{
    internal class BinaryTree
    {
        /// <summary>
        /// Class for the binary tree datastructure.
        /// </summary>
        public Node Root { get; set; }

        /// <summary>
        /// Add the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftNode;
                else if (value > after.Data)
                    after = after.RightNode;
                else
                {
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        /// <summary>
        /// Rekursive method.
        /// </summary>
        /// <param name="parent"></param>
        public void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Rekursive method.
        /// </summary>
        /// <param name="parent"></param>
        public void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Rekursive method.
        /// </summary>
        /// <param name="parent"></param>
        public void TraversePostOrder(Node parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
            Console.WriteLine();
        }
    }
}