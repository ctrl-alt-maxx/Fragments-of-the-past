using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ExplosionMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private Vector2 max;
    private IEnumerator _Exploser;
    // Start is called before the first frame update
    void Start()
    {
        _Exploser = Exploser();
        StartCoroutine(Exploser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Exploser()
    {
        while (true)
        {
            print("aaaa");
            float rndX = Random.Range(0, max.x);
            float rndY = Random.Range(0, max.y);
            Instantiate(_explosion, new Vector2(rndX, rndY), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
