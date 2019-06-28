namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }
        //هنگامی در حالت کامپیوت ایکوال صدا زده می شود ماشین حساب باید به حالت ارور استیت برود چون چنین عملیاتی ممکن نیست
        public override IState EnterEqual()
        {
            return new ErrorState(this.Calc);
        }
        //می رود Accumulate وقتی یک عدد وارد می شود اپراتور وارد شده و عدد به دیسپلی اضافه شده و ماشین حساب به حالت 
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Display += $"{this.Calc.PendingOperator}{c}";
            return new AccumulateState(this.Calc);
        }

        public override IState EnterZeroDigit()
        {
            this.Calc.Display += $"{this.Calc.PendingOperator}0";
            return new AccumulateState(this.Calc);
        }

        //اگر دراین حالت دوباره اپراتوری صدا زده شود هیچ تغییری ایجاد نمی شود
        public override IState EnterOperator(char c)
        {
            return this;
        }
        //وارد شدن نقطه ماشین حساب را به پوینت استیت می برد
        public override IState EnterPoint()
        {
            Calc.Display = $"{Calc.PendingOperator}0.";
            return new PointState(this.Calc);
        }

    }
}