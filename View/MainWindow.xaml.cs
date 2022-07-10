using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;
using System.DirectoryServices;
using System.Reflection;


namespace View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindowModel Model => (MainWindowModel)DataContext;

        public MainWindow()
        {
            DataContext = new WindowResultModel();
            InitializeComponent();
        }

        public void Serializable(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Model);
            }
        }

        public void Deserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    DataContext = formatter.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                DataContext = new WindowResultModel();
            }
        }

        

        //Обновить Свойство по данным в TextBox
        public void UpdateSource(TextBox textBox)
        {
            BindingExpression expression = textBox.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
        }

        //Обновить Свойство по данным в TextBlock
        public void UpdateSource(TextBlock textBlock)
        {
            BindingExpression expression = textBlock.GetBindingExpression(TextBlock.TextProperty);
            expression.UpdateSource();
        }

        //Обновить TextBox по данным в Свойстве
        public void UpdateTarget(TextBox textBox)
        {
            BindingExpression expression = textBox.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateTarget();
        }
        //Обновить TextBlock по данным в Свойстве
        public void UpdateTarget(TextBlock textBlock)
        {
            BindingExpression expression = textBlock.GetBindingExpression(TextBlock.TextProperty);
            expression.UpdateTarget();
        }

        //Метод для обработки ввода
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == ".") && (DS_Count(((TextBox)sender).Text) < 1))));
        }

        public int DS_Count(string s)
        {
            string substr = ".";
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.dat";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Serializable(saveFileDialog.FileName);
                }
            }
        }
        private void ButtonLoading_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog saveFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                saveFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.dat";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Deserialize(saveFileDialog.FileName);
                }
            }
        }
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Model.Update();
            WindowResult w = new WindowResult(Model);
            w.Show();
        }

        //private void ComboBoxDistanceChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UIElementCollection items = test.Children;
        //    foreach (var item in items)
        //    {

        //        if (!(item is TextBox))
        //        {
        //            continue;
        //        }

        //        if (((TextBox)item).Name == ((ComboBox)sender).Tag.ToString())
        //        {
        //            Model.SpeedLight = 6;
        //            Binding binding = BindingOperations.GetBinding(((TextBox)item), TextBox.TextProperty);

        //            TextBox.text


        //            return;
        //        }
        //    }

        //}


        //////////УЖЕ НЕ НАДО

        //private void ComboBoxDistanceFormulа_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UIElementCollection items = MainGrid.Children;
        //    foreach (var item in items)
        //    {
        //        if (!(item is TextBlock))
        //        {
        //            continue;
        //        }

        //        TextBlock textBlock = (TextBlock)item;

        //        if (textBlock.Name == ((ComboBox)sender).Tag.ToString())
        //        {
        //            Model.SpeedLight = 6;
        //            Binding binding = BindingOperations.GetBinding(((TextBox)item), TextBox.TextProperty);

        //            textBlock.Text = (GetProperty(Model, binding.Path.Path) * GetConversionFactor((DistanceEnum)((ComboBox)sender).SelectedItem)).ToString();

        //            return;
        //        }
        //    } 

        //}

        //public double GetProperty(MainWindowModel model, string nameProperty)
        //{
        //    Type myType = model.GetType();
        //    PropertyInfo myPropInfo = myType.GetProperty(nameProperty);
        //    return (double)myPropInfo.GetValue(model);
        //}

        //public double GetConversionFactor(DistanceEnum distanceEnum)
        //{
        //    switch (distanceEnum)
        //    {
        //        case DistanceEnum.Millimeter:
        //            return 1000;
        //        case DistanceEnum.Centimeter:
        //            return 100;
        //        case DistanceEnum.Decimeter:
        //            return 10;
        //        case DistanceEnum.Meter:
        //            return 1;
        //        case DistanceEnum.Kilometer:
        //            return 0.001;
        //        default:
        //            return 1;
        //    }
        //}
    }
}
