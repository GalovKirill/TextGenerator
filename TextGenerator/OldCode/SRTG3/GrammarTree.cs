using System;
using System.Collections.Generic;

namespace TextGenerator.OldCode.SRTG3
{
    public class WordsTree
    {
        private Node _root;

        private Node[] _nodes;
        
        private int _lastNodeIndex;

        public struct Node
        {
            private const int NoRigthSibling = -1;
            private const int NoChilds = -1;
            
            public Node(char c)
            {
                C =  c;
                RigthSibling = NoRigthSibling;
                FirstChild = NoChilds;

            }
            

            public readonly char C;

            public int RigthSibling;

            public int FirstChild;

            public bool HasChilds => FirstChild != NoChilds;

            public bool HasRigthSibling => RigthSibling != NoRigthSibling;
        }

        private bool SearchNodeInSiblings(char c, ref int node, out int searched)
        {
            if (_nodes[node].C == c)
            {
                searched = node;
                return true;
            }

            while (_nodes[node].HasRigthSibling)
            {
                var nextNode = _nodes[node].RigthSibling;
                if (_nodes[nextNode].C == c)
                {
                    searched = nextNode;
                    return true;
                }
                node = nextNode;
                
            }
            
            searched = -1;
            return false;
            
        }
        

        public WordsTree() : this(1)
        {
            
        }

        public WordsTree(int capacity)
        {
            _nodes = new Node[capacity];
            _root = new Node(char.MinValue);
            _nodes[0] = _root;
            _lastNodeIndex = 1;
        }
        
        public void Add(char[] item)
        {
            _root = _nodes[0];
            Add(item, 0);
        }

        private void AddRightSibling(int nodePtr, ref int toAdd, char c)
        {
            if(_lastNodeIndex == _nodes.Length)
                Resize();
            _nodes[_lastNodeIndex] = new Node(c);
            ref var node = ref _nodes[nodePtr];
            node.RigthSibling = _lastNodeIndex;
            toAdd = _lastNodeIndex;
            _lastNodeIndex++;
        }
        
        public void Add(char[] str, int parentNodePtr)
        {
            foreach (var c in str)
            {
                int nodePtr;
                if (_nodes[parentNodePtr].HasChilds)
                {
                    int childPtr = _nodes[parentNodePtr].FirstChild;
                    var finded = SearchNodeInSiblings(c, ref childPtr, out nodePtr);
                    if (!finded) AddRightSibling(childPtr, ref nodePtr, c);
                }
                else
                {
                    nodePtr = AddFirstChild(parentNodePtr, c);
                }

                parentNodePtr = nodePtr;
            }
        }
        
        private int AddFirstChild(int parent, char c)
        {
            if(_lastNodeIndex == _nodes.Length)
                Resize();
            var newNodePtr = _lastNodeIndex;
            _nodes[newNodePtr] = new Node(c);
            ref var nodeP = ref _nodes[parent];
            nodeP.FirstChild = newNodePtr;
            _lastNodeIndex++;
            return newNodePtr;
        }
    
        
        private int ChildsCount(in Node parent)
        {
            if (parent.HasChilds)
            {
                int count = 1;
                ref Node ch = ref _nodes[parent.FirstChild];
                while (ch.HasRigthSibling)
                {
                    count++;
                    ch = _nodes[ch.RigthSibling];
                }

                return count;

            }

            return 0;
        }

        private ref Node GetChild(in Node parent,int i)
        {
            ref Node res = ref _nodes[parent.FirstChild];
            for (int j = 1; j <= i; j++)
            {
                res = ref _nodes[res.RigthSibling];
            }

            return ref res;
        }
        
        public char GetRandomChar(in IList<char> subString)
        {
            return GetRandomChar(subString, 1);
        }
        
        private static readonly Random Rnd = new Random();
        
        
        private char GetRandomChar(in IList<char> subString, int parent)
        {

            int searched = 0;
            foreach (var c in subString)
            {
                var finded = SearchNodeInSiblings(c, ref parent, out searched);
                if (finded)
                {
                    parent = _nodes[searched].FirstChild;
                }
                else
                {
                    throw new Exception($"Не найдет нод \n C - {c}\n i - {parent}\n Substr - {searched}");
                }
            }

            return GetRandomCharFromChilds(searched);

        }

        private char GetRandomCharFromChilds(int parentPtr)
        {
            if (_nodes[parentPtr].HasChilds)
            {

                var count = ChildsCount(_nodes[parentPtr]);
                var randomChild = Rnd.Next(0, count - 1);
                return GetChild(_nodes[parentPtr], randomChild).C;
            }
            else
            {
                throw new Exception("Нет ребенка");
            }
        }
        
        
        
        private char GetRandomChar(in IList<char> subString, int i, in Node parent)
        {
            if (i == subString.Count)
            {
                var rndIndex = Rnd.Next(0, parent.FirstChild);
                ref Node n = ref _nodes[rndIndex];
                return n.C;
            }
            var c = subString[i];
            
//            if (TryGetNodeByChar(c, parent, out var node))
//            {
//                return GetRandomChar(subString, i + 1, node);
//            }

            throw new Exception($"Не найдет нод \n C - {c}\n i - {i}\n Substr - {subString.ToString()}");
        }

        public IList<char> GetRandomStr(int len)
        {
            var list = new List<char>(len);
            GetRandomStr(_root, list, len);
            return list;
        }

        private void GetRandomStr(Node parent, ICollection<char> chars, int len)
        {
            while (len != 0)
            {
                var childsCount = ChildsCount(parent);
                var randomIndex = Rnd.Next(0, childsCount - 1);
                ref Node node = ref GetChild(parent, 0);
                chars.Add(node.C);
                len--;                
                parent = node;
            }

        }

       


        private void Resize()
        {
            var newNodes = new Node[_nodes.Length + _nodes.Length / 4];
            _nodes.CopyTo(newNodes, 0);
            _nodes = newNodes;
            GC.Collect();

        }
        
       
    }
}