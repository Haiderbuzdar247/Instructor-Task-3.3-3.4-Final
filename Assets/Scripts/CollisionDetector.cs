using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Balls"))
        {
            
            int scaleBeforeCollision = (int)collision.gameObject.transform.localScale.x;
            if (scaleBeforeCollision > 2)
            {
                SoundManager.instance.scoreAdd();
                int nextScale = (int)scaleBeforeCollision / 2;
                for (int i = 0; i < 2; i++)
                {
                    
                    GameObject go = Instantiate(collision.gameObject, new Vector3(Random.Range(collision.gameObject.transform.position.x-1, collision.gameObject.transform.position.x+1), collision.gameObject.transform.position.y,2), Quaternion.identity);
                    go.transform.localScale = new Vector2(nextScale, nextScale);
                }
               
                Destroy(collision.gameObject);
                Destroy(gameObject);
                SoundManager.instance.audiostart();
            }
            else
            {
                SoundManager.instance.scoreAdd();
                SoundManager.instance.audiostart();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                return;
            }

        }

    }
}
