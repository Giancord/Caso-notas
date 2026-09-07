using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_grupal_s4
{
    internal class Program
    {
        //Variable global:
        static public double saldo = 1000;

        //Métodos sin retorno:
        static public void Menu()
        {
            string resp = "";
            Console.WriteLine("************************************************************");
            Console.WriteLine("\t\tMENÚ DE OPCIONES");
            Console.WriteLine("1. Consultar saldo actual");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Retirar");
            Console.WriteLine("4. Sumar números (1 hasta el número ingresado)");
            Console.WriteLine("5. Salir");
            Console.WriteLine("************************************************************");

            while (resp != "n")
            {
                Console.Write("\nIngrese una opción [1-5]: ");
                int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Consultar_saldo();
                        break;
                    case 2:
                        Depositar();
                        break;
                    case 3:
                        Retirar();
                        break;
                    case 4:
                        Sumar_num();
                        break;
                    case 5:
                        Console.WriteLine("Cerrando...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ha ingresado una opción inválida. Ingrese un número entre 1 y 5.");
                        break;
                }
                while (true)
                {
                    Console.Write("\n¿Desea ingresar otra opción[s/n]?: ");
                    resp = Console.ReadLine().ToLower();
                    if (resp == "s" || resp == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese solo 's' o 'n'.");
                    }
                }
                if (resp == "n")
                {
                    Console.WriteLine("Cerrando...");
                    break;
                }
            }
        }

        static void Consultar_saldo()
        {
            Console.Write($"Su saldo actual es: {saldo} soles.");
        }
        static void Depositar()
        {
            double depo;
            Console.Write("Ingrese el monto que desea depositar: ");
            depo = double.Parse(Console.ReadLine());
            saldo += depo;

        }
        static void Retirar()
        {
            double reti;
            Console.Write("Ingrese el monto que desea retirar: ");
            reti = double.Parse(Console.ReadLine());
            if (saldo - reti >= 0)
            {
                saldo -= reti;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }

        }
        static void Sumar_num()
        {
            int lim;
            int suma = 0;
            Console.Write("Ingrese el número final hasta el cual se realizará la suma desde 1: ");
            lim = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lim; i++)
            {
                suma += i;
            }
            Console.WriteLine($"Suma total desde 1 hasta {lim}: {suma}");
        }

        //Método Principal:
        static void Main(string[] args)
        {
            Console.WriteLine("BIENVENID@ AL CAJERO AUTOMÁTICO");
            Menu();
        }
    }
}
