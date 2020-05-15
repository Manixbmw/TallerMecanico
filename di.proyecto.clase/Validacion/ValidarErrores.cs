using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace di.proyecto.clase.Validacion
{
    public static class ValidarErrores
    {
        public static void quitarError(Control c)
        {
            c.BorderBrush = Brushes.LightGray;
            c.Foreground = Brushes.Black;
        }

        public static void marcarError(Control c)
        {
            c.BorderBrush = Brushes.Red;
            c.Foreground = Brushes.Red;
        }

    }
}
