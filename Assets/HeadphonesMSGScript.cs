using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphonesMSGScript : MonoBehaviour
{
    public static bool FirstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        if (FirstTime)
        {
            Invoke("DeactivatePanel", 4f);
            FirstTime = false;
        }
        else
        {
            DeactivatePanel();
        }
    }

    public void DeactivatePanel()
    {
        this.gameObject.SetActive(false);
    }

}
