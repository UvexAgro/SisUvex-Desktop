using SisUvex.Archivo.MixtearPallets;
using System;
using System.Windows.Forms;

namespace SisUvex.Nomina.Asistencia_AS
{
    public partial class FrmAsistenciaASConsulta : Form
    {
        private readonly ClsAsistenciaASConsulta cls;

        public FrmAsistenciaASConsulta()
        {
            AntdTheme.Apply();
            InitializeComponent();
            ApplyAntdLook();
            cls = new ClsAsistenciaASConsulta { frm = this };
        }

        /// <summary>Detalles visuales que el diseñador no genera (foco de las cajas de texto y ayudas emergentes).</summary>
        private void ApplyAntdLook()
        {
            AntdInputHost.Bind(pnlEmployeeInput, txbIdEmployee);
            AntdInputHost.Bind(pnlLastDaysInput, txbLastDays);

            toolTip.SetToolTip(btnSearchEmployee, "Buscar empleado");
            toolTip.SetToolTip(btnAddEmployee, "Agregar al listado los códigos escritos");
            toolTip.SetToolTip(btnAddList, "Agregar al listado los empleados del lugar de pago");
            toolTip.SetToolTip(btnAddNomWorkGroup, "Agregar al listado los empleados de la(s) cuadrilla(s) seleccionada(s)");
            toolTip.SetToolTip(btnClearList, "Limpiar el listado de empleados");
            toolTip.SetToolTip(btnModifyAttendance, "Modificar asistencias");
            toolTip.SetToolTip(btnExcel, "Exportar a Excel");
            toolTip.SetToolTip(btnOpenFrmAttendanceType, "Abrir el catálogo de tipos de asistencia");
            toolTip.SetToolTip(txbLastDays, "Sin listado: solo empleados con importe en los últimos X días. Vacío = sin ese límite");
            toolTip.SetToolTip(gripEmployeesResize, "Arrastra para cambiar el alto del listado de empleados");

            gripEmployeesResize.DragStarted += gripEmployeesResize_DragStarted;
            gripEmployeesResize.DragMoved += gripEmployeesResize_DragMoved;
            gripEmployeesResize.DragEnded += gripEmployeesResize_DragEnded;
            UpdateEmployeesMinExpButton();
        }

        /// <summary>Evita que los scrolls "salten" solos al enfocar un control (solo se mueven con el usuario).</summary>
        protected override System.Drawing.Point ScrollToControl(Control activeControl)
            => DisplayRectangle.Location;

        private void FrmAsistenciaASConsulta_Load(object sender, EventArgs e)
        {
            // Debe ir antes de cualquier cambio de alto: toma las separaciones ya escaladas por el DPI.
            CaptureEmployeesLayout();
            cls.BeginFormCat();
        }

        // ── Panel de empleados: minimizar / expandir y cambiar su alto ───────────

        /// <summary>Alto del panel de empleados cuando está minimizado (px lógicos a 96 dpi).</summary>
        private const int EmployeesCollapsedLogicalHeight = 160;
        /// <summary>Alto mínimo que se le deja al grid del reporte al agrandar el panel de empleados.</summary>
        private const int ReportGridMinLogicalHeight = 120;

        private bool _employeesLayoutCaptured;
        private bool _employeesCollapsed;
        private int _employeesExpandedHeight;
        private int _employeesCollapsedHeight;
        private int _dragStartHeight;

        /// <summary>Guarda las alturas de referencia (ya escaladas por el DPI) del panel de empleados.</summary>
        private void CaptureEmployeesLayout()
        {
            if (_employeesLayoutCaptured) return;
            _employeesLayoutCaptured = true;

            _employeesExpandedHeight = pnlCardEmployees.Height;
            _employeesCollapsedHeight = LogicalToDeviceUnits(EmployeesCollapsedLogicalHeight);
        }

        /// <summary>Alto máximo del panel de empleados sin dejar al grid del reporte sin espacio.</summary>
        private int MaxEmployeesCardHeight()
        {
            int max = pnlCardEmployees.Height + pnlGrid.Height - LogicalToDeviceUnits(ReportGridMinLogicalHeight);
            return Math.Max(_employeesCollapsedHeight, max);
        }

