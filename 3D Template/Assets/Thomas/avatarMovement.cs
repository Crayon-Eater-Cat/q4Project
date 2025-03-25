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
    bool attack;
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
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float x2;
        float y2;
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
        //combat:
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            x = 0;
            y = 0;
            anim.SetTrigger("attack");
        }
        //checking if you can jump:
        canjump = Physics.BoxCast(transform.position, new Vector3(0, 0.1f, 0), -transform.up,Quaternion.Euler(Vector3.zero),1);
        anim.SetBool("jumping",!canjump);
        Debug.Log(canjump);
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
