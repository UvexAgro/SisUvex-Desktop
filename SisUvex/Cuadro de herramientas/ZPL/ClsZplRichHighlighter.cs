using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas.ZPL
{
    /// <summary>
    /// Resalta ZPL en un <see cref="RichTextBox"/> sin mover el caret ni el scroll como al seleccionar todo el texto.
    /// </summary>
    public static class ClsZplRichHighlighter
    {
        private static readonly Color Comando = Color.FromArgb(0xB2, 0x22, 0x22);
        private static readonly Color Parametro = Color.FromArgb(0x00, 0x8B, 0x8B);
        private static readonly Color Comentario = Color.FromArgb(0x33, 0x33, 0x33);

        private const int WM_SETREDRAW = 0x000B;
        private const int EM_GETFIRSTVISIBLELINE = 0x00CE;
        private const int EM_LINESCROLL = 0x00B6;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public static void Aplicar(RichTextBox rtb)
        {
            if (rtb.IsDisposed || !rtb.IsHandleCreated)
                return;

            string t = rtb.Text;

            int selInicio = rtb.SelectionStart;
            int selLong = rtb.SelectionLength;
            Color baseTexto = rtb.ForeColor;

            IntPtr hwnd = rtb.Handle;
            int primeraLineaVisible = GetFirstVisibleLine(hwnd);

            bool undoSuspendido = ClsRichedTomUndo.TrySuspenderGrabacionUndo(hwnd, out IntPtr pTomDoc);
            try
            {
                SendMessage(hwnd, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
                rtb.SuspendLayout();
                try
                {
                    if (t.Length == 0)
                        return;

                    int idx = 0;
                    while (idx < t.Length)
                    {
                        int caret = t.IndexOf('^', idx);
                        if (caret < 0)
                        {
                            rtb.Select(idx, t.Length - idx);
                            rtb.SelectionColor = baseTexto;
                            break;
                        }

                        if (caret > idx)
                        {
                            rtb.Select(idx, caret - idx);
                            rtb.SelectionColor = baseTexto;
                        }

                        if (EmpiezaCon(t, caret, "^FX"))
                        {
                            int longCmd = 3;
                            rtb.Select(caret, longCmd);
                            rtb.SelectionColor = Comando;

                            int comInicio = caret + longCmd;
                            int comFin = t.Length;
                            for (int q = comInicio; q < t.Length; q++)
                            {
                                if (t[q] is '\r' or '\n')
                                {
                                    comFin = q;
                                    break;
                                }
                            }

                            if (comFin > comInicio)
                            {
                                rtb.Select(comInicio, comFin - comInicio);
                                rtb.SelectionColor = Comentario;
                            }

                            idx = comFin;
                            while (idx < t.Length && t[idx] is '\r' or '\n')
                                idx++;
                            continue;
                        }

                        if (EmpiezaCon(t, caret, "^FD"))
                        {
                            int longCmd = 3;
                            rtb.Select(caret, longCmd);
                            rtb.SelectionColor = Comando;

                            int dInicio = caret + longCmd;
                            int dFin = t.IndexOf('^', dInicio);
                            if (dFin < 0)
                                dFin = t.Length;

                            if (dFin > dInicio)
                            {
                                rtb.Select(dInicio, dFin - dInicio);
                                rtb.SelectionColor = Parametro;
                            }

                            idx = dFin;
                            continue;
                        }

                        int finCmd = caret + 1;
                        while (finCmd < t.Length && EsLetraComando(t[finCmd]) && finCmd - caret - 1 < 8)
                            finCmd++;

                        int longCmdGen = finCmd - caret;
                        if (longCmdGen > 0)
                        {
                            rtb.Select(caret, longCmdGen);
                            rtb.SelectionColor = Comando;
                        }

                        int pInicio = finCmd;
                        int pFin = t.IndexOf('^', pInicio);
                        if (pFin < 0)
                            pFin = t.Length;

                        if (pFin > pInicio)
                        {
                            rtb.Select(pInicio, pFin - pInicio);
                            rtb.SelectionColor = Parametro;
                        }

                        idx = pFin;
                    }
                }
                finally
                {
                    int largoTexto = rtb.TextLength;
                    int z = Math.Clamp(selInicio, 0, largoTexto);
                    int longMaxSel = Math.Max(0, largoTexto - z);
                    int longSel = Math.Min(selLong, longMaxSel);

                    rtb.Select(z, longSel);

                    RestaurarScrollVertical(hwnd, primeraLineaVisible);

                    SendMessage(hwnd, WM_SETREDRAW, new IntPtr(1), IntPtr.Zero);
                    rtb.ResumeLayout(false);
                    rtb.Invalidate();
                }
            }
            finally
            {
                if (undoSuspendido)
                    ClsRichedTomUndo.LiberarSuspension(pTomDoc);
            }
        }

        private static int GetFirstVisibleLine(IntPtr hwnd) =>
            unchecked((int)(long)(nint)SendMessage(hwnd, EM_GETFIRSTVISIBLELINE, IntPtr.Zero, IntPtr.Zero));

        private static void RestaurarScrollVertical(IntPtr hwnd, int lineaPrimeraAntes)
        {
            int lineaAhora = GetFirstVisibleLine(hwnd);
            int delta = lineaPrimeraAntes - lineaAhora;
            if (delta != 0)
                SendMessage(hwnd, EM_LINESCROLL, IntPtr.Zero, (IntPtr)delta);
        }

        private static bool EsLetraComando(char c) =>
            char.IsLetter(c) || c is '@' or '#';

        private static bool EmpiezaCon(string s, int i, string prefijo)
        {
            if (i + prefijo.Length > s.Length)
                return false;
            return s.AsSpan(i, prefijo.Length).Equals(prefijo, StringComparison.OrdinalIgnoreCase);
        }
    }
}
