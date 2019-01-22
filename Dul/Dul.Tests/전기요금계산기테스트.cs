using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dul.Tests
{
    [TestClass]
    public class 전기요금계산기테스트
    {
        /// <summary>
        /// 전기요금계산기 클래스 테스트 
        /// </summary>
        [TestMethod]
        public void 클래스기본테스트()
        {
            var cls = new 전기요금계산기();
            Assert.AreEqual("Dul." + nameof(전기요금계산기), cls.ToString());
        }
    }
}
