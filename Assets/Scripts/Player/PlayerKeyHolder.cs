using System.Collections.Generic;
using UnityEngine;


public class PlayerKeyHolder : MonoBehaviour
{
    [SerializeField] private List<KeyType> _keys = new List<KeyType>();
    
    public void AddKey(KeyType keyType)
    {
        _keys.Add(keyType);
    }
    
    public bool HasKey(KeyType keyType)
    {
        return _keys.Contains(keyType);
    }
}
