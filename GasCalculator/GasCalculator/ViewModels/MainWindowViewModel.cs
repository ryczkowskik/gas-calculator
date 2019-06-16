using GasCalculator.Commanding;
using GasCalculator.Entities;
using GasCalculator.Storage;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GasCalculator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            using (var db = new DataContext())
            {
                GasList = db.Gases.ToList();
            }
            SelectedGas = GasList.FirstOrDefault();
            CalculateValueCommand = new DelegateCommand(OnCalculateValue);
        }

        public List<Gas> GasList { get; private set; }

        private Gas _selectedGas;
        public Gas SelectedGas
        {
            get
            {
                return _selectedGas;
            }
            set
            {
                _selectedGas = value;
                RaisePropertyChanged();
            }
        }

        private decimal _value;
        public decimal Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        private decimal _result;
        public decimal Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        private decimal _factor;
        public decimal Factor
        {
            get
            {
                return _factor;
            }
            set
            {
                _factor = value;
                RaisePropertyChanged();
            }
        }

        private decimal _dgw;
        public decimal DGW
        {
            get
            {
                return _dgw;
            }
            set
            {
                _dgw = value;
                RaisePropertyChanged();
            }
        }

        private decimal _ggw;
        public decimal GGW
        {
            get
            {
                return _ggw;
            }
            set
            {
                _ggw = value;
                RaisePropertyChanged();
            }
        }

        private decimal _consistency;
        public decimal Consistency
        {
            get
            {
                return _consistency;
            }
            set
            {
                _consistency = value;
                RaisePropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand CalculateValueCommand { get; private set; }

        private void OnCalculateValue(object param)
        {
            Factor = _selectedGas.Factor;
            Result = _selectedGas.Factor * _value;
            DGW = _selectedGas.DGW;
            GGW = _selectedGas.GGW;
            Consistency = _selectedGas.Consistency;
            Description = _selectedGas.Description;
        }
    }
}
