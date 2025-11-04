using System.Collections;
using UnityEngine;

public class PingPongTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] private float _periodTime;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _target2;

    private WaitForSeconds _delay;
     
    private void Awake()
    {
        _delay = new WaitForSeconds(_periodTime);
        _target.SetActive(false);
        _target2.SetActive(true);
        Activate();
    }
    
    public void Activate()
    {
        StartCoroutine(PingPong());
    }
    
    private IEnumerator PingPong()
    {
        while (true)
        {
            yield return _delay;
            _target.SetActive(!_target.activeSelf);
            _target2.SetActive(!_target2.activeSelf);
        }
    }
}
