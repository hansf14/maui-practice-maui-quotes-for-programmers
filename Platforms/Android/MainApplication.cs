using Android.App;
using Android.Runtime;

namespace maui_quotes_for_programmers
{
  [Application]
  public class MainApplication : MauiApplication
  {
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
      : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
  }
}
