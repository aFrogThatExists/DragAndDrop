using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject TiedObject {private set; get;}
    
    void Awake() {
        TiedObject = null;
    }
    public bool tieMouse(GameObject gameObject)
    {
        if(TiedObject != null){
            return false;
        }
        TiedObject = gameObject;
        return true;
    }
    public void untieMouse(GameObject gameObject)
    {
        if(TiedObject == gameObject)
        {
            TiedObject = null;
        }

    }

}
