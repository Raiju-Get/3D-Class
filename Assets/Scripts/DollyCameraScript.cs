using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyCameraScript : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField]  AnimationCurve curve;
    [Range(0,1)]
    [SerializeField] float distance;
    [SerializeField] float finalPosToBe;
    [SerializeField] float currentPos;
    [SerializeField] float startingPos=0;
    [Range(0,1)]
    [SerializeField] float zoomTime;
    [SerializeField] int finalPrio = 11;
    [SerializeField] int startingPrio = 0;
    [SerializeField] float tempPos;
    [SerializeField] bool active;
    [Range(0, 1)]
    [SerializeField] float offsetTime;
    [Range(0,5)]
    [SerializeField] float disableTimer;



    private void Awake()
    {
        if (cam != null)
        {
            cam.Priority = finalPrio;
            cam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = startingPos;

            Invoke(nameof(Activate), 0.3f);
        }
    }

    void Activate()
    {
        active = true;
    }

    private void Update()
    {
        if (cam != null&& active)
        {
            currentPos = Mathf.MoveTowards(currentPos, distance, zoomTime*Time.deltaTime);
            tempPos = Mathf.Lerp(startingPos, finalPosToBe, curve.Evaluate(currentPos));
            cam.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = tempPos;
            if (tempPos >= (finalPosToBe - offsetTime))
            {
                ChangeCamera();
                active= false;
            }
        }
    }
    public void ChangeCamera()
    {
        if (cam != null)
        {       
            cam.Priority= startingPrio;
           
        }

        Invoke(nameof(DisableThis), disableTimer);
    }

    public void DisableThis()
    {
      
        this.gameObject.SetActive(false);

    }

   
}
