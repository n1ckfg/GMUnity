using UnityEngine;
using System.Collections;

public class ChaseTarget : MonoBehaviour {

    public GameObject target;
    public Vector3 p = new Vector3(0,0,0);
    public Vector3 t = new Vector3(0,0,0);
    public Vector3 e = new Vector3(10,10,10);

    void Start() {
    }

    void Update() {
        beginUpdate();
        p = tween3D(p,t,e);

        if(hitDetect3D(p,new Vector3(0.5f,0.5f,0.5f),t,new Vector3(0.5f,0.5f,0.5f))){
            t = randomizer(5);
        }

        endUpdate();
    }

    void beginUpdate(){
        t = transform.position; //this object's position
        p = target.transform.position; //the target's position
    }

    void endUpdate(){
        transform.position = t;
        target.transform.position = p;        
        Debug.Log("this: " + p + "   target: " + t);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    Vector3 tween3D(Vector3 v1, Vector3 v2, Vector3 e) {
        v1.x += (v2.x-v1.x)/e.x;
        v1.y += (v2.y-v1.y)/e.y;
        v1.z += (v2.z-v1.z)/e.z;
        return v1;
    }

    Vector3 randomizer(float spread){
        float x = Random.Range(-1f * spread, spread);
        float y = Random.Range(-1f * spread, spread);
        float z = Random.Range(-1f * spread, spread);
        Vector3 r = new Vector3(x,y,z);   
        return r;     
    }

    //3D Hit Detect.  Assumes center.  xyz, whd of object 1, xyz, whd of object 2.
    bool hitDetect3D(Vector3 p1, Vector3 s1, Vector3 p2, Vector3 s2) {
    s1.x /= 2;
    s1.y /= 2;
    s1.z /= 2;
    s2.x /= 2;
    s2.y /= 2; 
    s2.z /= 2; 
    if (  p1.x + s1.x >= p2.x - s2.x && 
          p1.x - s1.x <= p2.x + s2.x && 
          p1.y + s1.y >= p2.y - s2.y && 
          p1.y - s1.y <= p2.y + s2.y &&
          p1.z + s1.z >= p2.z - s2.z && 
          p1.z - s1.z <= p2.z + s2.z
      ) {
      return true;
    } 
    else {
      return false;
    }
    }

}