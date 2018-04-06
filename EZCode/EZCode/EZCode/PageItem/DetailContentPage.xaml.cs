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
	public partial class DetailContentPage : ContentPage
	{
        ObservableCollection<Model.ButtonItem> contentItemList;
        List<string> keyWordList;
        public DetailContentPage(int pageItem, int subject)
		{
			InitializeComponent ();
            contentItemList = new ObservableCollection<Model.ButtonItem>();
            contentInit(pageItem, subject);
        }

        async public void contentInit(int pageItem, int subject)
        {
            DetailContentListView.ItemsSource = contentItemList;

            switch (pageItem)
            {
                case (int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXPRESSION:
                    {
                        //List<Model.CongThuc> expr = await Database.CongThucDatabase.GetAllCongThucAsync();
                        List<Model.CongThuc> expr = await Database.MonHocCongThucDatabase.GetAllCongThucAsync(subject);
                        for (int i = 0; i < expr.Count; i++)
                        {
                            contentItemList.Add(new Model.ButtonItem { ButtonItemText = expr.ElementAt(i).Name, ButtonItemDetail = "", ButtonItemImage = expr.ElementAt(i).Image });
                        }
                        break;
                    }
                case (int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXERCISE:
                    {
                        //List<Model.BaiTap> exercise = await Database.BaiTapDatabase.GetAllBaiTapAsync();
                        List<Model.BaiTap> exercise = await Database.MonHocBaiTapDatabase.GetAllBaiTapAsync(subject);
                        for (int i = 0; i < exercise.Count; i++)
                        {
                            contentItemList.Add(new Model.ButtonItem { ButtonItemText = exercise.ElementAt(i).Name, ButtonItemDetail = "", ButtonItemImage = exercise.ElementAt(i).Image });
                        }
                        break;
                    }
                case (int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXAM:
                    {
                        //List<Model.DeThi> exercise = await Database.DeThiDatabase.GetAllDeThiAsync();
                        List<Model.DeThi> exam = await Database.MonHocDeThiDatabase.GetAllDeThiAsync(subject);
                        for (int i = 0; i < exam.Count; i++)
                        {
                            contentItemList.Add(new Model.ButtonItem { ButtonItemText = exam.ElementAt(i).Name, ButtonItemDetail = "", ButtonItemImage = exam.ElementAt(i).Image });
                        }
                        break;
                    }
                case (int)ConstantString.PAGE_ITEM.PAGE_ITEM_NOTE:
                    break;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Model.ButtonItem buttonItem = (Model.ButtonItem)e.SelectedItem;
                Navigation.PushAsync(new ExplainDetailPage());

                DisplayAlert("Hello", "This is page explain for\n" + buttonItem.ButtonItemText, "OK");

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (DetailContentListView != null)
            {
                DetailContentListView.ClearValue(ListView.SelectedItemProperty);
            }
        }
    }
}