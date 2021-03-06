﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            decimal _전력량 = 500M;
            //var expected = 280.6M * _전력량;
            decimal expected = (200M * 93.3m) + (200M * 187.9m) + (_전력량 - 400M) * 280.6M;
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
            decimal _전력량 = 500M;
            decimal expected = (200M * 78.3m) + (200M * 147.3m) + (_전력량 - 400M) * 215.6M;
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

        [TestMethod]
        public void 일반용_을_전력량요금_테스트()
        {
            var _전력량 = 1M;

            var expected = 78.5M * _전력량;

            var actual = _전기요금계산기.요금(계약종별.일반용, 압력분류.고압B, _전력량, 요금분류.을, 선택분류.선택II, _월: 3, _시: 12).전력량요금;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 산업용_을_고압B_선택III_여름철_중간부하_전력량요금_테스트()
        {
            var _전력량 = 1M;

            var expected = 106.8M * _전력량;

            var actual = _전기요금계산기.요금(계약종별.산업용, 압력분류.고압B, _전력량, 요금분류.을, 선택분류.선택III, _월: 7, _시: 9).전력량요금;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 전기요금계산기_클래스를_사용하여_특정_조건에_맞는_기본요금_또는_전력량요금()
        {
            전기요금계산기 my = new 전기요금계산기();

            decimal 킬로와트시 = 115.9M * 1M; 

            decimal _전력량요금 = my.요금(계약종별.일반용, 압력분류.고압A, 1, 요금분류.갑I, 선택분류.선택I, 6, 9).전력량요금;

            Assert.AreEqual(킬로와트시, _전력량요금);
        }

        [TestMethod]
        public void 전기요금계산기_월별요금_메서드_주택용_테스트()
        {
            전기요금계산기 calc = new 전기요금계산기();

            Dictionary<int, double> pairs = new Dictionary<int, double>();
            pairs.Add(1, 100); 

            var actual = calc.월별요금(pairs, 계약종별.주택용, 압력분류.고압, 요금분류.갑I, 선택분류.A);

            Assert.AreEqual(8560, actual[1]);
        }
    }
}