        /// <summary>
        /// Cambia el alto del panel de empleados. Todo lo que está debajo se recorre la misma diferencia y el grid
        /// del reporte absorbe el cambio (conserva su margen inferior actual, sea cual sea el tamaño de la ventana).
        /// </summary>
        private void ApplyEmployeesCardHeight(int height)
        {
            CaptureEmployeesLayout();
            height = Math.Max(_employeesCollapsedHeight, Math.Min(height, MaxEmployeesCardHeight()));

            int delta = height - pnlCardEmployees.Height;
            if (delta == 0) return;

            // Se congela el dibujo mientras se mueven las tarjetas y se repinta todo de una sola vez al final:
            // así no quedan "fantasmas" de los controles movidos (Windows copia los píxeles al reposicionar).
            bool freeze = IsHandleCreated && Visible;
            if (freeze) SendMessage(Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);

            SuspendLayout();
            try
            {
                pnlCardEmployees.Height = height;
                pnlCardDates.Top += delta;
                pnlCardView.Top += delta;
                pnlCardActions.Top += delta;
                pnlEmployeeAdvice.Top += delta;
                pgrReport.Top += delta;
                pnlGrid.SetBounds(pnlGrid.Left, pnlGrid.Top + delta, pnlGrid.Width, pnlGrid.Height - delta);
            }
            finally
            {
                ResumeLayout(true);
                if (freeze)
                {
                    SendMessage(Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
                    RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
                        RDW_INVALIDATE | RDW_ERASE | RDW_ALLCHILDREN | RDW_UPDATENOW);
                }
            }
        }

        private const int WM_SETREDRAW = 0x000B;
        private const uint RDW_INVALIDATE = 0x0001;
        private const uint RDW_ERASE = 0x0004;
        private const uint RDW_ALLCHILDREN = 0x0080;
        private const uint RDW_UPDATENOW = 0x0100;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);
        /// <summary>Minimiza (alto fijo de 160 px) o restaura el panel de empleados al alto que el usuario había dejado.</summary>
        internal void SetEmployeesCollapsed(bool collapsed)
        {
            CaptureEmployeesLayout();

            if (collapsed)
            {
                if (!_employeesCollapsed && pnlCardEmployees.Height > _employeesCollapsedHeight)
                    _employeesExpandedHeight = pnlCardEmployees.Height;
                _employeesCollapsed = true;
                ApplyEmployeesCardHeight(_employeesCollapsedHeight);
            }
            else
            {
                _employeesCollapsed = false;
                ApplyEmployeesCardHeight(Math.Max(_employeesExpandedHeight, _employeesCollapsedHeight + LogicalToDeviceUnits(40)));
            }

            UpdateEmployeesMinExpButton();
        }

        /// <summary>Minimiza el panel de empleados (lo usa "Cargar" al terminar de cargar datos).</summary>
        internal void CollapseEmployeesPanel() => SetEmployeesCollapsed(true);

        private void UpdateEmployeesMinExpButton()
        {
            btnEmployeesMinExp.IconSvg = _employeesCollapsed ? AntdIcons.Expand : AntdIcons.Compress;
            toolTip.SetToolTip(btnEmployeesMinExp,
                _employeesCollapsed ? "Expandir el listado de empleados" : "Minimizar el listado de empleados");
        }

        private void btnEmployeesMinExp_Click(object sender, EventArgs e)
        {
            SetEmployeesCollapsed(!_employeesCollapsed);
        }

        private void gripEmployeesResize_DragStarted(object? sender, EventArgs e)
        {
            CaptureEmployeesLayout();
            _dragStartHeight = pnlCardEmployees.Height;
            _pendingDragHeight = _dragStartHeight;
        }

        private long _lastDragApplyTick;
        private int _pendingDragHeight;

        private void gripEmployeesResize_DragMoved(object? sender, int deltaY)
        {
            _pendingDragHeight = Math.Max(_employeesCollapsedHeight, Math.Min(_dragStartHeight + deltaY, MaxEmployeesCardHeight()));

            // Limita la frecuencia (~40 repintados por segundo): el último alto pedido se aplica al soltar.
            long now = Environment.TickCount64;
            if (now - _lastDragApplyTick < 25) return;
            _lastDragApplyTick = now;

            if (_pendingDragHeight != pnlCardEmployees.Height)
                ApplyEmployeesCardHeight(_pendingDragHeight);
        }

        private void gripEmployeesResize_DragEnded(object? sender, EventArgs e)
        {
            if (_pendingDragHeight != pnlCardEmployees.Height && _pendingDragHeight >= _employeesCollapsedHeight)
                ApplyEmployeesCardHeight(_pendingDragHeight);

            // Arrastrado hasta el mínimo = minimizado; cualquier otro alto es el nuevo alto "expandido".
            if (pnlCardEmployees.Height <= _employeesCollapsedHeight + 2)
            {
                _employeesCollapsed = true;
            }
            else
            {
                _employeesCollapsed = false;
                _employeesExpandedHeight = pnlCardEmployees.Height;
            }

            UpdateEmployeesMinExpButton();
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            cls.BtnSearchEmployee();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            cls.BtnAddEmployee();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            cls.BtnAddList();
        }

        private void btnAddNomWorkGroup_Click(object sender, EventArgs e)
        {
            cls.BtnAddNomWorkGroup();
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            cls.BtnClearList();
        }

