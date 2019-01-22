namespace Dul
{
    /// <summary>
    /// 전기 요금 계산기 
    /// </summary>
    public class 전기요금계산기
    {
        /// <summary>
        /// 요금: 기본요금 및 전력량 요금 
        /// </summary>
        /// <param name="_계약종별"></param>
        /// <param name="_압력분류"></param>
        /// <param name="_전력량">전력량: kWh(킬로와트시)</param>
        /// <param name="_선택분류"></param>
        /// <returns></returns>
        public (decimal 기본요금, decimal 전력량요금) 요금(계약종별 _계약종별, 압력분류 _압력분류, decimal _전력량, 선택분류 _선택분류 = 선택분류.A)
        {
            var _요금 = (기본요금: 0M, 전력량요금: 0M); // 튜플 리터럴 사용해서 2개 값 저장 
            switch (_계약종별)
            {
                case 계약종별.주택용:

                    switch (_압력분류)
                    {
                        case 압력분류.저압:

                            if (_전력량 <= 200)
                            {
                                _요금.기본요금 = 910M;
                                _요금.전력량요금 = 93.3M;
                            }
                            else if (_전력량 <= 400)
                            {
                                _요금.기본요금 = 1600M;
                                _요금.전력량요금 = 187.9M;
                            }
                            else
                            {
                                _요금.기본요금 = 7300M;
                                _요금.전력량요금 = 280.6M;
                            }

                            break;
                        case 압력분류.고압:

                            break;
                        default:
                            break;
                    }

                    break;
                case 계약종별.일반용:

                    break;
                case 계약종별.산업용:

                    break;
                default:

                    break;
            }
            return _요금;
        }
    }
}
