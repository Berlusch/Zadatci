﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class E10CiklicnaTablica
    {

        /*Ciklična matrica
    Napraviti osnovni zadatak prema inicijalnoj slici
    Dodatno:
    Osigurati unos brojeva redova i kolona u rasponu 2 do 50
    Napraviti da nakon završetka generiranja jedne matrice pita želite li napraviti još jednu i tako sve dok ne unese NE
    Napraviti opcije programa o smjeru kretanja brojeva:
    1. dolje desno početak u smjeru kazaljke na satu(inicijalni zadatak)
    2. dolje lijevo početak u smjeru kazaljke na satu
    3. gore lijevo početak u smjeru kazaljke na satu
    4. gore desno početak u smjeru kazaljke na satu

    5. dolje desno početak u kontra smjeru kazaljke na satu 
    6. dolje lijevo početak u kontra smjeru kazaljke na satu
    7. gore lijevo početak u kontra smjeru kazaljke na satu
    8. gore desno početak u kontra smjeru kazaljke na satu

    19. sredina(ono što je bio kraj u prvih 8 primjera) lijevo u smjeru kazaljke na satu
    10. sredina(ono što je bio kraj u prvih 8 primjera) desno u smjeru kazaljke na satu
    11. sredina(ono što je bio kraj u prvih 8 primjera) gore u smjeru kazaljke na satu
    12. sredina(ono što je bio kraj u prvih 8 primjera) dolje u smjeru kazaljke na satu

    13. sredina(ono što je bio kraj u prvih 8 primjera) lijevo u kontra smjeru kazaljke na satu
    14. sredina(ono što je bio kraj u prvih 8 primjera) desno u kontra smjeru kazaljke na satu
    15. sredina(ono što je bio kraj u prvih 8 primjera) gore u kontra smjeru kazaljke na satu
    16. sredina(ono što je bio kraj u prvih 8 primjera) dolje u kontra smjeru kazaljke na satu

    Formatirati brojeve da budu potpisani po pravilima matematike: jedinica ispod jedinice, desetica ispod desetice, stotica ispod stotice*/


        public static void Izvedi()
        {


            int redova;
            int kolona;

            while (true)
            {
                try
                {
                    redova = E12Metode.UcitajCijeliBroj("Unesi broj redova (2-50): ");
                    if (redova < 2 || redova > 50)
                    {
                        Console.WriteLine("Broj nije u dopuštenom rasponu, pokušajte ponovno!");
                        continue;

                    }
                    break;

                }
                catch
                {
                    Console.WriteLine("Nisi unio cijeli broj!");
                }
            }


            while (true)
            {
                try
                {
                    kolona = E12Metode.UcitajCijeliBroj("Unesi broj kolona (2-50): ");
                    if (kolona < 2 || kolona > 50)
                    {
                        Console.WriteLine("Broj nije u dopuštenom rasponu, pokušajte ponovno!");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Nisi unio cijeli broj!");
                }
            }

            int cilj = redova * kolona;
            int brojac = 1;
            int maxLijevo = 0;
            int maxGore = 0;
            int maxDesno = kolona - 1;
            int maxDolje = redova - 1;

            int[,] tablica = new int[redova, kolona];

            // OSNOVNA CIKLIČNA TABLICA ---------------------------------------------------------

            while (brojac <= cilj)
            {
                // Dolje desno prema lijevo------------------------------------------------------
                for (int i = maxDesno; i >= maxLijevo && brojac <= cilj; i--)
                    tablica[maxDolje, i] = brojac++;
                maxDolje--;
                

                // Lijevo dolje prema gore-------------------------------------------------------------
                for (int i = maxDolje; i >= maxGore && brojac <= cilj; i--)
                    tablica[i, maxLijevo] = brojac++;
                maxLijevo++;
                

                // Gore lijevo prema desno-----------------------------------------------------------
                for (int i = maxLijevo; i <= maxDesno && brojac <= cilj; i++)
                    tablica[maxGore, i] = brojac++;
                maxGore++;
                

                // Desno gore prema dolje----------------------------------------------------------------
                for (int i = maxGore; i <= maxDolje && brojac <= cilj; i++)
                    tablica[i, maxDesno] = brojac++;
                maxDesno--;
                
            }

            //Ispis tablice-----------------------------------------------------------------------
            IspisiTablicu(tablica);



        }

        // ISPIŠI TABLICU
        private static void IspisiTablicu(int[,] tablica)
        {
            for (int i = 0; i < tablica.GetLength(0); i++)
            {
                for (int j = 0; j < tablica.GetLength(1); j++)
                {

                    {
                        Console.Write("{0,4}", tablica[i, j] + "  ");

                    }

                }
                Console.WriteLine();
                Console.WriteLine();

            }

        }
    }
}