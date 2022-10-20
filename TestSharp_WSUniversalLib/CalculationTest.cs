using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using WSUniversalLib;

namespace TestSharp_WSUniversalLib
{
    [TestClass]
    public class CalculationTest
    {
        // Добавьте библиотеку WSUniversalLib.dll участника в ссылки проекта тестирования (References).
        // https://docs.microsoft.com/ru-ru/visualstudio/ide/how-to-add-or-remove-references-by-using-the-reference-manager?view=vs-2019
        // Затем можно приступать к запуску тестов в окне Обозревателя тестов (Test Explorer).
        // Обратите внимание, что для поочередного запуска тестов разной сложности, можно использовать плейлисты (Playlist).
        private readonly Calculation classCalculation = new Calculation();

        #region Easy Test Methods
        [TestMethod]
        public void QuantityForProduct_Easy_01()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_01.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_01.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_02()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_02.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_02.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_03()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_03.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_03.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_04()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_04.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_04.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_05()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_05.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_05.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_06()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_06.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_06.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_07()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_07.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_07.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_08()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_08.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_08.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_09()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_09.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_09.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_10()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_10.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_10.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_11()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_11.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_11.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_12()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_12.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_12.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_13()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_13.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_13.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_14()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_14.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_14.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_15()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_15.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_15.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_16()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_16.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_16.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_17()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_17.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_17.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_18()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_18.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_18.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_19()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_19.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_19.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Easy_20()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Easy_20.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Easy_20.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Hard Test Methods
        [TestMethod]
        public void QuantityForProduct_Hard_01()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_01.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_01.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_02()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_02.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_02.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_03()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_03.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_03.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_04()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_04.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_04.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_05()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_05.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_05.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_06()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_06.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_06.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_07()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_07.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_07.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_08()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_08.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_08.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_09()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_09.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_09.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuantityForProduct_Hard_10()
        {
            // Arrange
            int productType, materialType, count;
            float width, length;
            ReadInputData("InputData_Hard_10.txt", out productType, out materialType, out count, out width, out length);
            int expected = ReadOutputData("OutputData_Hard_10.txt");

            // Act
            int actual = classCalculation.GetQuantityForProduct(productType, materialType, count, width, length);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        private void ReadInputData(string fileName, out int productType, out int materialType, out int count, out float width, out float length)
        {
            string path = "..\\..\\..\\TestingData\\" + fileName;
            string[] data = File.ReadAllLines(path);

            productType = int.Parse(data[0]);
            materialType = int.Parse(data[1]);
            count = int.Parse(data[2]);
            width = float.Parse(data[3].Replace('.', ','));
            length = float.Parse(data[4].Replace('.', ','));
        }

        private int ReadOutputData(string fileName)
        {
            string path = "..\\..\\..\\TestingData\\" + fileName;
            string data = File.ReadAllText(path);
            return int.Parse(data);
        }
    }
}
