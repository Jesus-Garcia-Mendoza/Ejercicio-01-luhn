using System;
using System.IO;

namespace EjercicioLuhn
{
    class Program
{
    //Guardo los resultados de todas las validaciones
    static int tarjetasValidas = 0;
    static int tarjetasInvalidas = 0;

    // Llevo el conteo de las marcas encontradas
    static int visa = 0;
    static int mastercard = 0;
    static int americanExpress = 0;
    static int discover = 0;
    static int desconocida = 0;

    static void Main(string[] args)
    {
        int opcion = 0;

        // Realizo el menu y lo mantengo el menu activo hasta que el usuario decida salir
        do
            {
                Console.Clear();

                Console.WriteLine("********** VALIDADOR DE TARJETAS **********");
                Console.WriteLine();
                Console.WriteLine("1. Validar una tarjeta");
                Console.WriteLine("2. Validar desde archivo");
                Console.WriteLine("3. Generar numero valido");
                Console.WriteLine("4. Estadisticas de las tarjetas");
                Console.WriteLine("5. Salir");
                Console.WriteLine();
                
                //Permito hacer correcion con el Try y Carch, mostrandole al usuario que debe escoger una opcion valida del menu sin letras
                try
                {
                    Console.Write("Seleccione una opcion: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Debe ingresar un numero del menu.");
                    opcion = 0;
                }
                
                // Ejecuto la opcion que selecciono el usuario
                switch (opcion)
                {
                    case 1:

                        ValidarTarjeta();

                        break;

                    case 2:

                        ValidarDesdeArchivo("tarjetas.txt");

                        break;

                    case 3:

                        string tarjetaGenerada = GenerarNumeroValido();

                        Console.WriteLine();
                        Console.WriteLine("NUMERO GENERADO");
                        Console.WriteLine();

                        Console.WriteLine("Numero: " + tarjetaGenerada);

                        Console.WriteLine("Marca: " + IdentificarMarca(tarjetaGenerada));

                        break;

                    case 4:

                        MostrarEstadisticas();

                        break;

                    case 5:

                        Console.WriteLine();
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:

                        Console.WriteLine();
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }

            while (opcion != 5);
        }

        static void ValidarTarjeta()
        {
            Console.WriteLine();
            Console.WriteLine("VALIDAR TARJETA");
            
            // Guardo el numero que ingresa el usuario para poder validarlo
            Console.Write("Ingrese el numero de tarjeta: ");
            string numero = Console.ReadLine() ?? "";

            if (numero == "")
            {
                Console.WriteLine("Debe ingresar un numero.");
                return;
            }

            // Verifico que todos los caracteres sean numeros
            for (int i = 0; i < numero.Length; i++)
            {
                if (!char.IsDigit(numero[i]))
                {
                    Console.WriteLine("La tarjeta solo puede contener numeros.");
                    return;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Numero: " + numero);

            // Busco la marca segun el numero ingresado
            string marca = IdentificarMarca(numero);

            Console.WriteLine("Marca: " + marca);

            // Envio el numero al algoritmo Luhn para revisar si es valido
            bool resultado = ValidarLuhn(numero);

            if (resultado)
            {
                Console.WriteLine("Estado: VALIDA");

                tarjetasValidas++;

                if (marca == "Visa")
                {
                    visa++;
                }

                if (marca == "Mastercard")
                {
                    mastercard++;
                }

                if (marca == "American Express")
                {
                    americanExpress++;
                }

                if (marca == "Discover")
                {
                    discover++;
                }

                if (marca == "Desconocida")
                {
                    desconocida++;
                }
            }
            
            else
            {
                Console.WriteLine("Estado: INVALIDA");

                tarjetasInvalidas++;

                if (marca == "Visa")
                {
                    visa++;
                }

                if (marca == "Mastercard")
                {
                    mastercard++;
                }

                if (marca == "American Express")
                {
                    americanExpress++;
                }

                if (marca == "Discover")
                {
                    discover++;
                }

                if (marca == "Desconocida")
                {
                    desconocida++;
                }
            }
            
        }

        static bool ValidarLuhn(string numero)
        {
            int suma = 0;
            bool duplicar = false;

            // Recorro el numero desde el ultimo digito hacia el primero.
            for (int i = numero.Length - 1; i >= 0; i--)
            {
                int digito = Convert.ToInt32(numero[i].ToString());

                // Dupllico cada segundo digito siguiendo el algoritmo
                if (duplicar)
                {
                    digito = digito * 2;

                    if (digito >= 10)
                    {
                        digito = digito - 9;
                    }
                }

                // Voy acumulando el valor de cada digito
                suma = suma + digito;

                duplicar = !duplicar;
            }

            // Si el resultado es multiplo de 10 el numero es valido.
            if (suma % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string IdentificarMarca(string numero)
        {
            string marca = "Desconocida";

            // Reviso la cantidad de digitos y el inicio del numero

            if (numero.Length == 13 || numero.Length == 16)
            {
                if (numero.StartsWith("4"))
                {
                    marca = "Visa";
                }
            }


            if (numero.Length == 16)
            {
                int inicio = Convert.ToInt32(numero.Substring(0, 2));

                if (inicio >= 51 && inicio <= 55)
                {
                    marca = "Mastercard";
                }
            }


            if (numero.Length == 15)
            {
                string inicio = numero.Substring(0, 2);

                if (inicio == "34" || inicio == "37")
                {
                    marca = "American Express";
                }
            }


            if (numero.Length >= 16 && numero.Length <= 19)
            {
                if (numero.StartsWith("6011"))
                {
                    marca = "Discover";
                }

                string primerosTres = numero.Substring(0, 3);
                int tres = Convert.ToInt32(primerosTres);

                if (tres >= 644 && tres <= 649)
                {
                    marca = "Discover";
                }


                if (numero.StartsWith("65"))
                {
                    marca = "Discover";
                }
            }

            if (numero.Length >= 16 && numero.Length <= 19)
            {
                int seis = Convert.ToInt32(numero.Substring(0, 6));

                if (seis >= 622126 && seis <= 622925)
                {
                    marca = "Discover";
                }
            }

            return marca;

        }

        static void ValidarDesdeArchivo(string ruta)
        {
            try
            {
                
                string[] tarjetas = File.ReadAllLines(ruta);

                Console.WriteLine();
                Console.WriteLine("VALIDACION DESDE ARCHIVO");
                Console.WriteLine();

                int validasArchivo = 0;
                int invalidasArchivo = 0;

                // Recorro cada tarjeta encontrada en el archivo
                for (int i = 0; i < tarjetas.Length; i++)
                {
                    string numero = tarjetas[i];


                    if (numero != "")
                    {
                        string marca = IdentificarMarca(numero);
                        bool resultado = ValidarLuhn(numero);


                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Numero: " + numero);
                        Console.WriteLine("Marca: " + marca);


                        if (resultado)
                        {
                            Console.WriteLine("Estado: VALIDA");
                            validasArchivo++;

                            tarjetasValidas++;

                            if (marca == "Visa")
                            {
                                visa++;
                            }

                            if (marca == "Mastercard")
                            {
                                mastercard++;
                            }

                            if (marca == "American Express")
                            {
                                americanExpress++;
                            }

                            if (marca == "Discover")
                            {
                                discover++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Estado: INVALIDA");

                            tarjetasInvalidas++;
                            invalidasArchivo++;

                            if (marca == "Visa")
                            {
                                visa++;
                            }

                            if (marca == "Mastercard")
                            {
                                mastercard++;
                            }

                            if (marca == "American Express")
                            {
                                americanExpress++;
                            }

                            if (marca == "Discover")
                            {
                                discover++;
                            }

                            if (marca == "Desconocida")
                            {
                                desconocida++;
                            }
                        }
                    }
                }
                


                Console.WriteLine();
                Console.WriteLine("============================");
                Console.WriteLine("RESUMEN DEL ARCHIVO");
                Console.WriteLine("============================");
                Console.WriteLine("Tarjetas validas: " + validasArchivo);
                Console.WriteLine("Tarjetas invalidas: " + invalidasArchivo);

            }
            catch (Exception)
            {
                Console.WriteLine("No fue posible leer el archivo.");
            }
        }

        static string GenerarNumeroValido()
        {
            
            Random aleatorio = new Random();

            string numero = "4";

            // Luego completo los siguientes 15 digitos
            while (numero.Length < 16)
            {
                numero = "4";

                for (int i = 1; i < 16; i++)
                {
                    numero = numero + aleatorio.Next(0, 10);
                }

                if (ValidarLuhn(numero))
                {
                    return numero;
                }
            }

            return numero;
        }

        static void MostrarEstadisticas()
        {
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine("        ESTADISTICAS");
            Console.WriteLine("===============================");

            Console.WriteLine();

            Console.WriteLine("Tarjetas validas: " + tarjetasValidas);

            Console.WriteLine("Tarjetas invalidas: " + tarjetasInvalidas);

            Console.WriteLine();

            Console.WriteLine("Desglose por marca:");

            Console.WriteLine("Visa: " + visa);

            Console.WriteLine("Mastercard: " + mastercard);

            Console.WriteLine("American Express: " + americanExpress);

            Console.WriteLine("Discover: " + discover);

            Console.WriteLine("Desconocidas: " + desconocida);

        }

    }
}
