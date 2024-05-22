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

    private void ExplodeDebris(object source)
    {
        foreach (Rigidbody2D debri in gameObject.GetComponentsInChildren<Rigidbody2D>())
        {

            Vector2 direction = gameObject.transform.position - (Vector3)source;

            debri.AddForce(direction.normalized * _ForcePropulsion, ForceMode2D.Impulse); 

        }
    }
}
