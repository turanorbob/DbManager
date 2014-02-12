using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TDatabase
    {
        private string name;
        private bool isSystem;
        private int dbid;

        public TDatabase(string name, bool isSystem, int dbid) {
            this.name = name;
            this.isSystem = isSystem;
            this.dbid = dbid;
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

        public int Dbid {
            get {
                return dbid;
            }
        }
    }
}
