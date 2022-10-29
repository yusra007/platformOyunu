using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meyveOlusturma : MonoBehaviour
{
    public GameObject apple;
    

    private void Start()
    {
       
        olustur();
       
    }
    public void olustur()
    {
        for (int i = 0; i < 20; i++)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(apple, spawnPosition, Quaternion.identity);

        }
    }
  

}
