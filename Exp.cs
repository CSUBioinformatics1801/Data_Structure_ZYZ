//utf-8
//Sean Peldom Zhang
//This is my Exp test of Data Structure
using System;
using System.IO;
using System.Text;

namespace Data_Structure_Exp
{
    class Exp_main
    {
        static void Main(string[] args)
        {

        }
    }
    class Exp1 //Sequential List & Linked List
    {
        public interface IListDS<T>
        {
            int GetLength();
            void Clear();
            bool IsEmpty();
            void Append(T item);
            void Insert(T item, int i);
            void Replace(T item, int i);
            T Delete(int i);
            T GetElem(int i);
            int Locate(T value);
            void display_all();
        }
        public class SeqList<T> : IListDS<T>
        {
            private int maxsize;
            private T[] data;
            private int last;
            public T this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
            public int Last
            { 
                get { return last; } 
            }
            public int Maxsize{ get; set; }
            public SeqList(int size)
            {
                data = new T[size];
                maxsize = size;
                last = -1;
            }//constructor
            public int GetLength()
            {
                return last + 1;
            }
            public void Clear()
            {
                last = -1;
            }
            public bool IsEmpty()
            {
                if (last == -1) return true;
                else return false;
            }
            public void EmptyListWarning()
            {
                Console.WriteLine("Empty List!");
            }
            public bool IsFull()
            {
                if (last == maxsize - 1) return true;
                else return false;
            }
            public void IsFullWarning()
            {
                Console.WriteLine("The Sequential List is Full! No more adding!");
            }
            public void PositionWarning()
            {
                Console.WriteLine("Wrong Position, please try another one.");
            }
            public void Append(T item)
            {
                if (IsFull() == true)
                {
                    IsFullWarning();
                    return;
                }
                else data[++last] = item;
            }
            public void Insert(T item,int i)
            {
                if (IsFull() == true)
                {
                    IsFullWarning();
                    return;
                }
                if (i <= 0 || i >= last + 3)
                {
                    PositionWarning();
                    return;
                }
                if (i == last + 2)
                {
                    data[last + 1] = item;
                    //you can't replace "last + 1" with "++last" as it'll be used as follows
                }
                else
                {
                    for (int j = last; j >= i - 1; --j)
                    {
                        data[j + 1] = data[j];
                    }//move data through the circle 
                }
                data[i - 1] = item;
                ++last;
            }
            public T Delete(int i)
            {
                T temp = default(T);
                if (IsEmpty() == true)
                {
                    Console.WriteLine("No item in the list.");
                    return temp;
                }
                if (i <= 0 || i >= last + 2)
                {
                    PositionWarning();
                    return temp;
                }
                if (i == last + 1)//if the deleted is the last one
                {
                    temp = data[last--];
                }
                else
                {
                    temp = data[i - 1];
                    for(int j = i; j <= last; ++j)
                    {
                        data[j] = data[j + 1];
                        //fill in the gap
                    }
                }
                --last;
              //  Console.WriteLine("Delete successfully!");
                return temp;
            }
            public T GetElem(int i)
            {
                if (IsEmpty()==true)
                {
                    EmptyListWarning();
                    return default(T);
                }
                if ((i <= 0) || (i >= last + 2))
                {
                    PositionWarning();
                    return default(T);
                }
                else return data[i - 1];
                
            }
            public int Locate(T value)
            {
                if (IsEmpty() == true)
                {
                    EmptyListWarning();
                    return -1;
                }
                else
                {
                    int i;
                    for(i=0; i <= last; ++i)
                    {
                        if (value.Equals(data[i])==true)
                        {
                            break;
                        }
                    }
                    if (i> last)
                    {
                        return -1;
                    }
                    return i;
                }
            }
            public void display_all()
            {
                if (IsEmpty() == true)
                {
                    EmptyListWarning();
                }
                else
                {
                    for(int i = 0; i <= last; i++)
                    {
                        if (i % 8 == 0 && i!=0) Console.WriteLine("");
                        Console.Write(data[i]+" ");
                        //8 items per line
                    }
                    Console.WriteLine("");
                }
            }
            public void Replace(T item, int i)
            {
                if (IsFull() == true)
                {
                    IsFullWarning();
                    return;
                }
                if (i <= 0 || i >= last + 3)
                {
                    PositionWarning();
                    return;
                }
                data[i-1] = item;
                Console.WriteLine("Replace done");
            }
        }
        public class Node<T>
        {
            public T data { get; set; }//data
            public Node<T> next { get; set; }// point
            public Node(T value, Node<T> p)//both
            {
                this.data = value;
                this.next = p;
            }
            public Node(Node<T> p)// null data
            {
                this.next = p;
            }
            public Node(T Data)//null point
            {
                this.data = Data;
                this.next = null;
            }
            public Node()//neither
            {
                this.data = default;
                this.next = null;
            }
        }
        public class LinkList<T>:IListDS<T>
        {
            private Node<T> head;
            public Node<T> Head { get; set; }
            public LinkList() { head = null; }//constructor
            public int GetLength()
            {
                Node<T> p = head;
                int length = 0;
                while (p != null)
                {
                    ++length;
                    p = p.next;
                }
                return length;
            }
            public void Clear() { head = null; }
            public bool IsEmpty()
            {
                if (head == null) return true;
                else return false;
            }
            public void EmptyListWarning()
            {
                Console.WriteLine("Empty List!");
            }
            public void Append(T item)//add at tail
            {
                Node<T> q = new Node<T>(item);
                Node<T> p = new Node<T>();
                if (IsEmpty())//empty list
                {
                    head = q;
                    return;
                }
                else //nut empty list
                {
                    p = head;
                    while (p.next != null)
                    {
                        p = p.next;
                    }
                    p.next = q;
                }
            }
            public void Insert(T item,int i)
            {
                if (IsEmpty()) 
                {
                    EmptyListWarning(); 
                    return;
                }
                if (i < 1) 
                {
                    PositionWarning();
                    return;
                }
                if(i==1)//new head
                {
                    Node<T> q = new Node<T>(item);
                    q.next = head;
                    head = q;
                    return;
                }
                else
                {
                    Node<T> p = head;
                    Node<T> r = new Node<T>();
                    int j = 1;
                    while (p.next != null&&j<i)//traversal
                    {
                        r = p;//before p
                        p = p.next;
                        ++j;
                    }
                    if (j == i)//add q right at the place between r and p
                    {
                        Node<T> q = new Node<T>(item);
                        q.next = p;
                        r.next = q;
                    }
                }
            }
            public void PositionWarning()
            {
                Console.WriteLine("Wrong Position, please try another one.");
            }
            public T Delete(int i)
            {
                if (IsEmpty())
                {
                    EmptyListWarning();
                    return default;
                }
                if (i <= -1)
                {
                    PositionWarning();
                    return default;
                }
                else
                {
                    Node<T> q=new Node<T>();
                    if (i == 1)//delete head
                    {
                        q = head;
                        head = head.next;
                        return q.data;
                    }
                    else
                    {
                        Node<T> p = head;
                        int j = 1;
                        while (p.next != null && j<i)
                        {
                            ++j;
                            q = p;//q is before p
                            p = p.next;
                        }
                        if(j==i)
                        {
                            q.next = p.next;//p is deleted
                            return p.data;
                        }
                        else
                        {
                            Console.WriteLine("Not exist! Please Try again!");
                            return default;
                        }
                    }
                }
            }
            public T GetElem(int i)
            {
                if (IsEmpty())
                {
                    EmptyListWarning();
                    return default;
                }
                if (i < 0)
                {
                    PositionWarning();
                    return default;
                }
                else
                {
                    Node<T> p=new Node<T>();
                    p = head;
                    int j = 1;
                    while(p.next!=null && j < i)
                    {
                        ++j;
                        p = p.next;
                    }
                    if (j == i)
                    {
                        return p.data;
                    }
                    else
                    {
                        Console.WriteLine("Not exist!");
                        return default;
                    }
                }
            }
            public int Locate(T value)
            {
                if (IsEmpty())
                {
                    EmptyListWarning();
                    return -1;
                }
                else
                {
                    Node<T> p = new Node<T>();
                    p = head;
                    int i = 1;
                    while (p.next != null && !p.data.Equals(value))
                    {
                        p = p.next;
                        ++i;
                    }
                    return i;
                }
            }
            public void Replace(T item,int i)
            {
                if (IsEmpty())
                {
                    EmptyListWarning();
                    return;
                }
                if (i < 0)
                {
                    PositionWarning();
                    return;
                }
                else
                {
                    Node<T> p = new Node<T>();
                    Node<T> q = new Node<T>(item);
                    p = head;
                    int j = 1;
                    while (p.next != null && j < i)
                    {
                        ++j;
                        p = p.next;
                    }
                    if (j == i)
                    {
                        p.data = q.data;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Not exist!");
                        return;
                    }
                }
            }
            public void display_all()
            {
                if (IsEmpty())
                {
                    EmptyListWarning();
                    return;
                }
                else
                {
                    Node<T> p = new Node<T>();
                    p = head;
                    int i = 1;
                    while (p.next != null)
                    {
                        Console.Write(p.data + " ");
                        if (i % 8 == 0 && i!=0) Console.WriteLine("");
                        i++;
                        p = p.next;
                    }
                    if ((i - 1) % 8 == 0) Console.WriteLine("");
                    Console.Write(p.data);//the last one(draw back of the circle)
                    Console.WriteLine("");
                }
            }
        }
        public static void Debug_Exp_1()
        {
            int qt = 1;
            SeqList<int> seqList = new SeqList<int>(20);
            //a sequential list that storing numbers
            //initiate the list
            for (int i = 1; i <= 10; i++)
            {
                seqList.Append(i);
            }
            Console.WriteLine("initiating:");
            seqList.display_all();
            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("list length(by function): "+seqList.GetLength());
            Console.WriteLine("list length(by value):" + (seqList.Last + 1));

            Console.Write("\nQ{0}\n", qt++);
            seqList.Insert(30,5);
            seqList.display_all();

            Console.Write("\nQ{0}\n", qt++);
            if (seqList.IsEmpty()) seqList.EmptyListWarning();
            else if (seqList.IsFull()) seqList.IsFullWarning();
            else Console.WriteLine("Neither full nor empty");

            Console.Write("\nQ{0}\n", qt++);
            seqList.Maxsize = 15;
            seqList.Insert(30, 5);
            seqList.display_all();
            Console.WriteLine("There isn't much difference between Q1 & Q4 thus confusing");

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("Skip the question as is it finished in Q1");

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("Skip the question as is it finished in Q3");

            Console.Write("\nQ{0}\n", qt++);
            seqList.Delete(7);
            seqList.display_all();

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("5th elem:"+ seqList.GetElem(5));

            Console.Write("\nQ{0}\n", qt++);
            seqList.Replace(30, 5);
            seqList.display_all();

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("Skip the question as is it finished in Q8");

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("place:" +seqList.Locate(9));

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("Skip the question as I displayed every times");

            Console.Write("\nQ{0}\n", qt++);
            seqList.Clear();
            seqList.display_all();

            Console.Write("\nQ{0}\n", qt++);
            if (seqList.IsEmpty()) seqList.EmptyListWarning();
        }
        public static void Debug_Exp_2() 
        {
            //initiate Q1
            int qt = 1;
            Console.Write("\nQ{0}\n",qt++);
            LinkList<int> linklist = new LinkList<int>();
            for(int i = 1; i <= 10; i++)
            {             
                linklist.Append(i);
            }
            linklist.display_all();

            Console.Write("\nQ{0}\n", qt++);
            if (linklist.IsEmpty()) linklist.EmptyListWarning();
            else Console.WriteLine("Not empty");

            Console.Write("\nQ{0}\n", qt++);
            linklist.Insert(30, 5);
            linklist.display_all();

            Console.Write("\nQ{0}\n", qt++);
            linklist.Delete(7);
            linklist.display_all();

            Console.Write("\nQ{0}\n", qt++);
            linklist.Replace(20, 5);
            linklist.display_all();

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine(linklist.GetElem(5));

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("Rank number: "+linklist.Locate(8));

            Console.Write("\nQ{0}\n", qt++);
            Console.WriteLine("length of link list:" + linklist.GetLength().ToString());

            Console.Write("\nQ{0}\n", qt++);
            linklist.Clear();
            if (linklist.IsEmpty()) linklist.EmptyListWarning();

        }
    }
    class Exp2 //Stack & Queue
    {
        //structure define
        public interface IStack<T>
        {
            int GetLength();
            bool IsEmpty();
            void EmptyWarning();
            void Clear();
            public bool IsFull();
            public void FullWarning();
            void Push(T item);
            T Pop();
            T GetPop();
        }
        public class SeqStack<T>:IStack<T> //Sequential Stack
        {
            private int maxsize;
            public int Maxsize 
            {
                get { return maxsize; }
                set{ maxsize = value; }
            }
            private T[] data;
            public T this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
            private int top;
            public SeqStack(int size)//null empty
            {
                data = new T[size];
                maxsize = size;
                top = -1;
            }
            public int Top 
            {
                get { return top; }
            }
            public int GetLength()
            {
                return top + 1;
            }
            public void Clear()
            {
                top = -1;
            }
            public bool IsEmpty()
            {
                if (top == -1) return true;
                else return false;
            }
            public void EmptyWarning()
            {
                Console.WriteLine("Empty Stack!");
            }
            public bool IsFull()
            {
                if (top + 1 == maxsize) return true;
                else return false;
            }
            public void FullWarning()
            {
                Console.WriteLine("Stack is full!");
            }
            public void Push(T item)
            {
                if (IsFull()) FullWarning();
                else data[++top] = item;
            }
            public T Pop()
            {
                T temp = default;
                if (IsEmpty()) 
                {
                    EmptyWarning();
                    return temp;
                } 
                else
                {
                    temp = data[top];
                    --top;
                    return temp;
                }
            }
            public T GetPop()
            {
                if (IsEmpty()) 
                {
                    EmptyWarning();
                    return default;
                }
                else
                {
                    return data[top];
                }
            }
        }
        public class LinkStack<T> : Exp1.Node<T> //linked stack
        {
            private Exp1.Node<T> top;
            public Exp1.Node<T> Top
            {
                get { return top; }
                set { top = value; }
            }
            private int num;
            public int Num
            {
                get { return num; }
                set { num = value; }
            }
            public LinkStack()
            {
                top = null;
                num = 0;
            }
            public int GetLength()
            {
                return num;
            }
            public void Clear()
            {
                top = null;
                num = 0;
            }
            public bool IsEmpty()
            {
                if (top == null && num == 0) return true;
                else return false;
            }
            public void EmptyWarning()
            {
                Console.WriteLine("Empty Stack!");
            }

