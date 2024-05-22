using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosionTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject _explosionVFX;

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

    private void Explode(object source)
    {
        Instantiate(_explosionVFX, (Vector3)source, Quaternion.identity);
    }

}
