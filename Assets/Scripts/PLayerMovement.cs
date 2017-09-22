using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PLayerMovement : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject[] pickups;
    private Rigidbody rb;
    private int Counter;
    private ArrayList stuff = new ArrayList();

    void Start (){
		rb = GetComponent<Rigidbody> ();
        Counter = 0;
        SetScore();
        winText.text = "Collect Purple Cubes For Points!";
        
        for (int x = 0; x < pickups.Length; x++)
        {
            stuff.Add(pickups[x]);
        }
        
	}

	void FixedUpdate () 
		{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (move*speed);
        


		}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            Counter++;
            SetScore();
            InfoText();
        }

        if (other.gameObject.CompareTag("Wall1")) {
            winText.text = "Red Cubes Remove Points!";

        }

        if (other.gameObject.CompareTag("info3"))
        {
            winText.text = "Clear all purple cubes to progress!";

        }

        if (other.gameObject.CompareTag("Clear Text")) {
            InfoText();
        }

        if (other.gameObject.CompareTag("Bad"))
        {
            Counter--;
            other.gameObject.SetActive(false);
            SetScore();
        }

        if (other.gameObject.CompareTag("Open3")) {
            Wall2.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("p3")) {
            stuff.Remove(other.gameObject);
        }
    }

    void SetScore() {
        countText.text = "Score: " + Counter.ToString();
        if (Counter == 8) {
        Wall1.gameObject.SetActive(false);
        }

        if (stuff.Count == 0) {
            Wall3.gameObject.SetActive(false);
        }

    }

    void InfoText() {
        winText.text = "";
    }

    

}
