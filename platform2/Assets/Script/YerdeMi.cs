using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YerdeMi : MonoBehaviour
{
    public LayerMask layer;
    public bool yerdeMiyiz;
    public Rigidbody2D rb;//Player rb
    public float speed = 8f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.oyunBasladiMi == false)
        {
            return;
        }


        RaycastHit2D carpiyorMu = Physics2D.Raycast(transform.position, Vector2.down, 1f, layer);

        if (carpiyorMu.collider == null)
        {
            Debug.Log("yerde");
            //Zemine çarpýyor
            yerdeMiyiz = true;
        }
        else
        {
            Debug.Log("havada");
            //Havadayýz
            yerdeMiyiz = false;
        }


        if (yerdeMiyiz == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("boþluða basýldý");
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }



    }
}
