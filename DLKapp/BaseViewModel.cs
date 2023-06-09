﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

/*
 * Parent class to all ViewModels. Implementing the PropertyChanged-EventHandler, the PropertyChanged-Event,
 * and the OnPropertyChanged-Function this way, saves writing alot of boilerplate code in the ViewModels.
 */

namespace DLKapp
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}

/*
Implementing fields using the BaseViewModel 

private <T> _varname;
public <T> Varname
{
    get
    {
        return _varname;
    }
    set
    {
        SetProperty(ref _varname, value);
    }
}
*/



