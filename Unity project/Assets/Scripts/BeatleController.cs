using System.Globalization;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BeatleController : MonoBehaviour {
	public float speed;
	public float torque;
    public GUIText DistancesText;
    public GUIText SignalText;

	private Rigidbody rigidbody;
	private bool targetExists = true;

	private IPEndPoint serverEndpoint = new IPEndPoint (IPAddress.Parse("127.0.0.1"), 52200);
	private int port = 10016;
	private UdpClient udp;
	private BinarySerializer serializer = new BinarySerializer();


    
	
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		udp = new UdpClient (port);
		udp.Connect (serverEndpoint);
		udp.Client.ReceiveTimeout = 1000;
	}
	
	void FixedUpdate()
	{
	    if (targetExists)
	    {
			var direction = (float)ComputeNavigation();
	        rigidbody.AddForce(transform.forward*speed*Time.deltaTime);
			rigidbody.AddTorque (transform.up * torque * direction * Time.deltaTime);
	    }		    
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "PickUp") {
			other.gameObject.SetActive (false);
		}
	}

    private double ComputeNavigation()
    {
		var distances = GetDistances ();
		var data = serializer.Serialize (distances);
		udp.Send (data, data.Length);
		var response = udp.Receive (ref serverEndpoint);
		var signal = serializer.Deserialize<double>(response);

		SignalText.text = string.Format("Signal: {0}", signal);

		return signal;
    }



    private double[] GetDistances()
    {
        var res = new double[2];
        var target = GameObject.Find("PickUp 12");
        if (target == null)
        {
            targetExists = false;
            return res;
        }

        var targetPos = target.transform.position;
        var eyesPos = transform.Find("beatbase/beateyes").position;
        var leftEyePos = eyesPos - transform.right * 3;
        var rightEyePos = eyesPos + transform.right * 3;

        res[0] = Vector3.Distance(targetPos, leftEyePos);
        res[1] = Vector3.Distance(targetPos, rightEyePos);
        DistancesText.text = string.Format("Left: {0}\nRight: {1}", res[0], res[1]);
        return res;
    }

	void OnApplicationQuit() {
		udp.Close ();
	}
}

public class BinarySerializer
{
	private static readonly BinaryFormatter _formatter = new BinaryFormatter(); 
	
	public byte[] Serialize<T>(T entity)
	{
		using (var stream = new MemoryStream())
		{
			_formatter.Serialize(stream, entity);
			return stream.ToArray();
		}
	}
	
	public T Deserialize<T>(byte[] bytes)
	{
		using (var stream = new MemoryStream())
		{
			stream.Write(bytes, 0, bytes.Length);
			stream.Position = 0;
			return (T)_formatter.Deserialize(stream); 
		}
	}
}
