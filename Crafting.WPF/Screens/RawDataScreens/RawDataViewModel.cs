using Crafting.WPF.Screens.RawDataScreens.ReagentScreen;
using Crafting.WPF.Screens.RawDataScreens.VialScreen;
using Crafting.WPF.Utilties;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crafting.WPF.Screens.RawDataScreens
{
    public class RawDataViewModel : ViewModelBase
    {
        private void Navigate(Page page)
        {
            ApplicationViewModel.TopLevelViewModel.CurrentPage = page;
        }

        /// <summary>
        /// Reagent navigation
        /// </summary>
        private ICommand _reagentNavigationCommand;

        public ICommand ReagentNavigationCommand
        {
            get
            {
                if (_reagentNavigationCommand == null)
                {
                    _reagentNavigationCommand = new RelayCommand(
                        p => this.Navigate(new ReagentPage()));
                }

                return _reagentNavigationCommand;
            }
        }

        private ICommand _vialNavigationCommand;

        public ICommand VialNavigationCommand
        {
            get
            {
                if (_vialNavigationCommand == null)
                {
                    _vialNavigationCommand = new RelayCommand(
                        p => this.Navigate(new VialPage()));
                }

                return _vialNavigationCommand;
            }
        }
    }
}