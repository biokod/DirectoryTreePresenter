using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DirectoryTreePresenter
{
    public class NodeController
    {
        public delegate void SizeUpdateHandler(object sender, SizeEventArgs e);
        public event SizeUpdateHandler SizeUpdated;

        private FileSystemInfo info;
        public FileSystemInfo Info
        {
            get
            {
                return info;
            }
        }

        private TreeNode node;
        public TreeNode Node {
            get
            {
                return node;
            } 
        }

        public XmlNode xmlNode;

        private List<TreeNode> childNodes;
        public List<TreeNode> ChildNodes {
            get
            {
                return childNodes;
            }
        }
        public long ByteSize { get; set; }

        private long totalSize;
        public long TotalSize
        {
            get
            {
                if (info is DirectoryInfo)
                {
                    totalSize = 0;
                    foreach (TreeNode n in ChildNodes)
                    {
                        totalSize += ((NodeController)n.Tag).TotalSize;
                    }
                    if (xmlNode != null)
                    {
                        XmlAttribute attr = xmlNode.Attributes["size"];
                        attr.Value = totalSize.ToString();
                    }
                    return totalSize;
                }
                else
                {
                    return ((FileInfo)info).Length;
                }
            }
        }


        public NodeController()
        {
        }

        public NodeController(TreeNode node, FileSystemInfo info)
        {
            //SizeUpdated = new SizeUpdateHandler
            childNodes = new List<TreeNode>();
            this.node = node;
            this.info = info;
        }

        public void AddChildNode(TreeNode tnode)
        {
            childNodes.Add(tnode);
            //((NodeController)tnode.Tag).SizeUpdated += OnNodeSizeUpdated;
        }

        public void UpdateSize()
        {
            long size = TotalSize;
        }

        private void OnNodeSizeUpdated(object sender, SizeEventArgs e)
        {
            ByteSize += e.size;
        }

        


    }
}
