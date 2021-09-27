using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToConnectOPCUA.Classes
{
    public class ListNodeStruct
    {
        private NodeType _nodeType;

        public NodeType NodeType
        {
            get { return _nodeType; }
            set { _nodeType = value; }
        }

        private string _parentPath;

        public string ParentPath
        {
            get { return _parentPath; }
            set { _parentPath = value; }
        }


        private int _nodeId;

        public int NodeID
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }


        private string _MainFolderName;

        public string MainFolderName
        {
            get { return _MainFolderName; }
            set { _MainFolderName = value; }
        }
        private bool _isRootEnd;

        public bool IsRootEnd
        {
            get { return _isRootEnd; }
            set { _isRootEnd = value; }
        }
        private int _LengthOfNode;

        public int LengthOfNode
        {
            get { return _LengthOfNode; }
            set { _LengthOfNode = value; }
        }

        private List<ListNodeStruct> _SubNodeNames;

        public List<ListNodeStruct> SubNodeNames
        {
            get { return _SubNodeNames; }
            set { _SubNodeNames = value; }
        }

        private NodeId _DataType;

        public NodeId DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
        public ListNodeStruct()
        {

        }
        public ListNodeStruct(string folderName,bool isFolder, List<ListNodeStruct> subNode)
        {
            MainFolderName = folderName;
            SubNodeNames = subNode;
            IsRootEnd = isFolder;
        }
    }
    public class IfItIsFolderStruct
    {
        private bool _IFItIsNotFolder;

        public bool IFItIsNotFolder
        {
            get { return _IFItIsNotFolder; }
            set { _IFItIsNotFolder = value; }
        }
        private string _SubNodeNames;

        public string SubNodeNames
        {
            get { return _SubNodeNames; }
            set { _SubNodeNames = value; }
        }
        private NodeType _NodeType;

        public NodeType NodeType
        {
            get { return _NodeType; }
            set { _NodeType = value; }
        }

        private NodeId _DataType;

        public NodeId DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }

        public IfItIsFolderStruct(bool folderName, string subNode,NodeId dataType)
        {
            IFItIsNotFolder = folderName;
            SubNodeNames = subNode;
            DataType = dataType;
        }
    }
}
