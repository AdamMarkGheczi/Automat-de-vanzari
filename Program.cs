using System;

namespace Vending_Machine
{
    class VendingMachine
    {
        private IStates CurrentState = new StateA();

        private enum Coins
        {
            Nickel = 5,
            Dime = 10,
            Quarter = 25
        }

        private void ChangeState(IStates NewState)
        {
            CurrentState = NewState;
        }

        public void InsertNickel()
        {
            CurrentState.InsertNickel(this);
        }
        public void InsertDime()
        {
            CurrentState.InsertDime(this);
        }

        public void InsertQuarter()
        {
            CurrentState.InsertQuarter(this);
        }
        private interface IStates
        {
            void InsertDime(VendingMachine VendingMachine);
            void InsertNickel(VendingMachine VendingMachine);
            void InsertQuarter(VendingMachine VendingMachine);
        }

        private class StateA : IStates
        {
            public void InsertNickel(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateB());
            }
            public void InsertDime(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateC());
            }
            public void InsertQuarter(VendingMachine VendingMachine)
            {
                Console.WriteLine($"Marfa eliberata, rest: {(int)Coins.Nickel} centi");
            }
        }
        private class StateB : IStates
        {
            public void InsertNickel(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateC());
            }
            public void InsertDime(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateD());
            }
            public void InsertQuarter(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateA());
                Console.WriteLine($"Marfa eliberata, rest: {(int)Coins.Dime} centi");
            }
        }

        private class StateC : IStates
        {
            public void InsertNickel(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateD());
            }
            public void InsertDime(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateA());
                Console.WriteLine("Marfa eliberata, rest: 0 centi");
            }
            public void InsertQuarter(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateA());
                Console.WriteLine($"Marfa eliberata, rest: {(int)Coins.Nickel + (int)Coins.Dime} centi");
            }
        }
        private class StateD : IStates
        {
            public void InsertNickel(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateA());
                Console.WriteLine("Marfa eliberata, rest: 0 centi");
            }
            public void InsertDime(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateA());
                Console.WriteLine($"Marfa eliberata, rest: {(int)Coins.Nickel} centi");
            }
            public void InsertQuarter(VendingMachine VendingMachine)
            {
                VendingMachine.ChangeState(new StateB());
                Console.WriteLine($"Marfa eliberata, rest: {(int)Coins.Nickel + (int)Coins.Dime} centi");
                Console.WriteLine("(Mai sunt 5 centi in automat)");
            }
        }
    }


    internal class Program
    {
        static void Main()
        {
            VendingMachine automat1 = new VendingMachine();

            string moneda;

            // Abordarea cu clase

            while (true)
            {
                // Nickel = 5 centi
                // Dime = 10 centi
                // Quarter = 25 centi

                Console.WriteLine("Ce moneda puneti in automat: Nickel (n), Dime (d) sau Quarter (q)");
                moneda = Console.ReadLine();

                switch (moneda)
                {
                    case "n":
                    case "N":
                        automat1.InsertNickel();
                        break;

                    case "d":
                    case "D":
                        automat1.InsertDime();
                        break;

                    case "q":
                    case "Q":
                        automat1.InsertQuarter();
                        break;
                }
            }

            // Abordarea simpla

            //int money = 0;
            //while (true)
            //{
            //    // Nickel = 5 centi
            //    // Dime = 10 centi
            //    // Quarter = 25 centi

            //    Console.WriteLine("Ce moneda puneti in automat: Nickel (n), Dime (d) sau Quarter (q)");
            //    moneda = Console.ReadLine();

            //    switch (moneda)
            //    {
            //        case "n":
            //        case "N":
            //            money += 5;
            //            break;

            //        case "d":
            //        case "D":
            //            money += 10;
            //            break;

            //        case "q":
            //        case "Q":
            //            money += 25;
            //            break;
            //    }

            //    if(money>=20)
            //    {
            //        money -= 20;

            //        int rest = 0;

            //        if(money >= 10)
            //        {
            //            money -= 10;
            //            rest += 10;
            //        }

            //        if (money >= 5)
            //        {
            //            money -= 5;
            //            rest += 5;
            //        }

            //        Console.WriteLine($"Marfa eliberata, rest: {rest} centi");
            //        if(money==5) Console.WriteLine("(Mai sunt 5 centi in automat)");
            //    }
            //}

        }
    }
}
