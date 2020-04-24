using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSet : MonoBehaviour
{
    public GameObject indicator;
    public bool music_on;
    public float movespeed;
    private float t = 0.0f;
    private bool switching;
    private float onX;
    private float offX;
    private RectTransform toggle;
    private RectTransform handle;

    public void Awake(){
            toggle = indicator.GetComponent<RectTransform>();
            onX=toggle.sizeDelta.x;
            offX=onX-2;
    }

    public void ToggleMusic(){
        if(music_on){
            music_on=false;
            switching = true;
        }else {
            music_on=true;
            switching = true;
        }

    }
    void update(){
        if(switching){
            if(music_on){
                toggle.localPosition = MoveIndicator(indicator,offX,onX);
            }else{
                toggle.localPosition = MoveIndicator(indicator,onX,offX);
            }
            
        }
    }
    private Vector3 MoveIndicator(GameObject movehand,float startX,float endX){
        Vector3 position = new Vector3(Mathf.Lerp(startX,endX,t+=movespeed*Time.deltaTime),0,0);
        if(t>1){
            t=0;
            switching = false;
        }
        return position;

    }
}
