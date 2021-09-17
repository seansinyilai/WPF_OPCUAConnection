/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace GPPlant
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the GPPlantType_StartProcess Method.
        /// </summary>
        public const uint GPPlantType_StartProcess = 24;

        /// <summary>
        /// The identifier for the GPPlantType_StopProcess Method.
        /// </summary>
        public const uint GPPlantType_StopProcess = 25;

        /// <summary>
        /// The identifier for the GPPlant1_StartProcess Method.
        /// </summary>
        public const uint GPPlant1_StartProcess = 35;

        /// <summary>
        /// The identifier for the GPPlant1_StopProcess Method.
        /// </summary>
        public const uint GPPlant1_StopProcess = 36;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the CoaterType_PLC1 Object.
        /// </summary>
        public const uint CoaterType_PLC1 = 9;

        /// <summary>
        /// The identifier for the GPPlantType_Coater Object.
        /// </summary>
        public const uint GPPlantType_Coater = 16;

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1 Object.
        /// </summary>
        public const uint GPPlantType_Coater_PLC1 = 17;

        /// <summary>
        /// The identifier for the GPPlant1 Object.
        /// </summary>
        public const uint GPPlant1 = 26;

        /// <summary>
        /// The identifier for the GPPlant1_Coater Object.
        /// </summary>
        public const uint GPPlant1_Coater = 27;

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1 Object.
        /// </summary>
        public const uint GPPlant1_Coater_PLC1 = 28;
    }
    #endregion

    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the Mitsubishi ObjectType.
        /// </summary>
        public const uint Mitsubishi = 1;

        /// <summary>
        /// The identifier for the PLC1Type ObjectType.
        /// </summary>
        public const uint PLC1Type = 2;

        /// <summary>
        /// The identifier for the CoaterType ObjectType.
        /// </summary>
        public const uint CoaterType = 8;

        /// <summary>
        /// The identifier for the GPPlantType ObjectType.
        /// </summary>
        public const uint GPPlantType = 15;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the PLC1Type_Connection Variable.
        /// </summary>
        public const uint PLC1Type_Connection = 3;

        /// <summary>
        /// The identifier for the PLC1Type_Connection_FalseState Variable.
        /// </summary>
        public const uint PLC1Type_Connection_FalseState = 6;

        /// <summary>
        /// The identifier for the PLC1Type_Connection_TrueState Variable.
        /// </summary>
        public const uint PLC1Type_Connection_TrueState = 7;

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection Variable.
        /// </summary>
        public const uint CoaterType_PLC1_Connection = 10;

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection_FalseState Variable.
        /// </summary>
        public const uint CoaterType_PLC1_Connection_FalseState = 13;

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection_TrueState Variable.
        /// </summary>
        public const uint CoaterType_PLC1_Connection_TrueState = 14;

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection Variable.
        /// </summary>
        public const uint GPPlantType_Coater_PLC1_Connection = 18;

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection_FalseState Variable.
        /// </summary>
        public const uint GPPlantType_Coater_PLC1_Connection_FalseState = 21;

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection_TrueState Variable.
        /// </summary>
        public const uint GPPlantType_Coater_PLC1_Connection_TrueState = 22;

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Output Variable.
        /// </summary>
        public const uint GPPlantType_Coater_PLC1_Output = 23;

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection Variable.
        /// </summary>
        public const uint GPPlant1_Coater_PLC1_Connection = 29;

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection_FalseState Variable.
        /// </summary>
        public const uint GPPlant1_Coater_PLC1_Connection_FalseState = 32;

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection_TrueState Variable.
        /// </summary>
        public const uint GPPlant1_Coater_PLC1_Connection_TrueState = 33;

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Output Variable.
        /// </summary>
        public const uint GPPlant1_Coater_PLC1_Output = 34;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the GPPlantType_StartProcess Method.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_StartProcess = new ExpandedNodeId(GPPlant.Methods.GPPlantType_StartProcess, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_StopProcess Method.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_StopProcess = new ExpandedNodeId(GPPlant.Methods.GPPlantType_StopProcess, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_StartProcess Method.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_StartProcess = new ExpandedNodeId(GPPlant.Methods.GPPlant1_StartProcess, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_StopProcess Method.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_StopProcess = new ExpandedNodeId(GPPlant.Methods.GPPlant1_StopProcess, GPPlant.Namespaces.GPPlant);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the CoaterType_PLC1 Object.
        /// </summary>
        public static readonly ExpandedNodeId CoaterType_PLC1 = new ExpandedNodeId(GPPlant.Objects.CoaterType_PLC1, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater Object.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater = new ExpandedNodeId(GPPlant.Objects.GPPlantType_Coater, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1 Object.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater_PLC1 = new ExpandedNodeId(GPPlant.Objects.GPPlantType_Coater_PLC1, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1 Object.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1 = new ExpandedNodeId(GPPlant.Objects.GPPlant1, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater Object.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater = new ExpandedNodeId(GPPlant.Objects.GPPlant1_Coater, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1 Object.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater_PLC1 = new ExpandedNodeId(GPPlant.Objects.GPPlant1_Coater_PLC1, GPPlant.Namespaces.GPPlant);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the Mitsubishi ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId Mitsubishi = new ExpandedNodeId(GPPlant.ObjectTypes.Mitsubishi, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the PLC1Type ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId PLC1Type = new ExpandedNodeId(GPPlant.ObjectTypes.PLC1Type, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the CoaterType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CoaterType = new ExpandedNodeId(GPPlant.ObjectTypes.CoaterType, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType = new ExpandedNodeId(GPPlant.ObjectTypes.GPPlantType, GPPlant.Namespaces.GPPlant);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the PLC1Type_Connection Variable.
        /// </summary>
        public static readonly ExpandedNodeId PLC1Type_Connection = new ExpandedNodeId(GPPlant.Variables.PLC1Type_Connection, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the PLC1Type_Connection_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId PLC1Type_Connection_FalseState = new ExpandedNodeId(GPPlant.Variables.PLC1Type_Connection_FalseState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the PLC1Type_Connection_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId PLC1Type_Connection_TrueState = new ExpandedNodeId(GPPlant.Variables.PLC1Type_Connection_TrueState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoaterType_PLC1_Connection = new ExpandedNodeId(GPPlant.Variables.CoaterType_PLC1_Connection, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoaterType_PLC1_Connection_FalseState = new ExpandedNodeId(GPPlant.Variables.CoaterType_PLC1_Connection_FalseState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the CoaterType_PLC1_Connection_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoaterType_PLC1_Connection_TrueState = new ExpandedNodeId(GPPlant.Variables.CoaterType_PLC1_Connection_TrueState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater_PLC1_Connection = new ExpandedNodeId(GPPlant.Variables.GPPlantType_Coater_PLC1_Connection, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater_PLC1_Connection_FalseState = new ExpandedNodeId(GPPlant.Variables.GPPlantType_Coater_PLC1_Connection_FalseState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Connection_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater_PLC1_Connection_TrueState = new ExpandedNodeId(GPPlant.Variables.GPPlantType_Coater_PLC1_Connection_TrueState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlantType_Coater_PLC1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlantType_Coater_PLC1_Output = new ExpandedNodeId(GPPlant.Variables.GPPlantType_Coater_PLC1_Output, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater_PLC1_Connection = new ExpandedNodeId(GPPlant.Variables.GPPlant1_Coater_PLC1_Connection, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection_FalseState Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater_PLC1_Connection_FalseState = new ExpandedNodeId(GPPlant.Variables.GPPlant1_Coater_PLC1_Connection_FalseState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Connection_TrueState Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater_PLC1_Connection_TrueState = new ExpandedNodeId(GPPlant.Variables.GPPlant1_Coater_PLC1_Connection_TrueState, GPPlant.Namespaces.GPPlant);

        /// <summary>
        /// The identifier for the GPPlant1_Coater_PLC1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId GPPlant1_Coater_PLC1_Output = new ExpandedNodeId(GPPlant.Variables.GPPlant1_Coater_PLC1_Output, GPPlant.Namespaces.GPPlant);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Coater component.
        /// </summary>
        public const string Coater = "MyCoater";

        /// <summary>
        /// The BrowseName for the CoaterType component.
        /// </summary>
        public const string CoaterType = "CoaterType";

        /// <summary>
        /// The BrowseName for the Connection component.
        /// </summary>
        public const string Connection = "Connection";

        /// <summary>
        /// The BrowseName for the GPPlant1 component.
        /// </summary>
        public const string GPPlant1 = "GP Plant #1";

        /// <summary>
        /// The BrowseName for the GPPlantType component.
        /// </summary>
        public const string GPPlantType = "GPPlantType";

        /// <summary>
        /// The BrowseName for the Mitsubishi component.
        /// </summary>
        public const string Mitsubishi = "Mitsubishi";

        /// <summary>
        /// The BrowseName for the PLC1 component.
        /// </summary>
        public const string PLC1 = "PLC1";

        /// <summary>
        /// The BrowseName for the PLC1Type component.
        /// </summary>
        public const string PLC1Type = "PLC1Type";

        /// <summary>
        /// The BrowseName for the StartProcess component.
        /// </summary>
        public const string StartProcess = "StartProcess";

        /// <summary>
        /// The BrowseName for the StopProcess component.
        /// </summary>
        public const string StopProcess = "StopProcess";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the GPPlant namespace (.NET code namespace is 'GPPlant').
        /// </summary>
        public const string GPPlant = "http://opcfoundation.org/GPPlant";
    }
    #endregion

    #region MitsubishiState Class
    #if (!OPCUA_EXCLUDE_MitsubishiState)
    /// <summary>
    /// Stores an instance of the Mitsubishi ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MitsubishiState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MitsubishiState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(GPPlant.ObjectTypes.Mitsubishi, GPPlant.Namespaces.GPPlant, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvR1BQbGFudP////8EYIACAQAAAAEAEgAAAE1p" +
           "dHN1YmlzaGlJbnN0YW5jZQEBAQABAQEAAQAAAP////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region PLC1State Class
    #if (!OPCUA_EXCLUDE_PLC1State)
    /// <summary>
    /// Stores an instance of the PLC1Type ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class PLC1State : MitsubishiState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public PLC1State(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(GPPlant.ObjectTypes.PLC1Type, GPPlant.Namespaces.GPPlant, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvR1BQbGFudP////8EYIACAQAAAAEAEAAAAFBM" +
           "QzFUeXBlSW5zdGFuY2UBAQIAAQECAAIAAAD/////AQAAABVgiQoCAAAAAQAKAAAAQ29ubmVjdGlvbgEB" +
           "AwAALwEARQkDAAAAAAH/////AwP/////AgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBBgAALgBE" +
           "BgAAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBBwAALgBEBwAAAAAV////" +
           "/wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public TwoStateDiscreteState Connection
        {
            get
            {
                return m_connection;
            }

            set
            {
                if (!Object.ReferenceEquals(m_connection, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_connection = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_connection != null)
            {
                children.Add(m_connection);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case GPPlant.BrowseNames.Connection:
                {
                    if (createOrReplace)
                    {
                        if (Connection == null)
                        {
                            if (replacement == null)
                            {
                                Connection = new TwoStateDiscreteState(this);
                            }
                            else
                            {
                                Connection = (TwoStateDiscreteState)replacement;
                            }
                        }
                    }

                    instance = Connection;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private TwoStateDiscreteState m_connection;
        #endregion
    }
    #endif
    #endregion

    #region CoaterState Class
    #if (!OPCUA_EXCLUDE_CoaterState)
    /// <summary>
    /// Stores an instance of the CoaterType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CoaterState : FolderState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CoaterState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(GPPlant.ObjectTypes.CoaterType, GPPlant.Namespaces.GPPlant, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvR1BQbGFudP////8EYIACAQAAAAEAEgAAAENv" +
           "YXRlclR5cGVJbnN0YW5jZQEBCAABAQgACAAAAAEAAAAAMAABAQkAAQAAAIRggAoBAAAAAQAEAAAAUExD" +
           "MQEBCQAALwEBAgAJAAAAAQEAAAAAMAEBAQgAAQAAABVgiQoCAAAAAQAKAAAAQ29ubmVjdGlvbgEBCgAA" +
           "LwEARQkKAAAAAAH/////AwP/////AgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBDQAALgBEDQAA" +
           "AAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBDgAALgBEDgAAAAAV/////wEB" +
           "/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public PLC1State PLC1
        {
            get
            {
                return m_pLC1;
            }

            set
            {
                if (!Object.ReferenceEquals(m_pLC1, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_pLC1 = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_pLC1 != null)
            {
                children.Add(m_pLC1);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case GPPlant.BrowseNames.PLC1:
                {
                    if (createOrReplace)
                    {
                        if (PLC1 == null)
                        {
                            if (replacement == null)
                            {
                                PLC1 = new PLC1State(this);
                            }
                            else
                            {
                                PLC1 = (PLC1State)replacement;
                            }
                        }
                    }

                    instance = PLC1;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PLC1State m_pLC1;
        #endregion
    }
    #endif
    #endregion

    #region GPPlantState Class
    #if (!OPCUA_EXCLUDE_GPPlantState)
    /// <summary>
    /// Stores an instance of the GPPlantType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GPPlantState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GPPlantState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(GPPlant.ObjectTypes.GPPlantType, GPPlant.Namespaces.GPPlant, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the instance with a node.
        /// </summary>
        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvR1BQbGFudP////+EYIACAQAAAAEAEwAAAEdQ" +
           "UGxhbnRUeXBlSW5zdGFuY2UBAQ8AAQEPAA8AAAABAQAAAAAwAAEBEAADAAAAhGDACgEAAAAGAAAAQ29h" +
           "dGVyAQAIAAAATXlDb2F0ZXIBARAAAC8BAQgAEAAAAAECAAAAADABAQEPAAAwAAEBEQABAAAAhGCACgEA" +
           "AAABAAQAAABQTEMxAQERAAAvAQECABEAAAABAQAAAAAwAQEBEAACAAAAFWCJCgIAAAABAAoAAABDb25u" +
           "ZWN0aW9uAQESAAAvAQBFCRIAAAAAAf////8DA/////8CAAAAFWCJCgIAAAAAAAoAAABGYWxzZVN0YXRl" +
           "AQEVAAAuAEQVAAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQEWAAAuAEQW" +
           "AAAAABX/////AQH/////AAAAABVgiQoCAAAAAQAGAAAAT3V0cHV0AQEXAAAvAD8XAAAAABj/////AQH/" +
           "////AAAAAARhggoEAAAAAQAMAAAAU3RhcnRQcm9jZXNzAQEYAAAvAQEYABgAAAABAf////8AAAAABGGC" +
           "CgQAAAABAAsAAABTdG9wUHJvY2VzcwEBGQAALwEBGQAZAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <remarks />
        public CoaterState Coater
        {
            get
            {
                return m_coater;
            }

            set
            {
                if (!Object.ReferenceEquals(m_coater, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_coater = value;
            }
        }

        /// <remarks />
        public MethodState StartProcess
        {
            get
            {
                return m_startProcessMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_startProcessMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startProcessMethod = value;
            }
        }

        /// <remarks />
        public MethodState StopProcess
        {
            get
            {
                return m_stopProcessMethod;
            }

            set
            {
                if (!Object.ReferenceEquals(m_stopProcessMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stopProcessMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_coater != null)
            {
                children.Add(m_coater);
            }

            if (m_startProcessMethod != null)
            {
                children.Add(m_startProcessMethod);
            }

            if (m_stopProcessMethod != null)
            {
                children.Add(m_stopProcessMethod);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case GPPlant.BrowseNames.Coater:
                {
                    if (createOrReplace)
                    {
                        if (Coater == null)
                        {
                            if (replacement == null)
                            {
                                Coater = new CoaterState(this);
                            }
                            else
                            {
                                Coater = (CoaterState)replacement;
                            }
                        }
                    }

                    instance = Coater;
                    break;
                }

                case GPPlant.BrowseNames.StartProcess:
                {
                    if (createOrReplace)
                    {
                        if (StartProcess == null)
                        {
                            if (replacement == null)
                            {
                                StartProcess = new MethodState(this);
                            }
                            else
                            {
                                StartProcess = (MethodState)replacement;
                            }
                        }
                    }

                    instance = StartProcess;
                    break;
                }

                case GPPlant.BrowseNames.StopProcess:
                {
                    if (createOrReplace)
                    {
                        if (StopProcess == null)
                        {
                            if (replacement == null)
                            {
                                StopProcess = new MethodState(this);
                            }
                            else
                            {
                                StopProcess = (MethodState)replacement;
                            }
                        }
                    }

                    instance = StopProcess;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private CoaterState m_coater;
        private MethodState m_startProcessMethod;
        private MethodState m_stopProcessMethod;
        #endregion
    }
    #endif
    #endregion
}