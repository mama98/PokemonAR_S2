using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Status_pokemon : MonoBehaviour
{
    public GameObject Pkmn;
    public class Attack
        {

            public String name;
            public int damage;
            public int PP;

            public Attack()
            {
                name = null;
                damage = 0;
                PP = 0;
            }
            public Attack(String name, int damage, int PP)
            {
                this.name = name;
                this.damage = damage;
                this.PP = PP;
            }
        }

        public class Pokemon
        {
        public GameObject Pkmn;
            public String name;
            public int health_points;
            public Attack attack1;
            public Attack attack2;
            public Attack attack3;
            public Attack attack4;

            public Pokemon()
            {
                this.name = null;
                this.health_points = 0;
                this.attack1 = null;
                this.attack2 = null;
                this.attack3 = null;
                this.attack4 = null;
            }

            public Pokemon(String name, int health_points, Attack attack1, Attack attack2, Attack attack3, Attack attack4)
            {
                this.name = name;
                this.health_points = health_points;
                this.attack1 = attack1;
                this.attack2 = attack2;
                this.attack3 = attack3;
                this.attack4 = attack4;
            }

            public void Attack_Adversary(Pokemon victim, int choice_attack)
            {

                if (choice_attack == 1) //changer en switch case
                {
                    Console.WriteLine(this.name + " attacks with " + this.attack1.name + Environment.NewLine);
                    victim.health_points -= this.attack1.damage;
                }

                if (choice_attack == 2)
                {
                    Console.WriteLine(this.name + " attacks with " + this.attack2.name + Environment.NewLine);
                    victim.health_points -= this.attack2.damage;
                }

                if (choice_attack == 3)
                {
                    Console.WriteLine(this.name + " attacks with " + this.attack3.name + Environment.NewLine);
                    victim.health_points -= this.attack3.damage;
                }

                if (choice_attack == 4)
                {
                    Console.WriteLine(this.name + " attacks with " + this.attack4.name + Environment.NewLine);
                    victim.health_points -= this.attack4.damage;
                }

            }

            public void Display_begin_battle(Pokemon pok2)
            {
                Console.WriteLine("You send your pokemon:");
                Console.WriteLine(this.name);
                Console.WriteLine("PV: " + this.health_points + Environment.NewLine);
                Console.WriteLine("The ennemy sends their pokemon:");
                Console.WriteLine(pok2.name);
                Console.WriteLine("PV: " + pok2.health_points + Environment.NewLine);
            }

            public void Display_status()
            {
                Console.WriteLine(this.name);
                Console.WriteLine("PV: " + this.health_points + Environment.NewLine);
            }

            public void Display_battle()
            {
                Console.WriteLine("Choose your attack");
                Console.WriteLine(this.attack1.name);
                Console.WriteLine(this.attack2.name);
                Console.WriteLine(this.attack3.name);
                Console.WriteLine(this.attack4.name + Environment.NewLine);

            }

            public void Display_end_battle(Pokemon pok2)
            {
                if (this.health_points <= 0)
                {
                Pkmn.SetActive(false); // die
                    Console.WriteLine("Your pokemon has fainted");
                    Console.WriteLine("You lost the battle");
                }

                if (pok2.health_points <= 0)
                {
                    Console.WriteLine("The ennemy pokemon has fainted");
                    Console.WriteLine("You won the battle");
                }
            }

        }

        static void Main(string[] args)
        {
            int battle_state = 0;
            int choice = 0;
            Attack spark = new Attack("Spark", 15, 20);
            Attack surf = new Attack("Surf", 30, 15);
            Attack peck = new Attack("Peck", 10, 30);
            Attack fire_punch = new Attack("Fire Punch", 40, 5);

            Attack acid = new Attack("Acid", 15, 20);
            Attack earthquake = new Attack("Earthquake", 30, 15);
            Attack rock_slide = new Attack("Rock Slide", 10, 30);
            Attack leafy_wind = new Attack("Leafy Wind", 40, 5);

            Pokemon pikachu = new Pokemon("Pikachu", 60, spark, surf, peck, fire_punch);
            Pokemon charmander = new Pokemon("Charmander", 60, earthquake, rock_slide, leafy_wind, acid);
            while (battle_state != 4)
            {
                switch (battle_state)
                {
                    case 0:
                        pikachu.Display_begin_battle(charmander);
                        battle_state = 1;
                        break;
                    case 1:
                        pikachu.Display_battle();
                        choice = Convert.ToInt32(Console.ReadLine());

                        pikachu.Attack_Adversary(charmander, choice); //player turn 
                        if (pikachu.health_points <= 0)
                        {
                            pikachu.health_points = 0;
                            battle_state = 2;
                            break;
                        }

                        if (charmander.health_points <= 0)
                        {
                            charmander.health_points = 0;
                            battle_state = 2;
                            break;
                        }
                        charmander.Display_status();


                        charmander.Attack_Adversary(pikachu, 2); // ennemy turn
                        if (pikachu.health_points <= 0)
                        {
                            pikachu.health_points = 0;
                            battle_state = 2;
                            break;
                        }

                        if (charmander.health_points <= 0)
                        {
                            charmander.health_points = 0;
                            battle_state = 2;
                            break;
                        }
                        pikachu.Display_status();

                        break;

                    case 2:
                        pikachu.Display_end_battle(charmander);
                        battle_state = 3;
                        break;
                }
            }

            Console.ReadKey();
        }
    


}
