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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag ("Player").transform;
        rayorigin = transform.GetChild(2);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rayorigin.LookAt(player);
        RaycastHit hit;
        if (Physics.Raycast(transform.position,rayorigin.forward,out hit,detectiondist))
        {
            if (hit.collider.gameObject.tag=="Player")
            {
                if (Vector3.Distance(transform.position,player.position)>stoppingdist)
                {
                    mode = "pursuit";
                }
                else
                {
                    mode = "attack";
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
            if (ishit==0)
            {

                anim.SetTrigger("attack");
                attacktimer = 10;
            }
        }
        if (attacktimer>0 )
        {
            attacktimer -= 1;
        }
        if (Vector3.Distance(transform.position,player.position)>=idledist)
        {
            mode = "idle";
        }
        if (ishit>0)
        {
            ishit -= 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamge(damage);
        }
    }
}
