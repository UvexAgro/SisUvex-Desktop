using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Extensiones
{
    public static class ControlExtensions
    {
        private static readonly Dictionary<Control, ExtensionProperties> extensionProperties = new Dictionary<Control, ExtensionProperties>();

        public static void SetMensajeVacio(this Control control, string mensaje)
        {
            GetOrCreateExtensionProperties(control).MensajeVacio = mensaje;
        }

        public static string GetMensajeVacio(this Control control)
        {
            return GetExtensionProperties(control).MensajeVacio;
        }

        public static void SetControlRelacionado(this Control control, Control controlRelacionado)
        {
            GetOrCreateExtensionProperties(control).ControlRelacionado = controlRelacionado;
        }

        public static Control GetControlRelacionado(this Control control)
        {
            return GetExtensionProperties(control).ControlRelacionado;
        }

        private static ExtensionProperties GetOrCreateExtensionProperties(Control control)
        {
            if (!extensionProperties.TryGetValue(control, out var properties))
            {
                properties = new ExtensionProperties();
                extensionProperties[control] = properties;
            }
            return properties;
        }

        private static ExtensionProperties GetExtensionProperties(Control control)
        {
            if (!extensionProperties.TryGetValue(control, out var properties))
            {
                throw new InvalidOperationException("No se ha seteado la propiedad al control.");
            }
            return properties;
        }

        private class ExtensionProperties
        {
            public string MensajeVacio { get; set; }
            public Control ControlRelacionado { get; set; }
        }
    }
}
