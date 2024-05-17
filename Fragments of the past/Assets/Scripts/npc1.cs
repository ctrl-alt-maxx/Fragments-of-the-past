using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class npc1 : MonoBehaviour
{
    [SerializeField]
    private Transform _joueur;

    [SerializeField]
    private float _distance;

    [SerializeField]
    private CollectionnableEnum _objet;

    [Header("Gestion du texte")]
    [SerializeField]
    private string _texteBase;

    [SerializeField]
    private string _texteFound;

    [SerializeField]
    private GameObject _textObject;

    [SerializeField]
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _textObject.GetComponent<TextMeshProUGUI>().text = _texteBase;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        _textObject.transform.position = screenPosition + _offset;
        if (_joueur.GetComponent<ControleJoueur>()._inventaire.Contains(_objet))
        {
            _textObject.GetComponent<TextMeshProUGUI>().text = _texteFound;
        }
        _textObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textObject.SetActive(false);
    }
}
