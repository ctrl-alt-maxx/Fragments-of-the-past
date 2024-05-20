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
    private float _DistanceVision = 5.0f;

    private Animator _Animator;
    Vector2 _DirectionMouvement;

    

    // Start is called before the first frame update
    void Start()
    {
        _Animator = GetComponent<Animator>();
     
      
    }

    // Update is called once per frame
    void Update()
    {
  
        Vector2 delta = _Target.position - gameObject.transform.position;
        Vector2 _DirectionVision = delta.normalized;
        int layerMask = LayerMask.GetMask(new[] { "Joueur" });
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, _DirectionVision, _DistanceVision, layerMask);       
        Debug.DrawRay(this.gameObject.transform.position, _DirectionVision * _DistanceVision,  Color.green);

        _DirectionMouvement = _DirectionVision;


        Vector2 directionAssainie = ForceAnimationVirtualJoystick.ForceDirectionAxe(_DirectionMouvement);
        _Animator.SetFloat("LookX", directionAssainie.x);
        _Animator.SetFloat("LookY", directionAssainie.y);
        
    }



    

   
}


