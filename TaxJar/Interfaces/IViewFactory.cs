using System;
using Xamarin.Forms;

namespace TaxJar.Interfaces
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;

        void RegisterView<TViewModel, TView>() where TViewModel : class, IViewModel where TView : View;

        Page Resolve<TViewModel>() where TViewModel : class, IViewModel;

        Page ResolvePage<TViewModel>() where TViewModel : class, IViewModel;

        View ResolveView<TViewModel>() where TViewModel : class, IViewModel;

        TViewModel ResolveViewModel<TViewModel>() where TViewModel : class, IViewModel;
    }
}
