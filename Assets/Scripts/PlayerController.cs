using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private Animator playerAnimator;
    public GameObject fireball;
    public float speed = 40.0f;
    public AudioSource gameplay;
    private bool gameover = false;
    public GameObject destroyParticle;
    private SoundManager scorepoints;
    // Start is called before the first frame update
    
    // Update is called once per frame
    private void Start()
    {

        scorepoints = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (!gameover)
        {
            transform.Translate(Vector3.right * horizontal * playerSpeed * Time.deltaTime);
        }
       
        if (horizontal != 0 && !gameover)
        {
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                playerAnimator.SetTrigger("Walk");
        }
        else
        {
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !gameover)

                playerAnimator.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.Space) && !gameover)
        {
            if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"));
            {
                playerAnimator.SetTrigger("Attack");
                Instantiate(fireball, transform.position, transform.rotation);
                SoundManager.instance.audiostart();

            }

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balls") && !gameover)
        {
            SoundManager.instance.healthplayer();
            if (scorepoints.life <= 0)
            {
                gameover = true;
                Debug.Log("gameover");
                playerAnimator.SetTrigger("Death");
                Destroy(collision.gameObject);
                Instantiate(destroyParticle, collision.gameObject.transform.position, Quaternion.identity);
            }   
        }
        else if (collision.gameObject.CompareTag("Health") && !gameover)
        {
            SoundManager.instance.Gainhealth();
            Destroy(collision.gameObject);
        }

        

    }


}
