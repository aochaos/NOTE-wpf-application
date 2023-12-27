using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kursach
{
    /// <summary>
    /// Interaction logic for Redactor.xaml
    /// </summary>
    public partial class Redactor : Window
    {
        public Redactor()
        {

            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbTextColor.ItemsSource = typeof(Colors).GetProperties().Select(c => c.Name);
        }
        public event EventHandler<DocumentSavedEventArgs> DocumentSaved;
        private object selectedFontFamily;
        private string selectedFontSize;
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();

            if (selectedFontFamily != null)
                cmbFontFamily.SelectedItem = selectedFontFamily;

            if (!string.IsNullOrEmpty(selectedFontSize))
                cmbFontSize.Text = selectedFontSize;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                            range.Save(fileStream, DataFormats.Rtf);
                        }
                        Doc savedDocument = new Doc()
                        {
                            Title = System.IO.Path.GetFileNameWithoutExtension(filePath),
                            Path = filePath,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        };
                        DocumentSaved?.Invoke(this, new DocumentSavedEventArgs(savedDocument));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error while saving: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
            }
        }
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                selectedFontFamily = cmbFontFamily.SelectedItem;
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, selectedFontFamily);
            }
        }

        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedFontSize = cmbFontSize.Text;
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, selectedFontSize);
        }
        private void cmbTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTextColor.SelectedItem != null)
            {
                string colorName = cmbTextColor.SelectedItem.ToString();
                var colorProperty = typeof(Colors).GetProperty(colorName);
                if (colorProperty != null)
                {
                    Color selectedColor = (Color)colorProperty.GetValue(null);
                    rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, new SolidColorBrush(selectedColor));
                }
            }
        }
    }
}
