using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float vantoc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance != null)
        {
            if (BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeController>());
            }
        }
        vantoc += (BirdController.instance.score / 100);
        //Debug.Log((BirdController.instance.score / 100));
        transform.position += Vector3.left * vantoc * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
