using System;
namespace RecreateDND
{
    public class PlayerStats
    {
        public bool strSaving, dexSaving, constSaving, intSaving, wisSaving, chaSaving, acrobatics, animalHandling, arcana, athletics, deception, history, insight, intimidation, investigation, medicine, nature, perception, performance, persuasion, religion, sleightOfHand, stealth, survival;

        public PlayerStats(bool strSaving = false, bool dexSaving = false, bool constSaving = false, bool intSaving = false, bool wisSaving = false,
                                bool chaSaving = false, bool acrobatics = false, bool animalHandling = false, bool arcana = false, bool athletics = false,
                                bool deception = false, bool history = false, bool insight = false, bool intimidation = false, bool investigation = false,
                                bool medicine = false, bool nature = false, bool perception = false, bool performance = false, bool persuasion = false,
                                bool religion = false, bool sleightOfHand = false, bool stealth = false, bool survival = false)
        {


            this.strSaving = strSaving;
            this.dexSaving = dexSaving;
            this.constSaving = constSaving;
            this.chaSaving = chaSaving;
            this.acrobatics = acrobatics;
            this.animalHandling = animalHandling;
            this.arcana = arcana;
            this.history = history;
            this.insight = insight;
            this.intimidation = intimidation;
            this.investigation = investigation;
            this.medicine = medicine;
            this.nature = nature;
            this.perception = perception;
            this.performance = performance;
            this.persuasion = persuasion;
            this.religion = religion;
            this.sleightOfHand = sleightOfHand;
            this.stealth = stealth;
            this.survival = survival;



        }
    }
}
