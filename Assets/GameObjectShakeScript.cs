using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectShakeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameObjectShake(float duration, float magnitude, GameObject Target)
    {
        StartCoroutine(GoShake(duration, magnitude, Target));
    }

    private IEnumerator GoShake(float duration, float magnitude, GameObject target)
    {
        Vector3 pos = target.transform.position;
        var elapsed = 0f;
        while(elapsed < duration)
        {
            float x = pos.x + Random.Range(-1f, 1f) * magnitude;
            float y = pos.y + Random.Range(-1f, 1f) * magnitude;
            transform.position = pos;
            elapsed += Time.deltaTime;
            yield return null;
        }
        target.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
