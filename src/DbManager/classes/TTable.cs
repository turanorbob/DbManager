using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TTable
    {
        private string name;
        private string dbName;
        private bool isSystem;
        private int uid;

        public TTable(string name, bool isSystem, int uid) {
            this.name = name;
            this.isSystem = isSystem;
            this.uid = uid;
        }

        public string Name {
            get {
                return name;
            }
        }

        public bool IsSystem {
            get {
                return isSystem;
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
