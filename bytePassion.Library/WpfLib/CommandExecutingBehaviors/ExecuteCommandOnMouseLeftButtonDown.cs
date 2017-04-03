using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace bytePassion.Lib.WpfLib.CommandExecutingBehaviors
{
	public class ExecuteCommandOnMouseLeftButtonDown : Behavior<FrameworkElement>
    {
		public static readonly DependencyProperty CommandProperty = 
			DependencyProperty.Register(nameof(Command),
									   typeof(ICommand),
									   typeof(ExecuteCommandOnMouseLeftButtonDown));

		public static readonly DependencyProperty CommandParameterProperty = 
			DependencyProperty.Register(nameof(CommandParameter),
										typeof(object),
										typeof(ExecuteCommandOnMouseLeftButtonDown));

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
			AssociatedObject.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
			
		}

		protected override void OnDetaching ()
		{
			base.OnAttached();
			AssociatedObject.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDown;
			
		}
	    
	    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
			if (Command != null)
				if (Command.CanExecute(CommandParameter))
					Command.Execute(CommandParameter);
		}	    
    }
}
