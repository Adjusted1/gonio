using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Goniometer.Functions;

using Goniometer_Controller;
using Goniometer_Controller.Motors;
using Goniometer_Controller.Sensors;

namespace Goniometer.Tests.IESNA
{
    public partial class LumenTestControl : UserControl, INotifyPropertyChanged
    {
        public LumenTestControl()
        {
            InitializeComponent();
        }

        private void LumenTestControl_Load(object sender, EventArgs e)
        {
            setupControl.PropertyChanged += new PropertyChangedEventHandler(setupControl_PropertyChanged);
        }

        #region setup page
        private void btnBack_Click(object sender, EventArgs e)
        {
            var notify = OnExit;
            if (notify != null)
                notify(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!setupControl.Validate())
                return;

            //pass values to other tab
            progressControl.chkEmail.Checked = setupControl.chkEmail.Checked;
            progressControl.txtEmail.Text    = setupControl.txtEmail.Text;

            double[] hRange =          setupControl.CalculateHorizontalRange();
            double[] vRange =          setupControl.CalculateVerticalRange();
            double[] hStrayRange =     setupControl.CalculateStrayHorizontalRange();
            double[] vStrayRange =     setupControl.CalculateStrayVerticalRange();
            MinoltaBaseSensor sensor = setupControl.Sensor;
            
            //start test
            progressControl.BeginTestAsync(setupControl.Sensor, hRange, vRange, hStrayRange, vStrayRange, 1);
            wizard.SelectedTab = tabProgress;
        }

        #region setup values
        public double? horizontalResolution
        {
            get
            {
                return setupControl.horizontalResolution;
            }
        }

        public double? horizontalStrayResolution
        {
            get
            {
                return setupControl.horizontalStrayResolution;
            }
        }

        public double? verticalResolution
        {
            get
            {
                return setupControl.verticalResolution;
            }
        }

        public double? verticalStrayResolution
        {
            get
            {
                return setupControl.verticalStrayResolution;
            }
        }

        public VerticalSymmetryEnum? verticalSymmetry
        {
            get
            {
                return setupControl.verticalSymmetry;
            }
        }

        public HorizontalSymmetryEnum? horizontalSymmetry
        {
            get
            {
                return setupControl.horizontalSymmetry;
            }
        }
        #endregion
        #endregion

        #region progresss page
        private void btnCancel_Click(object sender, EventArgs e)
        {
            progressControl.CancelTestAsync();

            //pass values to other tab
            setupControl.chkEmail.Checked = progressControl.chkEmail.Checked;
            setupControl.txtEmail.Text    = progressControl.txtEmail.Text;

            wizard.SelectedTab = tabCompletion;
        }

        private bool paused = false;
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                btnPause.Text = "Pause";
                paused = false;
            }
            else
            {
                btnPause.Text = "Unpause";
                paused = true;
            }
        }
        #endregion

        #region completion page
        /// <summary>
        /// Called when the control signals that it is ready to be closed
        /// </summary>
        public event EventHandler OnExit;
        private void btnClose_Click(object sender, EventArgs e)
        {
            var notify = OnExit;
            if (notify != null)
                notify(sender, e);
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            var notify = PropertyChanged;
            if (notify != null)
            {
                notify(this, new PropertyChangedEventArgs(info));
            }
        }

        private void setupControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var notify = PropertyChanged;
            if (notify != null)
            {
                notify(sender, e);
            }
        }
        #endregion
    }
}
