using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Luciole : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Rigidbody2D rb;
    private Vector2 _direction;
    IEnumerator _Voler;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _Voler = Voler();
        StartCoroutine(_Voler);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(_direction * force);
    }

    private IEnumerator Voler()
    {
        while (true)
        {
            _direction = Random.insideUnitCircle.normalized;
            yield return new WaitForSeconds(Random.Range(1,5));
        }
    }
}
