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
            SetValue(SelectedItem_Property, SelectedItem);
        }

        public object SelectedItem_
        {
            get { return GetValue(SelectedItem_Property); }
            set { SetValue(SelectedItem_Property, value); }
        }

        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
    }
}
