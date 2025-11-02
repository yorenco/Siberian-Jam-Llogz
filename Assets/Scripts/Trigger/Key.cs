using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Key : MonoBehaviour
{
    [SerializeField] private KeyType _keyType;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerKeyHolder playerKeyHolder))
            playerKeyHolder.AddKey(_keyType);
        
        Destroy(gameObject);
    }
}

public enum KeyType
{
    Base,
}