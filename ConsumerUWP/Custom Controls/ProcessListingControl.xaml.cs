using System;
using System.Collections.Generic;
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
using Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using ConsumerUWP.Annotations;
using System.Runtime.CompilerServices;
using Windows.UI.Notifications;
using ConsumerUWP.ViewModels;
using Template10.Utils;
using Activity = ConsumerUWP.ViewModels.Activity;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ConsumerUWP.Custom_Controls
{
    public sealed partial class ProcessListingControl : UserControl
    {
        #region DependecyProperties
        public static readonly DependencyProperty SavedProperty = DependencyProperty.Register(
            "Saved", typeof(IEnumerable<ProcessOrdre>), typeof(ProcessListingControl),
            new PropertyMetadata(default(IEnumerable<ProcessOrdre>)));

        public IEnumerable<ProcessOrdre> Saved
        {
            get { return (IEnumerable<ProcessOrdre>)GetValue(SavedProperty); }
            set { SetValue(SavedProperty, value); }
        }
        //
        public static readonly DependencyProperty PlannedProperty = DependencyProperty.Register(
            "Planned", typeof(IEnumerable<ProcessOrdre>), typeof(ProcessListingControl),
            new PropertyMetadata(default(IEnumerable<ProcessOrdre>)));

        public IEnumerable<ProcessOrdre> Planned
        {
            get { return (IEnumerable<ProcessOrdre>)GetValue(PlannedProperty); }
            set { SetValue(PlannedProperty, value); }
        }
        //
        public static readonly DependencyProperty DoingProperty = DependencyProperty.Register(
            "Doing", typeof(IEnumerable<ProcessOrdre>), typeof(ProcessListingControl),
            new PropertyMetadata(default(IEnumerable<ProcessOrdre>)));

        public IEnumerable<ProcessOrdre> Doing
        {
            get { return (IEnumerable<ProcessOrdre>)GetValue(DoingProperty); }
            set { SetValue(DoingProperty, value); }
        }
        //
        public static readonly DependencyProperty SelectedOrdreProperty = DependencyProperty.Register(
            "SelectedOrdre", typeof(ProcessOrderArk), typeof(ProcessListingControl),
            new PropertyMetadata(default(ProcessOrderArk)));

        public ProcessOrderArk SelectedOrdre
        {
            get { return (ProcessOrderArk)GetValue(SelectedOrdreProperty); }
            set { SetValue(SelectedOrdreProperty, value); }
        }

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
            "Date", typeof(string), typeof(ProcessListingControl), new PropertyMetadata(default(string),
                (o, args) =>
                {
                    ProcessListingControl mine = o as ProcessListingControl;
                    mine.updateDateTime();
                }));

        public string Date
        {
            get { return (string) GetValue(DateProperty); }
            set
            {
                SetValue(DateProperty, value);
            }
        }

        public static readonly DependencyProperty MonthProperty = DependencyProperty.Register(
            "Month", typeof(string), typeof(ProcessListingControl), new PropertyMetadata(default(string),
                ((o, args) =>
                {
                    ProcessListingControl mine = o as ProcessListingControl;
                    mine.updateDateTime();
                } )));

        public string Month
        {
            get { return (string) GetValue(MonthProperty); }
            set
            {
                SetValue(MonthProperty, value);
            }
        }

        public static readonly DependencyProperty yearProperty = DependencyProperty.Register(
            "year", typeof(string), typeof(ProcessListingControl), new PropertyMetadata(default(string),
                ((o, args) =>
                {
                    ProcessListingControl mine = o as ProcessListingControl;
                    mine.updateDateTime();
                } )));

        public string year
        {
            get { return (string) GetValue(yearProperty); }
            set
            {
                SetValue(yearProperty, value);
            }
        }

        public ObservableCollection<Models.Activity> Activities
        {
            get { return _activities; }
        }

        public static readonly DependencyProperty SaveOrderProperty = DependencyProperty.Register(
            "SaveOrder", typeof(ProcessOrdre), typeof(ProcessListingControl), new PropertyMetadata(default(ProcessOrdre)));

        public ProcessOrdre SaveOrder
        {
            get { return (ProcessOrdre) GetValue(SaveOrderProperty); }
            set { SetValue(SaveOrderProperty, value); }
        }

        #endregion

        private ObservableCollection<Models.Activity> _activities = Activity.LoadActivities();
        private List<Models.Activity> selectedActivities;


        private ListView PlannedList;
        private ListView AktiveList;
        private ListView ArkiveredeList;

        private StackPanel EditGrid;
        private StackPanel SaveGrid;

        public ProcessListingControl()
        {
            selectedActivities = new List<Models.Activity>();
            SaveOrder = new ProcessOrdre(){Process = 'p', ProcessDate = DateTime.Now};

            this.InitializeComponent();

            PlannedList = FindName("PlanlagteOrdre") as ListView;
            AktiveList = FindName("AktiveOrdre") as ListView;
            ArkiveredeList = FindName("ArkiveredeOrdre") as ListView;

            AktivitetsListe = FindName("AktivitetsListe") as ListView;
            EditGrid = FindName("EditGridView") as StackPanel;
            SaveGrid = FindName("SaveGridView") as StackPanel;
        }

        private void AktiveOrdre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditGrid.Visibility = Visibility.Collapsed;
            SaveGrid.Visibility = Visibility.Collapsed;
            Archive.Visibility = Visibility.Visible;

            PlannedList.SelectedIndex = -1;
            ArkiveredeList.SelectedIndex = -1;
        }

        private void ArkiveredeOrdre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditGrid.Visibility = Visibility.Collapsed;
            SaveGrid.Visibility = Visibility.Collapsed;

            PlannedList.SelectedIndex = -1;
            AktiveList.SelectedIndex = -1;
        }

        private void PlanlagteOrdre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditGrid.Visibility = Visibility.Visible;
            SaveGrid.Visibility = Visibility.Collapsed;

            AktiveList.SelectedIndex = -1;
            ArkiveredeList.SelectedIndex = -1;
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            //SelectedOrdre.ProcessDate = updateDateTime();
            Debug.WriteLine(ProcessOrderArk.SaveArk(SelectedOrdre));
        }

        private DateTime updateDateTime()
        {
            DateTime Curr = new DateTime(SelectedOrdre.ProcessDate.Year, SelectedOrdre.ProcessDate.Month, SelectedOrdre.ProcessDate.Day);

            if (year != null)
            {
                if (year == "") year = "1";
                Curr = new DateTime(Int32.Parse(year), Curr.Month, Curr.Day);
            }
            if (Month != null)
            {
                if (Month == "") Month = "1";
                Curr = new DateTime(Curr.Year, Int32.Parse(Month), Curr.Day);
            }
            if (Date != null)
            {
                if (Date == "") Date = "1";
                Curr = new DateTime(Curr.Year, Curr.Month, Int32.Parse(Date));
            }

            SelectedOrdre.ProcessDate = Curr;

            return Curr;
        }

        private void Create_OnClick(object sender, RoutedEventArgs e)
        {
            ProcessOrderArk.SaveProcessOrder(SaveOrder);
            ProcessOrderArk.SaveActivities(selectedActivities, SaveOrder.ProcessOrderNR);
            SaveGrid.Visibility = Visibility.Visible;
        }

        private void AktivitetChecked_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            Grid g = c.Parent as Grid;
            TextBlock t = g.AllChildren().First() as TextBlock;
            Models.Activity data = t.DataContext as Models.Activity;

            selectedActivities.Add(data);
        }

        private void AktivitetChecked_OnUnchecked(object sender, RoutedEventArgs e)
        {

            CheckBox c = sender as CheckBox;
            Grid g = c.Parent as Grid;
            TextBlock t = g.AllChildren().First() as TextBlock;
            Models.Activity data = t.DataContext as Models.Activity;

            Debug.WriteLine(selectedActivities.Remove(data));
        }

        private void SaveFVNR_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "") t.Text = "0";
            SaveOrder.EndproductNR = Int32.Parse(t.Text);
        }

        private void SaveColNr_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "") t.Text = "0";
            SaveOrder.ColumnNR = Int32.Parse(t.Text);
        }

        private void SavePONR_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "") t.Text = "0";
            SaveOrder.ProcessOrderNR = Int32.Parse(t.Text);
        }

        private void CreateNew_OnClick(object sender, RoutedEventArgs e)
        {
            SaveGrid.Visibility = Visibility.Visible;
            EditGrid.Visibility = Visibility.Collapsed;
            Button b = (Button) sender;
            b.Visibility = Visibility.Collapsed;
        }

        private void EditFVNR_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox t = sender as TextBox;
            if (t.Text == "") t.Text = "0";
            if(SelectedOrdre != null) SelectedOrdre.EndproductNR = Int32.Parse(t.Text);
        }

        private void EditColNR_OnTextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox t = sender as TextBox;
            if (t.Text == "") t.Text = "0";
            if (SelectedOrdre != null) SelectedOrdre.ColumnNR = Int32.Parse(t.Text);
        }

        private void Archive_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedOrdre.Process = 'a';
            ProcessOrderArk.SaveArk(SelectedOrdre);
        }
    }
}