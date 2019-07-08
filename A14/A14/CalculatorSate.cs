using System;
namespace A14
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.
    ///  # کلاس مادر که واسط آی استیت را پیاده سازی کرده که شامل متد های لازم برای ماشین حساب است
    /// </summary>
    public abstract class CalculatorState : IState
    {
        public Calculator Calc { get; }
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() => this;
        public virtual IState EnterZeroDigit() => this;
        public virtual IState EnterNonZeroDigit(char c) => this;
        public virtual IState EnterOperator(char c) => this;
        public virtual IState EnterPoint() => this;

        //اپراتور را پردازش می کند . ابتدا آن را ارزیابی می کند سپس دیسپلی را تغییر و اپراتور ماشین حساب را تغییر می دهد.سپس به استیت خود بر می گردد
        // اگر هر یک از متدها دچار مشکل شود و اکسپشن رخ بدهد وارد ارور استیت شده و ارور را چاپ می کند
        protected IState ProcessOperator(IState nextState, char? op = null)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}