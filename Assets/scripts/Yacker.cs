using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Yacker : MonoBehaviour 
{
	public int[] properties = new int[6]; 
	// Each is from 0-3 and represents what quality the Yacker has in each category
		//0 - Body
		//1 - Body Color
		//2 - Pattern
		//3 - Outline Color
		//4 - Part 1
		//5 - Part 2
	
	public Image body, outline, part1, part2, backdrop; 
	public int x, y;

	//Mutators
	public void setSprites(Sprite b, Color bC, Texture2D p, Sprite o, Color oC, Sprite p1, Sprite p2)
	{
		body.sprite = b;
		body.material = new Material (body.material);
		body.material.SetTexture("_TextureSlot1", p);
		body.material.color = bC;
        body.rectTransform.sizeDelta = new Vector2(100, 100);

		outline.sprite = o;
		outline.color = oC;

		part1.sprite = p1;
		part1.color = Color.white;
		part2.sprite = p2;
		part2.color = Color.white;

        backdrop.color = Color.clear;
    }	

	public void setProps(int b, int bC, int p, int oC, int p1, int p2)
	{
		properties[0] = b;
		properties[1] = bC;
		properties[2] = p;
		properties[3] = oC;
		properties[4] = p1;
		properties[5] = p2;
	}
	
	public void setLoc(int a, int b) {
		x = a;
		y = b;
	}

	public void changeSize(float scale){
		Vector2 dSize = new Vector2 (scale, scale);
		body.rectTransform.sizeDelta = dSize;
		outline.rectTransform.sizeDelta = dSize;
		part1.rectTransform.sizeDelta = dSize;
		part2.rectTransform.sizeDelta = dSize;
	}
}
