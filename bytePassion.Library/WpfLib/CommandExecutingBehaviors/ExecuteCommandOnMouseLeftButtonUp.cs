using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace bytePassion.Lib.WpfLib.CommandExecutingBehaviors
{
	public class ExecuteCommandOnMouseLeftButtonUp : Behavior<FrameworkElement>
    {
		public static readonly DependencyProperty CommandProperty = 
			DependencyProperty.Register(nameof(Command),
									   typeof(ICommand),
									   typeof(ExecuteCommandOnMouseLeftButtonUp));

		public static readonly DependencyProperty CommandParameterProperty = 
			DependencyProperty.Register(nameof(CommandParameter),
										typeof(object),
										typeof(ExecuteCommandOnMouseLeftButtonUp));

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
			AssociatedObject.PreviewMouseLeftButtonUp   += OnMouseLeftButtonUp;
		}

		protected override void OnDetaching ()
		{
			base.OnAttached();
			AssociatedObject.PreviewMouseLeftButtonDown -= OnMouseLeftButtonDown;
			AssociatedObject.PreviewMouseLeftButtonUp   -= OnMouseLeftButtonUp;
		}

	    private bool activated = false;
	  
	    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
		    if (activated)		    
			    if (Command != null)
				    if (Command.CanExecute(CommandParameter))
					    Command.Execute(CommandParameter);

		    activated = false;
	    }	   

	    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
		    activated = true;
	    }	    
    }
}
