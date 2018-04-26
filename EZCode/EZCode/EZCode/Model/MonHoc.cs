using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

using System;
using MvvmHelpers;
using EZCode.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EZCode.Model
{
    public class MonHoc : BaseViewModel
    {
        //AzureService azureService;
        //public ObservableRangeCollection<MonHoc> monHocDatas { get; } = new ObservableRangeCollection<MonHoc>();
        //public MonHoc()
        //{
        //    azureService = DependencyService.Get<AzureService>();
        //}
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        //ICommand loadModelCommand;
        //public ICommand LoadModelsCommand =>
        //    loadModelCommand ?? (loadModelCommand = new Command(async () => await ExecuteLoadModelCommandAsync()));

        //async Task ExecuteLoadModelCommandAsync()
        //{
        //    if (IsBusy)
        //        return;

        //    try
        //    {
        //        IsBusy = true;
        //        var monHoc = await azureService.GetMonHoc();
        //        monHocDatas.ReplaceRange(monHoc);
        //    }
        //    catch (Exception e)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Sync Error!!!\n", "Unable to sync datas!", "OK");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
    }
}
