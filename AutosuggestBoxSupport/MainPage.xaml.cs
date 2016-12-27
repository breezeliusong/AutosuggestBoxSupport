using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AutosuggestBoxSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            suggestions = new ObservableCollection<SampleSuggest>();//test AutosuggestBox
        }



        //private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        //{

        //}

        //private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        //{
        //    Debug.WriteLine("AutoSuggestBox_TextChanged");
        //}

        private void EditSuggestionButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("EditSuggestionButton_Click");
        }

        private void SearchtextAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Debug.WriteLine("SearchtextAutoSuggestBox_SuggestionChosen");
        }

        private void SearchtextAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            Debug.WriteLine("SearchtextAutoSuggestBox_TextChanged");
        }

        private void SearchtextAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Debug.WriteLine("SearchtextAutoSuggestBox_QuerySubmitted");
        }


        ///test AutosuggestBox
        private ObservableCollection<SampleSuggest> suggestions { get; set; }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
                textBlock.Text = args.ChosenSuggestion.ToString();
            else
                textBlock.Text = sender.Text;
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            suggestions.Clear();
            suggestions.Add(new SampleSuggest { Index=1,Value=sender.Text});
            suggestions.Add(new SampleSuggest { Index = 2, Value = sender.Text });
            sender.ItemsSource = suggestions;
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SampleSuggest suggest = args.SelectedItem as SampleSuggest;
            if (suggest == null)
                return;
            sender.Text = suggest.Value;
        }
    }
}
