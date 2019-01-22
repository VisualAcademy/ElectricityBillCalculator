namespace Dul
{
    public class 시간대계산기
    {
        public static 시간대 계산(int month, int hour)
        {
            시간대 _시간대 = 시간대.경부하;

            if (month == 11 || month == 12 || month == 1 || month == 2) // 겨울철
            {
                if (hour >= 23 || hour < 9)
                {
                    _시간대 = 시간대.경부하;
                }
                else if (hour == 9 || hour >= 12 && hour < 17 || hour == 20 || hour == 21)
                {
                    _시간대 = 시간대.중간부하;
                }
                else
                {
                    _시간대 = 시간대.최대부하;
                }
            }
            else // 나머지 계절
            {
                if (hour >= 23 || hour < 9)
                {
                    _시간대 = 시간대.경부하;
                }
                else if (hour == 9 || hour == 12 || hour >= 17 && hour == 22)
                {
                    _시간대 = 시간대.중간부하;
                }
                else
                {
                    _시간대 = 시간대.최대부하;
                }
            }


            return _시간대;
        }
    }
}
