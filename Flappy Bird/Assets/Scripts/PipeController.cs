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
        transform.position += Vector3.left * vantoc * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
