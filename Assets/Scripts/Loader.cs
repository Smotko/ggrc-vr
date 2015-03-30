using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject prefab;
	public GameObject line;
	public Texture[] textures;
	private string[] names = {
		"Program",
		"Regualtion",
		"Section",
		"Objective",
		"Control",
		"System",
		"Adudit",
	};
	private Color[] colors = {
		Color.magenta,
		Color.blue,
		Color.black,
		Color.blue,
		Color.green,
		Color.blue,
		Color.blue,
	};

	// Use this for initialization
	void Start () {
		for(int i = 0; i < textures.Length; i++) {
			for (int j = 0; j < (i+1)*2-1; j++){
				GameObject instance = Instantiate(prefab);
				int step = i*2;
				setText (instance, names[i] + " #" + (j+1));
				setIcon (instance, i);
				float pos = j - (i + 1);
				instance.transform.position = new Vector3(pos*10, step, step);

				// Lines
				if (i+1 >= textures.Length) {
					continue;
				}
				int numLines = Random.Range(1, (i+2)-1);
				if (i == 0) {
					// Make sure all first levels are connected
					numLines = 3;
				}
				for (int k = 0; k < numLines; k++) {
					GameObject l = Instantiate(line);
					LineRenderer lr = line.GetComponent<LineRenderer>();
					float lineOffset = 0.4f;
					lr.SetPosition(0, new Vector3(pos*10, step + lineOffset, step));
					lr.SetPosition(1, new Vector3(pos*10, step+1 - lineOffset, step));
					lr.SetPosition(2, new Vector3((pos + (k - numLines/2))*10, step+1 - lineOffset, step+2));
					lr.SetPosition(3, new Vector3((pos + (k - numLines/2))*10, step+1.8f - lineOffset, step+2));
					lr.SetColors(
						colors[i],
						colors[i]
					);
				}
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
