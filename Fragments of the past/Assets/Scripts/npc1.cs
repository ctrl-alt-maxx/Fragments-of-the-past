using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    private bool _isFirstTime = false;


    // Start is called before the first frame update
    void Start()
    {
        _textObject.GetComponent<TextMeshProUGUI>().text = _texteBase;
        _textObject.SetActive(false);
        _textObjectAction.GetComponent<TextMeshProUGUI>().text = _texteAction;
        _textObjectAction.SetActive(false);
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
                _joueur.GetComponent<ControleJoueur>()._inventaire.Remove(_objet);
                if(_isFirstTime)
                {
                    EventManager.TriggerEvent(EventManager.PossibleEvent.eAfficher, this.transform.position);
                    _textNbCles.SetActive(true);
                }
                _textObject.GetComponent<TextMeshProUGUI>().text = _texteFound;
                _textObjectAction.GetComponent<TextMeshProUGUI>().text = _texteAction2;
                _isFirstTime = true;
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
}