        private void chbShowReport_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbShowReport_CheckedChanged();
        }

        private void chbShowReportCalendar_CheckedChanged(object sender, EventArgs e)
        {
            cls.ChbShowReportCalendar_CheckedChanged();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            cls.BtnLoadReport();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            cls.BtnGenerateExcelReport();
        }

        private void btnModifyAttendance_Click(object sender, EventArgs e)
        {
            cls.BtnModifyAttendance();
        }

        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            cls.DgvReport_CellFormatting(sender, e);
        }

        private void dgvReport_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            cls.DgvReport_CellToolTipTextNeeded(sender, e);
        }

        private void dgvReport_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            cls.DgvReport_CellPainting(sender, e);
        }

        // ── Grid del listado de empleados (independiente de los grids del reporte) ──

        private void dgvEmployees_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            cls.DgvEmployees_CellPainting(sender, e);
        }

        private void dgvEmployees_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cls.DgvEmployees_ColumnHeaderMouseClick(sender, e);
        }

        private void dgvEmployees_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            cls.DgvEmployees_CurrentCellDirtyStateChanged(sender, e);
        }

        private void dgvEmployees_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cls.DgvEmployees_CellValueChanged(sender, e);
        }

        private void dgvReport_SelectionChanged(object sender, EventArgs e)
        {
            cls.DgvReport_SelectionChanged();
        }

        private void txbIdEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                cls.BtnAddEmployee();
                return;
            }

            // Ctrl+V / Shift+Insert: forzar pegado como texto plano (sin formato de Excel).
            if ((e.Control && e.KeyCode == Keys.V) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                e.SuppressKeyPress = true;
                cls.PasteEmployeeCodesAsPlainText();
            }
        }

        private void btnOpenFrmAttendanceType_Click(object sender, EventArgs e)
        {
            if (!User.HasViewCatalogsPermission())
                return;

            Nom_AttendanceType.FrmAttendanceTypeCat frm = new();
            FrmMenu.FrmMenuInstance.AbrirVentanaHijo(frm);
        }

        private void cmsIdEmployee_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiUndo.Enabled = txbIdEmployee.CanUndo;
            tsmiCut.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiCopy.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiPaste.Enabled = Clipboard.ContainsText();
            tsmiDelete.Enabled = txbIdEmployee.SelectionLength > 0;
            tsmiSelectAll.Enabled = txbIdEmployee.TextLength > 0;
        }

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Undo();
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Cut();
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            txbIdEmployee.Copy();
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            cls.PasteEmployeeCodesAsPlainText();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            txbIdEmployee.SelectedText = string.Empty;
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            txbIdEmployee.SelectAll();
        }

        /// <summary>
        /// Bloquea filtros, botones y cambios de vista mientras hay una carga en curso,
        /// para que Application.DoEvents de la barra de progreso no reentre en esas acciones.
        /// </summary>
        internal void SetOperationBusy(bool busy)
        {
            bool enabled = !busy;
            // Filtros (antes gpbFilters). cboAttendenceType no se toca: siempre está deshabilitado.
            foreach (Control filter in new Control[]
            {
                btnSearchEmployee, pnlEmployeeInput, btnAddEmployee,
                cboLP, btnAddList, cboNomWorkGroup, btnAddNomWorkGroup,
                cboAgriculturalCycle, cboSeason, cboWeek1, cboWeek2, dtpDate1, dtpDate2
            })
                filter.Enabled = enabled;

            // Opciones del reporte (antes bgpInfo).
            pnlLastDaysInput.Enabled = enabled;
            btnLoadReport.Enabled = enabled;

            btnClearList.Enabled = enabled;
            chbShowReport.Enabled = enabled;
            chbShowReportCalendar.Enabled = enabled;
            btnExcel.Enabled = enabled;
            btnModifyAttendance.Enabled = enabled;
            btnOpenFrmAttendanceType.Enabled = enabled;
        }

        /// <summary>
        /// Cursor de espera. Hay que restaurar también <see cref="Cursor.Current"/> y el del MDI:
        /// si no, tras Application.DoEvents el reloj se queda pegado aunque el formulario ya haya terminado.
        /// </summary>
        internal void SetWaitCursor(bool wait)
        {
            UseWaitCursor = wait;
            Cursor = wait ? Cursors.WaitCursor : Cursors.Default;
            Application.UseWaitCursor = wait;
            Cursor.Current = wait ? Cursors.WaitCursor : Cursors.Default;

            dgvReport.UseWaitCursor = wait;
            dgvEmployees.UseWaitCursor = wait;
            if (!wait)
            {
                dgvReport.Cursor = Cursors.Default;
                dgvEmployees.Cursor = Cursors.Default;
            }

            if (MdiParent != null)
            {
                MdiParent.UseWaitCursor = wait;
                if (!wait)
                    MdiParent.Cursor = Cursors.Default;
            }
        }
    }
}
