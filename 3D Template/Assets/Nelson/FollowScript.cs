using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targetObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 5 * Time.deltaTime);
    }
}
