using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ConsumerUWP.ViewModels;
using User = Models.User;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ConsumerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Operator_Overview : Page
    {
        private ObservableCollection<NavigationItem> menu = new ObservableCollection<NavigationItem>();
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public Operator_Overview()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Username = Session.CurrentUser.UserName;
            loginname.Text = Session.CurrentUser.UserName;
            if (Session.CurrentUser.AccessLevel == User.AccessLevels.ADMIN)
            {
                logintype.Text = "Admin";
            }
            else
            {
                logintype.Text = "Operatør";
            }
            menu.Clear();
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K2), MenuText = typeof(K_views.K2).Name, MenuIcon = "K2" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K3), MenuText = typeof(K_views.K3).Name, MenuIcon = "K3" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K4), MenuText = typeof(K_views.K4).Name, MenuIcon = "K4" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K5), MenuText = typeof(K_views.K5).Name, MenuIcon = "K5" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K6), MenuText = typeof(K_views.K6).Name, MenuIcon = "K6" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K7), MenuText = typeof(K_views.K7).Name, MenuIcon = "K7" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K8), MenuText = typeof(K_views.K8).Name, MenuIcon = "K8" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K11), MenuText = typeof(K_views.K11).Name, MenuIcon = "K11" });
            menu.Add(new NavigationItem { PageLink = typeof(K_views.K12), MenuText = typeof(K_views.K12).Name, MenuIcon = "K12" });




        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            listmenu.SelectedIndex = 0;
        }

        private void Button_Click_Pane(object sender, RoutedEventArgs e)
        {
            this.RootSpiltView.IsPaneOpen = !this.RootSpiltView.IsPaneOpen;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            // TODO: Kill session then navigate back to mainpage
            //
            Session.CurrentUser = null;
            this.Frame.Navigate(typeof(MainPage), null);



            /* // old code //
            if (splitviewContent.CanGoBack)
            {
                splitviewContent.GoBack();
            }
            */
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var naviitem = listmenu.SelectedItem as NavigationItem;
            splitviewContent.Navigate(naviitem.PageLink);
        }

        private void splitviewContent_Navigated(object sender, NavigationEventArgs e)
        {
            var page = splitviewContent.CurrentSourcePageType.Name;
            switch (page)
            {
                case "Page1":
                    listmenu.SelectedIndex = 0;
                    break;

                case "Page2":
                    listmenu.SelectedIndex = 1;
                    break;

                case "Page3":
                    listmenu.SelectedIndex = 2;
                    break;

                case "Page4":
                    listmenu.SelectedIndex = 3;
                    break;

                case "Page5":
                    listmenu.SelectedIndex = 3;
                    break;

                case "Page6":
                    listmenu.SelectedIndex = 3;
                    break;

                case "Page7":
                    listmenu.SelectedIndex = 3;
                    break;

                case "Page8":
                    listmenu.SelectedIndex = 3;
                    break;

                case "Page9":
                    listmenu.SelectedIndex = 3;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}
