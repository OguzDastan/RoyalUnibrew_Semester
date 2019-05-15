using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OverviewList : INotifyPropertyChanged
    {
        private string _arktype;
        private string _title;
        private string _controller;
        private bool _isChecked;

        public OverviewList(string arktype, string title)
        {
            _arktype = arktype;
            _title = title;
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        public string ArkType
        {
            get { return _arktype; }
            set { _arktype = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Controller
        {
            get { return _controller; }
            set
            {
                _controller = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("title:");
            sb.Append(Title);
            sb.Append("\n");
            sb.Append("kontrol:");
            sb.Append(Controller);
            return sb.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
