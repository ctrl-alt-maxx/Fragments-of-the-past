using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum Cles
{
    Bronze,
    Gris,
    Or
}

public class Cle : MonoBehaviour
{
    [SerializeField] 
    private Cles cle;
    [SerializeField]
    private TextMeshProUGUI nbCles;
    private UnityAction<object> _action;
    private UnityAction<object> _action2;   
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);    
        _action += Afficher;
        EventManager.StartListening(EventManager.PossibleEvent.eAfficher, _action);
        _action2 += ChangeNbClesText;
        EventManager.StartListening(EventManager.PossibleEvent.eChangerNbCle, _action2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Afficher(object source)
    {
        gameObject.SetActive(true);
    }

    private void ChangeNbClesText(object source)
    {
        if((Cles)source == cle)
        {
            int nb = int.Parse(nbCles.text);
            nb--;
            nbCles.text = nb.ToString();
        }
    }

    public Cles getCle()
    {
        return cle;
    }

}
    

