using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Silly.UI.Behaviors
{
    public class KeyboardBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.PreviewKeyDown += OnTextboxKeydown;
            this.AssociatedObject.PreviewMouseDown += OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(AssociatedObject);
            var charIndex = AssociatedObject.GetCharacterIndexFromPoint(point, false);
            if (charIndex == -1)
                return;
            var clickedLineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(charIndex);
            var actualLineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(AssociatedObject.CaretIndex);

            if (clickedLineIndex == actualLineIndex)
            {
                return;
            }

            e.Handled = true;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.PreviewKeyDown -= OnTextboxKeydown;
        }

        private void OnTextboxKeydown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                case Key.Down:
                    e.Handled = true;
                    break;
                case Key.Left:
                    var lineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(AssociatedObject.CaretIndex);
                    var previousLineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(AssociatedObject.CaretIndex - 1);
                    if (lineIndex != previousLineIndex)
                    {
                        e.Handled = true;
                    }
                    break;
            }
        }
    }
}
