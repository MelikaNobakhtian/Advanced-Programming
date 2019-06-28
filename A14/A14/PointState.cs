namespace A14
{
    /// <summary>
    /// این وضعیت نشان دهنده حالتی است که نقطه زده شده
    /// این وضعیت شبیه وضعیت
    /// Accumulate
    /// است
    /// تنها فرقش این است که نقطه جدیدی نمی شود زد.
    /// تغییرات لازم را برای این کار بدهید.
    /// </summary>
    public class PointState : AccumulateState
    {
        //است EnterPoint عمل می کند و تنها تفاوت آن در  AccumulateState این کلاس شبیه 
        public PointState(Calculator calc) : base(calc) { }
        //با وارد کردن نقطه هیچ تغییری ایجاد نمی شود
        public override IState EnterPoint()
        {
            return this;
        }


    }
}