using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel{
    class MainViewModel : INotifyPropertyChanged {
        //式の左辺
        private double lhs;
        //式の右辺
        private double rhs;
        //計算結果
        private double display;
        //直前の演算子
        public enum Operator{NONE,PLUS,MINUS,EQUALS, MULTIPLY, DIVIDED };
        public Operator Opera { get; set; }

        public MainViewModel() {
            display = 0;
        }


        //=がクリックされたら
        public void ClickEquals() {
            this.Equals();
            Lhs = 0;
            this.Opera = Operator.EQUALS;
        }
        public void CommandEquals() {
            this.Equals();
            OnPropertyChanged("Display");
        }
        public void Equals() {
            switch (this.Opera) {
                case Operator.PLUS:
                    Display += Lhs;
                    break;
                case Operator.MINUS:
                    Display = Lhs - Display;
                    break;
                case Operator.MULTIPLY:
                    Console.WriteLine(Lhs);
                    Console.WriteLine(Display);
                    Display *= Lhs;
                    break;
                case Operator.DIVIDED:
                    Display = Lhs / Display;
                    break;
                default:
                    break;
            }
        }

        public void inputNumeric(Double input) {
            if (this.Opera == Operator.EQUALS) {
                this.Opera = Operator.NONE;
                this.Display = 0;
            }

            this.Display *= 10;
            this.Display += input;
        }

        /// <summary>
        /// 左辺
        /// </summary>
        public double Lhs {
            get {
                return this.lhs;
            }
            set {
                this.lhs = value;
                if (value != 0)
                    this.display = 0;
                OnPropertyChanged("Lhs");
            }
        }

        /// <summary>
        /// 計算結果
        /// </summary>
        public double Display {
            get {
                return this.display;
            }
            set {
                this.display = value;
                OnPropertyChanged("Display");
            }
        }

        //INotifyPropertyChangedの実装
        public event PropertyChangedEventHandler PropertyChanged;

        //INotifyPropertyChangedの実装            
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
