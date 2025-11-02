using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public event Action OnPlayerDeath;
    
    public void Dead()
    {
        OnPlayerDeath?.Invoke();
        Debug.Log("Player Dead");
    }
}
