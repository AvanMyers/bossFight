using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 100;
            int playerDamage = 5;
            int poisonDamage = 20;
            int durationOfThePoison = 2;
            int poisonOnDagger = 0;
            int multiplierOfSneakyBlow = 5;
            int enemyHitBySmokeScreen = 0;
            int smokeScreenTimer = 3;
            int dropSmoke = 0;
            int smokeBomb = 2;
            int bossHealt = 500;
            int bossDamage = 20;
            int mimicDamge = 3;
            int bossDamegeInSmoke = 0;
            bool isPlayerHavePotion = true;
            string userInput;
            bool isSmokeScreen = false;
            bool isPoisonOnDager = false;
            string randomPotionDuration;
            Random random = new Random();

            Console.WriteLine("Сейчас начнется финальная битва с вашим злейшим врагом, у вас один единственный шанс, вы готовились к этому долгое время.");
            Console.WriteLine("Вы знаете,что враг сильнее вас и не будет играть честно, поэтому у вас есть средства для борьбы: ");
            Console.WriteLine($"1 - Удар кинжалом - наносит {playerDamage} ед. урона");
            Console.WriteLine($"2 - Нанести яд на оружие для увеличения урона на {poisonDamage} ед. урона на {durationOfThePoison} действий");
            Console.WriteLine($"3 - Кинуть дымовую шашки скрывающую вас от врага и дающее вам преимущество, у вас всего {smokeBomb} шт.");
            Console.WriteLine($"4 - Безопасно выпить зелье купленное у таинственного торговца.");
            Console.WriteLine("Враг перед вами, что будете делать?");

            while (playerHealth >= 0 || bossHealt >= 0)
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        if (isSmokeScreen)
                        {
                            bossHealt -= playerDamage * multiplierOfSneakyBlow;
                            playerHealth -= enemyHitBySmokeScreen;
                            Console.WriteLine($"Вы наносите удар по врагу которого он не видел из-за дыма нанося {playerDamage * multiplierOfSneakyBlow} ед. урона и скрываетесь в дыму");
                            Console.WriteLine($"У вас осталось {playerHealth}, а у вашего врага {bossHealt}");
                        }
                        else
                        {
                            bossHealt -= playerDamage;
                            playerHealth -= bossDamage;
                            Console.WriteLine($"Вы наносите удар своим кинжалом нанося {playerDamage} ед. урона, но не успеваете полностью уйти от удара варага.");
                            Console.WriteLine($"У вас осталось {playerHealth}, а у вашего врага {bossHealt}");
                        }
                        if (isPoisonOnDager)
                        {
                            poisonOnDagger--;
                        }
                        break;
                    case "2":
                        isPoisonOnDager = true;
                        poisonOnDagger = durationOfThePoison;
                        playerDamage += poisonDamage;
                        if (isSmokeScreen)
                        {
                            Console.WriteLine("Скрывшись в дыму в безопастности наносите яд на канжал готовясь нанести удар врагу.");
                            playerHealth -= bossDamegeInSmoke;
                        }
                        else
                        {
                            playerHealth -= bossDamage;
                            Console.WriteLine("Вы наносите яд на свой кинжал, но из-за этого вы не можете уклониться от удара");
                            Console.WriteLine($"У вас осталось {playerHealth}, а у вашего врага {bossHealt}");
                        }
                        break;
                    case "3":
                        if (smokeBomb > 0)
                        {
                            Console.WriteLine("Вы снимаете с пояса дымовую шашку и кидаете её на пол, густой дым заволакивает " +
                                "все вокруг давая вам преимущество для ударов и мешая врагу попадать по вам.");
                            isSmokeScreen = true;
                            smokeBomb--;
                            dropSmoke = smokeScreenTimer;
                        }
                        else
                        {
                            if (isSmokeScreen)
                            {
                                Console.WriteLine("Вы обыскивыете свои карманы в поисках дымовой шашки, но её нет, как хорошо, что вы все еще под завесой.");
                            }
                            else
                            {
                                Console.WriteLine("Вы обыскивыете свои карманы в поисках дымовой шашки, но её нет и это дает возможность врагу атаковать вас.");
                                playerHealth -= bossDamage;
                                Console.WriteLine($"У вас осталось {playerHealth}, а у вашего врага {bossHealt}");
                            }
                        }
                        break;
                    case "4":
                        if (isPlayerHavePotion)
                        {
                            Console.WriteLine("Вы открываете странную баночку и не знаете что с вами произойдет...");
                            randomPotionDuration = Convert.ToString(random.Next(0, 6));
                            switch (randomPotionDuration)
                            {
                                case "0":
                                    Console.WriteLine("К сожалению это зелье было не качаественным и как только вы его выпиваете ваш разум начинает мутнеть, этого хватает, что бы ваш враг убил вас.");
                                    playerHealth = 0;
                                    break;
                                case "1":
                                    Console.WriteLine("Как только вы пытаетесь открыть флакон, на нем появляются зубы и он кусает вас за палец и убегает, это оказался мимик");
                                    playerHealth -= mimicDamge;
                                    break;
                                case "2":
                                    Console.WriteLine("Вы чувтсвуете прилив сил и раны буквально затягиваются на вас, вы полностью здоровы.");
                                    playerHealth = 100;
                                    break;
                                case "3":
                                    Console.WriteLine("Вы чувтсвуете прилив сил, перехватив кинжал вы уверены, что стали сильнее.");
                                    playerDamage += 50;
                                    break;
                                case "4":
                                    Console.WriteLine("Вы выпиваете зелье и чувствуете как вас обволакивает прозрачная оболочка, вы уверены, что она не выдержит больше одного удара");
                                    playerHealth += bossDamage;
                                    break;
                                case "5":
                                    Console.WriteLine("Вы выпиваете зелье и в этот момент ваш враг наносит по вам удар, вы не смогли на него отреагировать, но что то не так" +
                                        ", вы не чувствуете боли и видите в глаза оппонента непонимание, он наносит еще серию ударов, но вам ни почём, вы неуязвимы");
                                    bossDamage = 0;
                                    break;
                            }
                            isPlayerHavePotion = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("К сожалению у вас было только одно зелье.");
                        }
                        break;
                }

                if (isSmokeScreen)
                {
                    dropSmoke--;
                    if (dropSmoke <= 0)
                    {
                        isSmokeScreen = false;
                        Console.WriteLine("Дым развеивается и враг прекрасно вас видит.");
                    }
                }

                if (isPoisonOnDager && poisonOnDagger <= 0)
                {
                        isPoisonOnDager = false;
                        playerDamage -= poisonDamage;
                        Console.WriteLine("Вы обращаете внимание на свой кинжал после удара и видите, что на нем не осталось и капли яда.");
                }

                if (playerHealth <= 0)
                {
                    Console.WriteLine("Вы пытаетесь осмотреться, но не получается, ваше тело вас не слушается, что то странное... вы видите ваше тело без головы лежащее в траве, кажется начинается дождь," +
                        "вы чувствуете первые капли на вашам лице и к сожалению последние. Вы погибли, сделав все что в аших силах");
                } 
                else if (bossHealt <= 0)
                {
                    Console.WriteLine("Вы вонзате свой кинжал врагу в горло, и видите как последние отблески жизни покидают его глаза, вы чувствуете на свем лице капли дождя, вы победили, но стоило ли это того," +
                        "решать уже вам.");
                }
            }
        }
    }
}
