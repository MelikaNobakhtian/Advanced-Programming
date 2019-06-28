using System;

namespace A14
{
    /// <summary>
    /// این کلاس بطور کامل پیاده سازی شده است و نیاز به تغییر ندارد.
    /// تنها تغییرات لازم کامنت های شماست 
    /// </summary>
    public class StartState : CalculatorState
    {
        public StartState(Calculator calc) : base(calc) { }
        //وارد کامپیوت استیت می شود
        public override IState EnterEqual() =>
            ProcessOperator(new ComputeState(this.Calc));
        //تا زمانی که صفر وارد می کنیم دیسپلی صفر می ماند و استیت تغییر نمی کند
        public override IState EnterZeroDigit()
        {
            this.Calc.Display = "0";
            return this;
        }
        //می شود accumulate هنگامی که اولین عدد غیر صفر در ماشین حساب وارد می شود دیسپلی برابر آن عدد می شود و ماشین حساب وارد حالت
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display = c.ToString();
            return new AccumulateState(this.Calc);
        }
        //وارد کامپیوت استیت می شود
        public override IState EnterOperator(char c) =>
            ProcessOperator(new ComputeState(this.Calc), c);
        //یک اعداد اعشاری را شروع می کند و به پوینت استیت می رود
        public override IState EnterPoint()
        {
            this.Calc.Display = "0.";
            return new PointState(this.Calc);
        }
    }
}