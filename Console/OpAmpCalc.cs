using System;
//using System.IO;

public class OpAmpCalc
{
    public static void Main(string[] args)
    {
		double Vref=0, Vref1=0, Vout_fs=0, Vout_zs=0, Vin_fs=0, Vin_zs=0;
		double m=0, b=0;
		double R1=1,R2=1,Rf=1,Rg=1,Rg2=1;
		string input;
	
	//Console.Write("Press any key to begin...");
	//Console.ReadKey();
		
	Console.Write("Voltage level of a stable reference, Vref[V] = ");
	input=Console.ReadLine();
	Vref=Convert.ToDouble(input);
	
	Console.Write("Full-scale output voltage, Vout_fs[V] = ");
	input=Console.ReadLine();
	Vout_fs=Convert.ToDouble(input);
	}
}