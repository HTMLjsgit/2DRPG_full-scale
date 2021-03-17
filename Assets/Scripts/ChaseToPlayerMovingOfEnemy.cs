using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChaseToPlayerMovingOfEnemy : MonoBehaviour
{
    public GameObject Target;
    float x;
    float y;
    float rad;
    public float speed;
    Rigidbody2D rigid;
    private Vector2 chaseToPosition;
    public static ChaseToPlayerMovingOfEnemy chase;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       // Target = PlayerGetScript.player_get.gameObject;
        SceneManager.sceneLoaded += SceneLoaded;
        Target = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    private void Awake()
    {
        chase = this;

    }
    // Update is called once per frame
    void Update()
    {
        chaseToPosition = this.transform.position;
        if (Vector2.Distance(Target.transform.position, this.transform.position) > 0.1f && Vector2.Distance(Target.transform.position, this.transform.position) < 1.5f)
        {
            rad = Mathf.Atan2(
                Target.transform.position.y - this.transform.position.y,
                Target.transform.position.x - this.transform.position.x);
            chaseToPosition.x += Mathf.Cos(rad) * speed;
            chaseToPosition.y += Mathf.Sin(rad) * speed;
            x = this.transform.position.x - Target.transform.position.x;
            y = this.transform.position.y - Target.transform.position.y;
            anim.SetFloat("x", x * -1);
            anim.SetFloat("y", y * -1);

            rigid.MovePosition(chaseToPosition);
        }

    }
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if(nextScene.name == "Map1")
        {
            Target = GameObject.FindGameObjectWithTag("Player").gameObject;

        }
    }
    float GetAim(Vector2 me, Vector2 target)
    {
        float rad2 = Mathf.Atan2(
          me.x - target.x,
          me.y - target.y
        );
        return rad2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
