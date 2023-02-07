using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtMaker : MonoBehaviour
{
    public Material NoDirt;
    public Material LowDirt;
    public Material MedDirt;
    public Material HighDirt;
	
	public MeshRenderer myMesh;
	int count=0;
    void Start()
    {
        myMesh=GetComponent<MeshRenderer>();
		CheckCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void CheckCount()
	{
		if(count==0||count==1)
		{
			myMesh.material=NoDirt;
		}
		if(count==2||count==3)
		{
			myMesh.material=LowDirt;
		}
		if(count==4||count==5)
		{
			myMesh.material=MedDirt;
		}
		if(count==6||count==7)
		{
			myMesh.material=HighDirt;
		}
	}
	
	void OnTriggerEnter(Collider actor)
	{
		if(actor.tag=="Customer"||actor.tag=="Player")
		{
			count++;
			 CheckCount();
		}
		if(actor.tag=="Cleaner")
		{
			count=0;
			 CheckCount();
		}
	}
}
