using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Shiny;
using Shiny.Net;

namespace Playground.Forms.ViewModels
{
    public abstract partial class ViewModelBase : ReactiveObject, IApplicationLifecycleAware, IConfirmNavigation,
        IConfirmNavigationAsync, IDestructible, IInitialize, IInitializeAsync, INavigationAware, IPageLifecycleAware
    {
        protected readonly INavigationService NavigationService;
        protected readonly IConnectivity ConnectivityService;

        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            ConnectivityService = ShinyHost.Resolve<IConnectivity>();
            Disposables = new CompositeDisposable();
            // Get internet status
            ConnectivityService.WhenInternetStatusChanged()
                .ToPropertyEx(this, x => x.IsOnline)
                .DisposeWith(Disposables);
            // Set IsBusy to true while BusyCounter > 0 (handling parallelism)
            this.WhenAnyValue(x => x.BusyCounter)
                .Select(busyCounter => busyCounter > 0)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.IsBusy)
                .DisposeWith(Disposables);
        }

        [Reactive] public string Title { get; set; }
        [ObservableAsProperty] public bool IsOnline { get; }
        [ObservableAsProperty] public bool IsBusy { get; }
        [Reactive] protected int BusyCounter { get; set; }
        protected CompositeDisposable Disposables { get; private set; }

        protected virtual void HandleIsBusy(bool isBusy)
        {
            if (isBusy)
                BusyCounter++;
            else if (BusyCounter > 0)
                BusyCounter--;
        }

        public virtual void OnResume()
        {
        }

        public virtual void OnSleep()
        {
        }

        public virtual bool CanNavigate(INavigationParameters parameters)
        {
            return true;
        }

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return Task.FromResult(true);
        }

        public virtual void Destroy()
        {
            Disposables.Dispose();
            Disposables = null;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}
