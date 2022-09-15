using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphonesMSGScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivatePanel", 4f);
    }

    public void DeactivatePanel()
    {
        this.gameObject.SetActive(false);
    }

}
