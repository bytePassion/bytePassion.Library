using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;


namespace bytePassion.Lib.WpfLib.CommandExecutingBehaviors
{
	public class ExecuteCommandOnRightClickBehavior : Behavior<FrameworkElement>
	{

		public static readonly DependencyProperty CommandProperty 
			= DependencyProperty.Register(nameof(Command), 
										  typeof (ICommand), 
										  typeof (ExecuteCommandOnRightClickBehavior));
		
		public static readonly DependencyProperty CommandParameterProperty 
			= DependencyProperty.Register(nameof(CommandParameter), 
										  typeof (object), 
										  typeof (ExecuteCommandOnRightClickBehavior));

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand) GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		protected override void OnAttached()
		{
			base.OnAttached();

			AssociatedObject.MouseRightButtonDown += OnMouseDown;
			AssociatedObject.MouseLeave           += OnMouseLeave;
			AssociatedObject.MouseRightButtonUp   += OnMouseUp;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			AssociatedObject.MouseRightButtonDown -= OnMouseDown;
			AssociatedObject.MouseLeave           -= OnMouseLeave;
			AssociatedObject.MouseRightButtonUp   -= OnMouseUp;
		}

		private bool possibleExecution = false;

		private void OnMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			if (possibleExecution)
			{
				possibleExecution = false;

				if (Command != null)
					if (Command.CanExecute(CommandParameter))
						Command.Execute(CommandParameter);
			}
		}

		private void OnMouseLeave(object sender, MouseEventArgs mouseEventArgs)
		{
			possibleExecution = false;
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
		{
			possibleExecution = true;
		}		
	}
}
