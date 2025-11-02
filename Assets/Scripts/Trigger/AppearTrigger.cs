using UnityEngine;

public class AppearTrigger : BaseTrigger
{
    [SerializeField] private GameObject _target;
    
    private void OnEnable()
    {
        if (_target == null)
            throw new System.ArgumentNullException(nameof(gameObject) + " has no target");
        
        _target.SetActive(false);
    }
    
    public override void Activate()
    {
        _target.SetActive(true);
    }
}
