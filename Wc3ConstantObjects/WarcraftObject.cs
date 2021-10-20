using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wc3ConstantObjects
{
    class WarcraftObject
    {
        string fourCC;
        string name;
        string editorSuffix;
        string variableName;
        bool addInitial;
        bool addSuffix;
        bool addTwoCC;
        Wc3Class.ObjectType objectType;

        public WarcraftObject()
        {

        }
        public WarcraftObject(Wc3Class.ObjectType objectType,string fourCC, string name, string editorSuffix,bool addInitial,bool removeRGB)
        {
            this.objectType = objectType;
            this.fourCC = fourCC;
            this.name = name;
            this.editorSuffix = editorSuffix;
            this.addSuffix = false;
            this.addTwoCC = false;
            this.addInitial = addInitial;
            if (removeRGB)
            {
                this.name = RemoveARGB(this.name);
                this.editorSuffix = RemoveARGB(this.editorSuffix);
            }

            UpdateVariableName();
        }

        public string FourCC { get => fourCC; set => fourCC = value; }
        public string Name { get => name; set => name = value; }
        public string EditorSuffix { get => editorSuffix; set => editorSuffix = value; }
        public bool AddSuffix { get => addSuffix; set { addSuffix = value; UpdateVariableName();  } }
        public bool AddTwoCC { get => addTwoCC; set { addTwoCC = value; UpdateVariableName(); } }
        public string VariableName { get => variableName; set => variableName = value; }

        
        private void UpdateVariableName()
        {
            variableName =(addInitial?objectType.ToString().Substring(0,2):string.Empty)+ Variablize(Name, !addInitial) + (AddSuffix ? Variablize(editorSuffix) : string.Empty) + (AddTwoCC ? FourCC.Substring(2, 2) : string.Empty);
        }

        public string ConvertTS()
        {
            return "export const " + VariableName + " = FourCC(\"" + fourCC + "\");";
        }

        private string Variablize(string name, bool startingString = false)
        {
            string newName = "";
            Regex regex = new Regex("[^a-zA-Z0-9]");
            newName = regex.Replace(name, "");
            if (startingString && Char.IsDigit(newName[0])) newName = newName.Insert(0, fourCC[0].ToString());
            return newName;
        }

        private string RemoveARGB(string content)
        {
            while (content.Contains("|c"))
            {
                int i = content.IndexOf("|c");
                content = content.Remove(i, 2 + 2 + 2 + 2 + 2);
            }
            content = content.Replace("|r", string.Empty);

            return content;
        }
    }
}
