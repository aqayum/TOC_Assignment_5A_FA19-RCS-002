using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class PlayerController : MonoBehaviour
{
    //  public GameObject pickup;
    // public TextMeshProGUI textdisplay;
    public float speed;
    public Text countText;
    public Text Finalpalindrome;

    //   public Text winText;

    public GameObject Playbutton;
    public GameObject player;
    private Rigidbody rb;
    private int count;
    public GameObject panel;
    public GameObject panel1;
    public SoundManager soundManager;


    private float ballRadius = 1f; //radius of ball to check the position in/out of road


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        //  winText.text = "";
        ballRadius = GetComponent<Renderer>().bounds.size.x / 3; //calculate radius
        panel.SetActive(false);
        panel1.SetActive(false);
        player.SetActive(false);
        Playbutton.SetActive(true);

    }
    void Update()
    {
        CheckPosition();
    }
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    RaycastHit hit;
    void CheckPosition()
    {
        if (!Physics.SphereCast(transform.position, ballRadius, Vector3.down, out hit, 100f))
        {
            panel.SetActive(true);
            player.SetActive(false);
            Debug.Log("Game Over");

        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= CreateBlocks.com)
        {
            //  winText.text = "You Win!";
            //  textdisplay.enabled = false; 
            panel1.SetActive(true);
            Finalpalindrome.text = "which are " + count.ToString();
            player.SetActive(false);
        }
    }

    public static bool IsPalindrome(string text)
    {
        if (text.Length <= 1)
            return true;
        else
        {
            if (text[0] != text[text.Length - 1])
                return false;
            else
                return IsPalindrome(text.Substring(1, text.Length - 2));
        }
    }
    public void playgame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Startgame()
    {
        player.SetActive(true);
        Playbutton.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pick Up"))
        {

            //   other.gameObject.SetActive(false);
            //   count = count + 1;
            //   SetCountText();

            string value = collision.gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text.ToString();
            if (IsPalindrome(value))
            {
                soundManager.PlaySound(soundManager.clickSound);
                collision.gameObject.SetActive(false);

                Debug.Log("pelendrom>>" + value);
                count++;
                SetCountText();
            }

            else
            {
                collision.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>().Play();

            }
        }
    } }
    

