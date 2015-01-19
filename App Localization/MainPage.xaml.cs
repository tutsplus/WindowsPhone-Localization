using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using App_Localization.Resources;
using System.Globalization;
using System.Threading;
using System.Windows.Markup;

namespace App_Localization
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            
        }
        private void SetUILanguage(String locale)
        {
            CultureInfo newCulture = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection),AppResources.ResourceFlowDirection);
            App.RootFrame.FlowDirection = flow;

            // Set the Language of the RootFrame to match the new culture.
            App.RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
        }
        private void updateUI()
        {
            apptitle.Text = AppResources.ApplicationTitle;
            pagetitle.Text = AppResources.mainpagetitle;
            usermessage.Text = AppResources.displayMessage;
            checkbutton.Content = AppResources.checkEligibility;
            enterage.Text = AppResources.userMessage;
        }
        // Sample code for building a localized ApplicationBar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/Check.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem zh_appBarMenuItem = new ApplicationBarMenuItem("中文");
            ApplicationBar.MenuItems.Add(zh_appBarMenuItem);
            zh_appBarMenuItem.Click += new EventHandler(zh_appBarMenuItem_Click);
 
            ApplicationBarMenuItem en_appBarMenuItem = new ApplicationBarMenuItem("english");
            ApplicationBar.MenuItems.Add(en_appBarMenuItem);
            en_appBarMenuItem.Click += new EventHandler(en_appBarMenuItem_Click);

            ApplicationBarMenuItem es_appBarMenuItem = new ApplicationBarMenuItem("español");
            ApplicationBar.MenuItems.Add(es_appBarMenuItem);
            es_appBarMenuItem.Click += new EventHandler(es_appBarMenuItem_Click);
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            checkeligibility();
        }

        private void es_appBarMenuItem_Click(object sender, EventArgs e)
        {
            SetUILanguage("es-ES");
            updateUI();
        }

        private void en_appBarMenuItem_Click(object sender, EventArgs e)
        {
            SetUILanguage("en-US");
            updateUI();
        }

        private void zh_appBarMenuItem_Click(object sender, EventArgs e)
        {
            SetUILanguage("zh-Hans");
            updateUI();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkeligibility();
        }
        private void checkeligibility()
        {
            try
            { 
            int userAge = Convert.ToInt32(age.Text);
            if (userAge > 18)
                MessageBox.Show(AppResources.yesMessage);
            else
                MessageBox.Show(AppResources.noMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(AppResources.validAge);
            }
        }
    }
}