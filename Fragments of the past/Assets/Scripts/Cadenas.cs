using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour
{
    [SerializeField] private GameObject cadenaBronze;
    [SerializeField] private GameObject cadenaGris;
    [SerializeField] private GameObject cadenaOr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle1))
            {
                cadenaBronze.GetComponent<Animator>().SetBool("Unlocked", true);
            }
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle2))
            {
                cadenaGris.GetComponent<Animator>().SetBool("Unlocked", true);
            }
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle3))
            {
                cadenaOr.GetComponent<Animator>().SetBool("Unlocked", true);
            }
        }
    }
}
