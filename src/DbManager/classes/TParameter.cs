using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.classes
{
    class TParameter
    {
        private string name;
        private object type;
        private int length;
        private string defValue;
        private bool isoutparam;

        public TParameter(string name, object type, int length, string defValue, bool isoutparam)
        {
            this.name = name;
            this.type = type;
            this.length = length;
            this.defValue = defValue;
            this.isoutparam = isoutparam;
            
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

        public bool IsOutParam {
            get {
                return isoutparam;
            }
            set {
                this.isoutparam = value;
            }
        }
    }
}
