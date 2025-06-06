using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHashMap : MonoBehaviour
{
    private class KeyValue
    {
        public string Key;
        public AudioClip Value;

        public KeyValue(string key, AudioClip value)
        {
            Key = key;
            Value = value;
        }
    }

    private const int SIZE = 128; // You can increase if needed
    private List<KeyValue>[] buckets;

    public CustomHashMap()
    {
        buckets = new List<KeyValue>[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            buckets[i] = new List<KeyValue>();
        }
    }

    private int GetIndex(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c;
        }
        return hash % SIZE;
    }

    public void Put(string key, AudioClip value)
    {
        int index = GetIndex(key);
        List<KeyValue> bucket = buckets[index];

        foreach (KeyValue kv in bucket)
        {
            if (kv.Key == key)
            {
                kv.Value = value; // Replace existing
                return;
            }
        }

        bucket.Add(new KeyValue(key, value)); // Add new
    }

    public AudioClip Get(string key)
    {
        int index = GetIndex(key);
        List<KeyValue> bucket = buckets[index];

        foreach (KeyValue kv in bucket)
        {
            if (kv.Key == key)
            {
                return kv.Value;
            }
        }

        Debug.LogWarning("SFX key not found: " + key);
        return null;
    }
}
