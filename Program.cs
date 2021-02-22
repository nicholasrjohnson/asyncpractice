
namespace asyncpractice
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;


    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if(args.Length != 1) {
                Console.WriteLine( "Incorrect amount of args");
                return 1;
            }
            int numBreasts = Convert.ToInt32(args[0]);
            
            var chickenTask = MakeChickenAsync(numBreasts);
            var cookingRiceTask = CookRiceAsync();
            var steamBrocTask = SteamBrocolliAsync();

            var dinnerTasks = new List<Task> {chickenTask, cookingRiceTask, steamBrocTask};

            while( dinnerTasks.Count > 0) { 

                Task doneTask = await Task.WhenAny( dinnerTasks);

                if( doneTask == chickenTask ){
                    Console.WriteLine("Chicken cooked.");                    
                } else if ( doneTask == cookingRiceTask) {
                    Console.WriteLine( "Rice Cooked.");
                } else if ( doneTask == steamBrocTask) {
                    Console.WriteLine("Brocolli steamed");
                }
                dinnerTasks.Remove(doneTask);
            }
            Console.WriteLine("Dinner is done.");
            return 0;
        }

        private static async Task<Chicken> MakeChickenAsync(int numBreasts) {
            var cutChickenTask = await CutChickenAsync(numBreasts);
            var seasonTask = await SeasonChickenAsync(numBreasts);
            var fryTask = await FryChickenAsync(numBreasts); 
            return new Chicken();
        }


         private static async Task<Chicken> CutChickenAsync(int numBreasts) {
            Chicken cutChicken = new Chicken();
            await Task.Delay( 3000*numBreasts);
            Console.WriteLine("Breasts cut.");
            return cutChicken; 
        }

        private static async Task<Chicken> SeasonChickenAsync(int numBreasts) {
            Chicken seasonedChicken = new Chicken();
            SaltAndPepperChicken();
            await Task.Delay( 2000*numBreasts);
            CurryPowderChicken();
            await Task.Delay(2000*numBreasts);
            HoneyChicken();
            await Task.Delay(2000*numBreasts);
            Console.WriteLine("Seasoned the chicken.");
            return seasonedChicken;
        }

        private static async Task<Chicken> FryChickenAsync(int numBreasts) {
            await Task.Delay(3000*numBreasts);
            Console.WriteLine("Fried the chicket");
 
            return new Chicken();
        }

        private static async Task<Rice> CookRiceAsync() {
            await Task.Delay(20000);
            Console.WriteLine("Cooked the rice");
            return new Rice();
        }

        private static async Task<Brocolli> SteamBrocolliAsync() {
            await Task.Delay(10000);
            Console.WriteLine("Steamed the Brocolli");
            
            return new Brocolli();
        }

        private static void SaltAndPepperChicken() {
            
            Console.WriteLine( "Salt and peppered chicken");
        }

        private static void CurryPowderChicken() {
            Console.WriteLine( "Curried chicken");
        }

        private static void HoneyChicken() {
            Console.WriteLine("Honeied the chicken");
        }
    }

   

    public class Chicken {
        public Chicken() {
            name = "Chicken";
        }
        private string name { get; set;}
    }

    public class CurryPowder {
        public CurryPowder() {
            name = "Curry";
        }
        private string name { get; set; }
    }

    public class SaltAndPepper {
        public SaltAndPepper() {
            name = "SandP";
        }
        private string name { get; set; }
    }

    public class Rice {
        public Rice() {
            name = "Rice";
        }
        private string name { get; set; }
    }
    public class Brocolli {
        public Brocolli() {
            name = "Brocolli";
        }
        private string name { get; set; }
    }
    public class Honey {
        public Honey() {
            name = "Honey";
        }
        private string name { get; set; }
    }
}