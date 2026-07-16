using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.CheckBoxes
{
    internal class ClsCheckBoxes
    {
        public static string GetCheckedValue(bool isChecked)
        {
            return isChecked ? "1" : "0";
        }

        public static string GetCheckedValue(CheckBox checkBox)
        {
            return GetCheckedValue(checkBox.Checked);
        }

        public static int GetCheckedValueInt(bool isChecked)
        {
            return isChecked ? 1 : 0;
        }
        public static int GetCheckedValueInt(CheckBox checkBox)
        {
            return GetCheckedValueInt(checkBox.Checked);
        }
    }
}
