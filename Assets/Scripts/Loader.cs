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
				float step = i*2/10f;
				setText (instance, names[i] + " #" + (j+1));
				setIcon (instance, i);
				float pos = j*2/10f - (step + 0.1f);
				instance.transform.position = new Vector3(pos*3, step-0.04f, step);

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
					float lineOffset = 0.04f;
					float upperPos = (j-k+1)*2/10f - (step + 0.1f);
					lr.SetPosition(0, new Vector3(pos*3, step + lineOffset - 0.02f, step));
					lr.SetPosition(1, new Vector3(pos*3, step+0.1f - lineOffset, step));
					lr.SetPosition(2, new Vector3((upperPos)*3, step+0.1f - lineOffset, step+0.2f));
					lr.SetPosition(3, new Vector3((upperPos)*3, step+0.14f - lineOffset, step+0.2f));
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
