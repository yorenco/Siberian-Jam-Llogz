using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerHealth playerHealth))
            playerHealth.Dead();
    }
}
