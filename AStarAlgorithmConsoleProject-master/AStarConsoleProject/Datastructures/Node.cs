namespace DataStructures
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node<T> previous;

        public Node(T data)
        {
            this.data = data;
        }

        
        public void AddToEnd(T data)
        {
            if (next == null)
            {
                next = new Node<T>(data);
                next.previous = this;
            }
            else
            {
                next.AddToEnd(data);
            }
        }



    }
}
