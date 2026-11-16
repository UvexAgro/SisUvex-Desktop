namespace SisUvex.Configuracion
{
    /// <summary>
    /// Lista desplegable de AntdUI en la que solo se puede elegir una opción: no se puede escribir,
    /// pegar, cortar ni borrar texto. Conserva la apertura normal de la lista con el clic y el teclado.
    /// </summary>
    public class SelectorServidores : AntdUI.Select
    {
        private const int WM_CHAR = 0x0102;
        private const int WM_UNICHAR = 0x0109;
        private const int WM_IME_CHAR = 0x0286;
        private const int WM_CUT = 0x0300;
        private const int WM_PASTE = 0x0302;
        private const int WM_CLEAR = 0x0303;
        private const int WM_UNDO = 0x0304;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CHAR:
                case WM_UNICHAR:
                case WM_IME_CHAR:
                case WM_CUT:
                case WM_PASTE:
                case WM_CLEAR:
                case WM_UNDO:
                    return;     // cualquier texto escrito o pegado se ignora
            }
            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys tecla = keyData & Keys.KeyCode;
            bool control = (keyData & Keys.Control) == Keys.Control;
            bool mayus = (keyData & Keys.Shift) == Keys.Shift;

            if (control && (tecla == Keys.V || tecla == Keys.X || tecla == Keys.Z || tecla == Keys.Y))
                return true;
            if (mayus && (tecla == Keys.Insert || tecla == Keys.Delete))
                return true;
            if (tecla == Keys.Delete || tecla == Keys.Back)
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Keys tecla = e.KeyCode;
            if (tecla == Keys.Delete || tecla == Keys.Back ||
                (e.Control && (tecla == Keys.V || tecla == Keys.X || tecla == Keys.Z || tecla == Keys.Y)))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            base.OnKeyDown(e);
        }
    }
}
