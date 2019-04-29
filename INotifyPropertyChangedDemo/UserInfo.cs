using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace INotifyPropertyChangedDemo
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo : INotifyPropertyChanged
    {
        public string UserName { get; set; }

        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if(this.age!=value)
                {
                    this.age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
