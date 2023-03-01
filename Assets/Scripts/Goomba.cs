using UnityEngine;

public class Goomba : MonoBehaviour
{

    
    public Sprite flatSprite;
    public int health = 1; // The amount of health the enemy has

  

    private void OnMouseDown()
    {
        // Reduce the enemy's health by 1
        health--;

        // Check if the enemy's health has reached 0
        if (health <= 0)
        {
           
            Hit();
            EnemySpawner.Instance.addPoint();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.starpower)
            {
                Hit();

            }
            else if (collision.transform.DotTest(transform, Vector2.down))
            {
                Flatten();

            }
            else
            {
                player.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
 
    }

    private void Hit()
    {
        
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
 
    }

}
