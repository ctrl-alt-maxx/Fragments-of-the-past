using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Inventaire : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;

    [SerializeField]
    private ControleJoueur _joueur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string inventaire = "Inventaire : \n";
        for (int i = 0; i < _joueur._inventaire.Count; i++)
        {
            /*
            if (_joueur._inventaire[i] == CollectionnableEnum.Cle_argent)
            {
                Instantiate
            }*/
            inventaire += _joueur._inventaire[i].ToString() + "\n";
        }
        m_TextMeshProUGUI.text = inventaire;
    }
}
