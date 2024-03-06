// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");//


namespace BancoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una cuenta bancaria inicial con saldo de $1000
            var cuentaBancaria = new CuentaBancaria(1000);

            // Creamos dos hilos para simular operaciones concurrentes
            Thread hiloIngreso = new Thread(() => RealizarIngreso(cuentaBancaria, 200));
            Thread hiloRetiro = new Thread(() => RealizarRetiro(cuentaBancaria, 300));

            // Iniciamos los hilos
            hiloIngreso.Start();
            hiloRetiro.Start();

            // Esperar a que ambos hilos terminen
            hiloIngreso.Join();
            hiloRetiro.Join();

            // Mostrar el saldo final
            Console.WriteLine($"Saldo final: ${cuentaBancaria.Saldo}");
        }

        static void RealizarIngreso(CuentaBancaria cuenta, decimal monto)
        {
            // Simular proceso de ingreso
            Thread.Sleep(1000); // Esperar 1 segundo
            cuenta.Ingresar(monto);
        }

        static void RealizarRetiro(CuentaBancaria cuenta, decimal monto)
        {
            // Simular proceso de retiro
            Thread.Sleep(1500); // Esperar 1.5 segundos
            cuenta.Retirar(monto);
        }
    }

    class CuentaBancaria
    {
        public decimal Saldo { get; private set; }

        public CuentaBancaria(decimal saldoInicial)
        {
            Saldo = saldoInicial;
        }

        public void Ingresar(decimal monto)
        {
            Saldo += monto;
            Console.WriteLine($"Ingreso: ${monto}");
        }

        public void Retirar(decimal monto)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro: ${monto}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para el retiro.");
            }
        }
    }
}