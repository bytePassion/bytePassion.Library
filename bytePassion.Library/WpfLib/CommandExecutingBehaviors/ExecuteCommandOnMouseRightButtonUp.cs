using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace bytePassion.Lib.WpfLib.CommandExecutingBehaviors
{
	public class ExecuteCommandOnMouseRightButtonUp : Behavior<FrameworkElement>
    {
		public static readonly DependencyProperty CommandProperty = 
			DependencyProperty.Register(nameof(Command),
									   typeof(ICommand),
									   typeof(ExecuteCommandOnMouseRightButtonUp));

		public static readonly DependencyProperty CommandParameterProperty = 
			DependencyProperty.Register(nameof(CommandParameter),
										typeof(object),
										typeof(ExecuteCommandOnMouseRightButtonUp));

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
			AssociatedObject.PreviewMouseRightButtonUp   += OnMouseRightButtonUp;
		}

		protected override void OnDetaching ()
		{
			base.OnAttached();
			AssociatedObject.PreviewMouseRightButtonDown -= OnMouseRightButtonDown;
			AssociatedObject.PreviewMouseRightButtonUp   -= OnMouseRightButtonUp;
		}

	    private bool activated = false;
	  
	    private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
		    if (activated)		    
			    if (Command != null)
				    if (Command.CanExecute(CommandParameter))
					    Command.Execute(CommandParameter);

		    activated = false;
	    }	   

	    private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
	    {
		    activated = true;
	    }	    
    }
}
