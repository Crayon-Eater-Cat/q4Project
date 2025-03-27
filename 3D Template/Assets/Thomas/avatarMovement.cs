using UnityEngine;

public class avatarMovement : MonoBehaviour
{
    Rigidbody rb;
    public float jumpforce;
    public float speed;
    public float camspeed;
    float angle;
    float camangle;
    Animator anim;
    public Transform cam;
    Transform campivot;
    bool canjump;
    public bool mousecontrolled;

    public KeyCode attackkey;

    bool attack;
    float timer;

    float x;
    float y;

    float x2;
    float y2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        campivot = transform.GetChild(2);
    }

    // Update is called once per frame
    void Update()
    {
        //get axis:
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
        transform.GetChild(3).GetComponent<BoxCollider>().enabled=attack;

        //checking if you can jump:
        canjump = Physics.BoxCast(transform.position, new Vector3(0, 1, 0), -transform.up, Quaternion.Euler(Vector3.zero), 1);
        anim.SetBool("jumping", !canjump);
        //combat:
        if (Input.GetKeyDown(attackkey)&&!attack&&canjump)
        {
            attack = true;
            timer = 150;
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
    }
}
