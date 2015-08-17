using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class ItemDatabase : MonoBehaviour {

	[SerializeField]
	List<Equipment> equipmentContainer;
	[SerializeField]
	List<Weapon> weaponsContainer;
	[SerializeField]
	List<Consumable> consumablesContainer;
	[SerializeField]
	List<Currency> currencyContainer;

	public List<Equipment> Equipments {
		get {
			return equipmentContainer;
		}
		set {
			equipmentContainer = value;
		}
	}
	
	public List<Weapon> Weapons {
		get {
			return weaponsContainer;
		}
		set {
			weaponsContainer = value;
		}
	}

	public List<Consumable> Consumables {
		get {
			return consumablesContainer;
		}
		set {
			consumablesContainer = value;
		}
	}

	public List<Currency> Currencies {
		get {
			return currencyContainer;
		}
		set {
			currencyContainer = value;
		}
	}

	void Start()
	{
		equipmentContainer = new List<Equipment>();
		weaponsContainer = new List<Weapon>();
		consumablesContainer = new List<Consumable>();
		currencyContainer = new List<Currency>();

		// CURRENCY
		currencyContainer.Add(new Currency(0,	"Brone Coin",	"I_BronzeCoin", "Item",	"A little shining bronze coin.",	true,	999,	ItemType.CURRENCY,	ItemQuality.COMMON,	1));
		currencyContainer.Add(new Currency(1,	"Silver Coin",	"I_SilverCoin", "Item",	"A little shining silver coin.",	true,	999,	ItemType.CURRENCY,	ItemQuality.COMMON,	100));
		currencyContainer.Add(new Currency(2,	"Gold Coin",	"I_GoldCoin", "Item",	"A little shining gold coin.",		true,	999,	ItemType.CURRENCY,	ItemQuality.COMMON,	10000));
		// ARMORS
		equipmentContainer.Add(new Equipment(3, "Leather Armor", "A_Armour01", "Item", "", false, 1, ItemType.CHEST, ItemQuality.COMMON, 250, 20, 3, 35, 20, 15));
		equipmentContainer.Add(new Equipment(4, "Iron Chest", "A_Armour02", "Item", "Common chest made from iron.", false, 1, ItemType.CHEST, ItemQuality.COMMON, 2500, 80, 15, 10, 0, 0));
		equipmentContainer.Add(new Equipment(5, "Golden Chest", "A_Armour03", "Item", "Expensive and stylic one.", false, 1, ItemType.CHEST, ItemQuality.UNCOMMON, 25000, 140, 30, 8, 0, 0));
		equipmentContainer.Add(new Equipment(6, "Diamons Chest", "A_Armor04", "Item", "Rare chest made only by dwarfs.", false, 1, ItemType.CHEST, ItemQuality.RARE, 500000, 220, 60, 15, 5, 5));
		equipmentContainer.Add(new Equipment(7, "Drakonir Chest", "A_Armor05", "Item", "Epic chest weared only by true warriors.", false, 1, ItemType.CHEST, ItemQuality.EPIC, 2500000, 370, 90, 20, 10, 20));
		// BOOTS
		equipmentContainer.Add(new Equipment(8, "Leather Boots", "A_Shoes01", "Item", "", false, 1, ItemType.BOOTS, ItemQuality.COMMON, 120, 5, 0, 10, 0, 0));
		equipmentContainer.Add(new Equipment(9, "Dragon Skin Boots", "A_Shoes02", "Item", "Made from dragon skin.", false, 1, ItemType.BOOTS, ItemQuality.UNCOMMON, 1200, 18, 0, 22, 0, 5));
		equipmentContainer.Add(new Equipment(10, "Fur Boots", "A_Shoes03", "Item", "", false, 1, ItemType.BOOTS, ItemQuality.COMMON, 3800, 28, 0, 30, 0, 15));
		equipmentContainer.Add(new Equipment(11, "Iron Boots", "A_Shoes04", "Item", "Common boots made from iron.", false, 1, ItemType.BOOTS, ItemQuality.COMMON, 22000, 39, 5, 15, 0, 28));
		equipmentContainer.Add(new Equipment(12, "Diamond Boots", "A_Shoes05", "Item", "Rare boots made only by dwarfs.", false, 1, ItemType.BOOTS, ItemQuality.RARE, 80000, 50, 11, 20, 5, 38));
		equipmentContainer.Add(new Equipment(13, "Aether Boots", "A_Shoes06", "Item", "You can feel dark pulsing energy.", false, 1, ItemType.BOOTS, ItemQuality.RARE, 260000, 74, 0, 6, 45, 47));
		equipmentContainer.Add(new Equipment(14, "Drakonir Boots", "A_Shoes07", "Item", "Epic boots weared only by true warriors.", false, 1, ItemType.BOOTS, ItemQuality.EPIC, 980000, 100, 25, 19, 20, 40));
		// HELMETS
		equipmentContainer.Add(new Equipment(15, "Leather Helmet", "C_Elm01", "Item", "", false, 1, ItemType.HELMET, ItemQuality.COMMON, 250, 10, 5, 0, 5, 0));
		equipmentContainer.Add(new Equipment(16, "Iron Helmet", "C_Elm03", "Item", "Common helmet made from iron.", false, 1, ItemType.HELMET, ItemQuality.COMMON, 500, 28, 10, 5, 5, 5));
		equipmentContainer.Add(new Equipment(17, "Royal Helmet", "C_Elm04", "Item", "Weared by kingdom knights.", false, 1, ItemType.HELMET, ItemQuality.RARE, 3500, 47, 0, 10, 0, 15));
		equipmentContainer.Add(new Equipment(18, "Magic Hat", "C_Hat01", "Item", "Magic can be felt near that hat.", false, 1, ItemType.HELMET, ItemQuality.RARE, 8000, 21, 0, 0, 90, 20));
		equipmentContainer.Add(new Equipment(19, "Dark Magician's Hat", "C_Hat02", "Item", "Only God knows what power is holding by that hat.", false, 1, ItemType.HELMET, ItemQuality.LEGENDARY, 1000000, 38, 0, 0, 240, 40));
		// NECKLACES
		equipmentContainer.Add(new Equipment(20, "Crystal Necklace", "Ac_Necklace01", "Item", "Basic necklace from poor quality crystals.", false, 1, ItemType.NECKLACE, ItemQuality.COMMON, 4000, 0, 2, 2, 2, 2));
		equipmentContainer.Add(new Equipment(21, "Sapphire Necklace", "Ac_Necklace02", "Item", "A sapphire is shining inside that necklace.", false, 1, ItemType.NECKLACE, ItemQuality.UNCOMMON, 8000, 0, 5, 0, 8, 6));
		equipmentContainer.Add(new Equipment(22, "Crimson Necklace", "Ac_Necklace03", "Item", "What secret that necklace holds?", false, 1, ItemType.NECKLACE, ItemQuality.UNCOMMON, 16000, 0, 5, 0, 25, 17));
		equipmentContainer.Add(new Equipment(23, "Pearl Necklace", "Ac_Necklace04", "Item", "Rare pearl was placed inside that necklace.", false, 1, ItemType.NECKLACE, ItemQuality.RARE, 32000, 0, 0, 0, 10, 5));
		equipmentContainer.Add(new Equipment(24, "Wolf Tooth Necklace", "Ac_Necklace06", "Item", "Many wolfs was taken down.", false, 1, ItemType.NECKLACE, ItemQuality.RARE, 64000, 0, 2, 15, 0, 0));
		equipmentContainer.Add(new Equipment(25, "Health Necklace", "Ac_Necklace05", "Item", "Increase health when weared.", false, 1, ItemType.NECKLACE, ItemQuality.COMMON, 1000, 0, 0, 0, 0, 0));
		equipmentContainer.Add(new Equipment(26, "Mana Necklace", "Ac_Necklace07", "Item", "Increase mana when weared.", false, 1, ItemType.NECKLACE, ItemQuality.COMMON, 1000, 0, 0, 0, 0, 0));
		// SHIELDS
		equipmentContainer.Add(new Equipment(27, "Wooden Shield", "E_Wood01", "Item", "", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 200, 80, 0, 0, 0, 0));
		equipmentContainer.Add(new Equipment(28, "Strenghened Wooden Shield", "E_Wood02", "Item", "", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 1200, 140, 5, 0, 0, 0));
		equipmentContainer.Add(new Equipment(29, "Heavy Wooden Shield", "E_Wood03", "Item", "", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 4500, 220, 10, 0, 0, 0));
		equipmentContainer.Add(new Equipment(30, "Forged Wooden Shield", "E_Wood04", "Item", "", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 13800, 317, 17, 0, 0, 0));
		equipmentContainer.Add(new Equipment(31, "Iron Shield", "E_Metal01", "Item", "Common shield made from iron.", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 21000, 317, 17, 0, 0, 0));
		equipmentContainer.Add(new Equipment(32, "Copper Shield", "E_Metal02", "Item", "What if you add some copper?", false, 1, ItemType.SHIELD, ItemQuality.COMMON, 43000, 520, 33, 0, 0, 0));
		equipmentContainer.Add(new Equipment(33, "Heavy Iron Shield", "E_Metal03", "Item", "Only some people can have it.", false, 1, ItemType.SHIELD, ItemQuality.UNCOMMON, 92000, 740, 46, 0, 0, 0));
		equipmentContainer.Add(new Equipment(34, "Iron Forged Shield", "E_Metal05", "Item", "When iron will be forged.", false, 1, ItemType.SHIELD, ItemQuality.UNCOMMON, 157000, 928, 68, 0, 0, 3));
		equipmentContainer.Add(new Equipment(35, "Valeran Shield", "E_Metal05", "Item", "Rare Valeran steel was used in this one.", false, 1, ItemType.SHIELD, ItemQuality.RARE, 318000, 1170, 86, 28, 0, 7));
		equipmentContainer.Add(new Equipment(36, "Bone Shield", "E_Bones02", "Item", "From rare monsters bones.", false, 1, ItemType.SHIELD, ItemQuality.RARE, 619000, 2284, 101, 33, 0, 12));
		equipmentContainer.Add(new Equipment(37, "Streathing Corruptor", "E_Bones03", "Item", "When evil bless an item.", false, 1, ItemType.SHIELD, ItemQuality.EPIC, 919000, 3428, 132, 42, 0, 16));
		equipmentContainer.Add(new Equipment(38, "Golden Shield", "E_Gold02", "Item", "Dwarfs... Only they could create such a thing.", false, 1, ItemType.SHIELD, ItemQuality.EPIC, 1680000, 5017, 186, 51, 0, 18));
		equipmentContainer.Add(new Equipment(39, "Royal Shield", "E_Gold01", "Item", "God, protect me from evil.", false, 1, ItemType.SHIELD, ItemQuality.LEGENDARY, 3216000, 6219, 228, 62, 0, 22));
		// SWORDS
		weaponsContainer.Add(new Weapon(40, "Katana", "W_Sword014", "Item", "Japaniese... How they do it?", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.COMMON, 500, 0, 0, 0, 0, 0, 10, 22, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(41, "Rappier", "W_Sword013", "Item", "", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.COMMON, 1000, 0, 0, 0, 0, 0, 16, 41, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(42, "Copper Sword", "W_Sword001", "Item", "", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.COMMON, 5000, 0, 3, 0, 0, 0, 31, 51, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(43, "Hardened Copper Sword", "W_Sword003", "Item", "When casual copper is not enought.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.UNCOMMON, 8600, 0, 6, 0, 0, 0, 47, 62, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(44, "Long Copper Sword", "W_Sword002", "Item", "Can you handle it?", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.UNCOMMON, 11200, 0, 11, 0, 0, 0, 59, 73, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(45, "Copper Cutter", "W_Sword004", "Item", "Can cut even rock.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.UNCOMMON, 22600, 0, 16, 5, 0, 0, 61, 81, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(46, "Two-Handed Copper Blade", "W_Sword006", "Item", "Weared by truly mens", false, 1, ItemType.TWOHAND_WEAPON, ItemQuality.RARE, 34800, 0, 49, 10, 0, 0, 120, 183, WeaponType.SWORD, 2.5f));
		weaponsContainer.Add(new Weapon(47, "Bone Crusher", "W_Sword005", "Item", "Mmm... Did you hear that?", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 120000, 0, 30, 25, 0, 0, 94, 117, WeaponType.SWORD, 1.0f));
		weaponsContainer.Add(new Weapon(48, "Iron Longblade", "W_Sword008", "Item", "Dwarfs helped a lot with that iron.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.RARE, 86000, 0, 26, 16, 0, 0, 79, 92, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(49, "Two-Handed Iron Blade", "W_Sword007", "Item", "Double hand - double power.", false, 1, ItemType.TWOHAND_WEAPON, ItemQuality.RARE, 142000, 0, 72, 22, 0, 0, 192, 227, WeaponType.SWORD, 2.0f));
		weaponsContainer.Add(new Weapon(50, "Royal Sword", "W_Sword010", "Item", "Weared by best of kingdom knights.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.LEGENDARY, 220000, 0, 42, 24, 0, 0, 96, 123, WeaponType.SWORD, 1.5f));
		weaponsContainer.Add(new Weapon(51, "Two-Handed Royal Blade", "W_Sword009", "Item", "Berserker mode ON!", false, 1, ItemType.TWOHAND_WEAPON, ItemQuality.LEGENDARY, 321600, 0, 94, 36, 0, 0, 260, 340, WeaponType.SWORD, 1.5f));
		weaponsContainer.Add(new Weapon(52, "Bone Sword", "W_Sword011", "Item", "From best quality Bones in world.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.LEGENDARY, 594000, 0, 55, 30, 0, 0, 111, 131, WeaponType.SWORD, 1.5f));
		weaponsContainer.Add(new Weapon(53, "Two-Handed Bone Blade", "W_Sword012", "Item", "From best quality Bones in world.", false, 1, ItemType.TWOHAND_WEAPON, ItemQuality.LEGENDARY, 9968270, 0, 117, 48, 0, 0, 310, 415, WeaponType.SWORD, 1.5f));
		weaponsContainer.Add(new Weapon(54, "Flash Blade", "W_Sword015", "Item", "Energy flow in this Blade.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 60, 100, 40, 40, 150, 220, WeaponType.SWORD, 0.6f));
		weaponsContainer.Add(new Weapon(55, "Fire Blade", "W_Sword016", "Item", "Fire occuping whole Blade.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 80, 40, 40, 40, 150, 220, WeaponType.SWORD, 0.5f));
		weaponsContainer.Add(new Weapon(56, "Water Blade", "W_Sword017", "Item", "Blade from Water... Interesting...", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 20, 80, 40, 40, 150, 220, WeaponType.SWORD, 0.8f));
		weaponsContainer.Add(new Weapon(57, "Ice Blade", "W_Sword018", "Item", "Cold Ice Blade in my hands.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 80, 40, 40, 40, 150, 220, WeaponType.SWORD, 0.8f));
		weaponsContainer.Add(new Weapon(58, "Corruption Blade", "W_Sword019", "Item", "Ugly smelt emanuating from that Blade.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 40, 60, 40, 40, 150, 220, WeaponType.SWORD, 0.8f));
		weaponsContainer.Add(new Weapon(59, "Earth Blade", "W_Sword020", "Item", "Earth hardened whole Blade.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 100, 20, 40, 40, 150, 220, WeaponType.SWORD, 0.8f));
		weaponsContainer.Add(new Weapon(60, "Wind Blade", "W_Sword021", "Item", "Blade from Wind, noone can see what is comming.", false, 1, ItemType.ONEHAND_WEAPON, ItemQuality.ARTIFACT, 1000000, 0, 40, 80, 40, 40, 150, 220, WeaponType.SWORD, 0.25f));
		// CONSUMABLES
		consumablesContainer.Add(new Consumable(100, "Small Health Potion", "P_Red02", "Item", "A small bottle of health potion.", true, 100, ItemType.POTION, ItemQuality.COMMON, 50, 100, 0));
		consumablesContainer.Add(new Consumable(101, "Health Potion", "P_Red03", "Item", "A bottle of health potion.", true, 100, ItemType.POTION, ItemQuality.COMMON, 120, 250, 0));
		consumablesContainer.Add(new Consumable(102, "Strong Health Potion", "P_Red01", "Item", "A bug bottle of health potion", true, 100, ItemType.POTION, ItemQuality.COMMON, 190, 500, 0));
	}

	public Item GetItemFromDatabase(int item_id)
	{
		Item tmpItem = null;

		if(tmpItem == null)
			tmpItem = currencyContainer.Find(item => item.ItemId == item_id);
		if(tmpItem == null)
			tmpItem = equipmentContainer.Find(item => item.ItemId == item_id);
		if(tmpItem == null)
			tmpItem = weaponsContainer.Find(item => item.ItemId == item_id);
		if(tmpItem == null)
			tmpItem = consumablesContainer.Find(item => item.ItemId == item_id);

		if(tmpItem != null)
			return tmpItem;
		else
			return new Item();
	}
	
}
