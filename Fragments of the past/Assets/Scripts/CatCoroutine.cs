using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CatCoroutine : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    private Animator _Animator;

    [SerializeField]
    private float _ForceMouvement = 10.0f;

    Vector2 _DirectionMouvement;

    IEnumerator _Errer;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _Errer = Errer();
        StartCoroutine(_Errer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionAssainie = ForceAnimationVirtualJoystick.ForceDirectionAxe(_DirectionMouvement);
        _Animator.SetFloat("MouvementX", directionAssainie.x);
        _Animator.SetFloat("MouvementY", directionAssainie.y);
    }

    private void FixedUpdate()
    {
        _Rigidbody2D.AddForce(_DirectionMouvement * _ForceMouvement);
    }

    private IEnumerator Errer()
    {
        while (true)
        {




            _DirectionMouvement = Vector2.zero;
            yield return new WaitForSeconds(2.5f);
            _DirectionMouvement = new Vector2(2.0f,0.0f);
            yield return new WaitForSeconds(6.0f);
            _DirectionMouvement = new Vector2(-2.0f, 0.0f);
            yield return new WaitForSeconds(6.0f);
        }
    }
}
