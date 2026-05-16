using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace IP_Adress
{
    public static class InlineBinding
    {
        public static readonly DependencyProperty InlinesProperty =
            DependencyProperty.RegisterAttached(
                "Inlines",
                typeof(Inline),
                typeof(InlineBinding),
                new PropertyMetadata(null, OnInlinesChanged));

        public static void SetInlines(DependencyObject obj, Inline value)
        {
            obj.SetValue(InlinesProperty, value);
        }

        public static Inline GetInlines(DependencyObject obj)
        {
            return (Inline)obj.GetValue(InlinesProperty);
        }

        private static void OnInlinesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlock tb)
            {
                tb.Inlines.Clear();
                if (e.NewValue is Inline inline)
                    tb.Inlines.Add(inline);
            }
        }
    }
}
