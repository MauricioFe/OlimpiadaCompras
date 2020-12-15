using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlimpiadaCompras.Util
{
    public abstract class ManipulaFormGenericoUtil
    {
        public static void LimpaTextBox(Form form)
        {
            foreach (var parent in form.Controls)
            {
                if (parent.GetType() == typeof(GroupBox))
                {
                    var group = (GroupBox)parent;
                    foreach (var childrenGroup in group.Controls)
                    {
                        if (childrenGroup.GetType() == typeof(TextBox))
                        {
                            var txt = (TextBox)childrenGroup;
                            txt.Text = string.Empty;
                        }
                    }
                }
                if (parent.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)parent;
                    txt.Text = string.Empty;
                }
            }
        }
    }
}
