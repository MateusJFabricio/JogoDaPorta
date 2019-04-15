using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodarChave : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * velocidade * Time.deltaTime);
    }
}
