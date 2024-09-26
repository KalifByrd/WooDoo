using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : Singleton<ItemDatabase>
{
    public List<Item> itemList = new List<Item>();
    public GameObject afro_space_buns_hair;
    public GameObject black_victorian_hair;
    public GameObject butt_cut_hair;
    public GameObject wavy_modern_hair;

    public GameObject heart_nose;


    public GameObject bat_wings_head_accessory;

    public GameObject sparkle_top;
    public GameObject heartskull_christmas_sweater_top;
    public GameObject plaid_bottom;
    public GameObject plaid_shorts_bottom;
    void Start()
    {

        //naked
        itemList.Add(new Item(0, "", "", "naked_legs", "Legs"));
        itemList.Add(new Item(1, "", "", "naked_torso", "Torso"));
        itemList.Add(new Item(2, "", "", "bald_head", "Hair"));
        itemList.Add(new Item(3, "", "", "empty_hand_r", "HandRight"));
        itemList.Add(new Item(4, "", "", "empty_hand_l", "HandLeft"));
        itemList.Add(new Item(5, "", "", "no_hat", "Hat"));
        itemList.Add(new Item(6, "", "", "no_head_accessory", "HeadAccessory"));
        itemList.Add(new Item(7, "", "", "no_socks", "Socks"));
        itemList.Add(new Item(8, "", "", "no_leggings", "Leggings"));
        itemList.Add(new Item(9, "", "", "no_nose", "Nose"));
        itemList.Add(new Item(10, "", "", "no_eyes", "Eyes"));
        itemList.Add(new Item(11, "", "", "no_eyebows", "Eyebrows"));
        itemList.Add(new Item(12, "", "", "no_mouth", "Mouth"));
        itemList.Add(new Item(13, "", "", "no_cheeks", "Cheeks"));
        itemList.Add(new Item(14, "", "", "no_details", "Details"));
        itemList.Add(new Item(15, "", "", "naked_slug", "Feet"));

        itemList.Add(new Item(16, "", "", "naked_body", "Body"));
        
        
        
        
        
        
        
        
        
        
        
        //face
        itemList.Add(new Item(30, "", "", "heart_nose", "Nose", heart_nose));
        //clothing
        // itemList.Add(new Item(50, "", "", "pants", "Legs", (GameObject)Resources.Load("Gear/pants")));
        // itemList.Add(new Item(51, "", "", "boots", "Feet", (GameObject)Resources.Load("Gear/boots")));
        // itemList.Add(new Item(53, "", "", "cuirass", "ChestArmor", (GameObject)Resources.Load("Gear/cuirass")));
        // itemList.Add(new Item(54, "", "", "gambeson", "Chest", (GameObject)Resources.Load("Gear/gambeson")));
        //weapons
        // itemList.Add(new Item(300, "", "", "halberd", "HandRight", (GameObject)Resources.Load("Gear/halberd")));
        //hair
        itemList.Add(new Item(200, "", "", "afro_space_buns_hair", "Hair", afro_space_buns_hair));
        itemList.Add(new Item(201, "", "", "black_victorian_hair", "Hair", black_victorian_hair));
        itemList.Add(new Item(202, "", "", "butt_cut_hair", "Hair", butt_cut_hair));
        itemList.Add(new Item(203, "", "", "wavy_modern_hair", "Hair", wavy_modern_hair));

        //accessories
        itemList.Add(new Item(300, "", "", "bat_wings_head_accessory", "HeadAccessory", bat_wings_head_accessory));

        //tops
        itemList.Add(new Item(400, "", "", "sparkle_top", "Torso", sparkle_top));
        itemList.Add(new Item(401, "", "", "heartskull_christmas_sweater_top", "Torso", heartskull_christmas_sweater_top));

        //bottoms
        itemList.Add(new Item(500, "", "", "plaid_bottom", "Legs", plaid_bottom));
        itemList.Add(new Item(501, "", "", "plaid_shorts_bottom", "Legs", plaid_shorts_bottom));
        
        
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].ItemID == id)
            {
                return itemList[i];
            }
        }
        return null;
    }

    public Item FetchItemBySlug(string slugName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {

            if (itemList[i].Slug == slugName)
            {
                return itemList[i];
            }
        }
        return null;
    }


}
