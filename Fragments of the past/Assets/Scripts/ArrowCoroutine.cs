using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCoroutine : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    private Animator _Animator;

    [SerializeField]
    private float _ForceMouvement = 10.0f;

    Vector2 _DirectionMouvement;

    IEnumerator _Bouger;

    // Start is called before the first frame update
    void Start()
    {
        
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Bouger = Bouger();
        StartCoroutine(_Bouger);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        _Rigidbody2D.AddForce(_DirectionMouvement * _ForceMouvement);
    }

    private IEnumerator Bouger()
    {
        while (true)
        {


            //_DirectionMouvement = Vector2.zero;
           // yield return new WaitForSeconds(2.5f);
            _DirectionMouvement = new Vector2(1.0f, 0.0f);
            yield return new WaitForSeconds(1.0f);
            _DirectionMouvement = new Vector2(-1.0f, 0.0f);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
