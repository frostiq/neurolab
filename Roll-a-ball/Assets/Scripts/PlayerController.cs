using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 1.0f;
	public GUIText countTest;
	public GUIText winText;
	
    private int count;
    private Rigidbody rigidbody;
    private NetworkView networkView;
    private Vector3 movement = Vector3.zero;

	void Start(){
		count = 0;
		SetCountText(count);
		winText.text = "";

	    rigidbody = GetComponent<Rigidbody>();
	    networkView = GetComponent<NetworkView>();

	    if (Network.Connect("localhost", 4585) == NetworkConnectionError.NoError)
	    {
	        Debug.Log("connected to server");
		}
	}
	
	void FixedUpdate () {
	    if (Network.peerType == NetworkPeerType.Client)
	    {
	        networkView.RPC("Animate", RPCMode.Server, networkView.owner);
	    }
	    rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	[RPC]
	void Animate(NetworkPlayer p){
	}

    [RPC]
    void SetMovement(Vector3 movement)
    {
        this.movement = movement;
		Debug.Log ("movement set: " + movement.ToString());
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "PickUp") {
			other.gameObject.SetActive (false);
			++count;
			SetCountText(count);
		}
	}

	void SetCountText(int count)
	{
	    countTest.text = "Count: " + count;
		if (count >= 13)
		{
			winText.text = "YOU WIN!";
		}
	}
}
