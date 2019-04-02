using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemberWiseCloneTest
{

    public class TestValue : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _a;
        public int a
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged();
            }
        }

        private bool _b;
        public bool b
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged();
            }
        }

        public TestValue Clone()
        {
            var tvalue = (TestValue)MemberwiseClone();
            //var tvalue = new TestValue();
            //tvalue.a = a;
            //tvalue.b = b;
            return tvalue;
        }
    }
}
