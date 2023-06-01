using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void TopMap()
    {
        Vector3 nowPosition = this.transform.position;
        Vector3 target = new Vector3(nowPosition.x, nowPosition.y + 10.5f, nowPosition.z);
        transform.position =  Vector3.Lerp(transform.position, target, 1.0f);
    }

    public void BottomMap()
    {
        Vector3 nowPosition = this.transform.position;
        Vector3 target = new Vector3(nowPosition.x, nowPosition.y - 10.5f, nowPosition.z);
        transform.position =  Vector3.Lerp(transform.position, target, 1.0f);
    }

    public void LeftMap()
    {
        Vector3 nowPosition = this.transform.position;
        Vector3 target = new Vector3(nowPosition.x - 23f, nowPosition.y, nowPosition.z);
        transform.position =  Vector3.Lerp(transform.position, target, 1.0f);
    }

    public void RightMap()
    {
        Vector3 nowPosition = this.transform.position;
        Vector3 target = new Vector3(nowPosition.x + 23f, nowPosition.y, nowPosition.z);
        transform.position =  Vector3.Lerp(transform.position, target, 1.0f);
    }
}
