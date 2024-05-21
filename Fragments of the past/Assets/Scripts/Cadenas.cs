using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour
{
    [SerializeField] private GameObject cadenaBronze;
    [SerializeField] private GameObject cadenaGris;
    [SerializeField] private GameObject cadenaOr;
    [SerializeField] private Animator joueur;
    [SerializeField] private ParticleSystem explosion;

    private bool isCle1 = false;
    private bool isCle2 = false;
    private bool isCle3 = false;


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
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle_argent))
            {
                if (!isCle1)
                    Instantiate(explosion, cadenaBronze.transform.position, Quaternion.identity);
                isCle1 = true;
                cadenaBronze.GetComponent<Animator>().SetBool("Unlocked", true);
                
            }
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle_bronze))
            {
                if(!isCle2)
                    Instantiate(explosion, cadenaGris.transform.position, Quaternion.identity);
                isCle2 = true;
                cadenaGris.GetComponent<Animator>().SetBool("Unlocked", true);
                
            }
            if (collision.gameObject.GetComponent<ControleJoueur>().getType().Contains(CollectionnableEnum.Cle_or))
            {
                if (!isCle3)
                    Instantiate(explosion, cadenaOr.transform.position, Quaternion.identity);
                isCle3 = true;
                cadenaOr.GetComponent<Animator>().SetBool("Unlocked", true);
                
            }

            if(isCle1 && isCle2 && isCle3)
            {
                joueur.SetBool("isFondue", true);
            }
        }
    }
}
