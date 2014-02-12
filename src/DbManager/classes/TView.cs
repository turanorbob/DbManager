using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TView
    {
        private int uid;
        private string name;
        private bool isSystem;
        private string dbName;

        public TView(int uid, string name, bool isSystem) {
            this.uid = uid;
            this.name = name;
            this.isSystem = isSystem;
        }

        public int Uid {
            get {
                return uid;
            }
        }

        public string Name {
            get {
                return name;
            }
        }

        public string Label {
            get {
                if (uid == 3)
                {
                    return "INFORMATION_SCHEMA." + name;
                }
                else {
                    return name;
                }
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
        
    }
}
