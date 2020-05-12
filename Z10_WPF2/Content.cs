using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z10_WPF2
{
    public class Content : INotifyPropertyChanged
    {
        private string _content;

        public string Path { get; set; }
        public string ContentText
        {
            get { return _content; }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
