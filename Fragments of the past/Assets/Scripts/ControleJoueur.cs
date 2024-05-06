using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class ControleRobin : MonoBehaviour
{

    private Animator AnimatorJoueur;
    private Rigidbody2D Rigidbody;

    private float ControleX;
    private float ControleY;

    [SerializeField]
    private float QuantiteForce;

    [SerializeField]
    private float VitesseMaximum;

    private int _LastFrameCountFire = -1;

    private bool _PeutMarcher = true;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorJoueur = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControleX = Input.GetAxis("Horizontal");
        ControleY = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(ControleX, ControleY);
        float longueurDirection = direction.magnitude;
        if (longueurDirection > 0.1f && _PeutMarcher)
        { 
            Vector2 directionAssainie = ForceAnimationVirtualJoystick.ForceDirectionAxe(direction);
            AnimatorJoueur.SetFloat("x", directionAssainie.x);
            AnimatorJoueur.SetFloat("y", directionAssainie.y);
        }
        float vitesse = Rigidbody.velocity.magnitude;
        AnimatorJoueur.SetFloat("vitesse", vitesse);
 
    }

    private void FixedUpdate()
    {
        if (_PeutMarcher)
        {
            float vitesseActuelle = Rigidbody.velocity.magnitude;
            if (vitesseActuelle < VitesseMaximum)
            {
                Rigidbody.AddForce(new Vector2(ControleX, ControleY) * QuantiteForce);
            }
        }
        else
        {
            Rigidbody.velocity = Vector2.zero;
        }
    }

    public void PeutMarcher()
    {
        _PeutMarcher = true;
    }

    public void Stop()
    {
        _PeutMarcher = false;
    }

}


