using System;
using System.ComponentModel;

namespace Goniometer_Controller.Sensors
{
    public interface IMinoltaT10Controller : INotifyPropertyChanged
    {
        double reading { get; }
        string status { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
