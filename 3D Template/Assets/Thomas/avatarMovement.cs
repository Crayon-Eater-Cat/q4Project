using UnityEngine;

public class avatarMovement : MonoBehaviour
{
    Rigidbody rb;
    public float mildinjuryseverity;
    public float criticalinjuryseverity;
    public float jumpforce;
    public float setspeed;
    float speed;
    public float camspeed;
    float angle;
    float camangle;
    Animator anim;
    public Transform cam;
    Transform campivot;
    public bool canjump;
    public bool mousecontrolled;
    public float invincibilityDuration;

    public KeyCode attackkey;

    bool attack;
    float timer;

    float x;
    float y;

    float x2;
    float y2;

    public HealthBar hb;

    public string enemyattacktag;

    bool invincible=false;

    float invintimer;

    public SphereCollider sc;

    bool dead=false;

    PlayerStats ps;

    string mode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mode = "standard";
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        campivot = transform.GetChild(2);

        ps = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ps.GetHealth());

        sc.enabled = attack;
        //get axis:
        if (!dead)
        {
            if (!attack)
            {

                x = Input.GetAxisRaw("Horizontal");
                y = Input.GetAxisRaw("Vertical");
            }
            if (!mousecontrolled)
            {

                x2 = Input.GetAxis("Horizontal2");
                y2 = Input.GetAxis("Vertical2");
            }
            else
            {
                x2 = Input.GetAxis("Mouse X");
                y2 = Input.GetAxis("Mouse Y");
            }
        }
        else
        {
            x = 0;
            y = 0;
            x2 = 0;
            y2 = 0;
        }

        //animation:
        if (x != 0 || y != 0)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        //direct person:
        if (y>0)
        {
            angle = campivot.rotation.eulerAngles.y;
        }
        if (y < 0)
        {
            angle = campivot.rotation.eulerAngles.y-180;
        }
        if (x>0)
        {
            angle = campivot.rotation.eulerAngles.y-90;
        }
        if (x < 0)
        {
            angle = campivot.rotation.eulerAngles.y + 90;
        }
        if (x>0&&y > 0)
        {
            angle = campivot.rotation.eulerAngles.y-45;
        }
        if (x>0&&y < 0)
        {
            angle = campivot.rotation.eulerAngles.y - 135;
        }
        if (x < 0&&y>0)
        {
            angle = campivot.rotation.eulerAngles.y + 45;
        }
        if (x < 0&&y<0)
        {
            angle = campivot.rotation.eulerAngles.y + 135;
        }

        //attackbox:
        transform.GetChild(3).GetComponent<SphereCollider>().enabled=attack;

        //checking if you can jump:
        canjump = Physics.BoxCast(transform.position, new Vector3(0, 1, 0), -transform.up, Quaternion.Euler(Vector3.zero), 1);
        anim.SetBool("jumping", !canjump);
        //combat:
        if (Input.GetKeyDown(attackkey)&&!attack&&canjump&&!dead)
        {
            attack = true;
            timer = 5;
        }
        if (attack)
        {
            timer -= 1;
            x = 0;
            y = 0;
        }
        if (timer<=0)
        {
            attack = false;
        }
        if (mode == "standard")
        {
            speed = setspeed;
        }
        else if (mode=="swift")
        {
            speed = setspeed * 2;
        }
        anim.SetBool("attackbool", attack);
        //________
        //jump:
        if (Input.GetKeyDown(KeyCode.Space)&&canjump)
        {
            rb.AddForce(transform.up*jumpforce);
        }
        //movement/rotation:
        camangle += camspeed * x2;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);
        campivot.rotation = Quaternion.Euler(0,camangle,0);

        Vector3 movementvel = -transform.right * Mathf.Abs(y) * speed+ -transform.right * Mathf.Abs(x) * speed;
        rb.linearVelocity = new Vector3(movementvel[0],rb.linearVelocity.y,movementvel[2]);
        if (invintimer>0)
        {
            invintimer -= 1;
        }
        if (invintimer<=0)
        {
            invincible = false;
        }
    }
    public string GetMode()
    {
        return mode;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag==enemyattacktag&&!invincible)
        {
            invincible = true;
            if (mode=="standard")
            {
                ps.DecreaseHealth(mildinjuryseverity);
            }
            else if (mode=="swift")
            {
                ps.DecreaseHealth(criticalinjuryseverity);
            }
                
            invintimer = invincibilityDuration;
            anim.SetTrigger("hit");
            if (ps.GetHealth()<=0)
            {
                anim.SetTrigger("dead");
                dead = true;
            }
        }
    }
}
