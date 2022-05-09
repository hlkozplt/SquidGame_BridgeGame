using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character_controller : MonoBehaviour
{
    public Transform player;
    float sinir;
    public float donmehizi;
    public AudioSource cigliksesi;
    public AudioSource gerilim_muzigi;
    public GameObject kaybettin_pnl;
    public GameObject kazandýn_pnl;
    Animator anim;
    public Rigidbody rigi;
    [SerializeField, Range(1, 2000)] float ileri = 5;
    [SerializeField, Range(1, 1000)] float hoplat = 5;






    private void Start()
    {
        anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked; bu kod mause imlecini gizliyor.
        cigliksesi = GetComponent<AudioSource>();
        gerilim_muzigi = GetComponent<AudioSource>();

        

  
    }

    void Update()
    {      
        hareket();
        float yan = Input.GetAxisRaw("Mouse X") * Time.deltaTime * donmehizi;       
        player.Rotate(Vector3.up * yan);

      
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
           
            kaybettin_pnl.SetActive(true);
            Time.timeScale = 0.0f;
            
        }
        if (collision.gameObject.name == "bitis")
        {

            kazandýn_pnl.SetActive(true);
            Time.timeScale = 0.0f;

        }
    }

    public void try_again_btn()
    {
        SceneManager.LoadScene("Scenes/bolum_1");
        Time.timeScale = 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kirilan")
        {
            cigliksesi.Play();

        }
    }
    void hareket ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            anim.SetBool("ziplama", true);
            rigi.AddForce(0, hoplat, 0, ForceMode.Impulse);
        }
        else
        {
            anim.SetBool("ziplama", false);
        }
       
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward *ileri * Time.deltaTime); 
            anim.SetBool("yurume", true);
        }
        else
        {
            anim.SetBool("yurume", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * ileri * Time.deltaTime);
            anim.SetBool("geri", true);
        }
        else
        {
            anim.SetBool("geri", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * ileri * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * ileri * Time.deltaTime);

        }

    }
   

}
