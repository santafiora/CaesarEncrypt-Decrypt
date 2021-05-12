using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarEncryption
{
    class Program
    {
        static void Main(string[] args)
        {

            int MenueAuswahl = SetStartMenue();

            while (MenueAuswahl != 0)
            {
                switch (MenueAuswahl)
                {
                    case 1:

                        Console.WriteLine("Bitte den Verschlüsselungstext eingeben: ");

                         string klartext = Console.ReadLine();
                             klartext = klartext.ToUpper();
                                 char[] secretMessage = klartext.ToCharArray();
                               Console.WriteLine("Bitte Positions Key eingeben: ");
                             int Key = Convert.ToInt32(Console.ReadLine());

                        //Aufruf der Enyryption Methode
                        Enryption(secretMessage, Key);
                              string secret = Enryption(secretMessage, Key);
                             Console.WriteLine(secret);
                       
                        //Aufruf der Menue Methode
                        MenueAuswahl = SetStartMenue();
                        break;

                    case 2:
                        Console.WriteLine("Bitte den Verschlüsselten Text eingeben: ");
                                string uklartext = Console.ReadLine();
                                    uklartext = uklartext.ToUpper();
                                      char[] usecretMessage = uklartext.ToCharArray();
                            Console.WriteLine("Bitte Positions Key eingeben: ");
                        int ukKey = Convert.ToInt32(Console.ReadLine());

                        //Aufruf der Decryption Methode
                        Decryption(usecretMessage, ukKey);
                                string Uksecret = Decryption(usecretMessage, ukKey);
                             Console.WriteLine(Uksecret);
                        //Aufruf der Menue Methode
                        MenueAuswahl = SetStartMenue();
                        break;

                    case 0:

                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        Console.ReadKey();
                        //Aufruf der Menue Methode
                        MenueAuswahl = SetStartMenue();

                        break;
                }

            }
        }


        /// <summary>
        /// Enyryption
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="key"></param>
        /// <returns> verschluesselteNachricht </returns>
        static string Enryption(char[] secretMessage, int key)
        {

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string verschluesselteNachricht = "";

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char c = secretMessage[i];
                if (alphabet.Contains(c))
                {
                    int position = Array.IndexOf(alphabet, c);
                    int position_new = position + key;
                    int rest = position_new % 26;
                    verschluesselteNachricht += alphabet[rest];
                }
                else
                {
                    verschluesselteNachricht += c;
                }

            }

            return verschluesselteNachricht;
        }




        /// <summary>
        /// Decryption
        /// </summary>
        /// <param name="secretMessage"></param>
        /// <param name="key"></param>
        /// <returns>verschluesselteNachricht</returns>
        static string Decryption(char[] usecretMessage, int ukey)
        {

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string verschluesselteNachricht = "";


            for (int i = 0; i < usecretMessage.Length; i++)
            {
                char c = usecretMessage[i];

                if (alphabet.Contains(c))
                {
                    int position = Array.IndexOf(alphabet, c);
                    int position_new = position - ukey;
                    int rest = position_new % 26;
                    verschluesselteNachricht += alphabet[rest];
                }
                else
                {
                    verschluesselteNachricht += c;
                }
            }

            return verschluesselteNachricht;
        }

        /// <summary>
        /// Gibt keinen Wert zurück
        /// </summary>
        /// <returns></returns>
        static int SetStartMenue()
        {
            Console.WriteLine("Willkommen zur Cäsar Verschlüsselung");
            Console.WriteLine("1. Für Text Verschlüsseln:");
            Console.WriteLine("2. Für Text Entschlüsseln:");
            Console.WriteLine("0. Für Programmende:");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}

