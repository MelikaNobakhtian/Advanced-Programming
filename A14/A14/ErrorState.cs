namespace A14
{
    /// <summary>
    /// ماشین حساب وقتی به این حالت وارد میشود که خطایی رخ داده باشد
    /// از این حالت هر کلیدی که فشار داده شود به وضعیت اولیه باید برگردیم
    /// #هنگامی که یک کلید قشار داده می شود اسکرین را کلیر می کنیم و دوباره به حالت اولیه ماشین حساب بر می گردیم
    /// </summary>
    public class ErrorState : CalculatorState
    {
        public ErrorState(Calculator calc) : base(calc) { }
        public override IState EnterEqual()
        {
            this.Calc.Clear();
            return new StartState(this.Calc);
        }
        public override IState EnterNonZeroDigit(char c)
        {
            this.Calc.Clear();
            return new StartState(this.Calc);
        }
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterOperator(char c)
        {
            this.Calc.Clear();
            return new StartState(this.Calc);
        }
        public override IState EnterPoint()
        {
            this.Calc.Clear();
            return new StartState(this.Calc);
        }
    }
}