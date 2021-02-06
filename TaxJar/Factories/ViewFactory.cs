using System;
using System.Collections.Generic;
using Autofac;
using TaxJar.Interfaces;
using Xamarin.Forms;

namespace TaxJar.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly static Dictionary<Type, Type> map = new Dictionary<Type, Type>();
        private readonly IComponentContext componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        void IViewFactory.Register<TViewModel, TView>()
        {
            map[typeof(TViewModel)] = typeof(TView);
        }

        void IViewFactory.RegisterView<TViewModel, TView>()
        {
            map[typeof(TViewModel)] = typeof(TView);
        }

        Page IViewFactory.Resolve<TViewModel>()
        {
            TViewModel viewModel = componentContext.Resolve<TViewModel>();

            var viewType = map[typeof(TViewModel)];
            var view = componentContext.Resolve(viewType) as Page;

            view.BindingContext = viewModel;

            return view;
        }

        Page IViewFactory.ResolvePage<TViewModel>()
        {
            var viewType = map[typeof(TViewModel)];
            var view = componentContext.Resolve(viewType) as Page;

            return view;
        }

        View IViewFactory.ResolveView<TViewModel>()
        {
            var viewType = map[typeof(TViewModel)];
            var view = componentContext.Resolve(viewType) as View;

            return view;
        }
        
        TViewModel IViewFactory.ResolveViewModel<TViewModel>()
        {
            return componentContext.Resolve<TViewModel>();
        }
    }
}
