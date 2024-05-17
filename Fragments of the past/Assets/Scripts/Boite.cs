using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxGrabber : MonoBehaviour
{
    private TargetJoint2D m_TargetJoint;

    private bool hasEntered = false;

    private bool isAttached = false;

    private GameObject _boite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasEntered && Input.GetKeyDown(KeyCode.T))
        {
            isAttached = true;
            m_TargetJoint = _boite.AddComponent<TargetJoint2D>();
            m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(transform.position);
        }
        if(Input.GetKeyUp(KeyCode.T))
        {
            isAttached = false;
        }
        if (isAttached)
        {
            m_TargetJoint.target = transform.position; 
        }
        else
        {
            Destroy(m_TargetJoint);
            m_TargetJoint = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            _boite = collision.gameObject;
            hasEntered = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            _boite = null;
            hasEntered = false;
        }
        
    }
}
