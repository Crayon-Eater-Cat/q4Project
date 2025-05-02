using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public float damage;
    public NavMeshAgent enemy;
    public Transform player;
    private WaveSpawner waveSpawner;
    string mode;
    Transform rayorigin;
    public float idledist;
    public float stoppingdist;
    public float detectiondist;
    float attacktimer;
    Animator anim;
    float ishit=0;

    public float initialhealth;
    float health;

    public SphereCollider sc;

    float attackcollider;

    float attacking;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = initialhealth;
        player = GameObject.FindWithTag ("Player").transform;
        rayorigin = transform.GetChild(2);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("enemy health: "+health);


        rayorigin.LookAt(player);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,rayorigin.forward,out hit,detectiondist))
        {
            if (hit.collider.gameObject.tag=="Player"&&mode!="death")
            {
                if (Vector3.Distance(transform.position,player.position)>stoppingdist)
                {
                    mode = "pursuit";
                }
                else
                {
                    mode = "attack";

                    transform.LookAt(player.position);
                    transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                }
            }
        }

        enemy.SetDestination(player.position);
        if (mode=="pursuit") 
        {
            enemy.isStopped = false;
            anim.SetBool("running",true);
        }
        else
        {
            enemy.isStopped = true;
            anim.SetBool("running", false);
        }
        if (attacktimer<=0 && mode == "attack")
        {
            if (ishit==0&&health>0)
            {
                anim.SetTrigger("attack");
                attacktimer = 10;
                attacking = 5;
            }
        }
        if (attacktimer>0 )
        {
            attacktimer -= 1;
        }

        if (attacking>0)
        {
            attacking -= 1;
        }

        anim.SetBool("attacking",attacking>0);
        sc.enabled = attacking > 0;

        if (Vector3.Distance(transform.position,player.position)>=idledist&&health>0)
        {
            mode = "idle";
        }
        if (ishit>0)
        {
            ishit -= 1;
        }
        else
        {
            anim.SetBool("hit", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamge(damage);
        }
        if (other.CompareTag("attack"))
        {

            Debug.Log("struck");
            if (health>=0)
            {
                anim.SetBool("hit", true);
                health -= 5;
                ishit = 50;
                Debug.Log(health);
                if (health<=0)
                {
                    anim.SetBool("death", true);
                    attacking = 0;
                    mode = "death";
                    Invoke("SelfDestruct", 7f);
                }
            }
        }
    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
