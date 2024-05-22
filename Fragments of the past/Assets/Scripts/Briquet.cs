using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briquet : MonoBehaviour
{
    [SerializeField]
    private GameObject _flame;
    [SerializeField]
    private string _textePeurFeu;
    private bool _isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _isActive = !_isActive;
            EventManager.TriggerEvent(EventManager.PossibleEvent.eChangerTxtFeu,_textePeurFeu);
        }

        _flame.SetActive(_isActive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 && _isActive)
        {
            EventManager.TriggerEvent(EventManager.PossibleEvent.eLightFire, gameObject.transform.position);
            gameObject.GetComponentInParent<Animator>().SetBool("isFondue", true);
        }
    }
}
