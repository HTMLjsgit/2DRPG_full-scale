using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationFinishScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationFinish()
    {
        StartCoroutine(animationStop());
    }
    IEnumerator animationStop()
    {
        yield return null;
        float r = this.gameObject.GetComponent<Image>().color.r;
        float b = this.gameObject.GetComponent<Image>().color.b;
        float g = this.gameObject.GetComponent<Image>().color.g;
        this.gameObject.GetComponent<Image>().color = new Color(r, b, g, 0);
        this.gameObject.GetComponent<Animator>().SetBool("play", false);
    }
}
