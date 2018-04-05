using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTb;
using System.Collections.Generic;

namespace HashTableTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Добавление 3-х элементов
        public void ThreeElementsTest()
        {
            var test = new HashTable();
            test.CreateHashTable(3);
            test.PutPair(0, 070);
            test.PutPair("Ответ на вопрос вселенной", "42");
            test.PutPair("Mind", 33);

            var keys = new object[] { 0, "Ответ на вопрос вселенной", "Mind" };
            var values = new object[] { 070, "42", 33 };
            for (int i = 0; i < 3; i++)
            {
                var first = test.GetKeyValue(keys[i]);
                var second = values[i];
                if (!(first).Equals(second))
                    throw new Exception();
            }
        }

        [TestMethod]
        //Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        public void EqualsKey ()
        {
            var test = new HashTable();
            test.CreateHashTable(2);
            test.PutPair(42, "Не ответ");
            test.PutPair(42, "Ответ");
            var key = 42;
            var value = "Ответ";
            var first = test.GetKeyValue(key);
            if (!(first).Equals(value))
                throw new Exception();
        }

        [TestMethod]
        //Добавление 10000 элементов в структуру и поиск одного из них
        public void OneOf10000 ()
        {
            var size = 10000;
            var test = new HashTable();
            test.CreateHashTable(size);
            for (int i = 1; i < size; i++)
            {
                Random rnd = new Random();
                var key = i + "Ы";
                var value = rnd.Next(42, 42001);
                test.PutPair(key, value);
            }

            test.PutPair(0, 42);
            var firts = test.GetKeyValue(0);
            if (firts != null)
                if (!(firts.Equals(42)))
                    throw new Exception();
        }

        [TestMethod]
        //Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
        public void nullValues ()
        {
            var size = 10000;
            var test = new HashTable();
            test.CreateHashTable(size);
            for (int i = 0; i < size; i++)
            {
                Random rnd = new Random();
                var key = i + "Ы";
                var value = rnd.Next(42, 42001);
                test.PutPair(key, value);
            }

            for (int i = size; i < size + 1000; i++)
            {
                if (!(test.GetKeyValue(i) == null))
                    throw new Exception();
            }
        }
    }
}
