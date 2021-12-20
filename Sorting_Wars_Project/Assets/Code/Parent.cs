using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parent : MonoBehaviour
{
    //======================================================
    //Parent Script gets references to all GameObjects and
    //exchanges data between scripts
    //======================================================

    //Reference to all scripts
    internal Timer time_script;
    public SortMenu menu_script;
    internal AI ai_script;
    internal Spawner spawner_script;

    //Components for Timer
    public Text timer_text;

    //Components for AI & Spawner
    public Transform target;
    public Camera cam;
    public Text comparison_field;
    public Dropdown dropdown;

    public void Assign()
    {
        ai_script = FindObjectOfType<AI>();
        spawner_script = FindObjectOfType<Spawner>();
        time_script = FindObjectOfType<Timer>();
    }


}
