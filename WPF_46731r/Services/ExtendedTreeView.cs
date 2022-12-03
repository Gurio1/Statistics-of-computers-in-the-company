using System.Windows;
using System.Windows.Controls;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;

namespace WPF_46731r.Services
{
    public class ExtendedTreeView : TreeView
    {
        public ExtendedTreeView()
            : base()
        {
            SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
        }

        void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem is Computer)
            {
                SetValue(SelectedComputer_Property, SelectedItem);
            }
            else if (SelectedItem is Building)
            {
                SetValue(SelectedBuilding_Property, SelectedItem);
            }
            else if (SelectedItem is Room)
            {
                SetValue(SelectedRoom_Property, SelectedItem);
            }
        }

        public object SelectedComputer_
        {
            get { return GetValue(SelectedComputer_Property); }
            set { SetValue(SelectedComputer_Property, value); }
        }
        public object SelectedBuilding_
        {
            get { return GetValue(SelectedComputer_Property); }
            set { SetValue(SelectedComputer_Property, value); }
        }
        public object SelectedRoom_
        {
            get { return GetValue(SelectedComputer_Property); }
            set { SetValue(SelectedComputer_Property, value); }
        }
        public static readonly DependencyProperty SelectedComputer_Property = DependencyProperty.Register("SelectedComputer_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SelectedBuilding_Property = DependencyProperty.Register("SelectedBuilding_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
        public static readonly DependencyProperty SelectedRoom_Property = DependencyProperty.Register("SelectedRoom_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
}
