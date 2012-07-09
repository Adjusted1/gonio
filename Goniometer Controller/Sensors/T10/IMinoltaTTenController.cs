using System;
using System.ComponentModel;

namespace Goniometer_Controller.Sensors
{
    public interface IMinoltaTTenController : INotifyPropertyChanged
    {
        double reading { get; }
        string status { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
