using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarChaveDoMal : MonoBehaviour
{
    public GameObject chaveDoMal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeraChaveDoMal());
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private IEnumerator GeraChaveDoMal()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4, 10));
            var clone = Instantiate(chaveDoMal, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

  
}
