using Opc.Ua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToConnectOPCUA.Classes
{
    public abstract class OpcuaNode
    {
        /// <summary>
        /// 節點路徑(逐級拼接)
        /// </summary>
        public abstract string NodePath { get; set; }
        /// <summary>
        /// 父節點路徑(逐級拼接)
        /// </summary>
        public abstract string ParentPath { get; set; }
        /// <summary>
        /// 節點編號 (節點編號不完全唯一,但是所有測點Id都是不同的)
        /// </summary>
        public abstract int NodeId { get; set; }
        /// <summary>
        /// 節點名称(展示名稱)
        /// </summary>
        public abstract string NodeName { get; set; }
        /// <summary>
        /// 是否端點(最底端子節點) 是否為資料夾
        /// </summary>
        public abstract bool IsTerminal { get; set; }
        /// <summary>
        /// 節點類型
        /// </summary>
        public abstract NodeType NodeType { get; set; }
        /// <summary>
        /// 節點類型
        /// </summary>
        public abstract NodeId DataType { get; set; }

    }
    public enum NodeType
    {
        /// <summary>
        /// 根結點
        /// </summary>
        GRC = 1,
        /// <summary>
        /// 目錄
        /// </summary>
        PLC1 = 2,
        /// <summary>
        /// 目錄
        /// </summary>
        PLC2 = 3,
        /// <summary>
        /// 測點
        /// </summary>
        Point = 4
    }
}
