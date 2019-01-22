using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class 전기요금계산기테스트
    {
        private readonly 전기요금계산기 _전기요금계산기;

        public 전기요금계산기테스트()
        {
            _전기요금계산기 = new 전기요금계산기();
        }
        /// <summary>
        /// 전기요금계산기 클래스 테스트 
        /// </summary>
        [TestMethod]
        public void 클래스_기본_테스트()
        {
            var cls = new 전기요금계산기();
            Assert.AreEqual("Dul." + nameof(전기요금계산기), cls.ToString());
        }

        [TestMethod]
        public void 주택용_저압_기본요금_테스트()
        {
            var expected = 1600M;
            var actual = _전기요금계산기.요금(계약종별.주택용, 압력분류.저압, 300M).기본요금;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 주택용_저압_전력량요금_테스트()
        {
            var _전력량 = 500M;
            var expected = 280.6M * _전력량;
            var actual = _전기요금계산기.요금(계약종별.주택용, 압력분류.저압, _전력량).전력량요금;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 주택용_고압_기본요금_테스트()
        {
            var expected = 1260M;
            var actual = _전기요금계산기.요금(계약종별.주택용, 압력분류.고압, 300M).기본요금;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 주택용_고압_전력량요금_테스트()
        {
            var _전력량 = 600M;
            var expected = 215.6M * _전력량;
            var actual = _전기요금계산기.요금(계약종별.주택용, 압력분류.고압, _전력량).전력량요금;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 일반용_갑I_전력량요금_테스트()
        {
            var _전력량 = 100M;

            var expected = 65.2M * _전력량;

            var actual = _전기요금계산기.요금(계약종별.일반용, 압력분류.저압전력, _전력량, 요금분류.갑I, 선택분류.선택II, _월: 3).전력량요금;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 일반용_갑II_전력량요금_테스트()
        {
            var _전력량 = 1M;

            var expected = 76.1M * _전력량;

            var actual = _전기요금계산기.요금(계약종별.일반용, 압력분류.고압A, _전력량, 요금분류.갑II, 선택분류.선택II, _월: 3, _시: 10).전력량요금;

            Assert.AreEqual(expected, actual);
        }
    }
}
