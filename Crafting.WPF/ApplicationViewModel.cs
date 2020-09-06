using Crafting.WPF.Screens.MainScreen;
using Crafting.WPF.Screens.RawDataScreens;
using Crafting.WPF.Utilties;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crafting.WPF
{
    public class ApplicationViewModel : ViewModelBase
    {
        public static ApplicationViewModel TopLevelViewModel { get; set; }

        public ApplicationViewModel()
        {
            TopLevelViewModel = this;
            this.CurrentPage = new MainPage();
        }

        private Page _currentPage;

        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                base.RaisePropertyChanged();
            }
        }

        #region Navigation

        private void ExecuteNavigationCommand(Page page)
        {
            this.CurrentPage = page ?? throw new System.ArgumentNullException(nameof(page));
        }

        private ICommand _rawDataNavigationCommand;

        public ICommand RawDataNavigationCommand
        {
            get
            {
                if (_rawDataNavigationCommand == null)
                {
                    _rawDataNavigationCommand = new RelayCommand(
                        p => this.ExecuteNavigationCommand(new RawDataPage()));
                }

                return _rawDataNavigationCommand;
            }
        }

        #endregion Navigation
    }
}