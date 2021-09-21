using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar
{
	private float energyTotal;
	
	
	
	public EnergyBar( float x){
		energyTotal = x;
	}
	
	public void addEnergy ( float valueEnergy){
		energyTotal = energyTotal + valueEnergy;
		if (energyTotal > 100) energyTotal = 100;
	}
	public void dropEnergy( float dropValue){
		energyTotal = energyTotal - dropValue;
	}
	
	
	public float getEnergy(){ return energyTotal;}

}
