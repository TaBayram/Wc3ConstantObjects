using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace Wc3ConstantObjects
{
    class Converter
    {
        BackgroundWorker backgroundWorker;
        MainForm mainForm;
        int currentThreadCount = 1;
        int sumProgress = 0;

        public Converter(BackgroundWorker backgroundWorker, MainForm mainForm) {
            this.backgroundWorker = backgroundWorker;
            this.mainForm = mainForm;

        }


        public void UpdateProgres(int value) {
            this.mainForm.threadUpdate.Invoke(sumProgress / currentThreadCount);
        }



        public List<WarcraftObject> CreateWarcraftObjectList(in string content, List<Wc3Class> wc3Classes) {

            List<string> idList = new List<string>();
            Dictionary<string, WarcraftObject> warcraftObjects = new Dictionary<string, WarcraftObject>();

            foreach (Wc3Class type in wc3Classes) {
                string tooltip = ", Tip (", tooltipExtended = ", Ubertip (", editorSuffix = ", EditorSuffix (", secondName = ", Name (";
                if (type.Type == Wc3Class.ObjectType.buffEffect) {
                    tooltip = ", Bufftip (";
                    tooltipExtended = ", Buffubertip (";
                }

                int i = 0; int progress = 0;
                while (i < content.Length) {
                    int index = content.IndexOf(type.Text + ":", i);
                    if (index == -1) break;
                    int space = content.IndexOf(" ", index);
                    string fourCC = content.Substring(space + 1, 4);
                    warcraftObjects.TryGetValue(fourCC, out WarcraftObject wcObj);
                    if (wcObj == null) {
                        int openingToName = content.IndexOf('(', space);
                        int closingToName = content.IndexOf(')', space);
                        string name = content.Substring(openingToName + 1, closingToName - openingToName - 1);

                        idList.Add(fourCC);
                        wcObj = new WarcraftObject(type.Type, fourCC, name);
                        warcraftObjects.Add(fourCC, wcObj);
                    }

                    if (wcObj != null) {
                        int propertyNameIndex = content.IndexOf(')', space) + 1;
                        List<string> properties = new List<string> { tooltip, tooltipExtended, editorSuffix, secondName };
                        for (int j = 0; j < 20; j++) {
                            char c = content[propertyNameIndex];
                            for (int x = properties.Count - 1; x >= 0; x--) {
                                char d = properties[x][j];
                                if (c != d) {
                                    properties.RemoveAt(x);
                                }

                            }
                            if (c == '(') {
                                break;
                            }
                            propertyNameIndex++;
                        }
                        if (properties.Count == 1) {
                            int propStart = content.IndexOf('{', propertyNameIndex) + 1;
                            int propEnd = content.IndexOf('}', propStart);
                            string text = content.Substring(propStart, propEnd - propStart).ReplaceFirst("\r\n","").ReplaceLast("\r\n", "");


                            if (properties[0] == tooltip) {
                                if (wcObj.Tooltip.Length == 0)
                                    wcObj.Tooltip = text;
                            }
                            if (properties[0] == tooltipExtended) {
                                if (wcObj.TooltipExtended.Length == 0)
                                    wcObj.TooltipExtended = text;
                            }
                            if (properties[0] == editorSuffix) {
                                if (wcObj.EditorSuffix.Length == 0)
                                    wcObj.EditorSuffix = text;
                            }
                            if (properties[0] == secondName) {
                                if (wcObj.SecondName.Length == 0)
                                    wcObj.SecondName = text;
                            }

                            propertyNameIndex = propEnd;
                        }

                        i = propertyNameIndex;
                    }


                    if (progress + 1 < (float)i / content.Length * 80) {
                        progress = (int)((float)i / content.Length * 80);
                        backgroundWorker.ReportProgress(Math.Min(100, progress));
                    }

                }
            }
            //warcraftObjects = warcraftObjects.OrderBy(o => o.VariableName).ToList();
            //warcraftObjects.Sort((x, y) => x.VariableName.CompareTo(y.VariableName));

            List<WarcraftObject> warcrafts = new List<WarcraftObject>();
            foreach (var fourCC in idList) {
                warcraftObjects.TryGetValue(fourCC, out WarcraftObject obj);
                warcrafts.Add(obj);
            }

            foreach (var wcObj1 in warcrafts) {
                foreach (var wcObj2 in warcrafts) {
                    if (wcObj1.ID != wcObj2.ID && wcObj1.Name == wcObj2.Name) {
                        wcObj1.hasDuplicateName = true;
                        wcObj2.hasDuplicateName = true;
                    }
                }
            }


            return warcrafts;
        }



        public string ListToFile(List<WarcraftObject> warcraftObjects, bool initals, bool removeColor, bool checkDuplicate, bool orderByFourCC) {
            if (orderByFourCC)
                warcraftObjects.Sort((x, y) => x.ID.CompareTo(y.ID));
            else
                warcraftObjects.Sort((x, y) => x.VariableName(initals, removeColor).CompareTo(y.VariableName(initals, removeColor)));

            string content = "";
            int i = 0;
            foreach (WarcraftObject warcraftObject in warcraftObjects) {
                content += warcraftObject.ConvertTS(initals, removeColor) + "\n";
                backgroundWorker.ReportProgress(Math.Min(80 + (int)((float)i / warcraftObjects.Count * 20), 100));
                i++;
            }

            return content;
        }



    }
}

public static class StringExtensionMethods
{
    public static string ReplaceFirst(this string text, string search, string replace) {
        int pos = text.IndexOf(search);
        if (pos < 0) {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }

    public static string ReplaceLast(this string text, string search, string replace) {
        int pos = text.LastIndexOf(search);
        if (pos < 0) {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}