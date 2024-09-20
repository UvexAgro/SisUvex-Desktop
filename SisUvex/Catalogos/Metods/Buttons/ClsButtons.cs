using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.Buttons
{
    internal class ClsButtons
    {
        private bool isChecked;

        public void ToggleButton()
        {
            isChecked = !isChecked;
        }
    }
}
