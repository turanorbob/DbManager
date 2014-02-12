using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
namespace DbManager.setting
{
    [DefaultPropertyAttribute("SaveOnClose")] 
    class AppSetting
    {
        private string name;
        private bool save;
        private int max;
        
        public AppSetting() { 
        
        }

        [CategoryAttribute("设置1"),
        DefaultValueAttribute("turan")]
        public string Name {
            get {
                return name;
            }
            set {
                this.name = value;
            }
        }

        
        [BrowsableAttribute(true),
     DefaultValueAttribute(true)] 
        public bool Save {
            get {
                return save;
            }
            set {
                this.save = value;
            }
        }

        [CategoryAttribute("设置1"),
        DefaultValueAttribute(12),
        DescriptionAttribute("true or false")] 
        public int Max {
            get {
                return max;
            }
            set {
                this.max = value;
            }
        }
    }
}
