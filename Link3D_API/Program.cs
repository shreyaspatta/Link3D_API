using System;
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
            Program foo = new Program();
            foo.Main1();
        }
        public void Main1()
        {
            string value1;
            string value2;
            string api_url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            /*XmlTextReader reader = new XmlTextReader(api_url);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Console.Write(">");
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }*/
            var webRequest = WebRequest.Create(api_url);
            string readalltext = null;
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                readalltext = reader.ReadToEnd();
            }

            Console.WriteLine("Enter the desired currency to Convert to: ");
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------LINK3D------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write("Enter the desired Currency: ");
            string currency_input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Currency Input: "+ currency_input);
            Console.Write("Enter the Amount: ");
            string value = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------OUTPUT-----------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------");
            Envelope euroconvertor = new Envelope();

            euroconvertor = Deserialize<Envelope>(readalltext);
            foreach(CubeCubeCube cube in euroconvertor.Cube.Cube1.Cube)
            {
                if(cube.currency == currency_input)
                {
                    Console.WriteLine("The output value is: " + Math.Round(Convert.ToDouble(value) * Convert.ToDouble(cube.rate), 2));
                }
            }
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
