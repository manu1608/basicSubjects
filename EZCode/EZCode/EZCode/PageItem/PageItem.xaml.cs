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
        public PageItem(int subject)
		{
            //InitializeComponent();

            pageInit(subject);
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async public void pageInit(int subject)
        {
            Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXPRESSION, subject)) { Title = ConstantString.EXPRESSIONS_TEXT });
            Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXERCISE, subject)) { Title = ConstantString.EXERCISES_TEXT });
            Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_EXAM, subject)) { Title = ConstantString.EXAMS_TEXT });
            Children.Add(new NavigationPage(new DetailContentPage((int)ConstantString.PAGE_ITEM.PAGE_ITEM_NOTE, subject)) { Title = ConstantString.NOTES_TEXT });
        }
    }
}