using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wc3ConstantObjects
{
    class Converter
    {
        BackgroundWorker backgroundWorker;

        public Converter(BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
        }



        public List<WarcraftObject> CreateWarcraftObjectList(in string content,List<Wc3Class> wc3Classes,bool addInitial,bool removeRGB)
        {
            List<WarcraftObject> warcraftObjects = new List<WarcraftObject>();
            string constants = "";


            foreach (Wc3Class type in wc3Classes)
            {

                int i = 0; int progress = 0;
                while (i < content.Length)
                {
                    int index = content.IndexOf(type.Text+":", i);
                    if (index == -1) break;
                    int space = content.IndexOf(" ", index);
                    string fourCC = content.Substring(space + 1, 4);

                    int openingToName = content.IndexOf('(', space);
                    int closingToName = content.IndexOf(')', space);
                    string name = content.Substring(openingToName + 1, closingToName - openingToName - 1);

                    int editorSuffixIndex = content.IndexOf("EditorSuffix", space);
                    int nextStringIndex = content.IndexOf("STRING", space);
                    string editorSuffix = "";
                    if (editorSuffixIndex != -1 && editorSuffixIndex < nextStringIndex)
                    {
                        int openingBrackey = content.IndexOf("{", editorSuffixIndex);
                        int closingBrackey = content.IndexOf("}", editorSuffixIndex);
                        editorSuffix = content.Substring(openingBrackey + 1, closingBrackey - openingBrackey);
                    }

                    WarcraftObject warcraftObj = new WarcraftObject(type.Type,fourCC, name, editorSuffix,addInitial, removeRGB);
                    if (IsNewModify(warcraftObjects, warcraftObj))
                        warcraftObjects.Add(warcraftObj);
                    i = closingToName;
                    if (progress + 1 < (float)i / content.Length * 80)
                    {
                        progress = (int)((float)i / content.Length * 80);
                        backgroundWorker.ReportProgress(Math.Min(100, progress));
                    }

                }
            }
            //warcraftObjects = warcraftObjects.OrderBy(o => o.VariableName).ToList();
            //warcraftObjects.Sort((x, y) => x.VariableName.CompareTo(y.VariableName));
            
            return warcraftObjects;
        }

        public string ListToFile(List<WarcraftObject> warcraftObjects,bool orderByFourCC)
        {
            if(orderByFourCC)
                warcraftObjects.Sort((x, y) => x.FourCC.CompareTo(y.FourCC));
            else
                warcraftObjects.Sort((x, y) => x.VariableName.CompareTo(y.VariableName));

            string content = "";
            int i = 0;
            foreach (WarcraftObject warcraftObject in warcraftObjects)
            {
                content += warcraftObject.ConvertTS() + "\n";
                backgroundWorker.ReportProgress(Math.Min(80 + (int)((float)i / warcraftObjects.Count * 20), 100));
                i++;
            }

            return content;
        }

        private bool IsNewModify(in List<WarcraftObject> warcraftObjects,in WarcraftObject warcraftObj)
        {
            foreach (WarcraftObject warcraftObject in warcraftObjects)
            {
                if (warcraftObject.FourCC == warcraftObj.FourCC)
                {
                    return false;
                }
                else if (warcraftObj.VariableName == warcraftObject.VariableName)
                {
                    if (!warcraftObj.AddSuffix)
                    {
                        warcraftObj.AddSuffix = true;
                        warcraftObject.AddSuffix = true;
                        if (warcraftObj.VariableName == warcraftObject.VariableName)
                        {
                            warcraftObj.AddTwoCC = true;
                            warcraftObject.AddTwoCC = true;
                        }
                    }
                    else if (!warcraftObj.AddTwoCC)
                    {
                        warcraftObj.AddTwoCC = true;
                        warcraftObject.AddTwoCC = true;
                    }
                }
                if (warcraftObj.Name == warcraftObject.Name)
                {
                    warcraftObj.AddTwoCC = warcraftObject.AddTwoCC;
                    warcraftObj.AddSuffix = warcraftObject.AddSuffix;
                }
            }

            return true;
        }
    }
}
