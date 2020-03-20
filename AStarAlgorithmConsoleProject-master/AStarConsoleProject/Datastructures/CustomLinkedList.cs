using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private Node<T> HeadNode { get; set; }

        public CustomLinkedList()
        {
            HeadNode = null;
        }

        public void AddLast(T data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(data);
            }
            else
            {
                HeadNode.AddToEnd(data);
            }
        }

        public void AddFirst(T data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T>(data);
            }
            else
            {
                Node<T> tmp = new Node<T>(data);
                tmp.next = HeadNode;
                HeadNode.previous = tmp;
                HeadNode = tmp;
            }
        }

        public bool Remove(T value)
        {

            if (HeadNode == null)
            {
                return false;
            }

            Node<T> tmp = FindNode(value);
            if (tmp == null)
            {
                return false;
            }

            NodeToRemove(tmp);
            return true;
        }

        private void NodeToRemove(Node<T> node)
        {
            if (node.next != null && node.previous != null) //Node is between two nodes
            {
                node.previous.next = node.next;
                node.next.previous = node.previous;

            }

            if (node.next != null && node.previous == null) //Node is at beginning
            {
                HeadNode = node.next;
                HeadNode.previous = null;
            }

            if (node.next == null && node.previous != null) //Node is at end
            {
                node.previous.next = null;
            }

            if (node.next == null && node.previous == null) //Node is the only node in list
            {
                HeadNode = null;
            }
        }

        private Node<T> FindNode(T value)
        {
            Node<T> tmpNode = HeadNode;
            for (int i = 0; i < this.Count(); i++)
            {
                if (tmpNode.data.Equals(value))
                {
                    return tmpNode;
                }
                tmpNode = tmpNode.next;
            }
            return null;
        }

        public T Find(T value)
        {
            Node<T> tmpNode = HeadNode;
            for (int i = 0; i < this.Count(); i++)
            {
                if (tmpNode.data.Equals(value))
                {
                    return tmpNode.data;
                }
                tmpNode = tmpNode.next;
            }
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = HeadNode;

            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
