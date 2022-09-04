using System;
using System.IO;

using System.Globalization;

public class OpAmpCalc
{
    public static void Main(string[] args)
    {
		double Vref=0, Vref1=0, Vout_fs=0, Vout_zs=0, Vin_fs=0, Vin_zs=0;
		double m=0, b=0;
		double R1=1,R2=1,Rf=1,Rg=1,Rg2=1;
		string input;
		
	Console.Write("Voltage level of a stable reference, Vref[V] = ");
	input=Console.ReadLine();
	Vref=double.Parse(input, CultureInfo.InvariantCulture);
	
	Console.Write("Full-scale output voltage, Vout_fs[V] = ");
	input=Console.ReadLine();
	Vout_fs=double.Parse(input, CultureInfo.InvariantCulture);
	
	
	
	//Console.Write("Press any key...");
	//Console.ReadKey();
	}
}