using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    public static bool isActivated;

    private UnityEngine.UI.Image image;
    private const float timeout = 15;  
    private float timeleft;

    void Start()
    {
        isActivated = false;
        timeleft = timeout;
        image = GetComponentInChildren<UnityEngine.UI.Image>();
    }

    void Update()
    {
        if(isActivated)
        {
            if (timeleft < 0)
            {
                this.gameObject.SetActive(false);
                GameStat.PassCheckpoint2(false);
            }
            else
            {
                GameStat.Checkpoint2Fill =
                    image.fillAmount = timeleft / timeout;
                timeleft -= Time.deltaTime;
            }
        }
    }
}
