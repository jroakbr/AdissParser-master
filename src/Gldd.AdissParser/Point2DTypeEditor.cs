using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Gldd.AdissParser
{
    public class Point2DTypeEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem)
        {
            TextBox textBox = new PropertyGridEditorTextBox();
            var binding = new Binding(nameof(PropertyItem.Value));
            binding.Converter = new Point2DValueConverter();
            BindingOperations.SetBinding(textBox, TextBox.TextProperty, binding);
            return textBox;
        }
    }
}
