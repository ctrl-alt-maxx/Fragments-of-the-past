using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum Cles
{
    Bronze,
    Gris,
    Or
}

public class Cle : MonoBehaviour
{
    [SerializeField] 
    private Cles cle;
    private UnityAction<object> _action;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);    
        _action += Afficher;
        EventManager.StartListening(EventManager.PossibleEvent.eAfficher, _action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Afficher(object source)
    {
        gameObject.SetActive(true);
    }
}
