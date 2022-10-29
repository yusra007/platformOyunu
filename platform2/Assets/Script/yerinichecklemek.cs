using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class yerinichecklemek : MonoBehaviour
{
    public bool aldýMi;
    private void Update()
    {
        if(aldýMi)
        {
            float spawnY = Random.Range
                          (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            transform.position = spawnPosition;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("zemin"))
    //    {
    //        float spawnY = Random.Range
    //                       (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
    //        float spawnX = Random.Range
    //            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
    //        aldýMi = true;
    //        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
    //        transform.position = spawnPosition;


    //    }

    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.CompareTag("zemin"))
        {
            aldýMi = false;
        }
       

    }

}
