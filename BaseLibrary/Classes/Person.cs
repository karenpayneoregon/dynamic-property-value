using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BaseLibrary.Classes
{
    public class Person : INotifyPropertyChanged
    {
        private DateTime? _birthDate;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime CurrentDateTime { get; set; } = DateTime.Now;
        public string Age
            => BirthDate?.Age(CurrentDateTime).YearsMonthsDays;

        /// <summary>
        /// For teaching to show underlying properties of <see cref="Helpers.Age"/>
        /// </summary>
        private void ForClass()
        {
            //BirthDate?.Age(DateTime.Now).Minutes;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
