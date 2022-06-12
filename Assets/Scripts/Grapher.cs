using System;
using UnityEngine;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine.UI;
// using System.Math;
namespace UnityTemplateProjects
{
    public class Grapher : MonoBehaviour
    {
        public Text textbox;
        public float w;
        public GameObject point;
        public float incrementAmount;
        private const float e = 2.7182818284590452353602874713527f;
        public float rangeW;
        //starting equation will be a 4th degree polynomial in factored form
        //-(x+3)(x+3)(x-5)(x+4)
        //tests multiplicites as well
        //dunno how to spell multiplicities
        //WXYZ dimensions (W is time) W will be an input b/c it is much easier to work with
        //Y will be an output, X an input, Z an output, somewhat random but it matches roughly 2d graphing
        //systems
        Complex zeroOne = new Complex(1,1);
        Complex zeroTwo = new Complex(1,1);
        Complex zeroThree = new Complex(-1,2);
        Complex zeroFour = new Complex(2,3);

        public bool opt1;
        //screw it the range is way to big for 4th degree making it 3rd degree instead
        Complex calculate(Complex value)
        {
            // Complex tempAnswer = new Complex();
            // Complex tempAnswer =  (Complex.Add(value,zeroOne))*(value + zeroTwo)*(value + zeroThree)*(value +zeroFour);
            // Complex tempAnswer =  (Complex.Add(value,zeroOne))*(value + zeroTwo)*(value + zeroThree);
            // Complex tempAnswer = Complex.Pow(e, value*Complex.ImaginaryOne);
            // Complex tempAnswer = SpecialFunctions.Gamma(value.Real,value.Complex);;
            // if (opt1)
            // {
            //     tempAnswer = Complex.Pow(e, value.Real*Complex.ImaginaryOne);
            // }
            // else
            // {
            //     Complex.Gamma(value);
            //     tempAnswer = Complex.Cos(value.Real)*Complex.ImaginaryOne*Complex.Sin(value.Real);
            // }
            // Complex tempAnswer = Complex.Pow(value,Complex.Pow(value,value));
            // Complex tempAnswer = Complex.Cos(value)+Complex.Sin(value);
            // Complex tempAnswer = new Complex(1, 0) / value;
            Complex tempAnswer = Complex.Pow(new Complex(3, 0), value);
            return tempAnswer;
        }

        private GameObject[] objects= new GameObject[200];

        private void Start()
        {
            Debug.Log(calculate(new Complex(3,-8)));
        }

        private void FixedUpdate()
        {
            foreach (GameObject oj in objects)
            {
                Destroy(oj);
            }
            for (int i = -100; i < 100; i++)
            {
                Complex tempComplex = calculate(new Complex(w, i));
                objects[i+100]=Instantiate(point,new UnityEngine.Vector3((float)tempComplex.Real*100,(float) tempComplex.Imaginary*100, i*10),quaternion.identity);
            }
            //might be off by exactly one frame, not sure
            textbox.text = w.ToString();
            w += incrementAmount;
            float a = 1;
            float b = 2;
            
            //a+bi
            new Complex(a,b);
        }
    }
}