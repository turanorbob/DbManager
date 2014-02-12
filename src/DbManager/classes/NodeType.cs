using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class NodeType
    {
        private ENodeType type;
        private string dbName;
        private string name;
        private int uid;
        private bool isexpand;

        public NodeType(ENodeType type, string name, string dbName, int uid) {
            this.type = type;
            this.name = name;
            this.dbName = dbName;
            this.uid = uid;
        }

        public bool IsExpand {
            get {
                return isexpand;
            }
            set {
                isexpand = true;
            }
        }

        public ENodeType Type
        {
            get {
                return type;
            }
        }

        public string Name {
            get {
                return name;
            }
        }

        public string DbName {
            get {
                return dbName;
            }
            set {
                this.dbName = value;
            }
        }

        public int Uid {
            get {
                return uid;
            }
        }
    }
}
