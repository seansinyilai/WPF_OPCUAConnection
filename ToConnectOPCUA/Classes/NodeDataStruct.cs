using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToConnectOPCUA.Classes
{
    public class NodeDataStruct : OpcuaNode
    {
        public override string NodePath { get; set ; }
        public override string ParentPath { get ; set ; }
        public override int NodeId { get ; set ; }
        public override string NodeName { get ; set ; }
        public override bool IsTerminal { get ; set ; }
        public override NodeType NodeType { get ; set ; }
        public override NodeId DataType { get ; set ; }
    }
}
