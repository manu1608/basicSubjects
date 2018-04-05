using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EZCode
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageItem : TabbedPage
	{
        TabbedPage itemPage;
        public PageItem (int subject)
		{
            //InitializeComponent();

            pageInit(subject);
            NavigationPage.SetHasBackButton(itemPage, false);
            NavigationPage.SetHasNavigationBar(itemPage, false);
        }

        async public void pageInit(int subject)
        {
            itemPage = new TabbedPage();
            itemPage.Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXPRESSION, subject)) { Title = ConstantString.EXPRESSIONS_TEXT });
            await Navigation.PushAsync(itemPage);

            itemPage.Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXERCISE, subject)) { Title = ConstantString.EXERCISES_TEXT });
            await Navigation.PushAsync(itemPage);

            itemPage.Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXAM, subject)) { Title = ConstantString.EXAMS_TEXT });
            await Navigation.PushAsync(itemPage);

            itemPage.Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_NOTE, subject)) { Title = ConstantString.NOTES_TEXT });
            await Navigation.PushAsync(itemPage);
        }
	}
}