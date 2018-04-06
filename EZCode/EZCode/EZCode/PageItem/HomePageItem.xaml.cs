using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZCode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageItem : ContentPage
    {
        ObservableCollection<Model.ButtonItem> buttonItemList;
        List<string> keyWordList;
        public HomePageItem()
        {
            InitializeComponent();

            buttonItemList = new ObservableCollection<Model.ButtonItem>();
            ButtonListInit();

            // for search
            GetKeyWordList();

            SuggestionListView.IsVisible = false;
        }

        async public void ButtonListInit()
        {
            HomeListView.ItemsSource = buttonItemList;

            List<Model.MonHoc> monHocs = await Database.MonHocDatabase.GetAllMonHocAsync();

            for (int i = 0; i < monHocs.Count; i++)
            {
                buttonItemList.Add(new Model.ButtonItem { ButtonItemText = monHocs.ElementAt(i).Name, ButtonItemDetail = "", ButtonItemImage = monHocs.ElementAt(i).Image });
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                //ItemSelected is called on deselection, which results in SelectedItem being set to null
                return;
            }

            Model.ButtonItem buttonItem = (Model.ButtonItem)e.SelectedItem;

            switch (buttonItem.ButtonItemText)
            {
                case ConstantString.DAI_SO_TEXT:
                    ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).PushAsync(new PageItem((int)ConstantString.MON_HOC.DAI_SO));
                    break;

                case ConstantString.GIAI_TICH_I_TEXT:
                    ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).PushAsync(new PageItem((int)ConstantString.MON_HOC.GIAI_TICH_1));
                    break;

                case ConstantString.GIAI_TICH_II_TEXT:
                    ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).PushAsync(new PageItem((int)ConstantString.MON_HOC.GIAI_TICH_2));
                    break;

                case ConstantString.VAT_LY_I_TEXT:
                    ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).PushAsync(new PageItem((int)ConstantString.MON_HOC.VAT_LY_1));
                    break;

                case ConstantString.VAT_LY_II_TEXT:
                    ((NavigationPage)((MasterDetailPage)App.Current.MainPage).Detail).PushAsync(new PageItem((int)ConstantString.MON_HOC.VAT_LY_2));
                    break;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (HomeListView != null)
            {
                HomeListView.ClearValue(ListView.SelectedItemProperty);
            }
        }
        async void GetKeyWordList()
        {
            List<Model.MonHoc> monHocs = await Database.MonHocDatabase.GetAllMonHocAsync();
            List<Model.CongThuc> congThucs = await Database.CongThucDatabase.GetAllCongThucAsync();
            List<Model.BaiTap> baiTaps = await Database.BaiTapDatabase.GetAllBaiTapAsync();
            List<Model.DeThi> deThis = await Database.DeThiDatabase.GetAllDeThiAsync();
            keyWordList = new List<string>();

            for (int i = 0; i < monHocs.Count; i++)
            {
                keyWordList.Add(monHocs.ElementAt(i).Name);
            }

            for (int i = 0; i < congThucs.Count; i++)
            {
                keyWordList.Add(congThucs.ElementAt(i).Name);
            }

            for (int i = 0; i < baiTaps.Count; i++)
            {
                keyWordList.Add(baiTaps.ElementAt(i).Name);
            }

            for (int i = 0; i < deThis.Count; i++)
            {
                keyWordList.Add(deThis.ElementAt(i).Name);
            }
        }

        void OnSearchButtonPressed (object sender, EventArgs e)
        {            
            if (keyWordList.Count == 0)
            {
                return;
            }

            string keyWord = HomeSearchBar.Text;

            if (keyWord != "")
            {
                IEnumerable<string> searchResult = keyWordList.Where(name => name.ToLower().Contains(keyWord.ToLower()));

                SuggestionListView.ItemsSource = searchResult;
                HomeListView.IsVisible = false;
                SuggestionListView.IsVisible = true;
            }
            else
            {
                SuggestionListView.ItemsSource = null;
                SuggestionListView.IsVisible = false;
                HomeListView.IsVisible = true;                
            }

        }

        void OnTextChanged (object sender, EventArgs e)
        {
            OnSearchButtonPressed(sender, e);
        }

        void OnItemTapped (object sender, ItemTappedEventArgs e)
        {
            var textCell = e.Item as string;
            DisplayAlert("Hello", "You have selected\n" + textCell, "OK");
        }
    }
}