using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodHandling : MonoBehaviour
{
    string currentFood;
    public bool isHolding = false;

    [System.Serializable]
    public class FoodPrefabs
    {
        public GameObject Tea;
        public GameObject Pakora, Samosa, PaneerTikka;
    }
    [SerializeField]

    public FoodPrefabs foodItems;

    [System.Serializable]
    public class IKConstraints
    {
        public GameObject RightHandEffector, LeftHandEffector;
    }
    [SerializeField]

    public IKConstraints TeaIK;
    public IKConstraints SamosaIK;
    public IKConstraints PaneerTikkaIK;
    public IKConstraints PakoriIK;

    public static PlayerFoodHandling Instance { get; set; }

     Animator anim;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        anim = this.GetComponent<Animator>();
        //PickFood("Tea");
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnAnimatorIK(int layerIndex)
    {
        if (currentFood == "Samosa")
        {
            //Debug.Log("Hello");

            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, SamosaIK.LeftHandEffector.transform.rotation);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, SamosaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, SamosaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, SamosaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        }

        if (currentFood == "PaneerTikka")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, PaneerTikkaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, PaneerTikkaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PaneerTikkaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, PaneerTikkaIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        }

        if (currentFood == "Pakori")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, PakoriIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, PakoriIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PakoriIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, PakoriIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        }

        if (currentFood == "Tea")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, TeaIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, TeaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        }
        else
        {
        
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
      
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            //For Left Hand
           
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKRotation(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }



    public void PickFood(string food)
    {
        currentFood = food;

        if (food == "Samosa")
        {
            foodItems.Samosa.SetActive(true);
        }

        if (food == "Tea")
        {
            foodItems.Tea.SetActive(true);
           
        }

        if (food == "Pakori")
        {
            foodItems.Pakora.SetActive(true);
           
        }


        if (food == "PaneerTikka")
        {
            foodItems.PaneerTikka.SetActive(true);
           

        }


    }


}
