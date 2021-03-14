using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Serialize {

  [System.Serializable]
  public class TableBase<Tkey, Tvalue, Type> where Type : KeyAndValue<Tkey, Tvalue>
    {
        [SerializeField]
        private List<Type> list;
        private Dictionary<Tkey, Tvalue> table;
        public Dictionary<Tkey, Tvalue> GetTable()
        {
            if(table == null)
            {
                table = ConvertListToDictionary(list);
            }
            return table;
        }

        public List<Type> GetList()
        {
            return list;
        }

        static Dictionary<Tkey, Tvalue> ConvertListToDictionary(List<Type> list)
        {
            Dictionary<Tkey, Tvalue> dic = new Dictionary<Tkey, Tvalue>();
            foreach(KeyAndValue<Tkey, Tvalue> pair in list)
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;        }
    }

    [System.Serializable]

    public class KeyAndValue<TKey, Tvalue>
    {
        public TKey Key;
        public Tvalue Value;

        public KeyAndValue(TKey key, Tvalue value)
        {

            Key = key;
            Value = value;
        }
        public KeyAndValue(KeyValuePair<TKey, Tvalue> pair)
        {
            Key = pair.Key;
            Value = pair.Value;
        }
    }
}