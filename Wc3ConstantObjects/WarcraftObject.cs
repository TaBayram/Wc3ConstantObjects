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
        public static bool addInitial;
        public static bool addSuffix;
        public static bool addTwoCC;


        string id;
        string name;
        string secondName = "";
        string tooltip = "";
        string tooltipExtended = "";
        string editorSuffix = "";

        public bool hasDuplicateName = false;


        Wc3Class.ObjectType objectType;

        public WarcraftObject()
        {

        }
        public WarcraftObject(Wc3Class.ObjectType objectType,string fourCC, string name)
        {
            this.objectType = objectType;
            this.id = fourCC;
            this.Name = name.Trim();
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Tooltip { get => tooltip; set => tooltip = value; }
        public string TooltipExtended { get => tooltipExtended; set => tooltipExtended = value; }
        public string EditorSuffix { get => editorSuffix; set => editorSuffix = value; }
        public string SecondName { get => secondName; set => secondName = value; }

        public string ConvertTS(bool addInitial, bool removeColor)
        {
            return "\n/**NAME:\t" + RemoveARGB(secondName)+ "\nTOOLTIP:\t" + RemoveARGB(tooltip) + " \nEXTENDED:\t" + RemoveARGB(tooltipExtended) + " \nSUFFIX:\t" + RemoveARGB(editorSuffix) + "*/ \n"+
                "export const " + VariableName(addInitial, removeColor) + " = FourCC(\"" + id + "\");";
        }

        public string VariableName(bool addInitial, bool removeColor) {
            return 
                (addInitial ? objectType.ToString().Substring(0, 2) : string.Empty) + 
                Variablize(objectType == Wc3Class.ObjectType.upgrade ? secondName : Name, removeColor, !addInitial) + 
                (hasDuplicateName ? id.Substring(2, 2) : string.Empty);
        }

        private string Variablize(string name, bool removeColor, bool startingString = false)
        {
            if (name == "") name = editorSuffix;
            if (name == "") name = tooltip;
            if (name == "") name = id;
            string newName = "";
            if(removeColor) name = RemoveARGB(name);
            Regex regex = new Regex("[^a-zA-Z0-9]");
            newName = regex.Replace(name, "");
            if (startingString && Char.IsDigit(newName[0])) newName = newName.Insert(0, id[0].ToString());
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
