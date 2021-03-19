namespace Unity.Build.Android.Classic
{
    sealed class AndroidRunInstance : IRunInstance
    {
        public bool IsRunning => true;

        public AndroidRunInstance()
        {
        }

        public void Dispose()
        {
        }
    }
}