            public void Push(T item)
            {
                Exp1.Node<T> q = new Exp1.Node<T>(item);
                if(top==null)top = q;//empty stack
                else //add q onto the top
                {
                    q.next = top;
                    top = q;
                }
                ++num;
            }
            public T Pop()
            {
                if (IsEmpty()) 
                {
                    EmptyWarning();
                    return default;
                } 
                else
                {
                    Exp1.Node<T> p = top;
                    top = top.next;
                    --num;
                    return p.data;
                }
            }
            public T GetTop()
            {
                if (IsEmpty())
                {
                    EmptyWarning();
                    return default;
                }
                else
                {
                    return top.data;
                }
            }
            
        }
        public interface IQueue<T>
        {
            int GetLength();
            bool IsEmpty();
            public void EmptyWarning();
            void Clear();
            void In_Queue(T item);
            T Out_Queue();
            T GetFront();
        }
        public class CSeqQueue<T> : IQueue<T> //sequential queue
        {
            private int maxsize;
            public int Maxsize
            {
                get { return maxsize; }
                set { maxsize = value; }
            }
            private T[] data;
            public T this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
            private int front;
            public int Front
            {
                get { return front; }
                set { front = value; }
            }
            private int rear;
            public int Rear
            {
                get { return rear; }
                set { rear = value; }
            }
            public CSeqQueue(int size)
            {
                data = new T[size];
                maxsize = size;
                front = rear = -1; 
            }
            public int GetLength()
            {
                return (rear - front + maxsize) % maxsize;
            }
            public void Clear()
            {
                front = rear = -1;
            }
            public bool IsEmpty()
            {
                if (front == rear) return true;
                else return false;
            }
            public void EmptyWarning()
            {
                Console.WriteLine("Queue is empty!");
            }
            public void FullWarning()
            {
                Console.WriteLine("Queue is empty!");
            }
            public bool IsFull()
            {
                if ((rear + 1) % maxsize == front) return true;
                else return false;
            }
            public T Out_Queue()
            {
                T temp = default;
                if (IsEmpty())
                {
                    EmptyWarning();
                    return default;
                }
                else
                {
                    temp = data[++front];
                    return temp;
                }
            } 
            public void In_Queue(T item)
            {
                if (IsFull())
                {
                    FullWarning();
                    return;
                }
                else data[++rear] = item;
            }
            public T GetFront()
            {
                if (IsEmpty()) 
                {
                    EmptyWarning();
                    return default;
                }
                else
                {
                    return data[front + 1];
                }
            }
        } 
        public class LinkQueue<T> : IQueue<T> //linked queue
        {
            private Exp1.Node<T> front;
            public Exp1.Node<T> Front
            {
                get { return front; }
                set { front = value; }
            }
            private Exp1.Node<T> rear;
            public Exp1.Node<T> Rear
            {
                get { return rear; }
                set { rear = value; }
            }
            private int num;//number of nodes in the queue
            public int Num
            {
                get { return num; }
                set { num = value; }
            }
            public LinkQueue()//defaut: null queue
            {
                front = rear = null;
                num = 0;
            }
            public bool IsEmpty()
            {
                if ((front == rear) && (num == 0)) return true;
                else return false;
            }
            public void EmptyWarning()
            {
                Console.WriteLine("Queue is empty!");
            }
            public void In_Queue(T item)
            {
                Exp1.Node<T> q = new Exp1.Node<T>(item);
                if (rear == null) rear = q;//null queue
                else //not null queue
                {
                    rear.next = q;
                    rear = q;
                }
                ++num;//added a node
            }
            public T Out_Queue()
            {
                if (IsEmpty())
                {
                    EmptyWarning();
                    return default;
                }
                else
                {
                    Exp1.Node<T> p = front;
                    front = front.next;
                    if (front == null) rear = null;//the only node was deleted
                    --num;
                    return p.data;
                }
            }
            public T GetFront()
            {
                if (IsEmpty())
                {
                    EmptyWarning();
                    return default;
                }
                return front.data;
            }
            public int GetLength()
            {
                return num;
            }
            public void Clear()
            {
                front = rear = null;
                num = 0;
            }
        }
        //algorithm based on Stack & Queue
        public static bool Judge_Tenet_SeqStack(string sator)
        {
            //from main()
            //Console.WriteLine("Input the testing palindrome:");
            //string palindrome = Console.ReadLine();
            //if (Exp2.Judge_Tenet(palindrome)) Console.WriteLine("Yes");
            //else Console.WriteLine("No");
            //able was I ere I saw elba by Napoléon Bonaparte
            if (sator.Length <2)
            {
                return false;
            }
            SeqStack<char> rotas = new SeqStack<char>(sator.Length);
            for(int i = 0; i < sator.Length; ++i)//reverse
            {
                rotas.Push(sator[i]);
            }
            for(int j = 0; j < sator.Length; ++j)//judge
            {
                if (rotas.Pop() != sator[j]) return false;                
            }
            return true;
        }
        public static bool Judge_Tenet_Queue(string sator)
        {
            if (sator.Length < 2)
            {
                return false;
            }
            CSeqQueue<char> rotas = new CSeqQueue<char>(sator.Length);
            for (int i = 0; i < sator.Length; ++i)//reverse
            {
                rotas.In_Queue(sator[i]);
            }
            for (int j = 0; j < sator.Length; ++j)//judge
            {
                if (rotas.Out_Queue() != sator[j]) return false;
            }
            return true;
        }
        public static bool Judge_Tenet_SeqList(string sator)
        {
            if (sator.Length < 2)
            {
                return false;
            }
            Exp1.SeqList<char> rotas = new Exp1.SeqList<char>(sator.Length);
            for (int i = 0; i < sator.Length; ++i)//reverse
            {
                rotas.Append(sator[i]);
            }
            for (int j = 0; j < sator.Length; ++j)//judge
            {

                if (rotas.GetElem(rotas.Last) != sator[j])
                {
                    rotas.Delete(rotas.Last);
                    return false;
                } 
            }
            return true;
        }
        public static bool Judge_Out_Stack_Seq(string ori_str,string out_str)
        {
            //from main:
            //Console.WriteLine("print in:");
            //string in_str = Console.ReadLine();
            //Console.WriteLine("print out");
            //string out_str = Console.ReadLine();
            //if (Exp2.Judge_Out_Stack_Seq(in_str, out_str)) Console.WriteLine("yes");
            //else Console.WriteLine("no");
            if (ori_str.Length != out_str.Length) return false;
            int o_ct=0;
            SeqStack<char> temp = new SeqStack<char>(ori_str.Length);
            for(int i = 0; i < ori_str.Length; i++)
            {
                temp.Push(ori_str[i]);
                while (!temp.IsEmpty() && temp.GetPop() == out_str[o_ct])
                {
                    temp.Pop();
                    ++o_ct;
                }
            }
            return (temp.IsEmpty()) ? true : false;  
        }
        public static void Print_All_Pop_Seq(string Push_Seq)
        {
            //from main
            //string temp = Console.ReadLine();
            //Exp2.Print_All_Pop_Seq(temp);
            int str_len = Push_Seq.Length;
            //Catalan number
            int Catalan_num = Addition_Math.combinatorial_num(2 * str_len, str_len) - Addition_Math.combinatorial_num(2 * str_len, str_len + 1);
            Console.WriteLine("Catalan number:" + Catalan_num);
            string[] seq = new string[Catalan_num];
            int catalan_index = 0;
            SeqStack<string> tmp_stck = new SeqStack<string>(Catalan_num-1);
            Catalan(0, 0, Push_Seq.Length, ref seq,ref catalan_index, tmp_stck);
            for(int i = 0; i < Catalan_num; i++)
            {
                Console.WriteLine(seq[i]);
            }//this is awesome
        }
        private static void Catalan(int push, int pop, int str_len,ref string[] seq, ref int catalan_index,SeqStack<string> tmp_stck)
        {           
            if (push == pop && pop == str_len)//can't move on
            {
                catalan_index++;
                if(!tmp_stck.IsEmpty())seq[catalan_index] = tmp_stck.Pop();//skip first
            }
            if (push < str_len)//push first
            {
                if (pop != push) tmp_stck.Push(seq[catalan_index].ToString());
                seq[catalan_index] += 'i';
                Catalan(push + 1, pop, str_len, ref seq, ref catalan_index,tmp_stck);
            }
            if (pop < push)//pop, if not, return to the last available node of the tree
            {
                seq[catalan_index] += 'o';
                Catalan(push, pop + 1, str_len, ref seq,ref catalan_index,tmp_stck);
            }
        }
        public static void GetAllStackArrangement(int[] array, int index, int[] ans, int ansIndex, int stackIndex)//made by Dominic Woo
        {
            if (index >= array.Length && stackIndex >= ans.Length)
            {
                Console.WriteLine(string.Join(", ", ans));
                return;
            }
            if (stackIndex >= ans.Length)
            {
                int temp = ans[ans.Length - 1];
                ans[ans.Length - 1] = array[index++];
                GetAllStackArrangement(array, index, ans, ansIndex, ans.Length - 1);
                ans[ans.Length - 1] = temp;
            }
            else if (index >= array.Length)
            {
                int temp = ans[ansIndex], temp2 = ans[stackIndex];
                ans[ansIndex++] = ans[stackIndex++];
                GetAllStackArrangement(array, index, ans, ansIndex, stackIndex);
                ans[ansIndex - 1] = temp;
                ans[stackIndex - 1] = temp2;
            }
            else
            {
                int temp = ans[ansIndex], temp2 = ans[stackIndex];
                ans[ansIndex++] = ans[stackIndex++];
                GetAllStackArrangement(array, index, ans, ansIndex, stackIndex);
                ansIndex--; stackIndex--;
                ans[ansIndex] = temp; ans[stackIndex] = temp2;
                temp = ans[--stackIndex];
                ans[stackIndex] = array[index++];
                GetAllStackArrangement(array, index, ans, ansIndex, stackIndex);
                ans[stackIndex] = temp;
            }
        }
        public static string base_conversion(int num, int trans_base, int ori_base = 10)
        {
            string trans_num="";//I don't know how to store a specail base value, so it would stored as a string 
            int num10;
            if (ori_base != 10)//trans its base into 10
            {
                num10 = num;
                SeqStack<int> num_10remain_array = new SeqStack<int>(100);//"100" is still in danger,I should've rewrite "*" next time
                while (num10 != 0)
                {
                    num_10remain_array.Push(num10 % 10);
                    num10 = (int)(num10 / 10);
                }//num10 would be 0 after that
                while (!num_10remain_array.IsEmpty())
                {
                    int temp_fac = num_10remain_array.GetLength() - 1;
                    int temp_pop = num_10remain_array.Pop();
                    num10 += temp_pop*Addition_Math.int_power(10, temp_fac);
                }
            }
            else num10 = num;
            SeqStack<int> trans_remain_array = new SeqStack<int>(100);
            while (num10 != 0)
            {
                trans_remain_array.Push(num10 % trans_base);
                num10 = (int)(num10 / trans_base);
            }//num10 would be 0 after that
            while (!trans_remain_array.IsEmpty())
            {
                trans_num += trans_remain_array.Pop().ToString();
            }
            return trans_num;
        }
    }
    class Exp3 //string
    {
        public class StringDS
        {
            //structure define
            public char[] data;
            public char this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
            public StringDS(char[] arr)//constructor
            {
                data = new char[arr.Length];
                for(int i = 0; i < arr.Length; ++i)
                {
                    data[i] = arr[i];
                }
            }
            public StringDS(int len)//constructor 2
            {
                char[] arr = new char[len];
                data = arr;
            }
            public int GetLength()
            {
                return data.Length;
            }
            public int Compare(StringDS s)//s is input item to compare
            {
                //0: same
                //1: bigger
                //-1: smaller
                int min_len = (this.GetLength() <= s.GetLength())? this.GetLength() : s.GetLength();
                int i;
                for (i = 0; i < min_len; i++)
                {
                    if (this[i] != s[i]) 
                    { break; } 
                }
                if (i < min_len)
                {
                    if (this[i] < s[i]) return -1;
                    else if (this[i] > s[i]) return 1;
                }
                else if (this.GetLength() == s.GetLength()) return 0;
                else if (this.GetLength() < s.GetLength()) return -1;
                return 1;
            }
            public void Possition_Warning()
            {
                Console.WriteLine("Possition error!");
            }
            public void Copy(StringDS s)//copy s to current string
            {
                for(int i = 0; i < s.GetLength(); i++)
                {
                    this.data[i] = s.data[i];
                }
            }
            public StringDS Get_Sub_String(int index, int len)
            {
                if ((index < 0) || (index > this.GetLength() - 1) || (len < 0) || (len > this.GetLength() - index))
                {
                    Possition_Warning();
                    return null;
                }
                StringDS s = new StringDS(len);
                for(int i = 0; i < len; i++)
                {
                    s[i] = this[i + index];
                }
                return s;
            }
            public StringDS Concatenation(StringDS s)//add s after this
            {
                StringDS con_str = new StringDS(this.GetLength() + s.GetLength());
                for(int i = 0; i < this.GetLength(); ++i)
                {
                    con_str.data[i] = s.data[i];
                }
                for(int j = 0; j < s.GetLength(); j++)
                {
                    con_str.data[this.GetLength() + j] = s.data[j];
                }
                return con_str;
            }
            public StringDS Insert(int index,StringDS s)//insert s at indexd position
            {
                int con_len = s.GetLength() + this.GetLength();
                StringDS con_str = new StringDS(con_len);
                if (index < 0 || index > this.GetLength() - 1)
                {
                    Possition_Warning();
                    return null;
                }
                for(int i = 0; i < index; ++i)//former str
                {
                    con_str[i] = this[i];
                }
                for(int j = index; j < index + s.GetLength(); j++)//insert str
                {
                    con_str[j] = s[j - index];
                }
                for(int k = index + s.GetLength(); k < con_len; k++)//fomer str
                {
                    con_str[k] = this[k - s.GetLength()];
                }
                return con_str;
            }
            public int BF_Locate(StringDS s)
            {
                if (this.GetLength() < s.GetLength())
                {
                    Console.WriteLine("Too long to locate!");
                    return -1;
                }
                int i = 0;
                int len = this.GetLength() - s.GetLength();
                while (i < len)
                {
                    StringDS temp = this.Get_Sub_String(i, s.GetLength());
                    if (temp.Compare(s) == 0) break;
                    i++;
                }
                if (i <= len) return i; //found, return the position of first char
                return -1;//unable to find
            }
            public void display_all()//print
            {
                for(int i = 0; i < data.Length; i++)
                {
                    if ((i != 0) && (i % 10 == 0))
                    {
                        Console.Write("-");
                        Console.WriteLine("");
                    }
                    Console.Write(data[i]);
                }
                Console.WriteLine("");
            }
            public StringDS Delete(int index, int len)
            {
                if ((index < 0) || (index > this.GetLength() - 1) || (len < 0) || (len > this.GetLength() - index))
                {
                    Possition_Warning();
                    return null;
                }
                StringDS new_str = new StringDS(this.GetLength() - len);
                for(int i = 0; i < index; i++)
                {
                    new_str[i] = this[i];
                }
                for(int j = index + len; index < this.GetLength(); ++j)
                {
                    new_str[j] = this[j];
                }
                return new_str;
            }
            public int[] Next(StringDS sch_str)//core: save repetitive computation
            {
                int[] next = new int[sch_str.GetLength()];
                if (sch_str.GetLength() < 2)//in this case, efficiency of KMP will be lower
                {
                    return next;
                }
                next[0] = -1; next[1]=0;//from PMT
                int n_i = 2;//from present next index, start at 2nd
                int s_i = 0;//from temp variate to count next value, start with next[i-1]
                while (n_i < sch_str.GetLength())
                {
                    if (sch_str.data[n_i] == sch_str.data[s_i])
                    {//if L[i-1]= L[i], then next[n_i]=n_i+s_i
                        next[n_i++] = ++s_i;
                    }
                    else
                    {//if not, check next
                        s_i = next[s_i];
                        if (s_i == -1)//means next[s_i]=1
                        {
                            next[n_i++] = ++s_i;
                        }
                    }
                }
                return next;
            }
            public int KMP_Locate(StringDS sch_str)
            {// for more information about KMP: https://www.zhihu.com/question/21923021
                int[] next = Next(sch_str);
                int m_i = 0;//main_str index
                int s_i = 0;//sch_str index
                while (s_i < sch_str.GetLength() && m_i < this.GetLength())
                {//if search string hasn't been matched && main string hasn't been oversearched
                    if (this[m_i] == sch_str[s_i])
                    {//next
                        m_i++;
                        s_i++;
                    }
                    else
                    {
                        s_i = next[s_i];//1st-type traceback from next, and it's the core of KMP for moving back several sites
                        if (s_i == -1) //2nd-type traceback
                        {
                            s_i++;
                            m_i++;
                        }
                    }
                }
                return s_i < sch_str.GetLength() ? -1:m_i - s_i;
            }
        }
        //algorithm based on string
        public static double[] test_alg_effient(int lapse, int main_str_len)
        {
            //from main:
            //type 1: 
            //int main_len = 10000;//search a word or a sentence(s) from a paper
            //for (int sch_len = 4; sch_len < 50; sch_len++)
            //{
            //    Console.WriteLine("Epoch: " + sch_len);
            //    double[] avg_tri = new double[2] { 0, 0 };
            //    for (int n = 0; n < 10; n++)
            //    {
            //        avg_tri[0] += 1.0 / 3.0 * Exp3.test_alg_effient(sch_len, main_len)[0];
            //        avg_tri[1] += 1.0 / 3.0 * Exp3.test_alg_effient(sch_len, main_len)[1];
            //    }
            //    Exp3.WriteCSV(sch_len, avg_tri);
            //}
            //type 2:
            //int sch_len = 6;//search a word from multi-paper
            //for (int main_len = 9000; main_len < 11000; main_len++)
            //{
            //    Console.WriteLine("Epoch: " + main_len);
            //    double[] avg_tri = new double[2] { 0, 0 };
            //    for (int n = 0; n < 10; n++)
            //    {
            //        avg_tri[0] += 1.0 / 3.0 * Exp3.test_alg_effient(sch_len, main_len)[0];
            //        avg_tri[1] += 1.0 / 3.0 * Exp3.test_alg_effient(sch_len, main_len)[1];
            //    }
            //    Exp3.WriteCSV(main_len, avg_tri);
            //}
            if (lapse > main_str_len) return null;
            StringDS main_ds = new StringDS(main_str_len);
            Random rd = new Random();
            for (int i = 0; i < main_str_len; i++)
            {
                main_ds.data[i] = (char)(rd.Next(0, 26) + (int)'a');
            }
            int begin = rd.Next(0, main_str_len - lapse);
            //Console.WriteLine("begin: " + begin + " end: " + (begin + lapse));
            StringDS sch_ds = main_ds.Get_Sub_String(begin, lapse);
            //Console.WriteLine("Main String:");
            //Console.WriteLine("==============");
            //main_ds.display_all();
            //Console.WriteLine("");
            //Console.WriteLine("Search String:");
            //Console.WriteLine("==============");
            //sch_ds.display_all();
            //Console.WriteLine("");
            DateTime beforeDT_BF = System.DateTime.Now;
            //time-comsuming function region
            main_ds.BF_Locate(sch_ds);
            //Console.WriteLine("BF_locate:"+);
            DateTime afterDT_BF = System.DateTime.Now;
            TimeSpan ts_BF = afterDT_BF.Subtract(beforeDT_BF);
            //Console.WriteLine("BF_Count: {0}ms.", ts_BF.TotalMilliseconds);
            //Console.WriteLine("");

            DateTime beforeDT_KMP = System.DateTime.Now;
            //time-comsuming function region
            main_ds.KMP_Locate(sch_ds);
            //Console.WriteLine("KMP_locate:" + );
            DateTime afterDT_KMP = System.DateTime.Now;
            TimeSpan ts_KMP = afterDT_KMP.Subtract(beforeDT_KMP);
            //Console.WriteLine("KMP_Count: {0}ms.", ts_KMP.TotalMilliseconds);
            //prediction:
            //KMP O(m+n)
            //BM O(m*n)
            double[] duel_time = { ts_BF.TotalMilliseconds, ts_KMP.TotalMilliseconds };
            return duel_time;
        }          
        public static void WriteCSV(int sch_len, double []data_ds)
        {
            string path = @"D:\Remain\6.数据结构\实验\CSVinfoalltest.csv";
            if (!File.Exists(path))File.Create(path).Close();
            StreamWriter sw=new StreamWriter(path,true,Encoding.UTF8);
            //sw.Write(main_len + ",");
            sw.Write(sch_len + ",");
            sw.Write(data_ds[0] + ",");//BF
            sw.Write(data_ds[1] + "\r\n");//KMP
            sw.Flush();
            sw.Close();
        } 
    }
    class Exp4 //Arrays and Generalized Tables
    {
        //not required
    }
    class Exp5 //Tree, Binary Tree, Huffman Tree
    {
        public class Node<T>
        {
            private T data;
            private Node<T> lChild;
            private Node<T> rChild;
            public Node(T val, Node<T> lp, Node<T> rp)
            {
                data = val;
                lChild = lp;
                rChild = rp;
            }
            public Node(Node<T> lp, Node<T> rp)
            {
                data = default;
                lChild = lp;
                rChild = rp;
            }
            public Node(T val)
            {
                data = val;
                lChild = null;
                rChild = null;
            }
            public T Data { get { return data; } set { data = value; } }
            public Node<T> LChild { get { return lChild; } set { lChild = value; } }
            public Node<T> RChild { get { return rChild; } set { rChild = value; } }
        }
        public class BiTree<T>
        {
            private Node<T> head;
            public Node<T> Head { get { return head; } set { head = value; } }
            public BiTree()
            {
                head = null;
            }
            public BiTree(T val)
            {
                Node<T> p = new Node<T>(val);
                head = p;
            }
            public BiTree(T val, Node<T> lp, Node<T> rp)
            {
                Node<T> p = new Node<T>(val, lp, rp);
                head = p;
            }
            public bool IsEmpty()
            {
                if (head == null) return true;
                else return false;
            }
            public Node<T> Root()
            {
                return head;
            }
            public Node<T> GetLChild(Node<T> p)
            {
                return p.LChild;
            }
            public Node<T> GetRChild(Node<T> p)
            {
                return p.RChild;
            }
            public void InsertL(T val, Node<T> p)
            //insert an node leftly between p and its leftchild
            {
                Node<T> temp = new Node<T>(val);
                temp.LChild = p.LChild;
                p.LChild = temp;
            }
            public void InsertR(T val, Node<T> p)
            //insert an node rightly between p and its rightchild
            {
                Node<T> temp = new Node<T>(val);
                temp.RChild = p.RChild;
                p.RChild = temp;
            }
            public Node<T> DeleteL(Node<T> p)
            {
                if (p == null || p.LChild == null) return null;
                else
                {
                    Node<T> temp = p.LChild;
                    p.LChild = null;
                    return temp;
                }
            }
            public Node<T> DeleteR(Node<T> p)
            {
                if (p == null || p.RChild == null) return null;
                else
                {
                    Node<T> temp = p.RChild;
                    p.RChild = null;
                    return temp;
                }
            }
            public bool Isleaf(Node<T> p)
            {
                if (p != null && p.LChild == null && p.RChild == null) return true;
                else return false;
            }
            public void PreOrder(Node<T> root)
            {//DLR auto!
                if (root == null) return;
                Console.Write(root.Data+" ");
                PreOrder(root.LChild);
                PreOrder(root.RChild);
            }
            public void InOrder(Node<T> root)
            {//LDR auto!
                if (root == null) return;
                InOrder(root.LChild);
                Console.Write(root.Data + " ");
                InOrder(root.RChild);
            }
            public void PostOrder(Node<T> root)
            {//LRD auto!
                if (root == null) return;
                PostOrder(root.LChild);
                PostOrder(root.RChild);
                Console.Write(root.Data + " ");
            }
            public void LevelOrder(Node<T> root)
            {
                if (root == null) return;
                Exp2.CSeqQueue<Node<T>> sq = new Exp2.CSeqQueue<Node<T>>(100);
                sq.In_Queue(root);
                while (!sq.IsEmpty())
                {
                    Node<T> temp = sq.Out_Queue();
                    Console.Write(temp.Data.ToString() + " ");
                 //   if (temp.LChild != null || temp.RChild != null) Console.Write("(");//to be deleted
                   // if (temp.LChild == null && temp.RChild == null) Console.Write(")");//to be deleted
                    if (temp.LChild != null) sq.In_Queue(temp.LChild);
                    if (temp.RChild != null) sq.In_Queue(temp.RChild);
                }
            }
            Node<T> Search(Node<T> root,T value)
            {
                Node<T> p = root;
                if (p == null) return null;
                if (p.Data.Equals(value)) return p;
                if (p.LChild != null) Search(p.LChild, value);
                if (p.RChild != null) Search(p.RChild, value);
                return null;
            }
            int CountLeafNode(Node<T> root)
            {
                if (root == null) return 0;
                else if (root.LChild == null && root.RChild == null) return 1;
                else return (CountLeafNode(root.LChild) + CountLeafNode(root.RChild));
            }
            int GetHeight(Node<T> root)
            {
                int lh, rh;
                if (root == null) return 0;
                else if (root.LChild == null && root.RChild == null) return 1;
                else
                {
                    lh = GetHeight(root.LChild);
                    rh = GetHeight(root.RChild);
                    return (lh > rh ? lh : rh) + 1;
                }
            }
            public bool Check_GT_str(string c_str) //example '(A(B,C(D,E\,)))';
            {
                int left_bracket = 0;
                int right_bracket = 0;
                int comma_num = 0;
                if (c_str.Length < 2) return false;
                for(int i=0;i<c_str.Length;i++)
                {
                    if ((int)c_str[i] == 92)//ascii 92='\'
                    {
                        i++;
                        continue;//jump '\,';
                    }
                    else if (c_str[i] != ',' && c_str[i] != '(' && c_str[i] != ')') continue;//values
                    else if (c_str[i] == '(') left_bracket++;
                    else if (c_str[i] == ')') right_bracket++;
                    else comma_num++;
                }
                if (left_bracket != right_bracket)
                {
                    Console.WriteLine("Unmatched {0} brackets!",left_bracket-right_bracket);
                    return false;
                }
                else if (left_bracket != comma_num + 1)
                {
                    Console.WriteLine("Wrong comma: {0}", -left_bracket + comma_num + 1);
                    return false;
                }
                else return true;
            }
            public Node<char> create_bitree(string c_str)
            {
                if (!Check_GT_str(c_str)) return null;//not legal
                const int start_lchild = 1, start_rchild = 2;
                int flag = 0, top = -1;
                Exp2.SeqStack<Node<char>> treestack = new Exp2.SeqStack<Node<char>>(c_str.Length);
                Node<char> temp = null;
                Node<char> root = null;
                for (int i = 0; i < c_str.Length; i++)
                {
                    if (c_str[i] == '(')
                    {
                        flag = start_lchild;
                        treestack[++top] = temp;
                    }
                    else if (c_str[i] == ',') flag = start_rchild;
                    else if (c_str[i] == ')') top--;
                    else if((int)c_str[i] == 92)// '\'
                    {
                        i++;
                        continue;
                    }
                    else //value
                    {
                        temp = new Node<char>(c_str[i]);//store temporary
                        temp.LChild = temp.RChild = null;
                        if (root == null) root = temp;
                        else
                        {
                            switch (flag)
                            {
                                case start_lchild:
                                    treestack[top].LChild = temp;
                                    break;
                                case start_rchild:
                                    treestack[top].RChild = temp;
                                    break;
                            }
                        }
                    }
                }
                return root;
            }
            public void display_bitree(Node<T> bitree,ref string dis_string)
            {            
                if (bitree == null) return;
                else
                {
                    dis_string += bitree.Data.ToString();
                    if (bitree.RChild != null && bitree.LChild != null)
                    {
                        dis_string += "(";
                        display_bitree(bitree.LChild,ref dis_string);
                        if (bitree.RChild != null) dis_string += ",";
                        display_bitree(bitree.RChild, ref dis_string);
                        dis_string += ")";
                    }
                }
                //test
                //Console.WriteLine("Input:");
                //string input_str = "(A(B(D,E),C(F,G)))";
                //Console.WriteLine(input_str);
                //Exp5.BiTree<char> biTree = new Exp5.BiTree<char>('A');
                //string output_str = "";
                //Exp5.Node<char> root = biTree.create_bitree(input_str);
                //biTree.display_bitree(root, ref output_str);
                //string new_output_str = "(" + output_str + ")";
                //Console.WriteLine("Output:\n" + new_output_str);
                //Console.Write("Preorder:\t");
                //biTree.PreOrder(root);
                //Console.Write("\nInorder:\t");
                //biTree.InOrder(root);
                //Console.Write("\nPostorder:\t");
                //biTree.PreOrder(root);
                //Console.Write("\nLevelorder:\t");
                //biTree.LevelOrder(root);
            }
        }
        //public struct PNode<T>
        //{
        //    public T data;
        //    public int pPos;
        //}
        public class HNode
        {
            private int weight;
            private int lChild;
            private int rChild;
            private int parent;
            public int Weight { get { return weight; } set { weight = value; } }
            public int Lchild { get { return lChild; } set { lChild = value; } }
            public int Rchild { get { return rChild; } set { rChild = value; } }
            public int Parent { get { return parent; } set { parent = value; } }
            public HNode()
            {
                weight = 0;
                lChild = -1;
                rChild = -1;
                parent = -1;
            }
            public HNode(int w,int lc,int rc,int p)
            {
                weight = w;
                lChild = lc;
                rChild = rc;
                parent = p;
            }

        }
        public class HuffmanTree
        {
            private HNode[] data;
            private int leafNum;
            public HNode this[int index]
            {
                get { return data[index]; }
                set { data[index] = value; }
            }
            public int LeafNum{ get { return leafNum; }set { leafNum = value; } }
            public HuffmanTree(int n)
            {
                data = new HNode[2*n-1];
                leafNum = n;
            }
            public void Create()
            {
                int max1, max2, temp1, temp2;
                for(int i = 0; i < this.leafNum; i++)
                {
                    data[i].Weight = Console.Read();
                }
                for (int i = 0; i < this.leafNum-1; i++)
                {
                    max1 = max2 = Int32.MaxValue;
                    temp1 = temp2 = 0;
                    //find the 2 node with minimal weight
                    for(int j = 0; j < this.leafNum + i; j++)
                    {
                        if(data[i].Weight<max1 && data[i].Parent == -1)
                        {
                            max2 = max1;
                            temp2 = temp1;
                            temp1 = j;
                            max1 = data[j].Weight;
                        }
                        else if (data[i].Weight < max2 && data[i].Parent == -1)
                        {
                            max2 = data[j].Weight;
                            temp2 = j;
                        }
                    }
                    data[temp1].Parent = this.leafNum + i;
                    data[this.leafNum + i].Weight = data[temp1].Weight + data[temp2].Weight;
                    data[this.leafNum + i].Lchild = temp1;
                    data[this.leafNum + i].Rchild = temp2;
                }
            }
        }
    }
    class Exp6 //Graph
    {
        public interface IGraph<T>
        {
            int GetNumOfVertex();
            int GetNumOfEdge();
            void SetEdge(Node<T> v1, Node<T> v2, int v);
            void DeleteEdge(Node<T> v1, Node<T> v2);
            bool JudgeEdge(Node<T> v1, Node<T> v2);
            bool IsNode(Node<T> val);
        }
        public class Node<T>
        {
            private T data;
            public Node(T val)
            {
                data = val;
            }
            public T Data { get { return data; } set { data = value; } }
        }
        public class Graph_Adj_Seq_Matrix<T> : IGraph<T>
        {
            private Node<T>[] nodes;
            private int numEdges;
            private int[,] matrix;
            public Graph_Adj_Seq_Matrix(int n)
            {
                nodes = new Node<T>[n];
                matrix = new int[n, n];
                numEdges = 0;
            }
            public Node<T> GetNode(int index)
            {
                return nodes[index];
            }
            public void SetNode(int index,Node<T> value)
            {
                nodes[index] = value;
            }
            public int NumEdges { get { return numEdges; } set {  numEdges = value; } }
            public int GetMatrix(int index1,int index2)
            {
                return matrix[index1, index2];
            }
            public void SetMatrix(int index1, int index2)
            {
                matrix[index1, index2]=1;
            }
            public int GetNumOfVertex()
            {
                return nodes.Length;
            }
            public int GetNumOfEdge()
            {
                return numEdges;
            }
            public bool IsNode(Node<T> val)
            {
                foreach(Node<T> node in nodes)
                {
                    if (val.Equals(node)) return true;
                }
                return false;
            }
            public int GetIndex(Node<T> val)
            {
                for (int i = 0; i < nodes.Length; ++i)
                {
                    if (nodes[i].Equals(val)) return i;
                }
                return -1;//if not return -1
            }
            public void SetEdge(Node<T> v1,Node<T> v2,int v)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                if (v != 1)
                {
                    Console.WriteLine("Invalid weight");
                    return;
                }
                matrix[GetIndex(v1), GetIndex(v2)] = matrix[GetIndex(v2), GetIndex(v1)] = v;
                ++numEdges;
            }
            public void DeleteEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                if(matrix[GetIndex(v1), GetIndex(v2)] == 1)
                {
                    matrix[GetIndex(v1), GetIndex(v2)] = 0;
                    matrix[GetIndex(v2), GetIndex(v1)] = 0;
                    --numEdges;
                }
            }
            public bool JudgeEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return false;
                }
                if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
                {
                    return true;
                }
                else return false;
            }
            public void Display_Nodes()
            {

            }
            public void Display_Edges()
            {

            }
        }
        public class adjListNode<T> 
        {
            private int adjvex;
            private adjListNode<T> next;
            public int Adjvex { get { return adjvex; } set { adjvex = value; } }
            public adjListNode<T> Next { get { return next; } set { next = value; } }
            public adjListNode(int vex)
            {
                adjvex = vex;
                next = null;
            }
        }
        public class VexNode<T>
        {
            private Node<T> data;
            private adjListNode<T> firstAdj;
            public Node<T> Data { get { return data; } set { data = value; } }
            public adjListNode<T> FirstAdj { get { return firstAdj; } set { firstAdj = value; } }
            public VexNode()
            {
                data = null;
                firstAdj = null;
            }
            public VexNode(Node<T> node,adjListNode<T> alNode)
            {
                data = node;
                firstAdj = alNode;
            }
        }
        public class GraphAdjList<T> : IGraph<T>
        {
            private VexNode<T>[] adjList;
            public VexNode<T> this[int index] { get { return adjList[index]; } set { adjList[index] = value; } }
            public int[] visited;
            public GraphAdjList(Node<T>[] nodes)
            {
                adjList = new VexNode<T>[nodes.Length];
                for(int i = 0; i < nodes.Length; i++)
                {
                    adjList[i].Data = nodes[i];
                    adjList[i].FirstAdj = null;
                }
                this.visited = new int[adjList.Length];
                for(int i = 0; i < visited.Length; ++i)
                {
                    visited[i] = 0;
                }
            }
            public int GetNumOfVertex()
            {
                return adjList.Length;
            }
            public int GetNumOfEdge()
            {
                int i = 0;
                foreach(VexNode<T> vexNode in adjList)
                {
                    adjListNode<T> p = vexNode.FirstAdj;
                    while (p != null)
                    {
                        ++i;
                        p = p.Next;
                    }
                }
                return (int)(i / 2);
            }
            public bool IsNode(Node<T> val)
            {
                foreach (VexNode<T> vexNode in adjList)
                {
                    if (val.Equals(vexNode.Data)) return true;
                }
                return false;
            }
            public int GetIndex(Node<T> val)
            {              
                for (int i = 0; i < adjList.Length; i++)
                {
                    if (adjList[i].Data.Equals(val)) return i;
                }
                return -1;//not found
            }
            public bool JudgeEdge(Node<T> v1,Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return false;
                }
                adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
                while (p != null)
                {
                    if (p.Adjvex == GetIndex(v2)) return true;
                    p = p.Next;
                }
                return false;
            }
            public void SetEdge(Node<T> v1,Node<T> v2,int val)
            {
                if (!IsNode(v1) || !IsNode(v2) || JudgeEdge(v1, v2))
                {
                    Console.WriteLine("Invalid Node");
                    return;
                }
                if (val != 1)
                {
                    Console.WriteLine("Invalid weight");
                    return;
                }
                //v2->v1
                adjListNode<T> p = new adjListNode<T>(GetIndex(v2));
                if (adjList[GetIndex(v1)].FirstAdj == null) adjList[GetIndex(v1)].FirstAdj = p;
                else
                {
                    p.Next = adjList[GetIndex(v1)].FirstAdj;
                    adjList[GetIndex(v1)].FirstAdj = p;
                }
                //v1->v2
                p = new adjListNode<T>(GetIndex(v1));
                if (adjList[GetIndex(v2)].FirstAdj == null) adjList[GetIndex(v2)].FirstAdj = p;
                else
                {
                    p.Next = adjList[GetIndex(v2)].FirstAdj;
                    adjList[GetIndex(v2)].FirstAdj = p;
                }
            }
            public void DeleteEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                if (JudgeEdge(v1, v2))
                {
                    //delete v1->v2
                    adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
                    adjListNode<T> pre = null;
                    while (p != null)
                    {
                        if (p.Adjvex != GetIndex(v2))
                        {
                            pre = p;
                            p = p.Next;
                        }
                    }
                    pre.Next = p.Next;
                    //delete v2->v1
                    p = adjList[GetIndex(v2)].FirstAdj;
                    pre = null;
                    while (p != null)
                    {
                        if (p.Adjvex != GetIndex(v1))
                        {
                            pre = p;
                            p = p.Next;
                        }
                    }
                    pre.Next = p.Next;
                }
            }
            public void DFS()//screen whole graph,O(n+e)
            {
                for(int i = 0; i < visited.Length; ++i)
                {
                    if (visited[i] == 0) DFSAL(i);
                }
            }
            public void DFSAL(int i)//start screen from a node
            {
                visited[i] = 1;
                adjListNode<T> p = adjList[i].FirstAdj;
                while (p != null)
                {
                    if (visited[p.Adjvex] == 0) DFSAL(p.Adjvex);
                    p = p.Next;
                }
            }
            public void BFS()//O(n+e)
            {
                for(int i = 0; i < visited.Length; ++i)
                {
                    if (visited[i] == 0) BFSAL(i);
                }
            }
            public void BFSAL(int i)
            {
                visited[i] = 1;
                Exp2.CSeqQueue<int> cSeq = new Exp2.CSeqQueue<int>(visited.Length);
                cSeq.In_Queue(i);
                while (!cSeq.IsEmpty())
                {
                    int k = cSeq.Out_Queue();
                    adjListNode<T> p = adjList[k].FirstAdj;
                    while (p != null)
                    {
                        if (visited[p.Adjvex] == 0)
                        {
                            visited[p.Adjvex] = 1;
                            cSeq.In_Queue(p.Adjvex);
                        }
                        p = p.Next;
                    }
                }
            }
        }
        public class NetAdjMatrix<T> : IGraph<T> 
        {
            private Node<T>[] nodes;
            private int numEdges;
            private int[,] matrix;
            public NetAdjMatrix(int n)
            {
                nodes = new Node<T>[n];
                matrix = new int[n, n];
                numEdges = 0;
            }       
            public int NumEdges { get { return numEdges; } set { numEdges = value; } }
            public void SetNode(int index, Node<T> val)
            {
                nodes[index] = val;
            }
            public int GetMatrix(int index1, int index2)
            {
                return matrix[index1, index2];
            }
            public void SetMatrix(int index1, int index2)
            {
                matrix[index1, index2] = 1;
            }
            public int GetNumOfVertex()
            {
                return nodes.Length;
            }
            public int GetNumOfEdge()
            {
                return numEdges;
            }
            public bool IsNode(Node<T> val)
            {
                foreach (Node<T> node in nodes)
                {
                    if (val.Equals(node)) return true;
                }
                return false;
            }
            public int GetIndex(Node<T> val)
            {               
                for (int i = 0; i < nodes.Length; ++i)
                {
                    if (nodes[i].Equals(val)) return i;
                }
                return -1;//if not return -1
            }
            public void SetEdge(Node<T> v1, Node<T> v2, int v)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                matrix[GetIndex(v1), GetIndex(v2)] = matrix[GetIndex(v2), GetIndex(v1)] = v;
                ++numEdges;
            }
            public void DeleteEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                if (matrix[GetIndex(v1), GetIndex(v2)] !=int.MaxValue)
                {
                    matrix[GetIndex(v1), GetIndex(v2)] = 0;
                    matrix[GetIndex(v2), GetIndex(v1)] = 0;
                    --numEdges;
                }
            }
            public bool JudgeEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return false;
                }
                if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
                {
                    return true;
                }
                else return false;
            }
            public int[] Prim()
            {
                int[] lowcost = new int[nodes.Length];
                int[] closevex = new int[nodes.Length];
                int mincost = int.MaxValue;
                for(int i = 1; i < nodes.Length; i++)
                {
                    lowcost[i] = matrix[0, i];
                    closevex[i] = 0;
                }
                lowcost[0] = 0;
                closevex[0] = 0;
                for(int i = 0; i < nodes.Length; i++)
                {
                    int k = 1, j = 1;
                    //select edges and nodes with min weight
                    while (j < nodes.Length)
                    {
                        if (lowcost[j] < mincost && lowcost[j] !=0) k = j;
                        ++j;
                    }
                    //add new node group
                    lowcost[k] = 0;
                    //recount weight among nodes
                    for (j = 1; j < nodes.Length; ++j)
                    {
                        lowcost[j] = matrix[k, j];
                        closevex[j] = k;
                    }
                }
                return closevex;
            } //Minimum Cost Spanning Tree
        }
        public class DirecNetAdjMatrix<T> : IGraph<T>
        {
            private Node<T>[] nodes;
            private int numArcs;
            private int[,] matrix;
            public DirecNetAdjMatrix(int n)
            {
                nodes = new Node<T>[n];
                matrix = new int[n, n];
                numArcs = 0;
            }
            public int NumArcs { get { return numArcs; }set{ numArcs = value; } }
            public Node<T> GetNode(int index)
            {
                return nodes[index];
            }
            public void SetNode(int index, Node<T> val)
            {
                nodes[index] = val;
            }
            public int GetMatrix(int index1,int index2)
            {
                return matrix[index1, index2];
            }
            public void SetMatrix(int index1,int index2,int val)
            {
                matrix[index1, index2] = val;
            }
            public int GetNumOfVertex()
            {
                return nodes.Length;
            }
            public int GetNumOfEdge()
            {
                return numArcs;
            }
            public bool IsNode(Node<T> val)
            {
                foreach(Node<T> node in nodes)
                {
                    if (val.Equals(node)) return true;
                }
                return false;
            }
            public int GetIndex(Node<T> val)
            {
                for (int i = 0; i < nodes.Length; ++i)
                {
                    if (nodes[i].Equals(val)) return i;
                }
                return -1;
            }
            public void SetEdge(Node<T> v1, Node<T> v2, int v)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                matrix[GetIndex(v1), GetIndex(v2)] = v;
                ++numArcs;
            }
            public void DeleteEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return;
                }
                if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
                {
                    matrix[GetIndex(v1), GetIndex(v2)] = int.MaxValue;
                    --numArcs;
                }
            }
            public bool JudgeEdge(Node<T> v1, Node<T> v2)
            {
                if (!IsNode(v1) || !IsNode(v2))
                {
                    Console.WriteLine("Invalid Nodes");
                    return false;
                }
                if (matrix[GetIndex(v1), GetIndex(v2)] != int.MaxValue)
                {
                    return true;
                }
                else return false;
            }
            public void Dijkstra(ref bool[,] pathMatrixArr,ref int[] shortPathArr,Node<T> n)
            {
                //O(n^2)
                int k = 0;
                bool[] final = new bool[nodes.Length];
                //initiate
                for(int i = 0; i < nodes.Length; i++)
                {
                    final[i] = false;
                    shortPathArr[i] = matrix[GetIndex(n), i];
                    for(int j = 0; j < nodes.Length; j++)
                    {
                        pathMatrixArr[i, j] = false;
                    }
                    if (shortPathArr[i] != 0 && shortPathArr[i] < int.MaxValue)
                    {
                        pathMatrixArr[i, GetIndex(n)] = true;
                        pathMatrixArr[i, i] = true;
                    }
                }
                //n is a start node
                shortPathArr[GetIndex(n)] = 0;
                final[GetIndex(n)] = true;
                //count shortest path
                for(int i = 0; i < nodes.Length; i++)
                {
                    int min = int.MaxValue;
                    for(int j = 0; j < nodes.Length; j++)
                    {
                        if (!final[j])
                        {
                            if (shortPathArr[j] < min)
                            {
                                k = j;
                                min = shortPathArr[j];
                            }
                        }
                    }
                    final[k] = true;
                    //reload min path
                    for (int j = 0; j < nodes.Length; j++)
                    {
                        if (!final[j] && (min + matrix[k, j] < shortPathArr[j]))
                        {
                            shortPathArr[j] = min + matrix[k, j];
                            for(int w = 0; w < nodes.Length; w++)
                            {
                                pathMatrixArr[j, w] = pathMatrixArr[k, w];
                            }
                            pathMatrixArr[j, j] = true;
                        }
                    }
                }
            }
        }
    }
    class Exp7 //Sort
    {

    }
    class Addition_Math
    {
        public static int factorial(int n)
        {
            if (n == 1 || n == 0) return 1;
            else return n * factorial(n - 1);
        }
        public static int combinatorial_num(int n1, int n2)//n1>n2
        {
            if (n1 < n2) return -1;//wrong
            else return factorial(n1) / factorial(n1 - n2) / factorial(n2);
        }
        public static int int_power(int basef, int exp)
        {
            if (exp == 0)return 1;
            int temp = int_power(basef, exp / 2);
            if (exp % 2 == 0) return temp * temp;
            else return basef * temp * temp;
        }
    }
}
