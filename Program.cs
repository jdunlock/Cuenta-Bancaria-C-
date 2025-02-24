using System;
using System.Collections.Generic;

class CuentaBancaria
{
    private string titular;
    private decimal saldo;

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        this.titular = titular;
        this.saldo = saldoInicial > 0 ? saldoInicial : 0;
    }

    public string Titular => titular;
    public decimal Saldo => saldo;

    public void Depositar(decimal monto)
    {
        if (monto > 0)
        {
            saldo += monto;
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: {saldo:C}");
        }
        else
        {
            Console.WriteLine("El monto debe ser positivo.");
        }
    }

    public void Retirar(decimal monto)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: {saldo:C}");
        }
        else if (monto > saldo)
        {
            Console.WriteLine("Fondos insuficientes.");
        }
        else
        {
            Console.WriteLine("El monto debe ser positivo.");
        }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("====================================");
        Console.WriteLine($"Titular: {titular}");
        Console.WriteLine($"Saldo: {saldo:C}");
        Console.WriteLine("====================================");
    }
}

class ProgramaBanco
{
    static void Main()
    {
        List<CuentaBancaria> cuentas = new List<CuentaBancaria>
        {
            new CuentaBancaria("Juan Pérez", 5000),
            new CuentaBancaria("Ana Gómez", 3000),
            new CuentaBancaria("Carlos Ramírez", 10000),
            new CuentaBancaria("María López", 7500),
            new CuentaBancaria("Pedro Martínez", 2000)
        };

        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("Bienvenido a su Banco De León Rijo");
            Console.WriteLine("====================================");
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Retirar");
            Console.WriteLine("3. Mostrar información de cuenta");
            Console.WriteLine("4. Salir");
            Console.Write("Elija una opción: ");

            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 4)
            {
                Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                continue;
            }

            if (opcion == 4)
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }

            Console.WriteLine("\nSeleccione una cuenta:");
            for (int i = 0; i < cuentas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cuentas[i].Titular}");
            }
            Console.Write("Opción: ");

            if (!int.TryParse(Console.ReadLine(), out int seleccion) || seleccion < 1 || seleccion > cuentas.Count)
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            CuentaBancaria cuenta = cuentas[seleccion - 1];

            if (opcion == 1 || opcion == 2)
            {
                Console.Write("Ingrese el monto: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal monto) || monto <= 0)
                {
                    Console.WriteLine("Monto inválido.");
                    continue;
                }
                if (opcion == 1)
                {
                    cuenta.Depositar(monto);
                }
                else
                {
                    cuenta.Retirar(monto);
                }
            }
            else if (opcion == 3)
            {
                cuenta.MostrarInformacion(); 
            }
        }
    }
}

