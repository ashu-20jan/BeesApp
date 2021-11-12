using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void StatusBtn_Click(object sender, EventArgs e)
        {
            // List to create instance of each type Bee
            List<Bee> list = new List<Bee>();
            
            for (int i = 0; i < 2; i++)
            {
                list.Clear();
                list.Add(new Worker());
                list.Add(new Drone());
                list.Add(new Queen());
            }
            //To print the status of all the bees
            void Status(int number, Bee bee)
            {
                
                textBox1.Text += (+number, '"' + bee.Type + '"',"Alive:" , bee.Alive, bee.health).ToString() + "\r\n";
        }

            //random number generator
            var random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                var damage = random.Next(0, 80);
                list[i].Damage(damage);
                Status(i + 1, list[i]);
            }
        }

       
    }


    // Base Class
    public  class Bee
    {
        //Properties
        public  float health { get;  set; }
                     
    
        public  string Type { get;  set; }
        protected int limit { get; set; }
        public  void Damage(int damage)
        {

            if ( damage > 0 && damage < 100)
            {
                this.health = this.health - damage;
            }
            
        }
        //Constructor
        public Bee(string type, int limit)
        {
            this.Type = type;
            this.limit = limit;
            this.health = 100;

        }
        public  bool Alive
        {
            get
            {
                return (this.health > this.limit);
            }
        }


    }
    // Derived Class Worker
    public  class Worker : Bee
    {
        public Worker() : base("Worker", 70) { }


    }
    //Derived Class Queen
    public  class Queen : Bee
    {
        public Queen() : base("Queen", 20) { }


    }
    //Derived Class Drone
    public   class Drone : Bee
    {
        public Drone() : base("Drone", 50) { }


    }
}
