using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }

            if (e.Key == Key.Left)
            {
                var lineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(AssociatedObject.CaretIndex);
                var previousLineIndex = AssociatedObject.GetLineIndexFromCharacterIndex(AssociatedObject.CaretIndex - 1);
                if(lineIndex != previousLineIndex)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
