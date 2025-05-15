using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisUvex.Catalogos.Metods;
using SisUvex.Catalogos.Metods.Querys;

namespace SisUvex.Material.MaterialRegister.Exit
{
    internal class EMaterialRegisterExit
    {
        public const string? cIdMatOutput = "idMatOutput";
        public const string? cPosition = "Posición";
        public const string? cIdOutputType = "idOutputType";
        public const string? cIdExitStatus = "idExitStatus";

        public static DataTable? GetDTOutputType()
        {
            return ClsQuerysDB.GetDataTable($" SELECT id_outputType AS [{ClsObject.Column.id}], v_nameType AS [{ClsObject.Column.name}] FROM Pack_OutputType ");
        }

        public static DataTable? GetDTExitStatus()
        {
            return ClsQuerysDB.GetDataTable($" SELECT id_exitStatus AS [{ClsObject.Column.id}], v_nameStatus AS [{ClsObject.Column.name}]  from Pack_ExitStatus ");
        }
    }
}