using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TProcedure
    {
        private string name;
        private int uid;
        private bool issystem;

        public TProcedure(string name, int uid, bool issystem) {
            this.name = name;
            this.uid = uid;
            this.issystem = issystem;
        }

        public string Name {
            get {
                return name;
            }
        }

        public int Uid {
            get {
                return uid;
            }
        }

        public bool IsSystem {
            get {
                return issystem;
            }
        }
    }
}
