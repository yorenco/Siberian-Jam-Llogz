using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishDoor : MonoBehaviour
{
    [SerializeField] private KeyType _requiredKey;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerKeyHolder playerKeyHolder))
        {
            if (playerKeyHolder.HasKey(_requiredKey) == false)
                return;
            
            GameState.Instance.GoToNextLevel();
        }
    }
}
