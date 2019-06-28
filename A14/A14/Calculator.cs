using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A14
{
    public class Calculator
    {
        // یک ماشین حساب جدید ساخته می شود و ماشین حساب به حالت استارت استیت می رود
        public Calculator(Action clearScreen)
        {
            this.State = new StartState(this);
            this.ClearScreen = clearScreen;
        }
        // یک دیکشنری که اپراتور های لازم برای ماشین حساب را در خود داردو یک فانکشن که عملیات مورد نظر را روی اعداد داده شده انجام می دهد
        public static readonly Dictionary<char, Func<double, double, double>> Operators =
            new Dictionary<char, Func<double, double, double>>()
            {
                ['+'] = (x, y) => x + y,
                ['-'] = (x, y) => x - y,
                ['/'] = (x, y) => x / y,
                ['*'] = (x, y) => x * y,
                ['^'] = (x, y) => Math.Pow(x, y)
            };
        //در هر مرحله دیسپلی را چاپ می کند
        public void PrintDisplay()
        {
            this.ClearScreen();
            Console.Write(this.Display);
        }

        public string Display { get; set; } = "0";
        public double Accumulation { get; set; }
        public char? PendingOperator { get; set; } = null;
        public IState State { get; protected set; }
        public Action ClearScreen { get; }
        // می ریزد  Accumulation اپراتور را ارزیابی می کند.اگر نال نباشد عملیات مورد نظر را انجام می دهد و جواب را در 
        //ریخته می شود Accumulation اگر اپراتور نال باشد به این معناست که اولین اپراتور وارد شده و هنوز عدد دومی نیست که روی آنها عملیات انجام دهیم تنها دیسپلی در
        public void Evalute()
        {
            Accumulation = PendingOperator.HasValue ?
                    Operators[PendingOperator.Value](Accumulation, double.Parse(Display)) :
                    double.Parse(Display);
        }
        //پیام متناظر با اکسپشن رخ داده را چاپ می کند
        public void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
            Thread.Sleep(500);
        }
        //تغییر می دهد Evaluteدیسپلی را به نتیجه 
        public void UpdateDisplay() => Display = Accumulation.ToString();
        public void EnterPoint() => State = State.EnterPoint();
        // متناظر با آن استیت صدا زده می شود EnterDigit هر عددی که وارد می شود ابتدا وارد این متد می شویم و  
        //سپس استیت به نتیجه ی آن تغییر می کند
        public void EnterZeroDigit() => State = State.EnterZeroDigit();
        public void EnterNonZeroDigit(char c) => State = State.EnterNonZeroDigit(c);
        //متناظر با هر استیت صدا زده می شود EnterOperator هر اپراتوری که وارد می شود ابتدا این متد صدا زده می شود.در این متد 
        public void EnterOperator(char op)
        {
            State = State.EnterOperator(op);
            PendingOperator = op;
        }
        //متناظر با هر استیت را صدا می زند و استیت را به نتیجه آن تغییر می دهد EnterEqual 
        public void EnterEqual() => State = State.EnterEqual();
        //همه چیز پاک شده و به حالت اولیه بر می گردد
        public void Clear()
        {
            Accumulation = 0;
            State = new StartState(this);
            PendingOperator = null;
            Display = "0";
        }
    }
}
