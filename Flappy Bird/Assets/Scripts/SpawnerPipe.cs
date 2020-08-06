using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // IEnumerator de co the delay (giong future trong dart de cos yield)
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);// trong 1 giay tao ra 1 cai pipe
        Vector3 temp = pipeObject.transform.position;
        temp.y = Random.Range(-2f, 3f);
        Instantiate(pipeObject, temp, Quaternion.identity);// sinh ra
        StartCoroutine(Spawner());// chay lai chinh no
    }

    // xu ly va cham neu co tick IsTrigger thi dung OnTriggerEnter2D, ko thi dung OnCollisionEnter2D


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sang")
        {
            Destroy(this);
        }
    }
    
}
