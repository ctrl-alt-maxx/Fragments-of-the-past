using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(Rigidbody2D))]
public class NPCRayCast : MonoBehaviour
{

    [SerializeField]
    private Transform _Target;

    [SerializeField]
    private float _ForceMouvement = 10.0f;

    [SerializeField]
    private float _DistanceVision = 5.0f;

    private Animator _Animator;
    //private Rigidbody2D _Rigidbody2D;
    Vector2 _DirectionMouvement;

    

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
        //_Rigidbody2D = GetComponent<Rigidbody2D>();

      
    }

    // Update is called once per frame
    void Update()
    {
  
        Vector2 delta = _Target.position - gameObject.transform.position;
        Vector2 _DirectionVision = delta.normalized;
        int layerMask = LayerMask.GetMask(new[] { "Obstacle", "Joueur" });
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, _DirectionVision, _DistanceVision, layerMask);
        // _BeingChassed = hit.collider && hit.collider.gameObject.layer == _Target.gameObject.layer;
        Debug.DrawRay(this.gameObject.transform.position, _DirectionVision * _DistanceVision,  Color.green);

        _DirectionMouvement = _DirectionVision;


        Vector2 directionAssainie = ForceAnimationVirtualJoystick.ForceDirectionAxe(_DirectionMouvement);
        _Animator.SetFloat("LookX", directionAssainie.x);
        _Animator.SetFloat("LookY", directionAssainie.y);
        
    }



    

   
}


