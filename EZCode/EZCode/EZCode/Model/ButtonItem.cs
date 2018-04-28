using System;
using System.Collections.Generic;
using System.Text;

using System;
using MvvmHelpers;
using EZCode.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EZCode.Model
{
    public class ButtonItem : BaseViewModel
    {
        AzureService azureService;
        public ObservableRangeCollection<MonHoc> monHocDatas { get; } = new ObservableRangeCollection<MonHoc>();
        public ButtonItem()
        {
            Debug.WriteLine("[ThanhHM] Function: ButtonItem::ButtonItem");
            azureService = DependencyService.Get<AzureService>();
            if (azureService == null)
                Debug.Write("[ThanhHM] Func ButtonItem::ButtonItem ====== azureService is null");
        }
        public string ButtonItemText { get; set; }
        public string ButtonItemDetail { get; set; }
        public string ButtonItemImage { get; set; }

        ICommand loadModelCommand;
        public ICommand LoadModelsCommand =>
            loadModelCommand ?? (loadModelCommand = new Command(async () => await ExecuteLoadModelCommandAsync()));

        async Task ExecuteLoadModelCommandAsync()
        {
            Debug.WriteLine("[ThanhHM] Function: ButtonItem::ExecuteLoadModelCommandAsync");
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var monHoc = await azureService.GetMonHoc();
                if (monHoc != null)
                    monHocDatas.ReplaceRange(monHoc);
                else
                    Debug.WriteLine("[ThanhHM] value is null");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ThanhHM] Error is: " + ex);

                await Application.Current.MainPage.DisplayAlert("Sync Error", "Unable to sync datas, you may be offline", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
