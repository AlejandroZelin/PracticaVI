using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour
{
    private GameObject personaje;
    public GameObject Setitauwu;
    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            Destroy(this.gameObject);
            Movimientos.crecer = true;
            Setitauwu.gameObject.SetActive(true);
        }
    }
}
