using AppealsAndComplaints.Utility;
using AppealsAndComplaints.WebAPI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<Node> nodeList = createdBinTree(bArr);
            System.Console.WriteLine("先序遍历");
            preOrder(nodeList[0]);
            System.Console.WriteLine("中序遍历");
            inOrder(nodeList[0]);
            System.Console.WriteLine("后序遍历");
            postOrder(nodeList[0]);

            System.Console.ReadKey();
        }

        /// <summary>
        /// 创建二叉树树
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static List<Node> createdBinTree(int[] arr) {
            List<Node> nodeList = new List<Node>();
            //将数组值依次转入Node节点
            for (int i = 0; i < arr.Length; i++)
            {
                nodeList.Add(new Node(arr[i]));
            }

            for (int j = 0; j < arr.Length/2-1; j++)
            {
                //左孩子
                nodeList[j].leftChild = nodeList[j * 2 + 1];
                //右孩子
                nodeList[j].rightChild = nodeList[j * 2 + 2];
            }

            //最后一个节点：因为最后一个父节点可能没有右孩子，所以单独拿出来处理
            int last = arr.Length / 2 - 1;
            //左孩子
            nodeList[last].leftChild = nodeList[last * 2 + 1];
            //右孩子
            if (arr.Length % 2 == 1) {
                nodeList[last].rightChild = nodeList[last * 2 + 2];
            }

            return nodeList;
        }

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="node"></param>
        static void preOrder(Node node) {
            if (node == null) return;
            System.Console.WriteLine(node.data+" ");
            preOrder(node.leftChild);
            preOrder(node.rightChild);
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="node"></param>
        static void inOrder(Node node) {
            if (node == null) return;
            inOrder(node.leftChild);
            System.Console.WriteLine(node.data+" ");
            inOrder(node.rightChild);
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="node"></param>
        static void postOrder(Node node) {
            if (node == null) return;
            postOrder(node.leftChild);
            postOrder(node.rightChild);
            System.Console.WriteLine(node.data+" ");
        }
    }

    class Node {
        public Node leftChild { get; set; }
        public Node rightChild { get; set; }
        public int data { get; set; }

        public Node(int newData) {
            leftChild = null;
            rightChild = null;
            data = newData;
        }
    }
}
