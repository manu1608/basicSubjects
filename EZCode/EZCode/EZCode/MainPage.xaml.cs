using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZCode
{
    public partial class MainPage : MasterDetailPage
	{
        ObservableCollection<Model.ButtonItem> buttonItemList;
        public MainPage()
		{
			InitializeComponent();

            // set home page is default page 
            // set master page invisible
            Detail = new NavigationPage(new HomePageItem());

            IsPresented = false;

            buttonItemList = new ObservableCollection<Model.ButtonItem>();
            ButtonListInit();
        }

        async public void ButtonListInit()
        {
            ButtonItemListView.ItemsSource = buttonItemList;

            List<Model.MonHoc> monHocs = await Database.MonHocDatabase.GetAllMonHocAsync();

            buttonItemList.Add(new Model.ButtonItem { ButtonItemText = ConstantString.HOME_TEXT, ButtonItemDetail = "", ButtonItemImage = ConstantString.HOME_IMAGE });

            for (int i = 0; i < monHocs.Count; i++)
            {
                buttonItemList.Add(new Model.ButtonItem { ButtonItemText = monHocs.ElementAt(i).Name, ButtonItemDetail = "", ButtonItemImage = monHocs.ElementAt(i).Image });
            }

            buttonItemList.Add(new Model.ButtonItem { ButtonItemText = ConstantString.ABOUT_TEXT, ButtonItemDetail = "", ButtonItemImage = ConstantString.ABOUT_IMAGE });
            buttonItemList.Add(new Model.ButtonItem { ButtonItemText = ConstantString.FEEDBACK_TEXT, ButtonItemDetail = "", ButtonItemImage = ConstantString.FEEDBACK_IMAGE });
            buttonItemList.Add(new Model.ButtonItem { ButtonItemText = ConstantString.CONTACT_TEXT, ButtonItemDetail = "", ButtonItemImage = ConstantString.CONTACT_IMAGE });
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                //ItemSelected is called on deselection, which results in SelectedItem being set to null
                return; 
            }

            Model.ButtonItem buttonItem = (Model.ButtonItem)e.SelectedItem;

            // set master page invisible
            IsPresented = false;

            switch (buttonItem.ButtonItemText)
            {
                case ConstantString.HOME_TEXT:
                    Detail = new NavigationPage(new HomePageItem());                    
                    break;

                case ConstantString.DAI_SO_TEXT:
                    Detail = new NavigationPage(new PageItem((int)ConstantString.MON_HOC.DAI_SO));
                    break;

                case ConstantString.GIAI_TICH_I_TEXT:
                    Detail = new NavigationPage(new PageItem((int)ConstantString.MON_HOC.GIAI_TICH_1));
                    break;

                case ConstantString.GIAI_TICH_II_TEXT:
                    Detail = new NavigationPage(new PageItem((int)ConstantString.MON_HOC.GIAI_TICH_2));
                    break;

                case ConstantString.VAT_LY_I_TEXT:
                    Detail = new NavigationPage(new PageItem((int)ConstantString.MON_HOC.VAT_LY_1));
                    break;

                case ConstantString.VAT_LY_II_TEXT:
                    Detail = new NavigationPage(new PageItem((int)ConstantString.MON_HOC.VAT_LY_2));
                    break;

                case ConstantString.ABOUT_TEXT:
                    Detail = new NavigationPage(new AboutPageItem());
                    break;

                case ConstantString.FEEDBACK_TEXT:
                    Detail = new NavigationPage(new FeedbackPageItem());
                    break;

                case ConstantString.CONTACT_TEXT:
                    Detail = new NavigationPage(new ContactPageItem());
                    break;
                default:
                    break;
            }
        }
    }
}
