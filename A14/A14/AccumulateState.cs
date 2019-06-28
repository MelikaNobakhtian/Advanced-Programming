using static System.Console;

namespace A14
{
    //این کلاس برای اضافه کردن اعداد مورد استفاده قرار میگیرد یعنی هرگاه رقمی اضافه شد ماشین حساب به این حالت می آید
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        //وقتی علامت مساوی زده شد ابتدا باید از دیسپلی تنها قسمتی رو جدا کنیم که بعد از اپراتور است و در واقع عدد بعدی است که باید با عدد قبلی عملیات روی آنها صورت بگیرد
        //  ماشین حساب در این حالت وارد کامپیوت استیت می شود
        public override IState EnterEqual()
        {
            var s = this.Calc.Display.Split(this.Calc.PendingOperator.Value);
            this.Calc.Display = s[1];
            return ProcessOperator(new ComputeState(this.Calc), '=');
        }
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // برای اضافه کردن ارقام وارد شده استفاده می شود و آن ها را به دیسپلی اضافه می کند
            this.Calc.Display += c;
            return this;
        }

        //هر گاه اپراتوری وارد شود آن اپراتور باید به عنوان اپراتور ماشین حساب انتخاب شود و ماشین حساب را به حالت کامپیوت ببرد
        public override IState EnterOperator(char c)
        {

            if (Calc.PendingOperator != null)
            {
                var s = this.Calc.Display.Split(this.Calc.PendingOperator.Value);
                Calc.Display = s[1];
            }
            return ProcessOperator(new ComputeState(this.Calc), c);
        }

        public override IState EnterPoint()
        {
            //هنگامی یک نقطه وارد میکنیم آن نقطه به دیسپلی اضافه می شود
            //پس از این کار وارد پوینت استیت می شویم
            this.Calc.Display += ".";
            return new PointState(Calc);
        }
    }
}