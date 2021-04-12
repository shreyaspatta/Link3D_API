using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using static Link3D_API.XmlReader;

namespace Link3D_API
{
    class Program
    {
        
        public static void Main()
        {
            bool boolcontinue ;
            Program foo = new Program();
            do
            {
                boolcontinue = foo.Main1();
            } while (boolcontinue);
        }
        public bool Main1()
        {
            string value1;
            string value2;
            string api_url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            var webRequest = WebRequest.Create(api_url);
            string readalltext = null;
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                readalltext = reader.ReadToEnd();
            }
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------LINK3D------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write("Enter the input Currency: ");
            Envelope euroconvertor = new Envelope();
            euroconvertor = Deserialize<Envelope>(readalltext);
            List<string> currencylist = new List<string>();
            foreach(Currency curr in euroconvertor.Cube.Cube1.Cube)
            {
                currencylist.Add(curr.currency);
            }
            string input_currency = Console.ReadLine().ToUpper();
            string output_currency= null;
            double input_value = 0.00;
            string output_value = null;
            double eurovalue = 0.00;
            double output_currvalue = 0.00; 
            bool loopcheck = true;
            if (currencylist.Contains(input_currency))
            {
                do
                {
                    Console.Write("Enter the desired Currency: ");
                    output_currency = Console.ReadLine().ToUpper();
                    if (currencylist.Contains(output_currency))
                    {
                        if(input_currency == output_currency)
                        {
                            Console.WriteLine("Enter different currencies");
                            CurrencyLegend();
                            loopcheck = false;
                            break;
                        }
                        Console.WriteLine("--------------------------------------------------------------------------");
                        Console.WriteLine("Currency Input: " + input_currency);
                        Console.WriteLine("Currency Output: " + output_currency);
                        Console.WriteLine("--------------------------------------------------------------------------");
                        do
                        {
                            Console.Write("Enter the Input Amount: ");
                            try
                            {
                                input_value = Convert.ToDouble(Console.ReadLine());
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Please enter a valid number!");
                            }
                        } while(true);
                        foreach (Currency curr in euroconvertor.Cube.Cube1.Cube)
                        {
                            if (curr.currency == input_currency)
                            {
                                eurovalue = Convert.ToDouble(input_value) / Convert.ToDouble(curr.rate);
                            }
                        }
                        foreach (Currency curr in euroconvertor.Cube.Cube1.Cube)
                        {
                            if (curr.currency == output_currency)
                            {
                                output_currvalue = eurovalue * Convert.ToDouble(curr.rate);
                                output_currvalue = Math.Round(output_currvalue, 2);
                            }
                        }

                        Console.WriteLine("---------------------------------OUTPUT-----------------------------------");
                        Console.WriteLine(input_currency + " " + input_value + " is " + output_currency + " " + output_currvalue);
                        Console.WriteLine("--------------------------------------------------------------------------");
                        loopcheck = false;
                    }
                    else
                    {
                        CurrencyLegend();
                        Console.WriteLine("Do you wish to retry? (y/n)");
                        string input1 = Console.ReadLine();
                        if (input1 == "y" || input1 == "Y")
                        {
                            loopcheck= true;
                        }
                        else
                        {
                            loopcheck = false;
                            break;
                        }
                        
                    }
                } while (loopcheck);
            }
            else
            {
                CurrencyLegend();
            }
            Console.WriteLine("Do you wish to continue? (y/n)");
            string input = Console.ReadLine();
            if(input=="y" || input=="Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CurrencyLegend()
        {
            Console.WriteLine("Enter the right Currency: ");
            Console.WriteLine("United States Dolllars: USD");
            Console.WriteLine("Japanese Yen: JPY");
            Console.WriteLine("Bulgarian Lev: BGN");
            Console.WriteLine("Czeck Koruna: CZK");
            Console.WriteLine("Danish Krone: DKK");
            Console.WriteLine("Pound Sterling: GBP");
            Console.WriteLine("Hungarian Forint: HUF");
            Console.WriteLine("Poland Zloty: PLN");
            Console.WriteLine("Romanian Leu: RON");
            Console.WriteLine("Swedish Krona: SEK");
            Console.WriteLine("Swiss Franc: CHF");
            Console.WriteLine("Icelandic Krona: ISK");
            Console.WriteLine("Norwegian krone: NOK");
            Console.WriteLine("Croatian kuna: HRK");
            Console.WriteLine("Russian ruble: RUB");
            Console.WriteLine("Turkish lira: TRY");
            Console.WriteLine("Australian dollar: AUD");
            Console.WriteLine("Brazilian real: BRL");
            Console.WriteLine("Canadian Dollar: CAD");
            Console.WriteLine("Chinese yuan renminbi: CNY");
            Console.WriteLine("Hong Kong dollar: HKD");
            Console.WriteLine("Indonesian Rupiah: IDR");
            Console.WriteLine("Israeli new shekel: ILS");
            Console.WriteLine("Indian Rupee: INR");
            Console.WriteLine("South Korean won: KRW");
            Console.WriteLine("Mexican peso: MXN");
            Console.WriteLine("Malaysian ringgit: MYR");
            Console.WriteLine("New Zealand dollar: NZD");
            Console.WriteLine("Philippine peso: PHP");
            Console.WriteLine("Singapore dollar: SGD");
            Console.WriteLine("Thai baht: THB");
            Console.WriteLine("South African rand: ZAR");
        }
        public T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
