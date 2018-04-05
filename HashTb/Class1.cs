using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTb
{
    public class HashTable
    {
        public List<int> hashList;
        public List<List<Database>> hashTable;

        public class Database
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        /// <summary>
        /// Поиск индекса хэш-кода
        /// </summary>
        public int FindIndexOfHashCode(int hashCode)
        {
            return hashList.IndexOf(hashCode);
        }

        /// <summary>
        /// Получение ключа хэш-кода
        /// </summary>
        public int GetHashCodeKey (object key)
        {
            return key.GetHashCode();
        }

        /// <summary>
        /// Создание хэш-таблицы
        /// </summary>
        /// <param name="size"></param>размер данной таблицы
        public void CreateHashTable (int size)
        {
            hashTable = new List<List<Database>>(size);
            hashList = new List<int>(size);
            for (int i = 0; i < size; i++)
                hashTable.Add(new List<Database>());
        }
        /// <summary>
        /// Добовление пары в хэш-таблицу
        /// </summary>
        public void PutPair(object key, object value)
        {
            var hashCode = GetHashCodeKey(key);
            var hashIndex = FindIndexOfHashCode(hashCode);
            var keyValue = new Database { Key = key, Value = value };

            if (hashIndex == -1 && hashTable.Count > hashList.Count)
            {
                hashList.Add(hashCode);
                hashIndex = FindIndexOfHashCode(hashCode);
                hashTable[hashIndex].Add(keyValue);
                return;
            }

            foreach(var pair in hashTable[hashIndex])
            {
                if (pair.Key.Equals(key))
                    pair.Value = value;
            }
        }
        /// <summary>
        /// Получение значения по ключу
        /// </summary>
        public object GetKeyValue (object key)
        {
            var index = FindIndexOfHashCode(GetHashCodeKey(key));

            if (index == -1)
                return null;

            foreach(var pair in hashTable[index])
            {
                if (pair.Key.Equals(key))
                    return pair.Value;
            }

            return null;
        }
    }
}
