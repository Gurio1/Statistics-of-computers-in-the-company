﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_46731r.Domain.Models.Computer;

namespace WPF_46731r.ViewModels
{
    public class TreeViewModelDetails : ViewModelBase
    {
        private Computer _item;

        public Computer Item { get => _item; set { _item = value; OnPropretyChanged(nameof(Item)); } }
    }
}
