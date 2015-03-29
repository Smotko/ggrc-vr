using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject prefab;
	public Texture[] textures;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < textures.Length; i++) {
			for (int j = 0; j < (i+1)*2-1; j++){
				GameObject instance = Instantiate(prefab);
				setText (instance, "Wohoooo");
				setIcon (instance, i);
				float pos = j - (i + 1);
				instance.transform.position = new Vector3(pos*10, i*2, i*2);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setText(GameObject instance, string text) {
		TextMesh tm = instance.GetComponentInChildren<TextMesh>();
		tm.text = text;
	}
	private void setIcon(GameObject instance, int iconId) {
		MeshRenderer[] objects =  instance.GetComponentsInChildren<MeshRenderer>();
		objects[0].material.mainTexture = textures[iconId];
	}
}
