using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingNotification
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) 
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                // Notify the View of a property change
                OnPropertyChanged(nameof(Number3)); 
            }
        }

        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                OnPropertyChanged(nameof(Number3));
            }
        }

        // The property is read-only. Updates every time you change the properties number1 and number2
        public int Number3 
        {
            get { return Model.SumOf(Number1, Number2); } 
        } 
    }
}
