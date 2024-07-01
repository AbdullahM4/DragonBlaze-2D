
using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap timer")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [Header("SFX")]
    [SerializeField] private AudioClip firetrapSound;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool triggered;
    private bool active;

    private Health playerHealth;


    private void Awake()
    {
        anim =GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if(!triggered)
            {  
                StartCoroutine(ActiveFiretrap());

            }
            if(active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
        
    }
    
    private IEnumerator ActiveFiretrap()
    {
        triggered= true;
        spriteRenderer.color = Color.red; // turn to red when activated

        //wait for delay  , active trap , turn on animation then go back to the original color
        yield return new WaitForSeconds(activationDelay);
        SoundManger.instance.PlaySound(firetrapSound);
        spriteRenderer.color = Color.white; // back to normal
        active = true;
        anim.SetBool("activated" , true);

        // wait for seconds , deactivate and reset all variables
        yield return new WaitForSeconds(activeTime);
        active= false;
        triggered= false;
        anim.SetBool("activated" , false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth= null;
        }
    }
}
