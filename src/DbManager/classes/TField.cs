using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TField
    {
        private string name;
        private object type;
        private int length;
        private string defValue;

        public TField(string name, object type, int length, string defValue) {
            this.name = name;
            this.type = type;
            this.length = length;
            this.defValue = defValue;
            
        }

        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        public string Type {
            get {
                return type.ToString();
            }
            set {
                this.type = value;
            }
        }

        public int Length {
            get {
                return length;
            }
            set {
                this.length = value;
            }
        }

        public string DefaultValue {
            get {
                return defValue;
            }
            set {
                this.defValue = value;
            }
        }
    }
}
