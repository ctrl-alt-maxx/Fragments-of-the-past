using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject _explosionVFX;
    [SerializeField]
    private Transform _Target;

    private UnityAction<object> _ExplosionTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _ExplosionTrigger = Explode;
        EventManager.StartListening(EventManager.PossibleEvent.eLightFire, _ExplosionTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Explode(object i)
    {
        Instantiate(_explosionVFX, _Target.position, Quaternion.identity);
    }

}
