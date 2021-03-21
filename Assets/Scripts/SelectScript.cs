using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponent<Button>() != null)
        {
            this.gameObject.GetComponent<Button>().Select();
        }else if(this.gameObject.GetComponent<Selectable>() != null)
        {
            this.gameObject.GetComponent<Selectable>().Select();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
