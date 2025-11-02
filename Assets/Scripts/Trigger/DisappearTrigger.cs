using UnityEngine;

public class DisappearTrigger : BaseTrigger
{
    [SerializeField] private GameObject _target;
    
    private void OnEnable()
    {
        if (_target == null)
            throw new System.ArgumentNullException(nameof(gameObject) + " has no target");
        
        _target.SetActive(true);
    }
    
    public override void Activate()
    {
        _target.SetActive(false);
    }
}
