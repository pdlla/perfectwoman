using UnityEngine;
using System.Collections;

using System.Reflection;
public class AnimationEffects 
{
	
	public static FlatElementAnimations.ElementAnimationDelegate get_effect(string effect)
	{
		/*
		string[] effects;
		if(effect != null && effect != "");
			effects = effect.Split(' ');*/
		
		return jiggle;
	}
	
	public static bool jiggle(FlatElementBase aBase, float aTime)
	{
		Debug.Log(aTime);
		aBase.mLocalRotation = Quaternion.AngleAxis(Mathf.Sin(aTime*1.5f)*10,Vector3.forward);
		return false;
	}
}
