using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CaesarEncryption
{
    class Program
    {
     /// <summary>
     /// 
     /// </summary>
     /// <param name="args"></param>
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

                        //Aufruf der statischen Encryption Methode

                        Encryption(secretMessage, Key);
                              string secret = Encryption(secretMessage, Key);
                             Console.WriteLine(secret);
                       
                        //Aufruf der Menue Methode
                        MenueAuswahl = SetStartMenue();
                        break;

                    case 2:
                        Console.WriteLine("Bitte den Verschlüsselten Text eingeben: ");
                                string vklartext = Console.ReadLine();
                                    vklartext = vklartext.ToUpper();
                                      char[] vsecretMessage = vklartext.ToCharArray();
                            Console.WriteLine("Bitte Positions Key eingeben: ");
                        int vKey = Convert.ToInt32(Console.ReadLine());

                        //Aufruf der statischen Decryption Methode
                        Decryption(vsecretMessage, vKey);
                                string vksecret = Decryption(vsecretMessage, vKey);
                             Console.WriteLine(vksecret);
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
      /// 
      /// </summary>
      /// <param name="secretMessage"></param>
      /// <param name="key"></param>
      /// <returns></returns>
        static public string Encryption(char[] secretMessage, int key)
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
        /// 
        /// </summary>
        /// <param name="vsecretMessage"></param>
        /// <param name="vkey"></param>
        /// <returns></returns>
        static public string Decryption(char[] vsecretMessage, int vkey)
        {

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string verschluesselteNachricht = "";


            for (int i = 0; i < vsecretMessage.Length; i++)
            {
                char c = vsecretMessage[i];

                if (alphabet.Contains(c))
                {
                    int position = Array.IndexOf(alphabet, c);
                    int position_new = position - vkey;
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
        /// 
        /// </summary>
        /// <returns></returns>
        static public int SetStartMenue()
        {
            Console.WriteLine("Willkommen zur Cäsar Verschlüsselung");
            Console.WriteLine("1. Für Text Verschlüsseln:");
            Console.WriteLine("2. Für Text Entschlüsseln:");
            Console.WriteLine("0. Für Programmende:");
            return Convert.ToInt32(Console.ReadLine());
        }

    }
}

