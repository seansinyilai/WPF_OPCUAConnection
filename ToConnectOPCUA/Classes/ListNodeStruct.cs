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
        private string _MainFolderName;

        public string MainFolderName
        {
            get { return _MainFolderName; }
            set { _MainFolderName = value; }
        }
        private List<IfItIsFolderStruct> _SubNodeNames;

        public List<IfItIsFolderStruct> SubNodeNames
        {
            get { return _SubNodeNames; }
            set { _SubNodeNames = value; }
        }
        public ListNodeStruct(string folderName, List<IfItIsFolderStruct> subNode)
        {
            MainFolderName = folderName;
            SubNodeNames = subNode;
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
