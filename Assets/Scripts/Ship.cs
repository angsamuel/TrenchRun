using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{

    [SerializeField] float boundary = 5f;
    [SerializeField] float speed = 1f;
    [SerializeField] float yawSpeed = 1f;
    [SerializeField] float settleSpeed = 1f;
    [SerializeField] Transform yawTransform;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Obstacle")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Move(float x){
        float movement = x*speed*Time.deltaTime;
        Debug.Log(movement);
        yawTransform.localEulerAngles -= new Vector3(0,0,1) *x*yawSpeed*Time.deltaTime;
        if(x == 0){
            yawTransform.rotation = Quaternion.Slerp(yawTransform.rotation, Quaternion.identity, settleSpeed*Time.deltaTime);
        }
        if(transform.position.x + movement > boundary){
            return;
        }
        if(transform.position.x + movement < -boundary){
            return;
        }
        transform.position += new Vector3(movement, 0, 0);
    }
}
