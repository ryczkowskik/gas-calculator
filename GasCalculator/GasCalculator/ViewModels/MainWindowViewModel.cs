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
    /// <summary>
    /// ViewModel dla widoku głównego
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainWindowViewModel()
        {
            using (var db = new DataContext())
            {
                GasList = db.Gases.ToList();
            }
            SelectedGas = GasList.FirstOrDefault();
            CalculateValueCommand = new DelegateCommand(OnCalculateValue);
        }

        /// <summary>
        /// Lista wszystkich gazów dla który możemy obliczyć wartość
        /// </summary>
        public List<Gas> GasList { get; private set; }

        private Gas _selectedGas;

        /// <summary>
        /// Wybrany gaz z listy GasList
        /// </summary>
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

        /// <summary>
        /// Wartość pomiaru
        /// </summary>
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

        /// <summary>
        /// Wynik mnożenia wartości pomiaru i przelicznika dla wybranego gazu
        /// </summary>
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

        /// <summary>
        /// Przelicznik dla wybranego gazu
        /// </summary>
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

        /// <summary>
        /// DGW wybranego gazu
        /// </summary>
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

        /// <summary>
        /// GGW wybranego gazu
        /// </summary>
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

        /// <summary>
        /// Gęstość wybranego gazu
        /// </summary>
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

        /// <summary>
        /// Charakterystyka wybranego gazu
        /// </summary>
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

        /// <summary>
        /// Polecenie obliczające wartość gazu oraz ustawiające odpowiednio właściwości
        /// </summary>
        public ICommand CalculateValueCommand { get; private set; }

      
        /// <summary>
        /// Zdarzenie mające miejsce podczas zmiany wartości którejś z właściwości
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            // Sprawdzenie, czy handler PropertyChanged posiada przypisaną wartość
            if (PropertyChanged != null)
            {
                // Wywołanie handlera PropertyChanged, przekazując nazwę zmiennej,
                // która wywołała to zdarzenie
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Obliczenie wartości gazu, po zmianie jego parametru
        /// </summary>
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
