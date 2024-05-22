using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class npc1 : MonoBehaviour
{
    [SerializeField]
    private Transform _joueur;

    [SerializeField]
    private CollectionnableEnum _objet;

    [Header("Gestion du texte")]
    [SerializeField]
    private string _texteBase;

    [SerializeField]
    private string _texteFound;

    [SerializeField]
    private string _texteAction;

    [SerializeField]
    private string _texteAction2;

    [SerializeField]
    private GameObject _textObject;

    [SerializeField]
    private GameObject _textObjectAction;

    [SerializeField]
    private GameObject _textNbCles;

    [SerializeField]
    private Vector3 _offset;


    private bool _isOnScreen = false;
    private bool _isFirstTime = true;
    private UnityAction<object> _action;


    // Start is called before the first frame update
    void Start()
    {
        _textObject.GetComponent<TextMeshProUGUI>().text = _texteBase;
        _textObject.SetActive(false);
        _textObjectAction.GetComponent<TextMeshProUGUI>().text = _texteAction;
        _textObjectAction.SetActive(false);

        _action += PeurDuFeu;
        EventManager.StartListening(EventManager.PossibleEvent.eChangerTxtFeu, _action);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isOnScreen)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            _textObject.transform.position = screenPosition + _offset;
            if (_joueur.GetComponent<ControleJoueur>()._inventaire.Contains(_objet))
            {
                if(_isFirstTime)
                {
                    EventManager.TriggerEvent(EventManager.PossibleEvent.eAfficher, this.transform.position);
                }
                _joueur.GetComponent<ControleJoueur>()._inventaire.Remove(_objet);
                _textObject.GetComponent<TextMeshProUGUI>().text = _texteFound;
                _textObjectAction.GetComponent<TextMeshProUGUI>().text = _texteAction2;
                _isFirstTime = false;
                if(_textNbCles !=  null)
                {
                    _textNbCles.SetActive(true);
                }
                
            }
            _textObjectAction.SetActive(true);
        }
        _textObject.SetActive(_isOnScreen);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
           _isOnScreen = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isOnScreen= false;
        }
    }

    private void PeurDuFeu(object source)
    {
        _texteBase = (string)source;
    }
}
