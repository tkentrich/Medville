using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	public enum CharacterRace { HUMAN, ELF, DWARF };
	public enum CharacterType { FIGHTER, THIEF, MAGE, CLERIC };
	public enum CharacterStatus { OK, DEAD };
	public enum Attribute { EXP, HP, HMAX, MP, MMAX, STR, WIS };

	public string characterName;
	public CharacterRace race;
	public CharacterType type;
	public CharacterStatus status;
	Dictionary<Attribute, int> attributes;

	public GameObject avatar;

	public void RandomCharacter () {
		switch (Random.Range(0, 3)) {
			default:
			case 0:
				race = CharacterRace.HUMAN;
				break;
			case 1:
				race = CharacterRace.ELF;
				break;
			case 2:
				race = CharacterRace.DWARF;
				break;
		}
		switch (Random.Range(0, 4)) {
			default:
			case 0:
				type = CharacterType.FIGHTER;
				break;
			case 1:
				type = CharacterType.THIEF;
				break;
			case 2:
				type = CharacterType.CLERIC;
				break;
			case 3:
				type = CharacterType.MAGE;
				break;
		}
		RandomizeAttributes();
	}

	public void RandomCharacter (CharacterRace race, CharacterType type) {
		this.race = race;
		this.type = type;
		RandomizeAttributes();
	}

	private void RandomizeAttributes() {
		attributes = new Dictionary<Attribute, int>();
		int hl = 5, hh = 10, ml = 1, mh = 4, sl = 5, sh = 6, wl = 5, wh = 6;
		switch (race) {
			case CharacterRace.DWARF:
				ml -= 1;
				mh -= 2;
				hl += 4;
				hh += 5;
				sl += 3;
				sh += 7;
				wl -= 3;
				wh -= 3;
				break;
			case CharacterRace.ELF:
				ml += 2;
				mh += 3;
				hl -= 2;
				hh -= 4;
				sl -= 2;
				sh -= 2;
				wl += 3;
				wh += 5;
				break;
		}
		switch (type) {
			case CharacterType.FIGHTER:
				sh += 4;
				wh -= 2;
				mh -= 2;
				hh += 5;
				break;
			case CharacterType.THIEF:
				sh += 1;
				wh += 1;
				mh -= 1;
				hh -= 1;
				break;
			case CharacterType.MAGE:
				sh -= 2;
				wh += 4;
				mh += 3;
				hh -= 3;
				break;
			case CharacterType.CLERIC:
				wh += 3;
				mh += 3;
				sh -= 1;
				break;
		}
		SetAttribute(Attribute.HMAX, Random.Range(hl, hh));
		SetAttribute(Attribute.MMAX, Random.Range(ml, mh));
		SetAttribute(Attribute.STR, Random.Range(sl, sh));
		SetAttribute(Attribute.WIS, Random.Range(wl, wh));
		RecoverFull();
	}

	public int GetAttribute(Attribute att) {
		return attributes[att];
	}

	public void SetAttribute(Attribute att, int value) {
		attributes[att] = value;
	}

	public void RecoverFull() {
		SetAttribute(Attribute.HP, GetAttribute(Attribute.HMAX));
		SetAttribute(Attribute.MP, GetAttribute(Attribute.MMAX));
	}
}
