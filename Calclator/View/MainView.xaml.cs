using Calculator.ViewModel;
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
using static Calculator.ViewModel.MainViewModel;

namespace Calculator.View
{
    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel ViewModel;
        public MainView()
        {
            InitializeComponent();

            this.ViewModel = new ViewModel.MainViewModel();
            this.DataContext = this.ViewModel;
        }

        private void Click_NumericChar(object sender, RoutedEventArgs e) {
            String input = ((Button)sender).CommandParameter.ToString();
            this.ViewModel.inputNumeric(Double.Parse(input));
        }

        private void Click_Command(object sender, RoutedEventArgs e) {
            String input = ((Button)sender).CommandParameter.ToString();
            switch (input) {
                case "AC":
                    this.ViewModel.Display = 0;
                    this.ViewModel.Opera = Operator.NONE;
                    break;
            }
        }

        private void Click_Operator(object sender, RoutedEventArgs e) {
            String input = ((Button)sender).CommandParameter.ToString();
            Operator operatorType = this.getOperatorType(input);

            //2回目以降の演算子の入力は＝の意味を持つ
            switch (operatorType) {
                case Operator.NONE:
                case Operator.EQUALS:
                    break;
                case Operator.PLUS:
                case Operator.MINUS:
                case Operator.MULTIPLY:
                case Operator.DIVIDED:
                    this.ViewModel.CommandEquals();
                    break;
            }
            switch (operatorType) {
                case Operator.PLUS:
                    this.ViewModel.Lhs = this.ViewModel.Display;
                    this.ViewModel.Opera = Operator.PLUS;
                    break;
                case Operator.MINUS:
                    this.ViewModel.Lhs = this.ViewModel.Display;
                    this.ViewModel.Opera = Operator.MINUS;
                    break;
                case Operator.MULTIPLY:
                    this.ViewModel.Lhs = this.ViewModel.Display;
                    this.ViewModel.Opera = Operator.MULTIPLY;
                    break;
                case Operator.DIVIDED:
                    this.ViewModel.Lhs = this.ViewModel.Display;
                    this.ViewModel.Opera = Operator.DIVIDED;
                    break;
                case Operator.EQUALS:
                    this.ViewModel.ClickEquals();
                    break;
            }

        }
        private Operator getOperatorType(String input) {
            switch (input) {
                case "+":
                    return Operator.PLUS;
                case "-":
                    return Operator.MINUS;
                case "×":
                    return Operator.MULTIPLY;
                case "÷":
                    return Operator.DIVIDED;
                case "=":
                    return Operator.EQUALS;
                default:
                    return Operator.NONE;
            }
        }
    }
}
