using System.Windows;

namespace bytePassion.Lib.Utils
{
	public interface IApplicationLifeCycle
	{ 
		void BuildAndStart(StartupEventArgs startupEventArgs);		
		void CleanUp(ExitEventArgs exitEventArgs);
	}
}
