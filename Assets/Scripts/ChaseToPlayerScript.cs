using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseToPlayerScript : MonoBehaviour
{
    GameObject Target;
    public float moveSpeed;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 TargetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, this.transform.position.z);
        TargetPosition.x = Mathf.Clamp(TargetPosition.x, minPosition.x, maxPosition.x); ;
        TargetPosition.y = Mathf.Clamp(TargetPosition.y, minPosition.y, maxPosition.y); ;
        this.transform.position = Vector3.Lerp(this.transform.position, TargetPosition, moveSpeed);
            
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
    }
}
