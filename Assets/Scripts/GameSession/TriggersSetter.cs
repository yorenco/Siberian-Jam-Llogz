using System.Collections.Generic;
using UnityEngine;

public class TriggersSetter : MonoBehaviour
{
    private void Start()
    {
        if(GameState.Instance.HasDrawingColliders)
            SetTriggersVisible();
    }
    
    private void SetTriggersVisible()
    {
        List<BaseTrigger> triggers = new List<BaseTrigger>(GetComponentsInChildren<BaseTrigger>());
        
        foreach (BaseTrigger trigger in triggers)
        {
            trigger.SetCollidersVisibility(true);
        }
    }
}
