using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeFollowP : MonoBehaviour
{
    public int pos = 0;
    public follow followTrns;
    public float delay = 0.03f;
    public int dist;
    public static float delaydivision = 1f;
    private void Start()
    {
        followTrns = GetComponent<follow>();
    }
    private void FixedUpdate()
    {
        if(controls.pos != pos)
        {
            dist = controls.pos - pos;
            pos = controls.pos;
            StartCoroutine(new queueNumerator(this, dist).catchup());
        }
    }
}
public class queueNumerator : MonoBehaviour
{
    private dodgeFollowP d;
    int di;
    public queueNumerator(dodgeFollowP c, int dis)
    {
        d = c;
        di = dis;
    }
    public IEnumerator catchup()
    {
        yield return new WaitForSeconds(d.delay / dodgeFollowP.delaydivision);
        d.followTrns.toFollow.Translate((di) * 4, 0, 0);
    }
}
