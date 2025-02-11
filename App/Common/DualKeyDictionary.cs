﻿using System.Collections;
using System.Collections.Generic;

namespace PDFPatcher.Common;

public class DualKeyDictionary<K, V> : IDictionary<K, V>
{
    private readonly Dictionary<K, V> _keyDictionary = new();
    private readonly Dictionary<V, K> _reverseDictionary = new();

    #region IEnumerable<KeyValuePair<K,V>> member

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator() =>
        ((IEnumerable<KeyValuePair<K, V>>)_keyDictionary).GetEnumerator();

    #endregion

    #region IEnumerable member

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_keyDictionary).GetEnumerator();

    #endregion

    public K GetKeyByValue(V value) => _reverseDictionary[value];

    #region IDictionary<K,V> member

    public void Add(K key, V value)
    {
        _keyDictionary.Add(key, value);
        _reverseDictionary.Add(value, key);
    }

    public bool ContainsKey(K key) => _keyDictionary.ContainsKey(key);

    public bool ContainsValue(V value) => _reverseDictionary.ContainsKey(value);

    public ICollection<K> Keys => _keyDictionary.Keys;

    public bool Remove(K key)
    {
        if (_keyDictionary.ContainsKey(key) == false)
        {
            return false;
        }

        V value = _keyDictionary[key];
        _keyDictionary.Remove(key);
        _reverseDictionary.Remove(value);
        return true;
    }

    public bool TryGetValue(K key, out V value) => TryGetValue(key, out value);

    public ICollection<V> Values => _reverseDictionary.Keys;

    public V this[K key]
    {
        get => _keyDictionary[key];
        set
        {
            Remove(key);
            Add(key, value);
        }
    }

    #endregion

    #region ICollection<KeyValuePair<K,V>> member

    public void Add(KeyValuePair<K, V> item) => Add(item.Key, item.Value);

    public void Clear()
    {
        _keyDictionary.Clear();
        _reverseDictionary.Clear();
    }

    public bool Contains(KeyValuePair<K, V> item) =>
        _keyDictionary.ContainsKey(item.Key) && _reverseDictionary.ContainsKey(item.Value);

    public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex) =>
        ((ICollection<KeyValuePair<K, V>>)_keyDictionary).CopyTo(array, arrayIndex);

    public int Count => _keyDictionary.Count;

    public bool IsReadOnly => false;

    public bool Remove(KeyValuePair<K, V> item) => Remove(item.Key);

    #endregion
}
