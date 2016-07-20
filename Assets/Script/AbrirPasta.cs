using UnityEngine;
using UnityEngine.UI;//Para Manipular as UIs
using System.Collections;

public class AbrirPasta : MonoBehaviour {

	private Config _config;

	// Use this for initialization
	void Start () {
		_config = GameObject.Find("Canvas").GetComponent<Config>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Abrir(){
		string local;
		local = _config._local;
		_config._local = this.gameObject.GetComponentInChildren<Text> ().text;
		this.gameObject.GetComponentInChildren<Text> ().text = local;
	}

}
