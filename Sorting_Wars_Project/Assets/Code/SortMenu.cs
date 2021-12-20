using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortMenu : MonoBehaviour
{
    //===========================================================
    //Zarz¹dzanie menu 
    //===========================================================
    //Reference to parent
    [SerializeField]
    Parent parent;

    public GameObject spawner;
    private GameObject active_spawner;
    public InputField amount;
    public GameObject vader;
    private GameObject vader_active;

    public void StartSort() {

        if (active_spawner == null) { 

            if(amount.text != "")
                spawner.GetComponentInChildren<Spawner>().amount = Convert.ToInt32(amount.text);

            active_spawner = Instantiate(spawner);
            vader_active = Instantiate(vader);
            vader_active.transform.SetParent(active_spawner.transform);

            parent.Assign();
        }
    }

    public void ResetSort() => Destroy(active_spawner.gameObject);
    public void ExitApp() => Application.Quit();

}
