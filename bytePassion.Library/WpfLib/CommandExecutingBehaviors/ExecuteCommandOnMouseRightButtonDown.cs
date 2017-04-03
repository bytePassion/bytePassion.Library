using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace bytePassion.Lib.WpfLib.CommandExecutingBehaviors
{
	public class ExecuteCommandOnMouseRightButtonDown : Behavior<FrameworkElement>
    {
		public static readonly DependencyProperty CommandProperty = 
			DependencyProperty.Register(nameof(Command),
									   typeof(ICommand),
									   typeof(ExecuteCommandOnMouseRightButtonDown));

		public static readonly DependencyProperty CommandParameterProperty = 
			DependencyProperty.Register(nameof(CommandParameter),
										typeof(object),
										typeof(ExecuteCommandOnMouseRightButtonDown));

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		protected override void OnAttached ()
		{
			base.OnAttached();
			AssociatedObject.PreviewMouseRightButtonDown += OnMouseRightButtonDown;
			
		}

		protected override void OnDetaching ()
		{
			base.OnAttached();
			AssociatedObject.PreviewMouseRightButtonDown -= OnMouseRightButtonDown;
			
		}
	    
	    private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
			if (Command != null)
				if (Command.CanExecute(CommandParameter))
					Command.Execute(CommandParameter);
		}	    
    }
}
