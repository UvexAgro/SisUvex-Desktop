using System;
using System.Drawing;
using System.Windows.Forms;

namespace SisUvex.Cuadro_de_herramientas.Loading
{
    public partial class FormConfGrapeLoading : Form
    {
        private GrapeLoadingControl loading;
        private bool isLoadingValues = false;

        public FormConfGrapeLoading()
        {
            InitializeComponent();

            InitializeLoadingPreview();
            ConfigureControls();
            RegisterEvents();

            LoadMediumValues();
            ApplyValuesToLoading();
        }

        private void InitializeLoadingPreview()
        {
            loading = new GrapeLoadingControl();
            Controls.Add(loading);
        }

        private void ConfigureControls()
        {
            NumericUpDown[] ints =
            {
                domainUpDown1, domainUpDown2,
                dupLocationX, dupLocationY,
                domainUpDown3,
                domainUpDown4,
                domainUpDown5, domainUpDown6,
                domainUpDown7, domainUpDown8,
                nudLogoSizeX, nudLogoSizeY,
                nudLogoOffsetX, nudLogoOffsetY
            };

            foreach (var c in ints)
            {
                c.Minimum = -1000;
                c.Maximum = 2000;
                c.DecimalPlaces = 0;
                c.Increment = 1;
            }

            NumericUpDown[] floats =
            {
                domainUpDown9, domainUpDown10, domainUpDown11
            };

            foreach (var c in floats)
            {
                c.Minimum = -10;
                c.Maximum = 10;
                c.DecimalPlaces = 2;
                c.Increment = 0.05M;
            }
        }

        private void RegisterEvents()
        {
            Control[] controls =
            {
                domainUpDown1, domainUpDown2,
                dupLocationX, dupLocationY,
                domainUpDown3,
                domainUpDown4,
                domainUpDown5, domainUpDown6,
                domainUpDown7, domainUpDown8,
                domainUpDown9, domainUpDown10,
                domainUpDown11,
                nudLogoSizeX, nudLogoSizeY,
                nudLogoOffsetX, nudLogoOffsetY
            };

            foreach (Control c in controls)
            {
                if (c is NumericUpDown nud)
                    nud.ValueChanged += (_, __) =>
                    {
                        if (!isLoadingValues)
                            ApplyValuesToLoading();
                    };
            }
        }

        private void SetValues(
            int sizeX, int sizeY,
            int locX, int locY,
            float thickness, int speed,
            float cox, float coy,
            float lox, float loy,
            float lsx, float lsy, float rot,
            float logoX, float logoY,
            float logoOX, float logoOY
        )
        {
            isLoadingValues = true;

            domainUpDown2.Value = sizeX;
            domainUpDown1.Value = sizeY;

            dupLocationX.Value = locX;
            dupLocationY.Value = locY;

            domainUpDown3.Value = (decimal)thickness;
            domainUpDown4.Value = speed;

            domainUpDown6.Value = (decimal)cox;
            domainUpDown5.Value = (decimal)coy;

            domainUpDown8.Value = (decimal)lox;
            domainUpDown7.Value = (decimal)loy;

            domainUpDown9.Value = (decimal)lsx;
            domainUpDown10.Value = (decimal)lsy;
            domainUpDown11.Value = (decimal)rot;

            nudLogoSizeX.Value = (decimal)logoX;
            nudLogoSizeY.Value = (decimal)logoY;

            nudLogoOffsetX.Value = (decimal)logoOX;
            nudLogoOffsetY.Value = (decimal)logoOY;

            isLoadingValues = false;
        }

        private void ApplyValuesToLoading()
        {
            loading.Size = new Size(
                (int)domainUpDown2.Value,
                (int)domainUpDown1.Value
            );

            loading.Location = new Point(
                (int)dupLocationX.Value,
                (int)dupLocationY.Value
            );

            loading.RingThickness = (float)domainUpDown3.Value;
            loading.AnimationSpeed = (int)domainUpDown4.Value;

            loading.CenterOffset = new PointF(
                (float)domainUpDown6.Value,
                (float)domainUpDown5.Value
            );

            loading.LeafOffset = new PointF(
                (float)domainUpDown8.Value,
                (float)domainUpDown7.Value
            );

            loading.LeafScaleX = (float)domainUpDown9.Value;
            loading.LeafScaleY = (float)domainUpDown10.Value;
            loading.LeafRotation = (float)domainUpDown11.Value;

            loading.LogoSize = new SizeF(
                (float)nudLogoSizeX.Value,
                (float)nudLogoSizeY.Value
            );

            loading.LogoOffset = new PointF(
                (float)nudLogoOffsetX.Value,
                (float)nudLogoOffsetY.Value
            );

            loading.Invalidate();
        }

        private void LoadMediumValues()
        {
            SetValues(
                150, 150,
                600, 180,
                32, 4,
                0, 0,
                10, -15,
                1, 1, 0,
                120, 120,
                0, 0
            );
        }
        private void LoadVerySmallValues()
        {
            SetValues(
                70, 70,
                600, 180,
                16, 5,
                0, 0,
                -4, -4,
                0.75f, 0.75f, 0,
                45, 45,
                0, 0
            );
        }

        private void LoadSmallValues()
        {
            SetValues(
                100, 100,
                600, 180,
                22, 5,
                0, 0,
                -2, -3,
                0.85f, 0.85f, 0,
                75, 75,
                0, 0
            );
        }

        private void LoadLargeValues()
        {
            SetValues(
                230, 230,
                600, 180,
                42, 4,
                0, 0,
                2, -30,
                1.1f, 1.1f, 0,
                180, 180,
                0, 0
            );
        }

        private void LoadVeryLargeValues()
        {
            SetValues(
                330, 330,
                600, 180,
                55, 3,
                0, 0,
                4, 4,
                1.25f, 1.25f, 0,
                260, 260,
                0, 0
            );
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            LoadMediumValues();
            ApplyValuesToLoading();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadMediumValues();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ApplyValuesToLoading();
        }

        private void btnVerySmall_Click(object sender, EventArgs e)
        {
            LoadVerySmallValues();
            ApplyValuesToLoading();
        }

        private void btnSmall_Click(object sender, EventArgs e)
        {
            LoadSmallValues();
            ApplyValuesToLoading();
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {
            LoadLargeValues();
            ApplyValuesToLoading();
        }

        private void btnVeryLarge_Click(object sender, EventArgs e)
        {
            LoadVeryLargeValues();
            ApplyValuesToLoading();
        }
    }
}