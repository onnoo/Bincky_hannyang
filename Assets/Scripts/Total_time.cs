using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Total_time : MonoBehaviour
{
    UnityEngine.UI.Text Totaltime;
    
    void Start()
    {
        Totaltime = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
            Totaltime.text = "걸린시간 : " + Player_Physics2DAndMecanim.goalTime;
    }
}
