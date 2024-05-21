using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebrisExplode : MonoBehaviour
{

    [SerializeField]
    private float _ForcePropulsion = 5f;
    private UnityAction<object> _ExplodeDebris;

    // Start is called before the first frame update
    void Start()
    {
        _ExplodeDebris = ExplodeDebris;
        EventManager.StartListening(EventManager.PossibleEvent.eLightFire, _ExplodeDebris);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExplodeDebris(object i)
    {
        foreach (Rigidbody2D debri in gameObject.GetComponentsInChildren<Rigidbody2D>())
        {

            debri.bodyType = RigidbodyType2D.Dynamic;
            Vector2 forceDirection = (debri.gameObject.transform.up).normalized; // get direction of launch

            debri.AddForce(forceDirection * _ForcePropulsion, ForceMode2D.Impulse); // propel the walls

        }
    }
}
