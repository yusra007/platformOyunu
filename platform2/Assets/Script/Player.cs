using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]//Ba�ka dosyalardan ula��lamaz sadece unity aray�z�nden ula��l�r
    float speed = 10f;


    

    //Bir componente kod ile ula�mak
    
    [SerializeField]
    Rigidbody2D rb;

    public Animator anim;
    public GameObject bayrak;
    public GameObject bayrak2;

    [SerializeField]
    bool kosuyorMu = false;

    int score = 0;

    [SerializeField]
    Text scoreText/*, enIyiScore*/;

    [SerializeField]
    GameObject yenidenOynaPanel;

    [SerializeField]
    Text panelScoreText;

    public static bool oyunBasladiMi = false;

    [SerializeField]
    GameObject baslangicPanel;


    //[SerializeField]
    //AudioSource coinSes;


    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = score.ToString();
        if (GameManager.isRestart == true)
        {
            baslangicPanel.SetActive(false);
        }
        
        scoreText.text = PlayerPrefs.GetInt("skor").ToString();
       
    }
   

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (oyunBasladiMi == false)
        {
            return;
        }
        //Tu�a bas�ld� m� - ne kadar bas�l (f)
        float horizontal = Input.GetAxis("Horizontal");//-1, 0, 1

        //Y�r�me
        move(horizontal);

        //Animasyon
        animasyon(horizontal);

        //Y�n Verme
        turnMove(horizontal);



    }

    //Y�r�mek
    void move(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void animasyon(float horizontal)
    {
        if (horizontal != 0)
        {
            kosuyorMu = true;
        }
        else
        {
            kosuyorMu = false;
        }

        anim.SetBool("kosuyorMu", kosuyorMu);
    }

    //Y�n De�i�tirme
    void turnMove(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(4f, 4f, 1f);

        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Alt�n �arpan yer

        if (collision.CompareTag("Coin"))
        {
            //coinSes.Play();
            scoreCounter(collision, 1);

            //D��mana �arpan yer
        }
        else if (collision.CompareTag("Enemy"))
        {

            death();

        }
        else if (collision.CompareTag("SuperStar"))
        {
            //coinSes.Play();
            scoreCounter(collision, 5);

        }
        else if (collision.CompareTag("Chest"))
        {
            Debug.Log("d��t�");
            bayrak.SetActive(true);
            bayrak2.SetActive(false);

            //string level = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetInt("skor", score);
            StartCoroutine(NextLevelAfterWait());
            //if (level == "Level2")
            //{

            //    SceneManager.LoadScene("Level3");
            //    PlayerPrefs.SetInt("skor", score);


            //}
            //if (level == "Level3")
            //{

            //    SceneManager.LoadScene("Level4");
            //    PlayerPrefs.SetInt("skor", score);
            //}
            //else
            //{

            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //    PlayerPrefs.SetInt("skor", score);
            //}


        }
    }
    IEnumerator NextLevelAfterWait()
    {
        yield return new WaitForSeconds(2.5f);
        
        SceneManager.LoadScene("Level2");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            death();
        }
    }

    void scoreCounter(Collider2D collision, int puan)
    {
        score += puan;
        Destroy(collision.gameObject);
        scoreText.text = score.ToString();
    }

    void death()
    {
       
        Destroy(this.gameObject);
        yenidenOynaPanel.SetActive(true);
        panelScoreText.text = "Score: " + score.ToString();
    }



   

    public void oyunaBasla()
    {
        
        oyunBasladiMi = true;
        baslangicPanel.SetActive(false);
    }
   
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("skor",score);
    }



}
