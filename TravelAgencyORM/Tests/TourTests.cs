namespace Tests
{
    using System;
    using NUnit.Framework;
    using Domain;

    [TestFixture]
    public class PacientTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            var client = new Client(1, "Игнатов", "Александр", "25.03.1976", "4718 190567", "Андреевич", "8708691914100201");
            var tour = new Tour(1, "Египет", "Каир", "80.000 руб.", client);
            var expected = "Египет, Каир, 80.000 руб., Фамилия: Игнатов, Имя: Александр, Отчество (при наличии): Андреевич, " +
                "Дата рождения: 25.03.1976, Паспорт: 4718 190567, Загранпаспорт (при наличии): 8708691914100201";

            var actual = tour.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptyClient_Success()
        {
            var tour = new Tour(1, "Беларусь", "Минск", "60.000 руб.");
            var expected = "Беларусь, Минск, 60.000 руб.,";

            var actual = tour.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptyClients_Success()
        {
            Assert.DoesNotThrow(() => _ = new Tour(1, "Беларусь", "Минск", "60.000 руб."));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        public void Ctor_WrongDataNullNameEmptyClients_Fail(string wrongCountry)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Tour(1, wrongCountry, "Минск", "60.000 руб."));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        public void Ctor_WrongDataNullNameEmptyClient_Fail(string wrongCountry)
        {
            var client = new Client(1, "Игнатов", "Александр", "25.03.1976", "4718 190567", "Андреевич", "8708691914100201");

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Tour(1, wrongCountry, "Минск", "60.000 руб."));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            var client = new Client(1, "Игнатов", "Александр", "25.03.1976", "4718 190567", "Андреевич", "8708691914100201");

            Assert.DoesNotThrow(() => _ = new Tour(1, "Египет", "Каир", "80.000 руб.", client));
        }
    }
}

