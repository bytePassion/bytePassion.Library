namespace bytePassion.Lib.Communication.State
{
	public interface ISharedStateWriteOnly<in T>
    {
        T Value { set; }
    }
}