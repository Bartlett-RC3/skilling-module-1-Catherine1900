using System;
namespace RC3Dogs
{
    public class Dogs
    {
        int age;
        float height;
        float weight;
        bool gender;
        string[] colours = { "brown", "yellow", "white", "black", "mix" };
        string personality;

        public Dogs(int _age, float _height, float _weight,  string[] _colours)
        {
            age = _age;
            height = _height;
            weight = _weight;
            gender = false;
            colours = _colours;

        }
        public void basicInformation()
        {
            Ageing();
            Growing();


        }

        public string getDogColour()
        {
            int i = 0;
            i = i + 1;
            return colours[i];
        }

        private void Ageing()
        {
            age = age + 1;
        }

        private void Growing()
        {
            height = height + 3.5f;
            weight = weight + 4.5f;
        }

        public string getPersonality()
        {

            return personality;
        }


    }
}
