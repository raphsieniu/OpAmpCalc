using System;
using System.IO;

using System.Globalization;

public class OpAmpCalc
{
    public static void Main(string[] args)
    {
		double Vref=0, Vref1=0, Vout_fs=0, Vout_zs=0, Vin_fs=0, Vin_zs=0;
		double m=0, b=0;
		unsigned double R1=1, R2=1, Rf=1, Rg=1, Rg1=1, Rg2=1;
		string input;
	
	do
	{
		Console.Write("Voltage level of a stable reference, Vref[V] = ");
		input=Console.ReadLine();
		Vref=double.Parse(input, CultureInfo.InvariantCulture);

		Console.Write("Full-scale output voltage, Vout_fs[V] = ");
		input=Console.ReadLine();
		Vout_fs=double.Parse(input, CultureInfo.InvariantCulture);

		Console.Write("Zero-scale output voltage, Vout_zs[V] = ");
		input=Console.ReadLine();
		Vout_zs=double.Parse(input, CultureInfo.InvariantCulture);

		Console.Write("Full-scale input voltage, Vin_fs[V] = ");
		input=Console.ReadLine();
		Vin_fs=double.Parse(input, CultureInfo.InvariantCulture);

		Console.Write("Zero-scale input voltage, Vin_zs[V] = ");
		input=Console.ReadLine();
		Vin_zs=double.Parse(input, CultureInfo.InvariantCulture);

		m=(Vout_fs-Vout_zs)/(Vin_fs-Vin_zs);
		b=Vout_zs-(m*Vin_zs);
		Console.WriteLine("m={0}, b={1}");

		if(m>=0 && b>=0)
		{
			Console.Write("Choose R1[Ohms]: ");
			input=Console.ReadLine();
			R1=double.Parse(input, CultureInfo.InvariantCulture);
			R2=(Vref*R1*m)/b;
			Console.Write("Choose Rf[Ohms]: ");
			input=Console.ReadLine();
			Rf=double.Parse(input, CultureInfo.InvariantCulture);
			Rg=(R2*Rf)/(m*(R1+R2)-R2);

			Console.WriteLine("SLOA097 (\"Designing Gain and Offset in Thirty Seconds\"), Figure 1:\nR1 = {0}Ohm, R2 = {1}Ohm, Rf = {2}Ohm, Rg = {3}Ohm", R1, R2 , Rf, Rg);
		}
		else if(m>=0 && b<0)
		{
			do
			{
				Console.Write("Consider enhanced accuracy? (y/n)";
				input=Console.Read();
				if(input!= "y" && input!= "Y" && input!= "n" && input!= "N") Console.WriteLine("Answer not recognized. Try again.");
			} while((input!= "y" && input!= "Y" && input!= "n" && input!= "N")

			if(input=="n" || input=="N")
			{
				Console.Write("Choose Rf[Ohms]: ");
				input=Console.ReadLine();
				Rf=double.Parse(input, CultureInfo.InvariantCulture);
				Rg=Rf/(m-1);
				Rg2=Rg/10;
				Rg1=Rg-Rg2;
				Vref1=(Abs(b)*Rg1)/(Rg1+Rf);
				R1=(Rg2*(Vref-Vref1))/Vref1;

				Console.WriteLine("SLOA097 (\"Designing Gain and Offset in Thirty Seconds\"), Figure 2 : \nR1 = {0}Ohm, Rg2 = {1}Ohm, Rg1 = {2}Ohm, Rf = {3}Ohm, Vref' = {4}V", R1, Rg2 , Rg1, Rf, Vref1);
			}
			else
			{
				Console.Write("Choose Rf[Ohms]: ");
				input=Console.ReadLine();
				Rf=double.Parse(input, CultureInfo.InvariantCulture);
				Rg=Rf/(m-1);
				Vref1=Abs(b)/m;
				Console.Write("Choose R1[Ohms]: ");
				input=Console.ReadLine();
				R1=double.Parse(input, CultureInfo.InvariantCulture);
				R2=(Vref1*R1)/(Vref-Vref1);

				Console.WriteLine("SLOA097 (\"Designing Gain and Offset in Thirty Seconds\"), Figure 3: \nR1 = {0}Ohm, R2 = {1}Ohm, Rf={2}Ohm, Rg={3}Ohm, Vref' = {4}V", R1, R2 , Rf, Rg, Vref1);
			}
		}
		else if(m<0 && b>=0)
		{
			Console.Write("Choose Rf[Ohms]: ");
			input=Console.ReadLine();
			Rf=double.Parse(input, CultureInfo.InvariantCulture);
			Rg=Rf/Abs(m);
			Console.Write("Choose R2[Ohms] (same order of magnitude as Rf): ");
			input=Console.ReadLine();
			R2=double.Parse(input, CultureInfo.InvariantCulture);
			R1=(b*R2*Rg)/(Vref*(Rf+Rg)-(b*Rg))

			Console.WriteLine("SLOA097 (\"Designing Gain and Offset in Thirty Seconds\"), Figure 4: \nR1 = {0}Ohm, R2 = {1}Ohm, Rf={2}Ohm, Rg={3}Ohm, Vref = {4}V", R1, R2 , Rf, Rg, Vref);
		}
		else if(m<0 && b<0)
		{
			Console.Write("Choose Rf[Ohms]: ");
			input=Console.ReadLine();
			Rf=double.Parse(input, CultureInfo.InvariantCulture);
			Rg1=Rf/Abs(m);
			Rg2=Vref*(Rf/Abs(b));

			Console.WriteLine("SLOA097 (\"Designing Gain and Offset in Thirty Seconds\"), Figure 5: \nRg1 = {0}Ohm, Rg2 = {1}Ohm, Rf={2}Ohm, Vref = {3}V", Rg1, Rg2 , Rf, Vref);
		}
		do
		{
			Console.Write("Do you want to perform another calculation? (y/n)");
			input=Console.ReadLine();
		}while(input!="n" && input!="N" && input!="y" && input!=""Y");
	}while(input=="y" || input=="Y");
	
	Console.Write("Press any key to quit...");
	Console.ReadKey();
	}
}
