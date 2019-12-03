using FieldsApp.Model;
using FieldsApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FieldsApp.Common
{

        public class DeleteCommand : ICommand
        {
            private StoresCatalog _catalog;
            private StoresViewModel _viewModel;

            public DeleteCommand(StoresCatalog catalog, StoresViewModel viewModel)
            {
                _catalog = catalog;
                _viewModel = viewModel;
            }
            public bool CanExecute(object parameter)
            {
                return _viewModel.SelectedStore != null;
            }

            public void Execute(object parameter)
            {
                // Delete from catalog
                _catalog.Delete(_viewModel.SelectedStore.Phone);
                // Set selection to null
                _viewModel.SelectedStore = null;
            }

            public void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;
        }

    }



