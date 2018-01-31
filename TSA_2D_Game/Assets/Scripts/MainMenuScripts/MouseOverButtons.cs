using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverButtons : MonoBehaviour {
	public Text text;
	private int originalFontSize;
	private Color originalColor;
	// Update is called once per frame
	void Awake(){
		text = GetComponentInChildren<Text>();
		originalColor = text.color;
		originalFontSize = text.fontSize;
	}

	public void Grow(){
		text.fontSize = 20;
		text.color = Color.green;
	}
	public void Shrink(){
		text.fontSize = originalFontSize;
		text.color = originalColor;
	}
}
