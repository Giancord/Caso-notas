using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Caso_notas
{
    internal class Program
    {
        //Sin retorno -> se agrega void
        //public -> para que no este transparente (visible para todo el programa)
        
        //FUNCIÓN SIN RETORNO:
        static public void Titulo() 
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("\t\tUPN");
            Console.WriteLine("**************************************");
        }

        //FUNCIÓN CON RETORNO:

        static public double Validar_nota(string mensaje) 
        {
            double nota;
            while (true) 
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (double.TryParse(entrada, out nota) && nota >= 0 && nota <= 20)
                {
                    return nota;
                }
                else 
                {
                    Console.WriteLine("Error.Ingrese un valor entre [0-20].");
                }
                
            }
        }

        static public double Calcula_EF(double Proyecto_F, double Lab) 
        {
            double prom_EF;
            prom_EF = Proyecto_F * .6 + Lab * .4;
            return prom_EF;
        }

        static public double Bono_Cisco(double notaEF, string Tiene_Cisco) 
        {
            if (Tiene_Cisco == "s") 
            {
                notaEF += 1;
                if (notaEF >= 20) 
                {
                    notaEF = 20;
                }
            }
            return notaEF;
        }

        static public double promedio_curso(double t1, double t2, double t3, double ep, double ef) 
        {
            double promedio;
            promedio = t1 * 0.1 + t2 * 0.1 + t3 * 0.1 + ep * 0.2 + ef * 0.5;
            return promedio;
        }

        static public string Condicion(double promedio) 
        {
            string estado;
            if (promedio >= 12)
            {
                estado = "Aprobado";
            }
            else 
            {
                estado = "Desaprobado";
            }
            return estado;
        }

        static void Main(string[] args)
        {
            string Curso_Cisco;
            Titulo(); //Si no tiene retorno se llama escribiendo su nombre.
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("****INGRESO DE NOTAS****");
            double T1 = Validar_nota("Ingresar nota T1: ");
            double T2 = Validar_nota("Ingresar nota T2: ");
            double T3 = Validar_nota("Ingresar nota T3: ");
            double ep = Validar_nota("Ingresar nota EP: ");
            Console.WriteLine("Ingresar notas para el Examen Final: ");
            double Proy_Final = Validar_nota("Ingresar nota del proyecto final: ");
            double N_lab = Validar_nota("Ingresar nota de Laboratorio: ");

            //validando
            while (true) 
            {
                Console.WriteLine("¿Realizó el curso de Cisco[s/n]?");
                Curso_Cisco = Console.ReadLine().ToLower();
                if (Curso_Cisco == "s" || Curso_Cisco=="n") 
                {
                    break;
                }
                Console.WriteLine("Error. Ingresar [s/n]: ");
            }
            double notaEF = Calcula_EF(Proy_Final, N_lab);
            double notaEF_Cisco = Bono_Cisco(notaEF, Curso_Cisco);
            double promedio = promedio_curso(T1, T2, T3, ep, notaEF_Cisco);
            string condicion_Est = Condicion(promedio);
            Console.WriteLine("=====================");
            Console.WriteLine("REPORTE FINAL: ", nombre);
            Console.WriteLine("=====================");
            if (Curso_Cisco == "s")
            {
                Console.WriteLine("Felicitaciones por completar tu curso de Cisco!!!");
            }
            Console.WriteLine($"Nota Examen Final: {notaEF_Cisco}");
            Console.WriteLine($"Promedio final: {promedio}");
            Console.WriteLine($"Condición: {condicion_Est}");
            Console.WriteLine("=====================");
            Console.ReadKey();
        }
    }
}
