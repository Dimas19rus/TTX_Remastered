using System;
using System.Collections.Generic;
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
using ViewModel;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для WindowResult.xaml
    /// </summary>
    public partial class WindowResult : Window
    {
        public WindowResultModel Model => (WindowResultModel)DataContext;
        public WindowResult(MainWindowModel mainModel)
        {
            InitializeComponent();
            DataContext = (WindowResultModel)mainModel;
            Model.Update();
        }
    }
}
