using UnityEngine;

public class fan : MonoBehaviour
{
    [SerializeField] GameObject fanoff, fanon;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            fanoff.SetActive(false);
            fanon.SetActive(true);
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }
    }
   
       
    
}
