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
            progressControl.TestCompleted += new EventHandler(progressControl_TestCompleted);
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
            if (!setupControl.IsValid())
                return;

            //pass values to other tab
            progressControl.EmailNotifications = setupControl.EmailNotifications;
            progressControl.Email              = setupControl.Email;
            progressControl.DataFolder         = setupControl.DataFolder;

            //iesna report values
            progressControl.TestName     = setupControl.TestName;
            progressControl.Manufacturer = setupControl.Manufacturer;
            progressControl.Model        = setupControl.Model;
            progressControl.Wattage      = setupControl.Wattage;
            progressControl.Length       = setupControl.Length;
            progressControl.Width        = setupControl.Width;
            progressControl.Height       = setupControl.Height;

            //running values
            double[] hRange      = setupControl.CalculateHorizontalRange();
            double[] vRange      = setupControl.CalculateVerticalRange();
            double[] hStrayRange = setupControl.CalculateStrayHorizontalRange();
            double[] vStrayRange = setupControl.CalculateStrayVerticalRange();

            double kCal     = setupControl.KCal;
            double kTheta   = setupControl.KTheta;
            double distance = setupControl.Distance;
            
            //fetch a list of active sensors
            var sensors = setupControl.GetSensors();
            
            //start test
            progressControl.BeginTestAsync(sensors, hRange, vRange, hStrayRange, vStrayRange, kCal, kTheta, distance);
            wizard.SelectedTab = tabProgress;
        }

        #region setup values
        public double HorizontalResolution
        {
            get { return setupControl.HorizontalResolution; }
        }

        public double HorizontalStrayResolution
        {
            get { return setupControl.HorizontalStrayResolution; }
        }

        public double VerticalResolution
        {
            get { return setupControl.VerticalResolution; }
        }

        public double VerticalStrayResolution
        {
            get { return setupControl.VerticalStrayResolution; }
        }

        public VerticalSymmetryEnum VerticalSymmetry
        {
            get { return setupControl.VerticalSymmetry; }
        }

        public HorizontalSymmetryEnum HorizontalSymmetry
        {
            get { return setupControl.HorizontalSymmetry; }
        }
        #endregion
        #endregion

        #region progresss page
        private void btnCancel_Click(object sender, EventArgs e)
        {
            progressControl.CancelTestAsync();

            //pass values to other tab
            setupControl.EmailNotifications = progressControl.EmailNotifications;
            setupControl.Email              = progressControl.Email;

            wizard.SelectedTab = tabCompletion;
        }

        private bool paused = false;
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (paused)
            {
                btnPause.Text = "Pause";
                paused = false;
                progressControl.PauseTestAsync();
            }
            else
            {
                btnPause.Text = "Unpause";
                paused = true;
                progressControl.UnpauseTestAsync();
            }
        }

        private void progressControl_TestCompleted(object sender, EventArgs e)
        {
            wizard.SelectedTab = tabCompletion;

            //this is where report generation should occur
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
