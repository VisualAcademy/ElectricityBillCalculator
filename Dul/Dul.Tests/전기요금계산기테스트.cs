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
            var expected = 280.6M;
            var actual = _전기요금계산기.요금(계약종별.주택용, 압력분류.저압, 500M).전력량요금;
            Assert.AreEqual(expected, actual);
        }
    }
}
