using System;
using System.Runtime.InteropServices;

namespace SisUvex.Cuadro_de_herramientas.ZPL
{
    /// <summary>
    /// Suspende y reanuda el registro en la pila de deshacer de Rich Edit (Text Object Model),
    /// para que el formateo programático no contamine Ctrl+Z.
    /// </summary>
    internal static class ClsRichedTomUndo
    {
        private const int WmUser = 0x0400;
        private const int EmGetOleInterface = WmUser + 108;
        private const int TomSuspend = -9999995;
        private const int TomResume = -9999994;

        private static readonly Guid GuidITextDocument = new("8CC497C0-A1DF-11CE-8098-00AA0047BE5D");

        /// <summary>Índice de Undo en ITextDocument cuando la tabla exporta también IDispatch (Rich Edit típico de WinForms).</summary>
        private const int UndoVtableSlotDispatch = 22;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int TomUndoDel(IntPtr pThis, int count, IntPtr pProp);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref IntPtr lParam);

        /// <summary>Inicia suspensión; si devuelve <see langword="true"/>, hay que llamar a <see cref="LiberarSuspension"/>.</summary>
        public static bool TrySuspenderGrabacionUndo(IntPtr richEditHwnd, out IntPtr textoDocumentPtr)
        {
            textoDocumentPtr = IntPtr.Zero;

            if (richEditHwnd == IntPtr.Zero)
                return false;

            IntPtr punk = IntPtr.Zero;
            SendMessage(richEditHwnd, EmGetOleInterface, IntPtr.Zero, ref punk);
            if (punk == IntPtr.Zero)
                return false;

            Guid iidDoc = GuidITextDocument;
            int hrQi = Marshal.QueryInterface(punk, ref iidDoc, out textoDocumentPtr);
            Marshal.Release(punk);

            if (hrQi != 0 || textoDocumentPtr == IntPtr.Zero)
                return false;

            TomUndoDel? undo = ObtenerUndo(textoDocumentPtr);
            if (undo == null)
            {
                Marshal.Release(textoDocumentPtr);
                textoDocumentPtr = IntPtr.Zero;
                return false;
            }

            int hrSus = undo(textoDocumentPtr, TomSuspend, IntPtr.Zero);
            if (hrSus != 0)
            {
                _ = undo(textoDocumentPtr, TomResume, IntPtr.Zero);
                Marshal.Release(textoDocumentPtr);
                textoDocumentPtr = IntPtr.Zero;
                return false;
            }

            return true;
        }

        public static void LiberarSuspension(IntPtr textoDocumentPtr)
        {
            if (textoDocumentPtr == IntPtr.Zero)
                return;

            TomUndoDel? undo = ObtenerUndo(textoDocumentPtr);
            if (undo != null)
                _ = undo(textoDocumentPtr, TomResume, IntPtr.Zero);

            Marshal.Release(textoDocumentPtr);
        }

        private static TomUndoDel? ObtenerUndo(IntPtr pDoc)
        {
            try
            {
                IntPtr vt = Marshal.ReadIntPtr(pDoc);
                IntPtr fn = Marshal.ReadIntPtr(vt, UndoVtableSlotDispatch * Marshal.SizeOf(typeof(IntPtr)));
                return Marshal.GetDelegateForFunctionPointer<TomUndoDel>(fn);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
