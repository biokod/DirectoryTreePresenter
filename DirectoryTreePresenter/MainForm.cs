using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DirectoryTreePresenter
{

    public partial class MainForm : Form
    {
        public DirectoryInfo dirInfo;
        public string folderName;
        public string xmlFilePath = "dirdata.xml";
        private Stream fileStream;

        public MainForm()
        {
            InitializeComponent();
            buttonBrowse.Click += new System.EventHandler(this.browseButton_Click);
            treeView.AfterSelect += showDetails;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog.SelectedPath;
                tfPath.Text = folderName;
                dirInfo = new DirectoryInfo(folderName);

                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.FileName = "result";
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileStream = saveFileDialog1.OpenFile();
                    TraverseTree(folderName);
                }
            
                
            }
        }

        private void showDetails(object sender, TreeViewEventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                tbCreated.Text = ((NodeController)treeView.SelectedNode.Tag).Info.CreationTime.ToString();
                tbModified.Text = ((NodeController)treeView.SelectedNode.Tag).Info.LastWriteTime.ToString();
                tbAccessed.Text = ((NodeController)treeView.SelectedNode.Tag).Info.LastAccessTime.ToString();
                //tbOwner.Text = ((FileSystemInfo)treeView.SelectedNode.Tag).CreationTime.ToString();
                tbAttributes.Text = ((NodeController)treeView.SelectedNode.Tag).Info.Attributes.ToString();
                tbSize.Text = ((NodeController)treeView.SelectedNode.Tag).TotalSize.ToString();
                //textBox.Text = treeView.SelectedNode.Name;
            }
        }

        private void setAttributes(NodeController cnode, XmlNode element, XmlDocument doc)
        {
            XmlAttribute attribute;

            attribute = doc.CreateAttribute("name");
            attribute.Value = cnode.Info.Name;
            element.Attributes.Append(attribute);
            
            attribute = doc.CreateAttribute("size");
            attribute.Value = cnode.TotalSize.ToString();
            element.Attributes.Append(attribute);

            attribute = doc.CreateAttribute("created");
            attribute.Value = cnode.Info.CreationTime.ToString();
            element.Attributes.Append(attribute);
            
            attribute = doc.CreateAttribute("modified");
            attribute.Value = cnode.Info.LastWriteTime.ToString();
            element.Attributes.Append(attribute);
            
            attribute = doc.CreateAttribute("accessed");
            attribute.Value = cnode.Info.LastAccessTime.ToString();
            element.Attributes.Append(attribute);
            
            attribute = doc.CreateAttribute("owner");
            attribute.Value = "User";
            element.Attributes.Append(attribute);
            
            attribute = doc.CreateAttribute("attributes");
            attribute.Value = cnode.Info.Attributes.ToString();
            element.Attributes.Append(attribute);
        }

        private void getXmlFile()
        {
            XmlTextWriter xtw;
            if (fileStream == null)
            {
                if (!File.Exists(xmlFilePath))
                {
                    xtw = new XmlTextWriter(xmlFilePath, Encoding.UTF8);
                    xtw.WriteStartDocument();
                    xtw.WriteStartElement("root");
                    xtw.WriteEndElement();
                    xtw.Close();
                }
            }
            else
            {
                xtw = new XmlTextWriter(fileStream, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement("root");
                xtw.WriteEndElement();
                xtw.Flush();
                fileStream.Position = 0;
            }
        }

        public void TraverseTree(string root)
        {
            long fileSize = 0;
            getXmlFile();
            XmlDocument doc = new XmlDocument();
            if (fileStream == null)
            {
                doc.Load(xmlFilePath);
            }
            else
            {
                
                doc.Load(fileStream);
            }

            XmlNode element, pxNode;

            pxNode = doc.ChildNodes[1]; //parent xmlNode
            pxNode.RemoveAll();

            // Data structure to hold names of subfolders to be
            // examined for files.
            Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>(20);

            DirectoryInfo currentDir;
            DirectoryInfo[] subDirs;
            FileInfo[] files;
            int depthLevel, curNodeIndex, nextDepthDirCount, depthDirCount;
            TreeNode node = new TreeNode();
            TreeNode curNode = new TreeNode();
            List<TreeNode> parentNodes = new List<TreeNode>();
            List<TreeNode> nextDepthNodes = new List<TreeNode>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }

            currentDir = new DirectoryInfo(root);
            dirs.Enqueue(currentDir);
            treeView.BeginUpdate();
            depthLevel = -1;
            curNodeIndex = 0;
            nextDepthDirCount = 0;
            depthDirCount = 0;

            while (dirs.Count > 0)
            {
                currentDir = dirs.Dequeue();
                fileSize = 0;

                if (treeView.Nodes.Count == 0)
                {
                    // added root folder
                    node = new TreeNode();
                    node.Name = currentDir.Name;
                    node.Text = "[" + node.Name + "]";
                    node.Tag = new NodeController(node, currentDir);
                    treeView.Nodes.Add(node);
                    curNodeIndex = depthDirCount = currentDir.GetDirectories().Length;
                    curNode = node;
                    parentNodes.Add(node);
                    setAttributes((NodeController)node.Tag, pxNode, doc);
                    ((NodeController)node.Tag).xmlNode = pxNode;
                }
                else
                {
                    if (curNodeIndex >= depthDirCount)
                    {
                        depthLevel++;
                        curNodeIndex = 0;
                        depthDirCount = nextDepthDirCount;
                        nextDepthDirCount = 0;
                        parentNodes = nextDepthNodes;
                        nextDepthNodes = new List<TreeNode>();
                    }
                    curNode = parentNodes[curNodeIndex];
                    pxNode = ((NodeController)curNode.Tag).xmlNode;
                }
                //Console.WriteLine(">[{0}]: {1}, {2}", currentDir.Name, currentDir.CreationTime, currentDir.Attributes);
                
                try
                {
                    // adding subdirectories
                    subDirs = currentDir.GetDirectories();
                    if(subDirs.Length > 0)
                    {
                        foreach (DirectoryInfo sdir in subDirs)
                        {
                            node = new TreeNode();
                            node.Name = sdir.Name;
                            node.Text = "[" + node.Name + "]";
                            node.Tag = new NodeController(node, sdir);
                            ((NodeController)curNode.Tag).AddChildNode(node);
                            curNode.Nodes.Add(node);
                            nextDepthNodes.Add(node);

                            element = doc.CreateElement("dir");
                            setAttributes((NodeController)node.Tag, element, doc);
                            pxNode.AppendChild(element);
                            ((NodeController)node.Tag).xmlNode = element;
                            
                            dirs.Enqueue(sdir);

                            //Console.WriteLine("[{0}]: {1}, {2}", sdir.Name, sdir.CreationTime, sdir.Attributes);
                        }
                        
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                
                try
                {
                    files = currentDir.GetFiles();
                }
                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                // Adding file nodes
                foreach (FileInfo fi in files)
                {
                    try
                    {
                        node = new TreeNode();
                        fileSize += fi.Length;
                        node.Name = fi.Name;
                        node.Text = node.Name;
                        node.Tag = new NodeController(node, fi);
                        ((NodeController)node.Tag).ByteSize = fi.Length;
                        ((NodeController)curNode.Tag).AddChildNode(node);
                        curNode.Nodes.Add(node);

                        element = doc.CreateElement("file");
                        setAttributes((NodeController)node.Tag, element, doc);
                        pxNode.AppendChild(element);
                        
                        //Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                ((NodeController)curNode.Tag).ByteSize = fileSize;
                nextDepthDirCount += subDirs.Length;
                curNodeIndex++;
            }
            ((NodeController)treeView.Nodes[0].Tag).UpdateSize();
            treeView.EndUpdate();
            doc.Save(fileStream);
            fileStream.Close();
            textBox.ResetText();
            if(doc.InnerXml.Length <= textBox.MaxLength) textBox.Text = doc.InnerXml;
        }


    }
}
